﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using Dapper;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;
using System.Data.SQLite;

namespace CalendarApp
{
    public class DatabaseManager
    {
        /* Driver class for DB (search, insert, delete, edit) */

        public List<CalendarDay> GetDay(DateTime date)
        {
            using (IDbConnection connection = new SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {
                return connection.Query<CalendarDay>($"SELECT * FROM CalendarDay WHERE Date = '{date}'").ToList();
            }
        }

        public void AddEvent(string Name, string Description, string _date)
        {
            DateTime Date = DateTime.Parse(_date);
            int CalendarDayId = FindDay(Date);
            using (IDbConnection connection = new SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {
                connection.Execute("INSERT INTO Event (Name, Description, CalendarDayID) VALUES(@Name ,@Description, @CalendarDayId)", new { Name, Description, Date, CalendarDayId});
            }
        }

        public void SearchEvent(string SearchName, string date)
        {
            DateTime _date = DateTime.Parse(date);
            string returnData = "";
            using (IDbConnection connection = new SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {
                string query = "SELECT Event.*, CalendarDay.Id AS CalendarDayId, CalendarDay.Date AS CalendarDate " +
                               "FROM Event " +
                               "INNER JOIN CalendarDay ON Event.CalendarDayId = CalendarDay.Id " +
                               "WHERE Event.Name = @Name AND CalendarDay.Date = @Date";

                var result = connection.QueryFirstOrDefault(query, new { Name = SearchName, Date = _date });

                if (result != null)
                {
                    // Access the variables from the result
                    int eventId = result.Id;
                    string eventDescription = result.Description;
                    DateTime storedEventDate = result.CalendarDate;

                    returnData = eventId.ToString() + " " + eventDescription + " " + storedEventDate.ToString();
                }
                else
                {
                    // Handle the case where no matching record is found
                    Console.WriteLine("No matching record found.");
                }
            }
            MessageBox.Show(returnData);

            //string query = "SELECT Event.* FROM Event INNER JOIN CalendarDay ON Event.calendarDayId = CalendarDay.id WHERE Event.name = 'searchName' AND CalendarDay.date = '_date'";
        }

        public int FindDay(DateTime date)
        {
            int CalendarDayId= -1;
            using (IDbConnection connection = new SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {   /* Attempt to find calendar day in DB if there are existing tasks for that day */
                try
                {
                    // Check if the day exists
                    bool recordExists = connection.QueryFirstOrDefault<bool>($"SELECT CASE WHEN EXISTS (SELECT Id FROM CalendarDay WHERE Date = @Date) THEN 1 ELSE 0 END", new { Date = date });

                    if (recordExists)
                    {
                        // Record day, get the Id
                        CalendarDayId = connection.QueryFirstOrDefault<int>("SELECT Id FROM CalendarDay WHERE Date = @Date", new { Date = date });
                    }
                    else
                    {
                        // Day doesn't exist, insert a new day
                        MessageBox.Show("Day not found. Inserting new day in CalendarDay and returning Id");
                        connection.Execute("INSERT INTO CalendarDay (Date) VALUES (@Date)", new { Date = date });
                        CalendarDayId = connection.QueryFirstOrDefault<int>("SELECT Id FROM CalendarDay WHERE Date = @Date", new { Date = date });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    // Handle the exception as needed
                }
            }
            return CalendarDayId;
        }
    }
}





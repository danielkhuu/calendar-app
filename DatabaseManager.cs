using System;
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

        public void AddEvent(string Name, string Description, string _date, string _type)
        {
            DateTime Date = DateTime.Parse(_date);
            int CalendarDayId = FindDay(Date);
            using (IDbConnection connection = new SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {
                connection.Execute("INSERT INTO Event (Name, Description, Type, CalendarDayID) VALUES(@Name ,@Description, @Type, @CalendarDayId)", new { Name, Description, Type=_type, CalendarDayId});
            }
        }

        public List<Event> RetrieveEventDataByDate(DateTime _date)
        {
            List<Event> returnEvents = new List<Event>();
            using (IDbConnection connection = new SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {
              
                // Step 1: Check if the date exists in CalendarDay
                int calendarDayId = FindDay(_date);

                // Step 2: Retrieve Event data based on the matching CalendarDayId
                string eventQuery = "SELECT * FROM Event WHERE CalendarDayId = @CalendarDayId";
                returnEvents = connection.Query<Event>(eventQuery, new { CalendarDayId = calendarDayId }).ToList();
            }
            return returnEvents;
        }
        /* Usage 
            List<Event> retrievedEvents = _databaseManager.RetrieveEventDataByDate(_TaskDate);
            foreach (var eventItem in retrievedEvents)
            {
                // Access event properties as needed
                MessageBox.Show($"Event Id: {eventItem.Id}, Name: {eventItem.name}, Description: {eventItem.description}");
            }
        */

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
                    int eventId = (int)result.Id;
                    string eventDescription = result.Description;
                    DateTime storedEventDate = result.CalendarDate;

                    returnData = SearchName + ": " + eventDescription + "\n Date:" + storedEventDate.ToString();
                }
                else
                {
                    // Handle the case where no matching record is found
                    Console.WriteLine("No matching record found.");
                    MessageBox.Show("Unable to locate task.");

                }
            }
            MessageBox.Show(returnData);
        }

        /* FindDay searches a date in CalendarDay table to retrieve its Id. If the date is not found, it creates a new record and returns its Id
                * This method is used by AddEvent. If the date of the given event has existing events, we give the event to be added the Id of the calendarDay. */
        public int FindDay(DateTime date)
        {
            int CalendarDayId = -1;
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

        public void RemoveEventAndCalendarDay(string eventName, string _date)
        {
            DateTime eventDate = DateTime.Parse(_date);

            using (IDbConnection connection = new System.Data.SQLite.SQLiteConnection(Helper.CnnVal("CalendarDB")))
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Step 1: Retrieve CalendarDayId based on eventDate
                    string calendarDayQuery = "SELECT Id FROM CalendarDay WHERE Date = @EventDate";
                    int calendarDayId = connection.QueryFirstOrDefault<int>(calendarDayQuery, new { EventDate = eventDate }, transaction);

                    if (calendarDayId != 0) // Assuming 0 is not a valid Id
                    {
                        // Step 2: Remove the event from the Event table
                        string removeEventQuery = "DELETE FROM Event WHERE Name = @EventName AND CalendarDayId = @CalendarDayId";
                        connection.Execute(removeEventQuery, new { EventName = eventName, CalendarDayId = calendarDayId }, transaction);

                        // Step 3: Check if the CalendarDay has no more events
                        string remainingEventsQuery = "SELECT COUNT(*) FROM Event WHERE CalendarDayId = @CalendarDayId";
                        int remainingEvents = connection.ExecuteScalar<int>(remainingEventsQuery, new { CalendarDayId = calendarDayId }, transaction);

                        if (remainingEvents == 0)
                        {
                            // Step 4: Remove the CalendarDay if it has no more events
                            string removeCalendarDayQuery = "DELETE FROM CalendarDay WHERE Id = @CalendarDayId";
                            connection.Execute(removeCalendarDayQuery, new { CalendarDayId = calendarDayId }, transaction);
                        }
                        MessageBox.Show("Removed");
                        transaction.Commit();
                    }
                    else
                    {
                        Console.WriteLine("No matching records found in CalendarDay table.");
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    transaction.Rollback();
                }
            }
        }
    }
}




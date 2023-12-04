using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CalendarApp
{   /* Helper class grabs the DB connectionString to connect to DB */
    public class Helper
    {

        private string connectionString;
        public static string CnnVal(string name) 
        {
            return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
        }

        public Helper(string dbFilePath)
        {
                
            if (File.Exists(dbFilePath))
            {
                // Database file already exists
                connectionString = $"Data Source={dbFilePath};Version=3;";
            }
            else
            {
                // Database file does not exist, create it
                CreateDatabase(dbFilePath);
            }
        }

        private void CreateDatabase(string dbFilePath)
        {
            SQLiteConnection.CreateFile(dbFilePath);

            // Additional initialization steps if needed
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();

                // Execute SQL commands to initialize the database
                // For example, create tables, insert initial data, etc.
                string createTableQuery = "CREATE TABLE IF NOT EXISTS CalendarDay (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Date DATETIME NOT NULL)";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                createTableQuery = "CREATE TABLE IF NOT EXISTS Event (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Description TEXT NULL, Type TEXT NULL, CalendarDayId INTEGER NOT NULL, CONSTRAINT FK_Event_Day FOREIGN KEY (CalendarDayId) REFERENCES CalendarDay(Id))";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }


                connection.Close();
            }

            connectionString = $"Data Source={dbFilePath};Version=3;";
        }
    }
}

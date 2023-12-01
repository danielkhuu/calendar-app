using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp
{   /* Helper class grabs the DB connectionString to connect to DB */
    public static class Helper
    {
        public static string CnnVal(string name) 
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;

namespace CalendarApp
{
    /// <summary>
    /// This is where the startup page is chosen
    /// To change which page you see you need to change the View in line 27: MonthView(), WeekView(), DailyView()
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Checks if database exists in the current folder and creates it if not
            string dbFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CalendarDB.sqlite");
            Helper sqliteHelper = new Helper(dbFilePath);

            // initializes window and opens the startup page
            InitializeComponent();       
            mainFrame.Navigate(new MonthView());
        }
 
    }
}






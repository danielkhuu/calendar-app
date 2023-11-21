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

namespace CalendarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MonthLabel.Content = DateTime.Now.ToString("MMMM");

            PopulateCalendarGrid(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void PopulateCalendarGrid(int year, int month)
        {
            // Get the first day of the month and the total days in the month
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Calculate the day of the week for the first day of the month (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
            int startingDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // Clear existing content in the grid
            CalendarGrid.Children.Clear();

            // Populate the grid with dates
            for (int day = 1; day <= daysInMonth; day++)
            {
                // Calculate the row and column indices based on the starting day of the week
                int row = (startingDayOfWeek + day - 1) / 7; // Integer division to determine the row
                int col = (startingDayOfWeek + day - 1) % 7; // Modulus to determine the column

                // Create a label for each date
                Label dateLabel = new Label
                {
                    Content = day.ToString(),
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };

                // Add the label to the grid at the calculated row and column
                CalendarGrid.Children.Add(dateLabel);
                Grid.SetRow(dateLabel, row);
                Grid.SetColumn(dateLabel, col);
            }
        }
    }
}



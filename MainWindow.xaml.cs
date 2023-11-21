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

            // Calculate the number of days from the previous month
            int daysInPreviousMonth = startingDayOfWeek;
            DateTime firstDayOfPreviousMonth = firstDayOfMonth.AddDays(-daysInPreviousMonth);

            // Calculate the total number of cells needed in the grid (6 rows)
            int totalCells = 6 * 7; // 6 rows * 7 columns

            // Clear existing content in the grid
            CalendarGrid.Children.Clear();

            // Populate the grid with dates
            for (int day = 1; day <= totalCells; day++)
            {
                // Calculate the row and column indices based on the total number of cells
                int row = (day - 1) / 7; // Integer division to determine the row
                int col = (day - 1) % 7; // Modulus to determine the column

                // Calculate the date for the current cell
                DateTime currentDate = firstDayOfPreviousMonth.AddDays(day - 1);

                // Create a label for each date
                Button dateLabel = new Button
                {
                    Content = currentDate.Day.ToString(),
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Gray,
                    Foreground = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    Background = Brushes.Transparent
                };

                // Set a different color for labels corresponding to dates outside the current month
                if (currentDate.Month != month)
                {
                    dateLabel.Foreground = Brushes.LightGray; // You can choose any color
                    dateLabel.BorderBrush = Brushes.LightGray;
                }

                else if (currentDate == DateTime.Today)
                {
                    dateLabel.Foreground = Brushes.Pink;
                    dateLabel.BorderBrush = Brushes.Black;
                    dateLabel.BorderThickness = new Thickness(2);
                }

                // Add the label to the grid at the calculated row and column
                CalendarGrid.Children.Add(dateLabel);
                Grid.SetRow(dateLabel, row);
                Grid.SetColumn(dateLabel, col);
            }
        }

    }

}






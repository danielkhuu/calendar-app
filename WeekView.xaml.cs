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
    /// Interaction logic for WeekView.xaml
    /// </summary>
    public partial class WeekView : Page
    {
        public string WeekRange { get; set; }
        public WeekView()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek); // Assuming Sunday is the start of the week
            DateTime endOfWeek = startOfWeek.AddDays(6);

            WeekRange = $"{startOfWeek.ToShortDateString()} - {endOfWeek.ToShortDateString()}";
            WeekLabel.Content = WeekRange;

            PopulateCalendarGrid(DateTime.Now.Month, (int)DateTime.Now.DayOfWeek);
        }

        private void PopulateCalendarGrid(int month, int week)
        {
            // Get the first day of the month and the total days in the month
            DateTime currentDate = DateTime.Today;


            // Calculate the day of the week for the first day of the month (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
            DateTime firstDayOfWeek = currentDate.AddDays(-week);

            // Clear existing content in the grid
            CalendarGrid.Children.Clear();

            // Populate the grid with dates
            for (int day = 1; day <= 7; day++)
            {
                // Calculate the row and column indices based on the total number of cells
                int col = (day - 1) % 7; // Modulus to determine the column

                // Calculate the date for the current cell
                DateTime dummyDate = firstDayOfWeek.AddDays(day - 1);

                // Create a label for each date
                Button dateLabel = new Button
                {
                    Content = dummyDate.Day.ToString(),
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Gray,
                    Foreground = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    Background = Brushes.Transparent
                };

                if (dummyDate == DateTime.Today)
                {
                    dateLabel.Foreground = Brushes.Pink;
                    dateLabel.BorderBrush = Brushes.Black;
                    dateLabel.BorderThickness = new Thickness(2);
                }

                // Add the label to the grid at the calculated row and column
                CalendarGrid.Children.Add(dateLabel);
                Grid.SetColumn(dateLabel, col);
            }
        }
    }
}

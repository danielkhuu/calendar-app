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
    public partial class MonthView : Page
    {
        private int _month { get; set; }
        private int _year {get; set; }


        public MonthView()
        {
            InitializeComponent();
            _month = DateTime.Now.Month;
            _year = DateTime.Now.Year;
            MonthLabel.Content = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.ToString("yyyy");

            PopulateCalendarGrid(_year, _month);
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            int prevMonth, prevYear;

            if(_month != 1)
            {
                prevMonth = _month - 1;
                _month = prevMonth;
            }

            else 
            { 
                _month = 12;
                prevYear = _year - 1;
                _year = prevYear;
            }

            DateTime _Date = new DateTime(_year, _month, 1);
            MonthLabel.Content = _Date.ToString("MMMM") + " " + _Date.ToString("yyyy");
            PopulateCalendarGrid(_year, _month);
            
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            int nextMonth, nextYear;

            if (_month != 12)
            {
                nextMonth = _month + 1;
                _month = nextMonth;
            }

            else
            {
                _month = 1;
                nextYear = _year + 1;
                _year = nextYear;
            }

            DateTime _Date = new DateTime(_year, _month, 1);
            MonthLabel.Content = _Date.ToString("MMMM") + " " + _Date.ToString("yyyy");
            PopulateCalendarGrid(_year, _month);

        }

        private void OpenDropDown_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu dropdownMenu = new ContextMenu();

            // Create buttons to be added to the dropdown menu
            Button button1 = new Button { Content = "Monthly", Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, Style = (Style)FindResource("HoverButtonDDStyle") };
            Button button2 = new Button { Content = "Weekly", Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, Style = (Style)FindResource("HoverButtonDDStyle") };
            Button button3 = new Button { Content = "Daily", Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, Style = (Style)FindResource("HoverButtonDDStyle") };

            // Attach click event handlers to the buttons if needed
            button1.Click += DropdownButton_Click;
            button2.Click += DropdownButton_Click;
            button3.Click += DropdownButton_Click;

            // Add buttons to the ContextMenu
            dropdownMenu.Items.Add(button1);
            dropdownMenu.Items.Add(button2);
            dropdownMenu.Items.Add(button3);

            // Set the placement target and open the ContextMenu
            dropdownMenu.PlacementTarget = sender as UIElement;
            dropdownMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            dropdownMenu.IsOpen = true;
        }

        private void DropdownButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ((ContextMenu)((FrameworkElement)sender).Parent).IsOpen = false;

            if (clickedButton != null)
            {
                // Get the content (text) of the clicked button
                string buttonText = clickedButton.Content.ToString();

                if (buttonText == "Monthly")
                {
                    NavigationService.Navigate(new MonthView());
                }

                else if (buttonText == "Weekly")
                {
                    NavigationService.Navigate(new WeekView());
                }

                else
                {
                    NavigationService.Navigate(new DailyView());
                }
            }
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
                    dateLabel.Foreground = Brushes.LightGray; 
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

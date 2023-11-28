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
        private int _month { get; set; }
        private int _year { get; set; }
        private int _day { get; set; }
        public WeekView()
        {
            InitializeComponent();

            DateTime today = DateTime.Today;
            _month = today.Month;
            _year = today.Year;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek); // Assuming Sunday is the start of the week
            DateTime endOfWeek = startOfWeek.AddDays(6);
            _day = startOfWeek.Day;

            WeekRange = $"{startOfWeek.ToShortDateString()} - {endOfWeek.ToShortDateString()}";
            WeekLabel.Content = WeekRange;

            PopulateCalendarGrid(today);
        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e)
        {
            DateTime prevWeek = new DateTime(_year, _month, _day);

      
            prevWeek = prevWeek.AddDays(-7);
            _month = prevWeek.Month;
            _day = prevWeek.Day;
            _year = prevWeek.Year;

            PopulateCalendarGrid(prevWeek);
            DateTime prevWeekEnd = prevWeek.AddDays(6);
            WeekLabel.Content = $"{prevWeek.ToShortDateString()} - {prevWeekEnd.ToShortDateString()}";
        }

        private void NextWeek_Click(object sender, RoutedEventArgs e)
        {
            DateTime nextWeek = new DateTime(_year, _month, _day);

            nextWeek = nextWeek.AddDays(7);
            _month = nextWeek.Month;
            _day = nextWeek.Day;
            _year = nextWeek.Year;

            PopulateCalendarGrid(nextWeek);
            DateTime nextWeekEnd = new DateTime();
            nextWeekEnd = nextWeek.AddDays(6);
            WeekLabel.Content = $"{nextWeek.ToShortDateString()} - {nextWeekEnd.ToShortDateString()}";
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

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddingTask addwindow = new AddingTask();
            addwindow.Show();

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchTask searchwindow = new SearchTask();
            searchwindow.Show();
        }

        private void PopulateCalendarGrid(DateTime dayX)
        { 
            // Calculate the day of the week for the first day of the month (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
            DateTime firstDayOfWeek = dayX.AddDays(-(int)dayX.DayOfWeek);

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

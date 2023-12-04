//Function Page for Daily View

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
    public partial class DailyView : Page
    {
        private int _month { get; set; }
        private int _year { get; set; }
        private int _day { get; set; }
        private DateTime Today { get; set; }
        public DailyView()
        {
            InitializeComponent();

            // initialize data for page
            DateTime today = DateTime.Today;
            Today = today;
            _month = today.Month;
            _year = today.Year;
            _day = today.Day;

            // Display today's date
            DayLabel.Content = Today.ToLongDateString();

            // Create and display grid
            PopulateCalendarGrid();
        }

        // Function to display previous day
        private void PrevDay_Click(object sender, RoutedEventArgs e)
        {
            DateTime prevDay = new DateTime(_year, _month, _day);

            prevDay = prevDay.AddDays(-1);
            _month = prevDay.Month;
            _day = prevDay.Day;
            _year = prevDay.Year;

            DayLabel.Content = prevDay.ToLongDateString();
            PopulateCalendarGrid();
        }

        // Function to display next day
        private void NextDay_Click(object sender, RoutedEventArgs e)
        {
            DateTime nextDay = new DateTime(_year, _month, _day);

            nextDay = nextDay.AddDays(1);
            _month = nextDay.Month;
            _day = nextDay.Day;
            _year = nextDay.Year;

            DayLabel.Content = nextDay.ToLongDateString();
            PopulateCalendarGrid();
        }

        // Dropdown for changing the page
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

        // Changes the page based on which dropdown button was clicked
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

        // Opens add task window
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddingTask addwindow = new AddingTask();
            addwindow.Show();

        }

        // Opens search task window
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchTask searchwindow = new SearchTask();
            searchwindow.Show();
        }

        // Opens settings window
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            CalendarSettings settings = new CalendarSettings();
            settings.Show();
        }

        // Creates and populates the dates grid
        private void PopulateCalendarGrid()
        {
            // Clear previous data
            CalendarGrid.Children.Clear();

            // Retrieve tasks for today's date
            DatabaseManager databaseManager = new DatabaseManager();
            DateTime dateTime = new DateTime(_year, _month, _day);
            var tasksForDate = databaseManager.RetrieveEventDataByDate(dateTime);

            int i = 1;

            // Create grid row for each task in the date
            foreach (Event _event in tasksForDate)
            {
                Label timeLabel = new Label
                {
                    Content = _event.name,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Gray,
                    Foreground = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    Background = Brushes.Transparent
                };

                CalendarGrid.Children.Add(timeLabel);
                Grid.SetRow(timeLabel, i-1);
                Grid.SetColumn(timeLabel, 0);

                Button taskLabel = new Button
                {
                    Content = _event.description,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Gray,
                    Foreground = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    Background = Brushes.Transparent
                };

                CalendarGrid.Children.Add(taskLabel);
                Grid.SetRow(taskLabel, i-1);
                Grid.SetColumn(taskLabel, 1);

                i++;
            }
        }
        
    }
}

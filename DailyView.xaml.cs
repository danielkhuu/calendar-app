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
    /// <summary>
    /// Interaction logic for DailyView.xaml
    /// </summary>
    public partial class DailyView : Page
    {
        public DailyView()
        {
            InitializeComponent();
            DayLabel.Content = DateTime.Now.ToLongDateString();

            PopulateCalendarGrid();
        }

        //Needs to be updated once database is functional, currently just used for example
        private void PopulateCalendarGrid()
        {

            for (int i = 1; i < 5; i++)
            {
                Label timeLabel = new Label
                {
                    Content = i.ToString() + ":00",
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
                    Content = "Example Task - Example Description",
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
            }
        }
        
    }
}

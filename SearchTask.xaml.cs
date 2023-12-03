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
using System.Windows.Shapes;

namespace CalendarApp
{
    /// <summary>
    /// Interaction logic for SearchTask.xaml
    /// </summary>
    public partial class SearchTask : Window
    {
        private string _SearchName;
        private string _SearchDate;
        private DatabaseManager _databaseManager;
        public SearchTask()
        {
            _databaseManager = new DatabaseManager();
        }

        private void SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _SearchName = SearchName.Text;
        }

        private void SearchDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            _SearchDate = SearchDate.Text;
        }

        private void CancelTask_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _databaseManager.SearchEvent(_SearchName, _SearchDate);
        }
    }
}

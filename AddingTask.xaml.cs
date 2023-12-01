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
    /// Interaction logic for AddingTask.xaml
    /// </summary>
    public partial class AddingTask : Window
    {
        private string _title = "";
        private string _description = "";
        DatabaseManager _databaseManager = new DatabaseManager();
        public AddingTask()
        {
            InitializeComponent();
        }

        public void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            string _TaskName = TaskName.Text;
            string _TaskDescription = TaskDescription.Text;
            string _TaskDate = TaskDate.Text;
            _databaseManager.AddEvent(_TaskName, _TaskDescription, _TaskDate);
            MessageBox.Show("Event Added");
            this.Close();

        }

        private void TaskName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //read user input of name and description
        }

        private void CancelTask_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DateInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //read user input on date of a task/event
        }
    }
}

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
        //private string _title = "";
        //private string _description = "";
        public AddingTask()
        {
            InitializeComponent();
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            //add task to database here?
        }

        private void TaskName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

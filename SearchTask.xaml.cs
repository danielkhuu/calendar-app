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
        public SearchTask()
        {
            InitializeComponent();
        }

        private void SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchDate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CancelTask_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

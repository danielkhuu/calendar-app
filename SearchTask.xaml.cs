﻿using System;
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
        private DatabaseManager _databaseManager;
        public SearchTask()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();
        }

        private void SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _SearchName = SearchName.Text;
        }

        private void SearchDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _SearchDate = SearchDate.Text;
        }

        private void CancelTask_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTask_Click(object sender, RoutedEventArgs e)
        {
            string _SearchName = SearchName.Text;
            string _SearchDate = SearchDate.Text;
            if (_SearchName != "" && _SearchDate != "")
            {
                _databaseManager.SearchEvent(_SearchName, _SearchDate);
            }
            else
            {
                MessageBox.Show("Please enter a name and date.");
            }
        }

        private void ScheduleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            string _SearchName = SearchName.Text;
            string _SearchDate = SearchDate.Text;
            if (_SearchName != "" && _SearchDate != "")
            {
                _databaseManager.RemoveEventAndCalendarDay(_SearchName, _SearchDate);
            }
            else
            {
                MessageBox.Show("Please enter a name and date.");
            }
        }
    }
}
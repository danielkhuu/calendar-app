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
    /// Interaction logic for CalendarSettings.xaml
    /// </summary>
    public partial class CalendarSettings : Window
    {
        // Color settings properties
        public SolidColorBrush BackgroundColor { get; set; }
        public SolidColorBrush ForegroundColor { get; set; }

        public CalendarSettings()
        {
            InitializeComponent();

            // the color settings and the default values
            BackgroundColor = new SolidColorBrush(Colors.White);
            ForegroundColor = new SolidColorBrush(Colors.Black);

            // the Set color settings for UI elements
            // this could change based on you guys opinion 
            BackgroundColorPicker.SelectedColor = BackgroundColor.Color;
            ForegroundColorPicker.SelectedColor = ForegroundColor.Color;
        }

        private void ApplySettings_Click(object sender, RoutedEventArgs e)
        {
            // Applying color settings
            BackgroundColor = new SolidColorBrush(BackgroundColorPicker.SelectedColor ?? Colors.White);
            ForegroundColor = new SolidColorBrush(ForegroundColorPicker.SelectedColor ?? Colors.Black);

            this.Close();
        }

        private void CancelSettings_Click(object sender, RoutedEventArgs e)
        {
            // Close the settings window with no change
            this.Close();
        }
    }
}


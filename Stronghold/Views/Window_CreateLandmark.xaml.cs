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

namespace Stronghold.Views
{
    /// <summary>
    /// Interaction logic for Window_CreateLandmark.xaml
    /// </summary>
    public partial class Window_CreateLandmark : Window
    {
        public event EventHandler LandmarkCreated;
        public Window_CreateLandmark()
        {
            InitializeComponent();
        }

        private void CreateLandmarkButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.LandmarkCreated?.Invoke(this, null);

            this.Hide();
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

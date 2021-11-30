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
using Controller;
using Utility;

namespace Stronghold.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Dashboard.xaml
    /// </summary>
    public partial class UC_Dashboard : UserControl
    {
        private AuthenticationController authenticationController = new();
        private LandmarkController landmarkController = new();

        private Window_CreateLandmark windowCreateLandmark = new();

        public UC_Dashboard()
        {
            InitializeComponent();

            this.CurrentUsername.Content = Authentication.User.Username;

            this.SubscribeToEvents();
        }

        public void GetData()
        {

        }

        public void SubscribeToEvents()
        {
            this.windowCreateLandmark.LandmarkCreated += this.OnLandmarkCreated;
        }

        public void OnLandmarkCreated(object sender, EventArgs e)
        {
            this.GetData();
        }

        private void NewLandmarkButton_Click(object sender, RoutedEventArgs e)
        {
            windowCreateLandmark.Show();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            Feedback feedback = this.authenticationController.SignOut();

            if (feedback.MessageType == Feedback.Type.Success)
            {
                this.Content = new UC_Authentication();
            }
        }
    }
}

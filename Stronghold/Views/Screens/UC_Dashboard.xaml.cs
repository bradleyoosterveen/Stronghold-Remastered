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
using Model;
using Stronghold.Views.Components;
using Utility;

namespace Stronghold.Views.Screens
{
    /// <summary>
    /// Interaction logic for UC_Dashboard.xaml
    /// </summary>
    public partial class UC_Dashboard : UserControl
    {
        private readonly AuthenticationController _authenticationController = new();
        private readonly DashboardController _dashboardController = new();

        private readonly Window_CreateLandmark _windowCreateLandmark = new();

        public UC_Dashboard()
        {
            InitializeComponent();

            this.CurrentUsername.Content = Authentication.User.Username;

            this.SubscribeToEvents();

            this.UpdateList();
        }

        public void UpdateList()
        {
            this.LandmarkList.Children.Clear();

            foreach (Landmark landmark in this._dashboardController.GetLandmarks())
            {
                UC_LandmarkCard landmarkCard = new UC_LandmarkCard(landmark);

                this.LandmarkList.Children.Add(landmarkCard);

                landmarkCard.ViewLandmark += this.OnViewLandmark;
            }
        }

        public void SubscribeToEvents()
        {
            this._windowCreateLandmark.LandmarkCreated += this.OnLandmarkCreated;
        }

        public void OnLandmarkCreated(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        public void OnViewLandmark(object sender, EventArgs e)
        {
            
        }

        private void NewLandmarkButton_Click(object sender, RoutedEventArgs e)
        {
            this._windowCreateLandmark.Show();
            this._windowCreateLandmark.Activate();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Are you sure you want to log out?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msgBoxResult != MessageBoxResult.Yes)
                return;

            Feedback feedback = this._authenticationController.SignOut();

            if (feedback.MessageType == Feedback.Type.Success)
            {
                this.Content = new UC_Authentication();
            }
        }
    }
}

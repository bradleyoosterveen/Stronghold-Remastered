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
using Stronghold.Resources.Styling;
using Utility;

namespace Stronghold.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UC_AccessCard.xaml
    /// </summary>
    public partial class UC_Authentication : UserControl
    {
        private AuthenticationController AuthenticationController = new AuthenticationController();

        public UC_Authentication()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            Request request = new Request();

            request.AddData("username", this.UsernameInput.Text);
            request.AddData("securitytoken", this.SecurityTokenInput.Password);

            Feedback feedback = this.AuthenticationController.SignIn(request);

            if (feedback.MessageType == Feedback.Type.Success)
            {
                this.Content = new UC_Dashboard();
            }
            else
            {
                MessageBox.Show(feedback.Message);
            }
        }
    }
}

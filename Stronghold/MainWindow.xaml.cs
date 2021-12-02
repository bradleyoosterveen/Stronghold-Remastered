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
using Data;
using Stronghold.Views.UserControls;
using Utility;

namespace Stronghold
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DotNetEnv.Env.TraversePath().Load();

            Feedback databaseFeedback = Database.Initialize();

            if (databaseFeedback.MessageType == Feedback.Type.Error)
                this.ShowError(databaseFeedback.Message);

            this.App.Content = new UC_Authentication();
        }
        public void ShowError(string message)
        {
            MessageBoxResult result = MessageBox.Show(message);

            if (result == MessageBoxResult.OK)
                this.Close();
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

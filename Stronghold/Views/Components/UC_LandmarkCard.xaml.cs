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

namespace Stronghold.Views.Components
{
    /// <summary>
    /// Interaction logic for UC_LandmarkCard.xaml
    /// </summary>
    public partial class UC_LandmarkCard : UserControl
    {
        public event EventHandler DeleteLandmark;
        public event EventHandler EditLandmark;

        private readonly LandmarkCardController _landmarkCardController = new();

        private readonly Landmark _landmark;

        public UC_LandmarkCard(Landmark landmark)
        {
            InitializeComponent();

            this._landmark = landmark;

            this.SetLabels();

            this.Buttons.Visibility = Visibility.Hidden;

            // @TODO: Edit landmark 
            // @TODO: Delete landmark ((StackPanel)this.Parent).Children.Remove(this);
        }

        public void SetLabels()
        {
            this.DimensionLabel.Content = this._landmark.Dimension.Description;
            this.DescriptionLabel.Content = this._landmark.Description;
            this.CoordinatesLabel.Content = $"{this._landmark.X}/{this._landmark.Y}/{this._landmark.Z}";
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Buttons.Visibility = Visibility.Visible;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Buttons.Visibility = Visibility.Hidden;
        }

        private void DeleteButton_Clicked(object sender, RoutedEventArgs e)
        {
            this._landmarkCardController.DeleteLandmark(this._landmark.ID);

            this.DeleteLandmark?.Invoke(this, EventArgs.Empty);
        }
    }
}

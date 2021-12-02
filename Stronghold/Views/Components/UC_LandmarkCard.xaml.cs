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
using Model;

namespace Stronghold.Views.Components
{
    /// <summary>
    /// Interaction logic for UC_LandmarkCard.xaml
    /// </summary>
    public partial class UC_LandmarkCard : UserControl
    {
        public event EventHandler ViewLandmark;

        private readonly Landmark _landmark;

        public UC_LandmarkCard(Landmark landmark)
        {
            InitializeComponent();

            this._landmark = landmark;

            this.SetLabels();
        }

        public void SetLabels()
        {
            this.DimensionLabel.Content = this._landmark.Dimension.Description;
            this.DescriptionLabel.Content = this._landmark.Description;
            this.OwnerLabel.Content = this._landmark.Owner.Username;
            this.CoordinatesLabel.Content = $"{this._landmark.X}/{this._landmark.Y}/{this._landmark.Z}";
        }
    }
}

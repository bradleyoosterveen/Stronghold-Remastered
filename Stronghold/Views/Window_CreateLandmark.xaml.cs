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
using Controller;
using Model;
using Utility;

namespace Stronghold.Views
{
    /// <summary>
    /// Interaction logic for Window_CreateLandmark.xaml
    /// </summary>
    public partial class Window_CreateLandmark : Window
    {
        public event EventHandler LandmarkCreated;

        private readonly CreateLandmarkController _createLandmarkController = new();

        public Window_CreateLandmark()
        {
            InitializeComponent();

            this.FillDimensionComboBox();
        }

        public void FillDimensionComboBox()
        {
            foreach (Dimension dimension in this._createLandmarkController.GetDimensions())
            {
                this.DimensionInput.Items.Add(
                    new KeyValuePair<int,string>(dimension.ID, dimension.Description)
                );
            }
        }

        public bool FieldsAreEmpty()
        {
            if (this.DescriptionInput.Text is "" or null) return true;
            if (this.XInput.Text is "" or null) return true;
            if (this.YInput.Text is "" or null) return true;
            if (this.ZInput.Text is "" or null) return true;

            return false;
        }

        private void CreateLandmarkButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (FieldsAreEmpty())
            {
                MessageBox.Show("Not all fields are filled in");
                return;
            }

            int dimension = ((KeyValuePair<int, string>)this.DimensionInput.SelectionBoxItem).Key;
            string description = this.DescriptionInput.Text;
            int x = int.Parse(this.XInput.Text);
            int y = int.Parse(this.YInput.Text);
            int z = int.Parse(this.ZInput.Text);

            Request request = new();
            request.AddData("dimension_id", dimension);
            request.AddData("description", description);
            request.AddData("x", x);
            request.AddData("y", y);
            request.AddData("z", z);

            Feedback feedback = this._createLandmarkController.InsertLandmark(request);

            if (feedback.MessageType != Feedback.Type.Success)
            {
                MessageBox.Show(feedback.Message);
                return;
            }

            this.LandmarkCreated?.Invoke(this, EventArgs.Empty);

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

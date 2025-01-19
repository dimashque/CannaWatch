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
using CannaWatch.ViewModels;

namespace CannaWatch.Views
{
    /// <summary>
    /// Interaction logic for PlantView.xaml
    /// </summary>
    public partial class PlantView : Window
    {
        private readonly PlantViewModel plantViewModel;
        public PlantView()
        {
            InitializeComponent();
            var sensorService = ((App)Application.Current).PlantViewSensorService;

            plantViewModel = new PlantViewModel(sensorService);
            DataContext = plantViewModel;
            this.Closed += PlantView_Closed;
        }

        private void PlantView_Closed(object sender, EventArgs e)
        {
            plantViewModel.CloseSerialPort();
            Application.Current.Shutdown();
        }


    }
}

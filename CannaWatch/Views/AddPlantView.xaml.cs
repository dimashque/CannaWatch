using CannaWatch.ViewModels;
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


namespace CannaWatch.Views
{
    /// <summary>
    /// Interaction logic for AddPlantView.xaml
    /// </summary>
    public partial class AddPlantView : Window
    {
        private AddPlantViewModel viewModel;
        public AddPlantView()
        {
            InitializeComponent();
            viewModel = new AddPlantViewModel();
            DataContext = viewModel;

            
        }
    }
}

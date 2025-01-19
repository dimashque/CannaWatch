using System.Windows;

namespace CannaWatch.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewPlants_Click(object sender, RoutedEventArgs e)
        {
            var plantView = new PlantView();
            plantView.Show();
            this.Hide();
        }

          private void AddPlant_Click(object sender, RoutedEventArgs e)
        {
            var addPlantView = new AddPlantView();
            addPlantView.Show();
            this.Hide();
        } 

        private void CloseProgram_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
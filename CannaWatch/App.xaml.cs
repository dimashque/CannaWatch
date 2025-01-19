using System.Configuration;
using System.Data;
using System.Windows;
using CannaWatch.Models;
using CannaWatch.Services;
using CannaWatch.Interfaces;

namespace CannaWatch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SensorService PlantViewSensorService { get; private set; }
        public SensorService AddPlantViewSensorService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // SensorService for PlantView (only Temperature and Humidity sensors)
            PlantViewSensorService = new SensorService();
            PlantViewSensorService.AddSensor(new TempSensor());
            PlantViewSensorService.AddSensor(new HumSensor());
            //PlantViewSensorService.InitializeSensors();

            // SensorService for AddPlantView (only FlameAlarm sensor)
            AddPlantViewSensorService = new SensorService();
            AddPlantViewSensorService.AddSensor(new FlameSensor());
           // AddPlantViewSensorService.InitializeSensors();

            // Initialize MainWindow or other initial logic here if needed
        }

    }

}

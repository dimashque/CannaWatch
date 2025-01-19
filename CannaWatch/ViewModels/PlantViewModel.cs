using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CannaWatch.Data;
using CannaWatch.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CannaWatch.Commands;
using CannaWatch.Views;
using System.Windows;
using CannaWatch.Services;
using System.IO.Ports;
using System.ComponentModel;

namespace CannaWatch.ViewModels
{
    public class PlantViewModel : INotifyPropertyChanged
    {
        private AppDbContext _context;
        private SensorService _sensorService;
        private SerialPort _serialPort;

        private string _tentTemp;
        private string _tentHum;

        public string TentTemp
        {
            get => _tentTemp;
            set
            {
                _tentTemp = value;
                OnPropertyChanged(nameof(TentTemp));
                
            }
        }
        public string TentHum
        {
            get => _tentHum;
            set
            {
                _tentHum = value;
                OnPropertyChanged(nameof(TentHum));
                
            }
        }

        public ObservableCollection<Plant> Plants { get; set; }

        public ICommand WaterPlantCommand { get; }
        public ICommand FeedPlantCommand { get; }

        public ICommand OpenDetailsCommand { get; }

        public ICommand HarvestPlantCommand { get; }



        public PlantViewModel(SensorService sensorService)
        {
            _context = new AppDbContext();

            _sensorService = sensorService;
            try
            {
                _sensorService.InitializeSensors();
                
                InitializeSerialPort();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error Communication: " + ex.Message);
            }

           
            
            //Relay Commnands
            WaterPlantCommand = new RelayCommand(WaterPlant);
            FeedPlantCommand = new RelayCommand(FeedPlant);
            OpenDetailsCommand = new RelayCommand(OpenDetails);
            HarvestPlantCommand = new RelayCommand(HarvestPlant);

            LoadPlants();
        }

        public void LoadPlants()
        {
            Plants = new ObservableCollection<Plant>(_context.Plants.ToList());

        }

        public void InitializeSerialPort()
        {
            System.Diagnostics.Debug.WriteLine("initilizing SerialPorts");
            
            _serialPort = new SerialPort("COM8", 9600);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            
            _serialPort.Open();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                
                string data = sp.ReadExisting();
                
                System.Diagnostics.Debug.WriteLine($"Data received: {data}");
                _serialPort.WriteLine($"Data received: {data}");

                // Example data format: "25.5,65.4"
                string[] sensorValues = data.Trim().Split(',');

                if (sensorValues.Length == 2)
                {
                    // Check and parse temperature and humidity
                    TentTemp = sensorValues[0]; // Directly assign to string for simplicity
                    TentHum = sensorValues[1];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataReceivedHandler: {ex.Message}");
            }
        }


        public void CloseSerialPort()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        public void WaterPlant(object param)
        {
            if (param is Plant plant)
            {
                plant.LastWatered = DateTime.Now;
                _context.Plants.Update(plant);
                _context.SaveChanges();
            }

        }

        public void FeedPlant(object param)
        {
            if (param is Plant plant)
            {
                plant.LastFed = DateTime.Now;
                _context.Plants.Update(plant);
                _context.SaveChanges();
            }

        }

        public void HarvestPlant(object param)
        {
            if (param is Plant plant)
            {
                plant.isHarvested = true;
                _context.Plants.Update(plant);
                _context.SaveChanges();
                MessageBox.Show($"Happy {plant.Strain} harvesting :)");
            }

        }

        public  void OpenDetails(object param)
        {
            if (param is Plant plant)
            {
                var detailsView = new DetailsView();
                var viewModel = new DetailsViewModel(plant, "sk-proj-sk-n2lXLinrr-6-nnPoSEdLFN_ewzpFTv76iVH46dTZcuT3BlbkFJsX5M8rYlzKy2vPYESp1gH9W0_Uy5Hmm2KnvZu9rAwA"); // Replace with your actual API key
                detailsView.DataContext = viewModel;

                // Load the plant info asynchronously
              // _=  viewModel.LoadPlantInfoAsync();

                detailsView.ShowDialog();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

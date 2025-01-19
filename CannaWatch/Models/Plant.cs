using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace CannaWatch.Models
    {
    public class Plant : INotifyPropertyChanged
    {
        private DateTime _lastWatered;
        private DateTime _lastFed;

        public int Id { get; set; }
        public string Strain { get; set; }
        public string ImageUrl { get; set; }

        public DateTime PlantDate { get; set; }

        public bool isHarvested { get; set; } = false;

        public DateTime LastWatered
        {
            get => _lastWatered;
            set
            {
                _lastWatered = value;
                OnPropertyChanged(nameof(LastWatered));
                OnPropertyChanged(nameof(DaysSinceLastWatered));
            }
        }

        public DateTime LastFed
        {
            get => _lastFed;
            set
            {
                _lastFed = value;
                OnPropertyChanged(nameof(LastFed));
                OnPropertyChanged(nameof(DaysSinceLastFed));
            }
        }

        public int DaysSinceLastWatered => (DateTime.Now - LastWatered).Days;
        public int DaysSinceLastFed => (DateTime.Now - LastFed).Days;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}



using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CannaWatch.Interfaces;


namespace CannaWatch.Services
{
    public class SensorService
    {
        private readonly List<ISensor>sensors = new List<ISensor>();

      

        public void AddSensor(ISensor sensor)
        {
            sensors.Add(sensor);
        }

        public void InitializeSensors()
        {
            foreach (var sensor in sensors)
            {
                sensor.Initialize();
            }
        }

        public void UpdateSensors()
        {
            foreach (var sensor in sensors)
            {
                sensor.Update();
            }
        }

        public IEnumerable<ISensor> GetSensors() => sensors;
    }
}

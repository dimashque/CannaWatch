using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CannaWatch.Interfaces;

namespace CannaWatch.Models
{
    public class HumSensor : ISensor
    {
        public string SensorType => "HumSensor";
        public List<string> Values { get; } = new List<string>();

        public void Initialize()
        {
            //
        }


        public void Update()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaWatch.Interfaces
{
    public interface ISensor 
    {
        string SensorType {  get; }
        List<string> Values { get;  }

        void Initialize();

        
        void Update();
    }
}

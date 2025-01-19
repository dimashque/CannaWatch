using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaWatch.Models
{
    public  class Strain
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Type { get; set; }

        public string? ThcLevel { get; set; }

        public string? RelaxedValue { get; set; }
        public string? HappyValue { get; set; }
        public string? EuphoricValue { get; set; }
        public string? UpliftedValue { get; set; }
        public string? SleepyValue { get; set; }
        public string? DryMouthValue { get; set; }
        public string? DryEyeValue { get; set; }
        public string? DizzyValue { get; set; }

        public string? ParanoidValue { get; set; }
        public string? AnxiousValue { get; set; }
        public string? StressValue { get; set; }
        public string? PainValue { get; set; }
        public string? DepressionValue { get; set; }
        public string? AnxietyValue { get; set; }
        public string? InsomniaValue { get; set; }

    }
}

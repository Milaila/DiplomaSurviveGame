using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class UniformDistribution : INumberDistribution
    {
        private readonly Random _rnd = new Random();
        public double Min { get; set; }
        public double Max { get; set; }

        public double Next()
        {
            return Min + (1 - _rnd.NextDouble()) * (Max - Min);
        }
    }
}

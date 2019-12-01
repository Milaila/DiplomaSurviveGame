using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Deduction : DTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Coefficient { get; set; }
        public DeductionType Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamNode
    { 
        public ExamNode Left { get; set; }
        public ExamNode Right { get; set; }
        public ExamPage Page { get; set; }
    }
}

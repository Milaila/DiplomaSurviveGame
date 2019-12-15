using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public interface IExam
    {
        int Level { get; set; }
        ExamType Type { get; set; }
        ExamPage Start();
        IExam Clone();
    }
}

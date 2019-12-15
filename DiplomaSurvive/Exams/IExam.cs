using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive.Exams
{
    public interface IExam
    {
        void Start();
        ExamPage Next();
    }
}

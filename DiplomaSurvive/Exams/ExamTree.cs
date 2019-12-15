using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamTree : IExam
    {
        public ExamPage RootPage { get; set; }
        public int Level { get; set; }
        public ExamType Type { get; set; }
        public virtual ExamPage Start()
        {
            return RootPage;
        }
        public IExam Clone()
        {
            return new ExamTree
            {
                RootPage = (ExamPage)RootPage.Clone(),
                Level = Level,
                Type = Type
            };
        }
    }
}

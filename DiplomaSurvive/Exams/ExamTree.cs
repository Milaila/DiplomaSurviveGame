using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamTree : IExam, ICloneable<ExamTree>, ICloneable<IExam>
    {
        public ExamPage RootPage { get; set; }
        public int Level { get; set; }
        public ExamType Type { get; set; }
        protected ICloneable<ExamPage> CloneableRootPage
        {
            get
            {
                return RootPage;
            }
        }

        public virtual ExamPage Start()
        {
            return RootPage;
        }
        IExam ICloneable<IExam>.Clone()
        {
            return (this as ICloneable<ExamTree>).Clone();
        }
        ExamTree ICloneable<ExamTree>.Clone()
        {
            return new ExamTree
            {
                RootPage = CloneableRootPage.Clone(),
                Level = Level,
                Type = Type
            };
        }
    }
}

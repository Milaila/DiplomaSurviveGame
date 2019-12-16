using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamTree : IExam, ICloneable<ExamTree>
    {
        protected ExamPage _rootPage;

        public ExamPage RootPage
        {
            get { return _rootPage; }
            set
            {
                ICloneable<ExamPage> cloneable = value;
                _rootPage = cloneable.Clone();
            }
        }
        public int Level { get; set; }
        public ExamType Type { get; set; }
        protected ExamPage RootPageClone
        {
            get
            {
                ICloneable<ExamPage> cloneable = _rootPage;
                return cloneable.Clone();
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
                RootPage = RootPageClone,
                Level = Level,
                Type = Type
            };
        }
    }
}

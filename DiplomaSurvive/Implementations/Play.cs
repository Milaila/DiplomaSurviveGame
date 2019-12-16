using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Play
    {
        public IStore<IExam> ExamStore { get; protected set; }

        public Play()
        {

        }
        public void InitExamStore()
        {
            ExamStore = new BaseStore<IExam>
            {
                new ExamTree()
            };
        }
    }
}

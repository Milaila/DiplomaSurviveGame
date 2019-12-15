using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamFailPage : ExamPage
    {
        public override ExamPageType Type
        {
            get
            {
                return ExamPageType.Fail;
            }
        }
    }
}

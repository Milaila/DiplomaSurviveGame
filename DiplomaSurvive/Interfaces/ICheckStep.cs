using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public interface ICheckStep
    {
        double Check(BaseContext context);
        void SetNextStep(ICheckStep step);
    }
}

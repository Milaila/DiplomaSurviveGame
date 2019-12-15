using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public interface ICheckStep: ICloneable<ICheckStep>
    {
        event ValueChanged OnNeedCheck;
        double Check();
        void SetNextStep(ICheckStep step);
    }
}

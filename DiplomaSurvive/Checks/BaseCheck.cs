using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class BaseCheck
    {
        public int Priority { get; set; }
        public ICheckStep CheckChain { protected get; set; }
        public virtual (double probability, DeductionType) Check(BaseContext context)
        {
            return CheckChain?.Check(context) ?? (0, DeductionType.Undefined);
        }
    }
}

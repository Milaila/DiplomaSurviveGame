using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class BaseCheck
    {
        public int Priority { get; set; } = int.MaxValue;
        public bool IsDirty 
        { 
            get
            {
                return CheckChain?.NeedCheck() ?? false;
            }
        }
        public DeductionType DeductionType { get; set; } = DeductionType.Undefined;
        public ICheckStep CheckChain { protected get; set; }
        public virtual double Check()
        {
            return CheckChain?.Check() ?? 0;
        }
    }

    public enum ChangedValue
    {

    }
}

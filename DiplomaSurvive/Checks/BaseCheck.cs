using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class BaseCheck
    {
        private ICheckStep _checkChain;
        public int Priority { get; set; } = int.MaxValue;
        //public int Level;
        //public double Time;
        public bool IsDirty { get; private set; } = true;
        public DeductionType DeductionType { get; set; } = DeductionType.Undefined;
        public ICheckStep CheckChain 
        { 
            protected get
            {
                return _checkChain;
            }
            set
            {
                if (_checkChain != null)
                {
                    _checkChain.OnNeedCheck -= NeedCheck;
                }
                _checkChain = value;
                _checkChain.OnNeedCheck += NeedCheck;
            }
        }
        public virtual double Check()
        {
            IsDirty = false;
            return CheckChain?.Check() ?? 0;
        }
        public void NeedCheck()
        {
            IsDirty = true;
        }
    }
}

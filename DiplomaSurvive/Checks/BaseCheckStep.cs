using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class BaseCheckStep : ICheckStep
    {
        protected ICheckStep _nextStep;
        protected BaseContext _context;
        protected bool _needCheck = true;
        public event ValueChanged OnNeedCheck;
        public ICheckStep NextStep
        {
            set
            {
                SetNextStep(value);
            }
        }

        public BaseCheckStep(BaseContext context)
        {
            _context = context;
        }

        public void SetNextStep(ICheckStep step)
        {
            if (_nextStep != null)
            {
                _nextStep.OnNeedCheck -= AskForCheck;
            }
            _nextStep = step;
            _nextStep.OnNeedCheck += AskForCheck;
        }
        public virtual double Check()
        {
            double probability = 0;
            _needCheck = false;

            if (TryHandle(ref probability) || _nextStep == null)
            {
                return probability;
            }
            return _nextStep.Check();
        }
        protected void AskForCheck()
        {
            _needCheck = true;
            OnNeedCheck?.Invoke();
        }
        protected abstract bool TryHandle(ref double probability);
    }
}

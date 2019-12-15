using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class BaseCheckStep : ICheckStep, ICloneable<BaseCheckStep>
    {
        protected ICheckStep _nextStep;
        protected BaseContext _context;
        public bool NeedCheck { get; protected set; }
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
            NeedCheck = false;

            if (TryHandle(ref probability) || _nextStep == null)
            {
                return probability;
            }
            return _nextStep.Check();
        }
        protected void AskForCheck()
        {
            NeedCheck = true;
            OnNeedCheck?.Invoke();
        }
        protected abstract bool TryHandle(ref double probability);
        ICheckStep ICloneable<ICheckStep>.Clone()
        {
            return (this as ICloneable<BaseCheckStep>).Clone();
        }
        public abstract BaseCheckStep Clone();
    }
}

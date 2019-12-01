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
        public ICheckStep NextStep
        {
            set
            {
                _nextStep = value;
            }
        }

        public void SetNextStep(ICheckStep step)
        {
            _nextStep = step;
        }
        public virtual (double, DeductionType) Check(BaseContext context)
        {
            double probability = 0;
            DeductionType type = DeductionType.None;
            if (TryHandle(context, ref probability, ref type) || _nextStep == null)
            {
                return (probability, type);
            }
            return _nextStep.Check(context);
        }
        protected abstract bool TryHandle(BaseContext context, ref double probability, ref DeductionType deductionType);
    }
}

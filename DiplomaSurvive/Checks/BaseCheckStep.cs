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
        public ICheckStep NextStep
        {
            set
            {
                _nextStep = value;
            }
        }

        public BaseCheckStep(BaseContext context)
        {
            _context = context;
        }

        public void SetNextStep(ICheckStep step)
        {
            _nextStep = step;
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
        protected abstract bool TryHandle(ref double probability);
        public bool NeedCheck()
        {
            if (_needCheck)
            {
                return true;
            }
            return _nextStep?.NeedCheck() ?? false;
        }
        protected void AskForCheck()
        {
            _needCheck = true;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class BaseCheckStep : ICheckStep, ICloneable<BaseCheckStep>
    {
        protected ICheckStep _nextStep;
        [field:NonSerialized]
        protected BaseContext _context;
        public bool NeedCheck { get; protected set; }
        [field:NonSerialized]
        public event ValueChanged OnNeedCheck;
        public Func<double> CheckFunc;
        public TryHandleDelegate TryHandleFunc;
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
            if (CheckFunc != null)
            {
                return CheckFunc();
            }

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
        protected virtual bool TryHandle(ref double probability)
        {
            return TryHandleFunc?.Invoke(ref probability) ?? false;
        }
        ICheckStep ICloneable<ICheckStep>.Clone()
        {
            return (this as ICloneable<BaseCheckStep>).Clone();
        }
        public virtual BaseCheckStep Clone()
        {
            return new BaseCheckStep(_context)
            {
                NextStep = _nextStep.Clone(),
                CheckFunc = CheckFunc,
                TryHandleFunc = TryHandleFunc
            };
        }
        public virtual object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }

    public delegate bool TryHandleDelegate(ref double probability);
}

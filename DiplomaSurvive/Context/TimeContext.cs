using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class TimeContext : Context
    {
        protected double _lastTaskChanged;
        protected double _lastClickChanged;
        public virtual double LastTask
        {
            get { return _lastTaskChanged; }
            set
            {
                _lastTaskChanged = value;
                OnLastTaskChanged?.Invoke();
            }
        }
        public virtual double LastClick
        {
            get { return _lastClickChanged; }
            set
            {
                _lastClickChanged = value;
                OnLastClickChanged?.Invoke();
            }
        }
        public event ValueChanged OnLastTaskChanged;
        public event ValueChanged OnLastClickChanged;

        public TimeContext()
        {
            OnLastClickChanged += ContextChanged;
            OnLastTaskChanged += ContextChanged;
        }
    }
}

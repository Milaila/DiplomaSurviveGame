using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class MainContext : Context
    {
        protected double _levelChanged;
        public virtual double LastTask
        {
            get { return _levelChanged; }
            set
            {
                _levelChanged = value;
                OnLevelChanged?.Invoke();
            }
        }
        public event ValueChanged OnLevelChanged;

        public MainContext()
        {
            OnLevelChanged += ContextChanged;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class Context
    {
        public event ValueChanged OnContextChanged;

        protected void ContextChanged()
        {
            OnContextChanged?.Invoke();
        }
    }
}

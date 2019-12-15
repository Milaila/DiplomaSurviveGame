using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Button<T> : Button
    {
        public override event ValueChanged OnClickEvent;
        public virtual T OnClick (BaseContext context = null)
        {
            OnClickEvent?.Invoke();
            return default(T);
        }
    }

    public class Button
    {
        public string Title { get; set; }
        public virtual event ValueChanged OnClickEvent;
    }
}

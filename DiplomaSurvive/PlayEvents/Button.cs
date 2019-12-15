using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Button
    {
        public string Title { get; set; }
        public event ValueChanged OnClickEvent;

        public virtual void OnClick(BaseContext context)
        {
            OnClickEvent?.Invoke();
        }
    }
}

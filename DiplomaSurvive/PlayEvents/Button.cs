using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Button<T> : Button, ICloneable<Button<T>>
    {
        public override event ValueChanged OnClickEvent;
        public virtual T OnClickFunc(BaseContext context = null)
        {
            OnClickEvent?.Invoke();
            return default(T);
        }

        Button<T> ICloneable<Button<T>>.Clone()
        {
            return new Button<T>
            {
                Title = Title,
            };
        }
    }

    public class Button : ICloneable<Button>
    {
        public string Title { get; set; }
        public virtual event ValueChanged OnClickEvent;

        public virtual void OnClick(BaseContext context = null)
        {
            OnClickEvent?.Invoke();
        }
        Button ICloneable<Button>.Clone()
        {
            return new Button
            {
                Title = Title,
            };
        }
    }
}

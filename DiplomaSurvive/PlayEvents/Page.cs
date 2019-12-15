using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Page : ICloneable<Page>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public event ValueChanged OnCloseEvent;

        public virtual void OnClose()
        {
            OnCloseEvent?.Invoke();
        }
        Page ICloneable<Page>.Clone()
        {
            return new Page
            {
                Title = Title,
                Description = Description
            };
        }
    }
}

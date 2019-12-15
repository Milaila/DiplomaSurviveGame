using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ActionPage<TButton> : Page, ICloneable<ActionPage<TButton>>
        where TButton : Button, ICloneable<TButton>
    {
        public virtual List<TButton> Buttons { get; } = new List<TButton>();
        public virtual void AddButton(TButton button)
        {
            Buttons.Add(button.Clone());
        }

        ActionPage<TButton> ICloneable<ActionPage<TButton>>.Clone()
        {
            var page = new ActionPage<TButton>
            {
                Title = Title,
                Description = Description
            };
            foreach (var button in Buttons)
            {
                page.AddButton(button);
            }
            return page;
        }
    }
}

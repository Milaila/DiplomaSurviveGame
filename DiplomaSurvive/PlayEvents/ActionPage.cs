using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ActionPage<TButton> : Page
        where TButton : Button
    {
        public virtual List<TButton> Buttons { get; } = new List<TButton>();
        public virtual void AddButton(TButton button)
        {
            Buttons.Add(button.Clone() as TButton);
        }
        public override Page Clone()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PlayEvent : ActionPage<Button<Page>>, ICloneable<PlayEvent>
    {
        public virtual bool IsAvailable(BaseContext context = null)
        {
            return true;
        }
        PlayEvent ICloneable<PlayEvent>.Clone()
        {
            var page = new PlayEvent
            {
                Title = Title,
                Description = Description,
            };
            foreach (var button in Buttons)
            {
                page.AddButton(button);
            }
            return page;
        }
    }
}

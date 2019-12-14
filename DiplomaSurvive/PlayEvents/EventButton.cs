using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PlayEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EventButton LeftButton { get; set; }
        public EventButton RightButton { get; set; }
    }

    public abstract class EventButton
    {
        public string Title { get; set; }
        public abstract void OnClick(BaseContext context); 
    }
}

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
        public Dictionary<string, IButton> Buttons { get; set; }
        public virtual bool IsAvailable { get; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ActionPage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Button> Buttons { get; } = new List<Button>();
    }
}

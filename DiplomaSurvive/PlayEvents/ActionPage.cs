using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ActionPage<TButton> where TButton : Button
    {
        public List<TButton> Buttons { get; } = new List<TButton>();
    }
}

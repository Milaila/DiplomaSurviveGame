using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ActionPage<TButton> : Page
    {
        public List<Button<TButton>> Buttons { get; } = new List<Button<TButton>>();
    }
}

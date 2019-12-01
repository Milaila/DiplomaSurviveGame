using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class TasksContext
    {
        public virtual double LastTask { get; set; }
        public virtual double LastClick { get; set; }
    }
}

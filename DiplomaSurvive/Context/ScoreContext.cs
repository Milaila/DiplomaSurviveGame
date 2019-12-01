using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class ScoreContext
    {
        public virtual int StudyScore { get; set; }
        public virtual int PersonalLifeScore { get; set; }
        public virtual int MaxPersonalLifeScore { get; set; }
        public virtual int MaxStudyScore { get; set; }
    }
}

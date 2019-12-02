using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PersonalLifeScoreDefaultShorтtageCheckStep : BaseCheckStep
    {
        public double DeductionProbability { get; set; } = 1;

        public PersonalLifeScoreDefaultShorтtageCheckStep(BaseContext context) : base(context)
        {
            _context.Score.OnMinPersonalLifeScoreChanged += AskForCheck;
            _context.Score.OnPersonalLifeScoreChanged += AskForCheck;
        }
        protected override bool TryHandle(ref double probability)
        {
            if (_context.Score.PersonalLifeScore <= _context.Score.MinPersonalLifeScore)
            {
                probability = DeductionProbability;
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PersonalLifeScoreDefaultShortageCheckStep : BaseCheckStep
    {
        public double DeductionProbability { get; set; } = 1;

        public PersonalLifeScoreDefaultShortageCheckStep(BaseContext context) : base(context)
        {
            _context.Score.OnMinPersonalLifeScoreChanged += AskForCheck;
            _context.Score.OnPersonalLifeScoreChanged += AskForCheck;
        }
        protected override bool TryHandle(ref double probability)
        {
            if (_context.Score.PersonalLifeScore <= _context.Score.MinPersonalLifeScore)
            {
                probability = DeductionProbability;
                return true;
            }

            return false;
        }
    }

    public class PersonalLifeScoreShortageCheckStep : BaseCheckStep
    {
        public double DeductionProbability { get; set; } = 1;
        public int MinScore { get; set; } = 0;

        public PersonalLifeScoreShortageCheckStep(BaseContext context) : base(context)
        {
            _context.Score.OnMinPersonalLifeScoreChanged += AskForCheck;
            _context.Score.OnPersonalLifeScoreChanged += AskForCheck;
        }
        protected override bool TryHandle(ref double probability)
        {
            if (_context.Score.PersonalLifeScore <= MinScore)
            {
                probability = DeductionProbability;
                return true;
            }

            return false;
        }
    }
}

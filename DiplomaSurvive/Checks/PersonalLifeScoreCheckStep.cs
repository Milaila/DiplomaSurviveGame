using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PersonalLifeScoreCheckStep : BaseCheckStep
    {
        public int MinScore { get; set; } = 0;
        public int MaxScore { get; set; } = int.MaxValue;
        public double ExcessProbability { get; set; } = 1;
        public double ShortageProbability { get; set; } = 1;

        protected override bool TryHandle(BaseContext context, ref double probability)
        {
            if (context.Score.PersonalLifeScore <= MinScore)
            {
                probability = ExcessProbability;
                return true;
            }

            if (context.Score.PersonalLifeScore >= MaxScore)
            {
                probability = ShortageProbability;
                return true;
            }

            return false;
        }
    }

    public class PersonalLifeDefaultScoreCheckStep : BaseCheckStep
    {
        public double ExcessProbability { get; set; } = 1;
        public double ShortageProbability { get; set; } = 1;
        protected override bool TryHandle(BaseContext context, ref double probability)
        {
            if (context.Score.PersonalLifeScore <= context.Score.MinPersonalLifeScore)
            {
                probability = ExcessProbability;
                return true;
            }

            if (context.Score.PersonalLifeScore >= context.Score.MaxPersonalLifeScore)
            {
                probability = ShortageProbability;
                return true;
            }

            return false;
        }
    }
}

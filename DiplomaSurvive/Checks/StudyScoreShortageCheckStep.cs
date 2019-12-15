﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class StudyScoreShortageCheckStep : BaseCheckStep
    {
        public double DeductionProbability { get; set; } = 1;
        public int MinScore { get; set; } = 0;

        public StudyScoreShortageCheckStep(BaseContext context) : base(context)
        {
            _context.Score.OnStudyScoreChanged += AskForCheck;
        }
        protected override bool TryHandle(ref double probability)
        {
            if (_context.Score.StudyScore <= MinScore)
            {
                return false;
            }

            probability = DeductionProbability;
            return true;
        }
        public override ICheckStep Clone()
        {
            return new StudyScoreShortageCheckStep(_context)
            {
                NextStep = _nextStep.Clone(),
                DeductionProbability = DeductionProbability,
                MinScore = MinScore
            };
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamPage : ActionPage<ExamButton>
    {
        public virtual ExamPageType Type { get; set; }

        public void Act(double probability)
        {
            foreach(var button in Buttons)
            {
                button.SetDeductionProbability(probability);
            }
        }
        public override Page Clone()
        {
            var page = new ExamPage
            {
                Title = Title,
                Description = Description,
                Type = Type
            };
            foreach (var button in Buttons)
            {
                page.AddButton(button);
            }
            return page;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamSuccessPage : ExamPage
    {
        public override ExamPageType Type
        {
            get
            {
                return ExamPageType.Success;
            }
        }
        public override Page Clone()
        {
            var page = new ExamSuccessPage
            {
                Title = Title,
                Description = Description,
                Type = ExamPageType.Success
            };
            foreach (var button in Buttons)
            {
                page.AddButton(button);
            }
            return page;
        }
    }
}

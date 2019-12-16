using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class SimilarPageExam: ExamPage
    {
        public SimilarPageExam(INumberGenerator generator, ExamPage nextPage, string leftTitle = "", 
            string rightTitle = "", double leftCoef = 0, double rightCoef = 0)
        {
            Buttons.Add(new ExamButton(generator)
            {
                Title = leftTitle,
                NextPage = nextPage,
                DeductionCoefficient = leftCoef
            });
            Buttons.Add(new ExamButton(generator)
            {
                Title = rightTitle,
                NextPage = nextPage,
                DeductionCoefficient = rightCoef
            });
        }
        public SimilarPageExam(ExamPage nextPage, ExamButton leftButton, ExamButton rightButton)
        {
            LeftButton = leftButton;
            RightButton = rightButton;
            leftButton.NextPage = nextPage;
            rightButton.NextPage = nextPage;
        }
    }
}

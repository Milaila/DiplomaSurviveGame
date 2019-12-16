using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class SimilarPageExam: ExamPage
    {
        public SimilarPageExam(INumberGenerator generator, ExamPage nextPage, Button button, double leftCoef = 0, double rightCoef = 0)
        {
            Buttons.Add(new ExamButton(button, generator)
            {
                NextPage = nextPage,
                DeductionCoefficient = leftCoef
            });
            Buttons.Add(new ExamButton(button, generator)
            {
                NextPage = nextPage,
                DeductionCoefficient = rightCoef
            });
        }
    }
}

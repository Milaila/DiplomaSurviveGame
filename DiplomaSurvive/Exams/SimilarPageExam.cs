using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    [Serializable]
    public class SimilarPageExam: ExamPage
    {
        protected ExamPage _nextPage;
        public ExamPage NextPage
        {
            get { return _nextPage; }
            set
            {
                _nextPage = value;
                if (LeftButton != null)
                {
                    LeftButton.NextPage = value;
                }
                if (RightButton != null)
                {
                    RightButton.NextPage = value;
                }
            }
        }
        public double Probability
        {
            set
            {
                SetProbability(value);
            }
        }
        public SimilarPageExam(string title = "", string leftTitle = "", string rightTitle = "", double leftCoef = 0, 
            double rightCoef = 0, ExamPage nextPage = null, INumberGenerator generator = null)
        {
            Title = title;
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
        public SimilarPageExam(ExamButton leftButton, ExamButton rightButton, ExamPage nextPage = null)
        {
            LeftButton = leftButton;
            RightButton = rightButton;
            leftButton.NextPage = nextPage;
            rightButton.NextPage = nextPage;
        }
        public SimilarPageExam(List<SimilarPageExam> pages)
        {
            SimilarPageExam lastPage = this;
            foreach (SimilarPageExam page in pages)
            {
                lastPage.NextPage = page;
                lastPage = page;
            }
        }
    }
}

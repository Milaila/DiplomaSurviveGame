using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamButton: Button<ExamPage>
    {
        public double CurrProbability { get; protected set; } = 1;
        public double DeductionCoefficient { get; set; } = 1;
        public ExamPage NextPage { get; set; }
        public ExamFailPage FailPage { get; set; } = new ExamFailPage();
        public ExamSuccessPage SuccessPage { get; set; } = new ExamSuccessPage();
        public INumberGenerator NumberGenerator { get; set; } = new DefaultNumberGenerator();

        public void SetDeductionProbability(double probability)
        {
            CurrProbability = probability * DeductionCoefficient;
        }
        public override ExamPage OnClickFunc (BaseContext context = null)
        {
            base.OnClickFunc(context);
            if (NextPage != null)
            {
                NextPage.Act(CurrProbability);
                return NextPage;
            }

            if (NumberGenerator.NextDouble01() < CurrProbability)
            {
                return SuccessPage;
            }

            return FailPage;
        }
        public override Button Clone()
        {
            return new ExamButton
            {
                Title = Title,
                CurrProbability = CurrProbability,
                DeductionCoefficient = DeductionCoefficient,
                NextPage = NextPage.Clone() as ExamPage,
                NumberGenerator = NumberGenerator,
                SuccessPage = SuccessPage.Clone() as ExamSuccessPage,
                FailPage = FailPage.Clone() as ExamFailPage,
            };
        }
    }
}

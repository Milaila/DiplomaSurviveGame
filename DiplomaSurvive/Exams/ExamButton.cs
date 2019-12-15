using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamButton: Button<ExamPage>, ICloneable<ExamButton>
    {
        public double CurrProbability { get; protected set; } = 1;
        public double DeductionCoefficient { get; set; } = 1;
        public ExamPage NextPage { get; set; }
        public ExamFailPage FailPage { get; set; } = new ExamFailPage();
        public ExamSuccessPage SuccessPage { get; set; } = new ExamSuccessPage();
        public INumberGenerator NumberGenerator { get; set; } = new DefaultNumberGenerator();
        protected ICloneable<ExamPage> CloneableNextPage
        {
            get
            {
                return NextPage;
            }
        }
        protected ICloneable<ExamFailPage> CloneableFailPage
        {
            get
            {
                return FailPage;
            }
        }
        protected ICloneable<ExamSuccessPage> CloneableSuccessPage
        {
            get
            {
                return SuccessPage;
            }
        }

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

        ExamButton ICloneable<ExamButton>.Clone()
        {
            return new ExamButton
            {
                Title = Title,
                CurrProbability = CurrProbability,
                DeductionCoefficient = DeductionCoefficient,
                NextPage = CloneableNextPage.Clone(),
                NumberGenerator = NumberGenerator,
                SuccessPage = CloneableSuccessPage.Clone(),
                FailPage = CloneableFailPage.Clone(),
            };
        }
    }
}

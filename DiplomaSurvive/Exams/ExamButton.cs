using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamButton: Button<ExamPage>, ICloneable<ExamButton>
    {
        protected ExamPage _nextPage;
        protected ExamSuccessPage _successPage;
        protected ExamFailPage _failPage;
        public double CurrProbability { get; protected set; } = 1;
        public double DeductionCoefficient { get; set; } = 1;
        public ExamPage NextPage
        {
            get { return _nextPage; }
            set { _nextPage = (value as ICloneable<ExamPage>).Clone(); }
        }
        public ExamFailPage FailPage
        {
            get { return _failPage; }
            set { _failPage = (value as ICloneable<ExamFailPage>).Clone(); }
        }
        public ExamSuccessPage SuccessPage
        {
            get { return _successPage; }
            set { _successPage = (value as ICloneable<ExamSuccessPage>).Clone(); }
        }
        public INumberGenerator NumberGenerator { get; set; } = new DefaultNumberGenerator();
        protected ExamPage NextPageClone
        {
            get
            {
                ICloneable<ExamPage> cloneable = NextPage;
                return cloneable.Clone();
            }
        }
        protected ExamFailPage FailPageClone
        {
            get
            {
                ICloneable<ExamFailPage> cloneable = FailPage;
                return cloneable.Clone();
            }
        }
        protected ExamSuccessPage SuccessPageClone
        {
            get
            {
                ICloneable<ExamSuccessPage> cloneable = SuccessPage;
                return cloneable.Clone();
            }
        }

        public ExamButton()
        {
            _failPage = new ExamFailPage();
            _successPage = new ExamSuccessPage();
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
                NextPage = NextPageClone,
                NumberGenerator = NumberGenerator,
                SuccessPage = SuccessPageClone,
                FailPage = FailPageClone,
            };
        }
    }
}

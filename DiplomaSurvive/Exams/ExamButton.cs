using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamButton: Button<ExamPage>, ICloneable<ExamButton>
    {
        protected INumberGenerator _numberGenerator;
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

        public ExamButton(INumberGenerator generator)
        {
            _failPage = new ExamFailPage();
            _successPage = new ExamSuccessPage();
            _numberGenerator = generator ?? new DefaultNumberGenerator();
        }
        public ExamButton(Button button, INumberGenerator generator)
            : this(generator)
        {
            Title = button.Title;
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

            if (_numberGenerator.NextDouble01() < CurrProbability)
            {
                return SuccessPage;
            }

            return FailPage;
        }
        ExamButton ICloneable<ExamButton>.Clone()
        {
            return new ExamButton(_numberGenerator)
            {
                Title = Title,
                CurrProbability = CurrProbability,
                DeductionCoefficient = DeductionCoefficient,
                NextPage = NextPageClone,
                SuccessPage = SuccessPageClone,
                FailPage = FailPageClone,
            };
        }
    }
}

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
        public double CurrProbability { get; protected set; } = 1;
        public double DeductionCoefficient { get; set; } = 1;
        public ExamPage NextPage
        {
            get { return _nextPage; }
            set { _nextPage = (value as ICloneable<ExamPage>).Clone(); }
        }
        public ExamFailPage FailPage { get; set; }
        public ExamSuccessPage SuccessPage { get; set; }
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

        public ExamButton(INumberGenerator generator = null)
        {
            _numberGenerator = generator ?? new DefaultNumberGenerator();
        }
        public ExamButton(string title, double deductionCoef, INumberGenerator generator = null)
            : this(generator)
        {
            Title = title;
            DeductionCoefficient = deductionCoef;
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
                NextPage.SetPosibility(CurrProbability);
                return NextPage;
            }

            if (_numberGenerator.NextDouble01() < CurrProbability)
            {
                SuccessPage = SuccessPage ?? new ExamSuccessPage();
                return SuccessPage;
            }

            FailPage = FailPage ?? new ExamFailPage();
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

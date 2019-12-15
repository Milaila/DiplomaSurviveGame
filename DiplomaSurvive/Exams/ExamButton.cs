using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class ExamButton: Button<Tuple<double, ExamPage>>
    {
        protected double _currProbability;
        public double DeductionCoefficient { get; set; }
        public ExamPage NextPage { get; set; }
        public void SetDeductionProbability(double probability)
        {
            _currProbability = probability * DeductionCoefficient;
        }

        public override Tuple<double, ExamPage> OnClick (BaseContext context = null)
        {
            base.OnClick(context);
            NextPage.Act(_currProbability);
            return new Tuple<double, ExamPage>(_currProbability, NextPage);
        }
    }
}

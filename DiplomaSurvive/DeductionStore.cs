using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class DeductionStore : IDeductionStore
    {
        private readonly List<Deduction> _deductions;
        private readonly INumberGenerator _generator;

        public DeductionStore(ICollection<Deduction> deductions, INumberGenerator generator = null)
        {
            _deductions = deductions.ToList() ?? throw new ArgumentNullException();
            _generator = generator ?? new DefaultNumberGenerator();
        }

        public Deduction GetDeduction(DeductionType type, int? level = null)
        {
            var deductions = _deductions.Where(d => d.Type == type);
            if (level.HasValue)
            {
                deductions = deductions.Where(d => d.Level == level || d.Level <= 0);
            }

            int? index = _generator.IndexByCoefficients(deductions.Select(x => x.Coefficient).ToList());

            return index == null 
                ? null 
                : deductions.ToList()[index.Value];
        }
    }
}

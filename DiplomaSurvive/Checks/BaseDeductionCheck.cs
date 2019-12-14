using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class BaseDeductionCheck : IDeductionCheck
    {
        protected BaseContext _context;
        protected List<BaseCheck> _checks;
        protected IDeductionStore _deductionStore;

        public BaseDeductionCheck (BaseContext context, ICollection<BaseCheck> checks, IDeductionStore deductionStore)
        {
            _context = context ?? throw new ArgumentNullException("Context must be not null");
            _checks = checks?.ToList() ?? new List<BaseCheck>();
            _checks.OrderBy(x => x.Priority);
            _deductionStore = deductionStore ?? throw new ArgumentNullException("Deduction store must be not null");
        }

        public Deduction CheckForDeduction()
        {
            var currChecks = _checks.Where(check => check.IsDirty);
            List<double> probabilities
            foreach(var check in currChecks)
            {
                
            }

        }
    }

}

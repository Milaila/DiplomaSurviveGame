using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PlayEventStore : BaseStore<PlayEvent>
    {
        public PlayEventStore(ICollection<PlayEvent> events = null, INumberGenerator numberGenerator = null)
            : base(events, numberGenerator)
        { }

        public override PlayEvent Get(BaseContext context = null)
        {
            var availableEl = GetAll().Where(el => el.IsAvailable(context)).ToList();
            if (availableEl.Count == 0)
            {
                return null;
            }
            int num = _numberGen.Next(availableEl.Count);
            return _elements[num];
        }
       
    }
}

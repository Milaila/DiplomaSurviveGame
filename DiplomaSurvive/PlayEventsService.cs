using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PlayEventsService : IPlayEventsService
    {
        private readonly BaseContext _context;
        private readonly INumberDistribution _generator;
        public double NextTime { get; } = 0;

        public PlayEventsService(BaseContext context, INumberDistribution generator)
        {
            _context = context;
            _generator = generator;
        }

        public void GenerateNextTime()
        {
            throw new NotImplementedException();
        }

        public PlayEvent GetEvent()
        {
            throw new NotImplementedException();
        }
    }
}

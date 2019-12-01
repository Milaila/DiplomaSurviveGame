using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public abstract class DTO
    {
        public int Id { get; set; }

        public DTO()
        {
            Id = GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public interface IExamService
    {
        IExam GetSession(int? level = null);
        IExam GetEIT(int? level = null);
    }
}

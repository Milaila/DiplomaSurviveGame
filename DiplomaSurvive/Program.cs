using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Program
    {
        static void Main(string[] args)
        {
            BaseContext context = new BaseContext()
            {
                Score = new ScoreContext()
                {
                    PersonalLifeScore = 10,
                },
            };

            BaseCheck checkService = new BaseCheck()
            {
                CheckChain = new PersonalLifeScoreDefaultShortageCheckStep(context)
                {
                    DeductionProbability = 0.8,
                },
                DeductionType = DeductionType.Undefined
            };
            Console.WriteLine(checkService.IsDirty);
            Console.WriteLine(checkService.Check());
            Console.WriteLine(checkService.IsDirty);
            context.Score.MinPersonalLifeScore = 8;
            Console.WriteLine(checkService.IsDirty);
            Console.WriteLine(checkService.Check());
            Console.WriteLine(checkService.IsDirty);
            context.Score.PersonalLifeScore = 7;
            Console.WriteLine(checkService.IsDirty);
            Console.WriteLine(checkService.Check());
            Console.ReadKey();
        }
    }
}

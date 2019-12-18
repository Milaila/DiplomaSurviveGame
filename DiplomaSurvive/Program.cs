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
                    PersonalLifeScore = 50,
                }
            };
            PersonalLifeScoreShortageCheckStep step = new PersonalLifeScoreShortageCheckStep(context)
            {
                MinScore = 100,
            };
            ICheckStep stepI = step;
            ICheck check = new BaseCheck
            {
                CheckChain = stepI.ShallowCopy() as ICheckStep
            };
            Console.WriteLine("initial  " + check.Check());
            step.MinScore = 20;
            Console.WriteLine("step.MinScore = 20;  " + check.Check());
            context.Score.PersonalLifeScore = 120;
            Console.WriteLine("PersonalLifeScore = 120;  " + check.Check());
            context.Score.PersonalLifeScore = 10;
            Console.WriteLine("PersonalLifeScore = 10;  " + check.Check());

            Console.ReadKey();
        }

        public static void Check1()
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class A
    {
        public int Num { get; set; } = 1;

        public virtual A Clone1()
        {
            return new A
            {
                Num = Num
            };
        }
        public virtual A Clone2()
        {
            return Clone1();
        }
        public virtual A Clone3()
        {
            return Clone1();
        }
    }
    public class C : A
    {
        public string Str { get; set; } = "cc";
        public void Smart()
        {

        }
    }
    public class B : C
    {
        public string Type { get; set; } = "s";

        //public override A Clone1()
        //{
        //    A b1 = (B)base.Clone1();
        //    b1.Type = Type;
        //    return b1;
        //    //return base.Clone1();
        //}
        public override A Clone2()
        {
            return new B
            {
                Num = Num,
                Type = Type,
                Str = Str
            };
        }
        public override A Clone3()
        {
            return (A) new B
            {
                Num = Num,
                Type = Type,
                Str = Str
            };
        }
        public virtual B Clone5()
        {
            return new B
            {
                Num = Num,
                Type = Type,
                Str = Str
            };
        }
        //public virtual B Clone6()
        //{
        //    //return (B) base.Clone1();
        //}
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //Check1();
            A a1 = new A
            {
                Num = 5
            };
            C b1 = new B
            {
                Num = 3,
                Type = "s3"
            };
            B b2 = new B
            {
                Num = 4,
                Type = "s4"
            };
            C c1 = (B)b1.Clone1();
            Console.WriteLine("A a1 = new A");
            Console.WriteLine(a1.Clone1().Num);
            Console.WriteLine(a1.Clone2().Num);
            Console.WriteLine(a1.Clone3().Num);
            Console.WriteLine("A b1 = new B");
            Console.WriteLine(b1.Clone1().Num + ((A)b1.Clone1()).Num);
            Console.WriteLine(b1.Clone2().Num + ((B)b1.Clone1()).Str);
            Console.WriteLine(b1.Clone3().Num + ((B)b1.Clone1()).Str);
            Console.WriteLine("B b2 = new B");
            Console.WriteLine(b2.Clone1().Num + ((B)b2.Clone1()).Str);
            Console.WriteLine(b2.Clone2().Num + ((B)b2.Clone2()).Str);
            Console.WriteLine(b2.Clone3().Num + ((B)b2.Clone3()).Str);
            Console.WriteLine(b2.Clone5().Num + b2.Clone5().Type);
            //Console.WriteLine(b2.Clone6().Num + b2.Clone6().Type);

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

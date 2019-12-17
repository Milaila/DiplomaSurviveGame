using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Play
    {
        protected INumberGenerator _numberGenerator;
        public IStore<IExam> ExamStore { get; protected set; }

        public Play(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }
        public void InitExamStore()
        {

            var exam1 = new List<SimilarPageExam>()
            {
                new SimilarPageExam(Subjects.CHOOSE_SUBJECT, Subjects.ALGEBRA, Subjects.CHEMISTRY, 1.15, 0.9) { Posibility = 0.5 },
                new SimilarPageExam(Questions.FROW_WHAT_BEGIN, Answers.THEORETICAL_TASKS, Answers.PRACTICAL_TASKS, 1, 0.98),
                new SimilarPageExam(Questions.TRY_TO_WRITE_OFF, Answers.YES, Answers.NO, 0.5, 1.5),
            };
            ExamStore = new BaseStore<IExam>
            {
                new ExamTree()
                {
                    RootPage = new SimilarPageExam(exam1),
                    Type = ExamType.EIT,
                }
            };
        }
    }

    public static class Questions
    {
        public const string FROW_WHAT_BEGIN = "С чего вы начнете?";
        public const string TRY_TO_WRITE_OFF = "Попробовать списать?";
        public const string CHOOSE_SUBJECT = "Выберите предмет";
        //public const string  = "";
    }
    public static class Answers
    {
        public const string THEORETICAL_TASKS = "Теоретические вопросы";
        public const string PRACTICAL_TASKS = "Задачи";
        public const string THEORY = "Теория";
        public const string PRACTICE = "Практика";
        public const string NO = "нет";
        public const string YES = "да";
        //public const string  = "";
    }
    public static class Subjects
    {
        public const string CHOOSE_SUBJECT = "Выберите предмет";
        public const string ENGLISH = "Английский";
        public const string MATH = "Математика";
        public const string CHEMISTRY = "Химия";
        public const string HISTORY = "История";
        public const string LITERATURE = "Литература";
        public const string GEOMETRY = "Геометрия";
        public const string ALGEBRA = "Алгебра";
        public const string SPANISH = "Испанский";
        public const string DISCRETE_MATH = "Дискретная математика";
        public const string LINEAR_ALGEBRA = "Линейная алгебра";
        public const string COMPUTER_SCIENCE = "Компьютерные науки";
        public const string PHILOSOPHY = "Философия";
        public const string PSYCHOLOGY = "Психология";
        public const string COMPUTER_ENGINEERING = "Компьютерная инженерия";
        public const string CULTUROLOGY = "Культурология";
        public const string PHYSICS = "Физика";
        public const string GAME_DEVELOPMENT = "Разработка игр";
    }
}

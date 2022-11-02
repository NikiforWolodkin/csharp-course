using System;
using System.Collections.Generic;
using System.Text;
using Medallion;

namespace Laba5
{
    public struct Student
    {
        public string Name { get; set; }
        public string Status { get; private set; } = "Обучается";
        public float GPA { get; set; } = 0;

        public Student(string name)
        {
            Name = name;
        }

        public void Expell()
        {
            Status = "Отчислен";
        }
    }

    public static class SessionController
    {
        public static int CountExams(Session session)
        {
            return session.Exams.Count;
        }

        public static int CountExamsWithSpecificAmountOfQuestions(Session session, int amountOfQuestions)
        {
            if (session.Exams != null)
            {
                int count = 0;
                foreach (var exam in session.Exams)
                {
                    if (exam.GetAmountOfQuestions() == amountOfQuestions)
                    {
                        count++;
                    }
                }
                return count;
            }
            return 0;
        }
    }

    public class Session
    {
        public List<Examination.ExaminationChallenge> Exams { get; private set; } =
            new List<Examination.ExaminationChallenge>();
        
        public void AddExam(Examination.ExaminationChallenge exam)
        {
            Exams.Add(exam);
        }

        public void RemoveExam(Examination.ExaminationChallenge exam)
        {
            Exams.Remove(exam);
        }

        public void Start()
        {
            if (Exams != null)
            {
                foreach (var exam in Exams)
                {
                    exam.Start();
                }

                for (int i = 0; i < Exams.Count; i++)
                {
                    Console.WriteLine($"Экзамен {i}: {Exams[i].Status}");
                }
            }
        }

        public void Print()
        {
            if (Exams != null)
            {
                foreach (var exam in Exams)
                {
                    Console.WriteLine(exam.ToString());
                }
                return;
            }
            Console.WriteLine("Сессия пуста");
        }
    }

    public static partial class Examination
    {
        public enum ExamTypes
        {
            Test,
            Exam,
            Final
        }

        private static Question[] s_questionSet = {
            new Question("2+2", "4"),
            new Question("0+2", "2"),
            new Question("2-2", "0"),
            new Question("7+3", "10"),
            new Question("1+1", "2")
        };

        abstract public class ExaminationChallenge
        {
            private int _amountOfQuestions;
            private int _allowedMistakes;
            public string Status = "Ожидает";
            public ExaminationChallenge(int amountOfQuestions, int allowedMistakes)
            {
                _amountOfQuestions = amountOfQuestions;
                _allowedMistakes = allowedMistakes;
            }

            public void Start()
            {
                Questions questions = new Questions();
                for (int i = 0; i < _amountOfQuestions; i++)
                {
                    if (questions.Next() != true)
                    {
                        _allowedMistakes--;
                    }
                    if (_allowedMistakes < 0)
                    {
                        Console.WriteLine("Испытание не пройдено!");
                        Status = "Не пройдено";
                        return;
                    }
                }
                Console.WriteLine("Испытание пройдено!");
                Status = "Пройдено";
            }

            public virtual int GetAmountOfQuestions()
            {
                return _amountOfQuestions;
            }

            public virtual void ShowAmountOfMistakes()
            {
                if (Status == "Ожидает")
                {
                    Console.WriteLine($"Экзамен еще не пройден");
                    return;
                }
                Console.WriteLine($"Совершено {_amountOfQuestions - _allowedMistakes} ошибок");
            }

            public override string ToString()
            {
                return base.ToString() + $" Кол-во вопросов: {_amountOfQuestions}, Состояние: {Status}";
            }
        }

        public class Test : ExaminationChallenge
        {
            public Test(int amountOfQuestions) : base(amountOfQuestions, amountOfQuestions) { }
        }

        public class Exam : ExaminationChallenge
        {
            private const int _allowedMistakes = 1;
            public Exam(int amountOfQuestions) : base(amountOfQuestions, _allowedMistakes) { }

            public virtual void ShowAmountOfMistakes()
            {
                if (Status == "Ожидает")
                {
                    Console.WriteLine($"Экзамен еще не пройден");
                    return;
                }
                Console.WriteLine(_allowedMistakes == 1 ? "Совершено 0 ошибок" : "Совершена 1 ошибка");
            }
        }

        public class Final : ExaminationChallenge
        {
            private const int _allowedMistakes = 0;
            public Final(int amountOfQuestions) : base(amountOfQuestions, _allowedMistakes) { }

            public override void ShowAmountOfMistakes()
            {
                Console.WriteLine($"Ошибки не допускаются для сдачи выпускного экзамена");
            }
        }
    }
}

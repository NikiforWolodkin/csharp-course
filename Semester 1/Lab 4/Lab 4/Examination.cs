using System;
using System.Collections.Generic;
using System.Text;
using Medallion;

namespace Lab_4
{
    public static class Examination
    {
        public class Printer
        {
            public static void IAmPrinting(Object someobj)
            {
                if (someobj is IShowStatus || someobj is Printer)
                {
                    Console.WriteLine(someobj.ToString());
                    Console.WriteLine(someobj.GetType());
                }
            }
        }

        public interface IShowStatus
        {
            void ShowStatus();
        }

        abstract public class ExaminationChallenge
        {
            private int _amountOfQuestions;
            public int _allowedMistakes;
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

            public virtual void ShowAmountOfMistakes()
            {
                Console.WriteLine($"Совершено {_amountOfQuestions - _allowedMistakes} ошибок");
            }

            public abstract void ShowStatus();

            public override string ToString()
            {
                return base.ToString() + $" Кол-во вопросов: {_amountOfQuestions}, Кол-во ошибок: {_allowedMistakes}, Состояние: {Status}";
            }
        }

        public class Test : ExaminationChallenge, IShowStatus
        {
            public Test(int amountOfQuestions) : base(amountOfQuestions, amountOfQuestions) { }

            public virtual void ShowAmountOfMistakes()
            {
                Console.WriteLine(_allowedMistakes == 1 ? "Совершено 0 ошибок" : "Совершено 1 ошибок");
            }

            public override void ShowStatus()
            {
                Console.WriteLine($"{Status}");
            }
        }

        public class Exam : ExaminationChallenge, IShowStatus
        {
            private const int _allowedMistakes = 1;
            public Exam(int amountOfQuestions) : base(amountOfQuestions, _allowedMistakes) { }

            public override void ShowStatus()
            {
                Console.WriteLine($"{Status}");
            }
        }

        public class Final : ExaminationChallenge, IShowStatus
        {
            private const int _allowedMistakes = 0;
            public Final(int amountOfQuestions) : base(amountOfQuestions, _allowedMistakes) { }

            public override void ShowAmountOfMistakes()
            {
                Console.WriteLine($"Ошибки не допускаются для сдачи выпускного экзамена");
            }

            public override void ShowStatus()
            {
                Console.WriteLine($"{Status}");
            }
        }

        sealed private class Questions 
        {
            static Question[] s_questionSet = {
                new Question("2+2", "4"),
                new Question("0+2", "2"),
                new Question("2-2", "0"),
                new Question("7+3", "10"),
                new Question("1+1", "2")
            };
            private Question[] _questions = s_questionSet;
            private int _index = 0;
            public Questions()
            {
                _questions.Shuffle();
            }

            public bool Next()
            {
                Console.WriteLine(_questions[_index].QuestionPrompt);
                if (Console.ReadLine() == _questions[_index].Answer)
                {
                    _index++;
                    return true;
                }
                else
                {
                    _index++;
                    return false;
                }
            }

            class Question
            {
                public string QuestionPrompt;
                public string Answer;
                public Question(string questionPrompt, string answer)
                {
                    QuestionPrompt = questionPrompt;
                    Answer = answer;
                }

                public override string ToString()
                {
                    return base.ToString() + $" Вопрос: {QuestionPrompt}";
                }
            }

            public override string ToString()
            {
                return base.ToString() + $" Вопросов: {_index + 1}";
            }

            public override int GetHashCode()
            {
                string[] questionsString = new string[_questions.Length];
                for (int i = 0; i < _questions.Length; i++)
                {
                    questionsString[i] = _questions[i].QuestionPrompt;
                }
                return String.Join("", questionsString).GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj is Questions)
                {
                    return obj.GetHashCode() == base.GetHashCode();
                }
                return false;
            }
        }
    }
}

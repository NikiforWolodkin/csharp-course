using System;
using System.Collections.Generic;
using System.Text;
using Medallion;

namespace Lab_13
{
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

        [Serializable]
        public class Exam
        {
            public int AmountOfQuestions { get; set; }
            public int AllowedMistakes { get; set; }
            public string Status { get; set; }
            [NonSerialized] private string Student;

            public Exam()
            {
                Status = "Ожидает";
                Student = "Не определен";
            }

            public Exam(int amountOfQuestions, int allowedMistakes)
            {
                Status = "Ожидает";
                AmountOfQuestions = amountOfQuestions;
                AllowedMistakes = allowedMistakes;
                Student = "Не определен";
            }

            public Exam(int amountOfQuestions, int allowedMistakes, string student)
            {
                Status = "Ожидает";
                AmountOfQuestions = amountOfQuestions;
                AllowedMistakes = allowedMistakes;
                Student = student;
            }

            public void Start()
            {
                Questions questions = new Questions();
                for (int i = 0; i < AmountOfQuestions; i++)
                {
                    if (questions.Next() != true)
                    {
                        AllowedMistakes--;
                    }
                    if (AllowedMistakes < 0)
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
                return AmountOfQuestions;
            }

            public virtual void ShowAmountOfMistakes()
            {
                if (Status == "Ожидает")
                {
                    Console.WriteLine($"Экзамен еще не пройден");
                    return;
                }
                Console.WriteLine($"Совершено {AmountOfQuestions - AllowedMistakes} ошибок");
            }

            public override string ToString()
            {
                return base.ToString() + $" {AmountOfQuestions}, {AllowedMistakes}, {Status}, {Student}";
            }
        }
    }
}

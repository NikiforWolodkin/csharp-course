using Medallion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public static partial class Examination
    {
        sealed private class Questions
        {
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

            public override string ToString()
            {
                return base.ToString() + $" Вопросов пройдено: {((_index + 1) != 1 ? (_index + 1) : 0)}";
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

        private class Question
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
    }
}

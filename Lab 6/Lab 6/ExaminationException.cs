using Lab_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class ExaminationArgumentException : ArgumentException
    {
        public int IncorrectValue { get; set; }
        public ExaminationArgumentException(string message, int incorrectValue) : base(message)
        {
            IncorrectValue = incorrectValue;
        }
    }

    public class QuestionArgumentException : ArgumentException
    {
        public int IncorrectValue { get; set; }
        public QuestionArgumentException(string message, int incorrectValue) : base(message)
        {
            IncorrectValue = incorrectValue;
        }
    }

    public class SessionException : Exception
    {
        public Examination.ExaminationChallenge IncorrectExam { get; set; }
        public SessionException(string message, Examination.ExaminationChallenge incorrectExam) : base(message)
        {
            IncorrectExam = incorrectExam;
        }
    }
}

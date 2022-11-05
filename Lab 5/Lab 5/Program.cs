using Lab_5;
using static Laba5.Examination;

Console.WriteLine("Hello World!");

Exam exam1 = new Exam(3);
Test exam2 = new Test(5);
Final exam3 = new Final(4);

Session session = new Session();
session.AddExam(exam1);
session.AddExam(exam2);
session.AddExam(exam3);
session.Print();
session.Start();
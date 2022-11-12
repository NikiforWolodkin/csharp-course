using Lab_5;
using static Lab_5.Examination;

Console.WriteLine("Hello World!");

Exam exam1 = new Exam(3);
Test exam2 = new Test(5);
Final exam3 = new Final(4);

Session session = new Session();
session.AddExam(exam1);
session.AddExam(exam2);
session.AddExam(exam3);
Console.WriteLine(SessionController.CountExams(session));
Console.WriteLine(SessionController.CountExamsWithSpecificAmountOfQuestions(session, 3));
session.Print();
session.Start();

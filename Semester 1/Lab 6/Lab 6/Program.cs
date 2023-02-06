using System.Diagnostics;
using Lab_6;
using static Lab_6.Examination;

Console.WriteLine("Hello World!");

try
{
    Exam exam1 = new Exam(-2);
}
catch
{
    Console.WriteLine("Произошла ошибка!");
}
try
{
    Exam exam2 = new Exam(20);  
}
catch
{
    Console.WriteLine("Произошла ошибка!");
}
try
{
    Exam exam3 = new Exam(3);
    Session session1 = new Session();
    session1.RemoveExam(exam3);
}
catch
{
    Console.WriteLine("Произошла ошибка!");
}
try
{
    Session session2 = null;
    var exams = session2.Exams;
}
catch 
{
    Console.WriteLine("Произошла ошибка!");
}
try
{
    int vaiable1 = 0;
    int variable = 5 / vaiable1;
}
catch
{
    Console.WriteLine("Произошла ошибка!");
}
Console.WriteLine();

try
{
    try
    {
        Exam exam = new Exam(-5);
    }
    catch (ExaminationArgumentException ex)
    {
        Console.WriteLine("Произошла ошибка!");
        Console.WriteLine(ex.Message);
        throw;
    }
}
catch (ExaminationArgumentException ex)
{
    Console.WriteLine(ex.IncorrectValue);
    Console.WriteLine(ex.Source);
    Console.WriteLine(ex.StackTrace);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Выполнение операции прекращено.");
    Debug.Fail("Произошла ошибка");
}


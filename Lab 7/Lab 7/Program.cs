using Lab_7;
using static Lab_7.Examination;

Set<int> set1 = new Set<int>(2, 5, 8, 19);
int[] shuffled1 = set1.Shuffle();
foreach (var item in shuffled1)
{
    Console.WriteLine(item);
}
Set<double> set2 = new Set<double>(4, 14.2, 192.3, 2017.145);
double[] shuffled2 = set2.Shuffle();
foreach (var item in shuffled2)
{
    Console.WriteLine(item);
}
Set<char> set3 = new Set<char>('A', 'B', 'C', 'D');
char[] shuffled3 = set3.Shuffle();
foreach (var item in shuffled3)
{
    Console.WriteLine(item);
}
Console.WriteLine();

set1.Add(5);
set1.Add(6);
set1.Remove(6);
set1.Remove(7);
Console.WriteLine();

Exam exam1 = new Exam(3);
Test exam2 = new Test(5);
Final exam3 = new Final(4);

Session<ExaminationChallenge> session = new Session<ExaminationChallenge>();
session.AddExam(exam1);
session.AddExam(exam2);
session.AddExam(exam3);
session.Print();
Console.WriteLine();

Set<int>.SerializeJSON(set1, @"C:\csharp\set.json");
Set<int> set4 = Set<int>.ReadFromJSON(@"C:\csharp\set.json");
set1.Print();
set4.Print();
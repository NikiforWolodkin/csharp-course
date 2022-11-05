using System;
using Lab_4;

Examination.Exam exam = new Examination.Exam(3);
exam.ShowStatus();
exam.Start();
exam.ShowStatus();
Console.WriteLine("");

Examination.IShowStatus interfacePointer = exam as Examination.IShowStatus;
interfacePointer.ShowStatus();
if (exam is Examination.ExaminationChallenge)
{
    Console.WriteLine("Наследует от абстрактного класса");
}
Console.WriteLine("");

Examination.Test test = new Examination.Test(3);
Examination.Final final = new Examination.Final(3);
Examination.Printer printer = new Examination.Printer();
Object[] array = { exam, test, final, printer};
foreach (var obj in array)
{
    Examination.Printer.IAmPrinting(obj);
}    

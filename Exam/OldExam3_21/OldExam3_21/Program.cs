using ConsoleApp2;

Student student1 = new Student("Andrey", 7, 2, Speciality.Mobile, new int[] { 7, 5, 6 });
Console.WriteLine(student1.GetGrades());

Student student2 = new Student("Dmitry", 7, 2, Speciality.Mobile, new int[] { 6, 5, 10 });
Student student3 = new Student("Evgeny", 7, 2, Speciality.POIT, new int[] { 8, 6, 3 });
Student student4 = new Student("Zhenya", 7, 2, Speciality.POIT, new int[] { 4, 4, 4 });
Student student5 = new Student("Artem", 7, 2, Speciality.ISIT, new int[] { 5, 5, 5 });

Group group7 = new Group(student1, student2, student3, student4, student5);

var specialities = from s in group7.Students
                   group s by s.Speciality;

foreach (var speciality in specialities)
{
    var students = from s in speciality
                   orderby s.ExamGrades.Max()
                   select s;

    Console.WriteLine(students.Last());
}

try
{
    group7.Clean();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    group7.Clean();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

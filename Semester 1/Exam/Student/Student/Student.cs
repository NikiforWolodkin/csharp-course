using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public enum Speciality
    {
        ISIT,
        POIT,
        Mobile
    }

    public interface ICleanable
    {
        void Clean();
    }

    public class Student
    {
        public string Name { get; set; }
        public int Group { get; set; }
        public int Year { get; set; }
        public Speciality Speciality { get; set; }
        public int[] ExamGrades { get; set; }

        public Student()
        {
            Name = "";
            Group = 0;
            Year = 1;
            Speciality = Speciality.ISIT;
            ExamGrades = new int[] { 0, 0, 0 };
        }

        public Student(string name, int group, int year, Speciality speciality, int[] examGrades)
        {
            Name = name;
            Group = group;
            Year = year;
            Speciality = speciality;
            ExamGrades = examGrades;
        }

        public (int, int, int) GetGrades()
        {
            return (
                ExamGrades.Min(),
                ExamGrades.Max(),
                (int)ExamGrades.Average()
            );
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Group : ICleanable
    {
        public List<Student> Students { get; set; }

        public Group(params Student[] students)
        {
            Students = new List<Student>(students);
        }

        public void Clean()
        {
            if (Students.Count == 0)
            {
                throw new Exception("Collection is already empty");
            }

            Students.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person(int id, string name, int age, string email, string phone)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            Phone = phone;
        }
        public static string Check(int id, string name, int age, string email, string phone)
        {
            if (string.IsNullOrEmpty(name) || age == null || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                return "Введенные данные не могут быть пустым";
            }
            if (age < 16 || age > 100)
            {
                return "Возраст от 16 до 100 лет";
            }
            if (!email.Contains("@"))
            {
                return "Почта должна содержать '@'";
            }
            return "";
        }
        public class Student : Person
        {
            private static string id;

            public string Group { get; set; }
            public List<Course> Courses { get; set; }
            public Student(int id, string name, int age, string email, string phone, string group)
                : base(id, name, age, email, phone)
            {
                Courses = new List<Course>();
            }
            public override string GetInfo()
            {
                return "Студент" + id + "nigger";
            }
        }
        public class Teacher : Person
            {
                private static string id;

                public string Group { get; set; }
                public List<Course> Courses { get; set; }
                public Teacher(int id, string name, int age, string email, string phone, string group)
                    : base(id, name, age, email, phone)
                {
                    Courses = new List<Course>();
                }
                public override string GetInfo()
                {
                    return "Teacher" + id + "nigger";
                }
            }
        public class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public Teacher Teacher { get; set; }
            public List<Student> Students { get; set; }

            public Course (int id, string title)
            {
                Id = id;
                Title = title;
                Students = new List<Student>();
            }

            public static string Check(string title)
            {
                if(title == null || title.Length == 0)
                {
                    return "Nigger your string is empty";
                }
                return "";
            }
            public bool Enroll(Student student)
            {
                if (Students.Contains(student))
                {
                    return false;
                }
                Students.Add(student);
                student.Courses.Add(this);
                return true;
            }            
            public void SetTeacher(Teacher teacher)
            {
                Teacher = teacher;
                teacher.Courses = new List<Course>();
            }
            public string GetInfo()
            {
                string teacherName = "Не назначен";
                if (Teacher != null)
                {
                    teacherName = Teacher.Name;
                }
                return Id + Title + teacherName + Students.Count;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args) {

            
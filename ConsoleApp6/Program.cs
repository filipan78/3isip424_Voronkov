using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args) {
            class Student {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public Student(int id, string name, int age, string email, string phone)
            {
                ID = id;
                Name = name;
                Age = age;
                Email = email;
                Phone = phone;
            }
            public static string Check(int id, string name, int age, string email, string phone) {
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
            public Student(int id, string name, int age, string email, string phone, string group)
                : base(id, name, age, email, phone)
            {
                Group = group;
            }
        }
    }
}
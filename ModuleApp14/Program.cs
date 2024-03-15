using System.Diagnostics;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Text;

namespace ModuleApp14;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Student> students = new List<Student>()
        {
            new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
            new Student {Name = "Василиса", Age = 24, Languages = new List<string>{"английский", "французский"}},
            new Student {Name = "Никита", Age = 30, Languages = new List<string>{"английский", "испанский"}},
            new Student {Name = "Лариса", Age = 18, Languages = new List<string>{"испанский", "немецкий"}}
        };

        var selectedStudents = students.SelectMany(s => s.Languages, (s, l) => new { Student = s, Lang = l })
            .Where(s => s.Lang == "немецкий" && s.Student.Age < 30)
            .Select(s => s.Student);

        foreach(var student in selectedStudents)
            Console.WriteLine($"{student.Name} --> {student.Age}");
    }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Languages { get; set; }
}
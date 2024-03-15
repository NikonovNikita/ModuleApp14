using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ModuleApp14;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string[] text = { "Раз два три четыре пять шесть семь восемь девять десять", 
            "Шла Саша по шоссе и сосала сушку"};

        var result = from str in text
                     from word in str.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     select word;

        foreach( var word in result )
            Console.WriteLine(word);
    }
}

class City
{
    public string Name { get; set; }
    public long Population { get; set; }
    public City(string name, long population)
    {
        Name = name;
        Population = population;
    }
}
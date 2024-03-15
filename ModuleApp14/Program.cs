using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ModuleApp14;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var countries = new Dictionary<string, List<City>>();
        
        var russianCities = new List<City>()
        {
            new City("Москва", 11900000),
            new City("Санкт-Петербург", 4991000),
            new City("Волгоград", 1099000),
            new City("Казань", 1169000),
            new City("Севастополь", 449138)
        };

        var belarusCities = new List<City>()
        {
            new City("Минск", 1200000),
            new City("Витебск", 362466),
            new City("Гродно", 368710)
        };

        var americanCities = new List<City>()
        {
            new City("Нью-Йорк", 8399000),
            new City("Вашингтон", 705749),
            new City("Альбукерке", 560218)
        };
        
        countries.TryAdd("Россия", russianCities);
        countries.TryAdd("Беларусь", belarusCities);
        countries.TryAdd("США", americanCities);

        var result = from country in countries
                     from city in country.Value
                     where city.Population > 1000000
                     orderby city.Population descending
                     select city;

        foreach(var city in result)
            Console.WriteLine($"{city.Name} --> {city.Population} человек");
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
namespace TombolaBeansTechTest.Services;

using System.Text.Json;
using TombolaBeansTechTest.Models;

public class CoffeeBeanService
{
    private List<CoffeBeans> _beans;

    public CoffeeBeanService()
    {
        string json = File.ReadAllText("wwwroot/data/coffeeBeans.json");
        _beans = JsonSerializer.Deserialize<List<CoffeBeans>>(json);
    }

    public List<CoffeBeans> GetAllBeans() => _beans;
    public CoffeBeans GetBeanById(int id) => _beans.FirstOrDefault(b => b.Id == id);
    public CoffeBeans GetBeanOfTheDay()
    {
        var random = new Random();
        return _beans[random.Next(_beans.Count)];
    }
}

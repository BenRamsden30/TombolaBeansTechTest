using Microsoft.AspNetCore.Components;
using TombolaBeansTechTest.Models;

namespace TombolaBeansTechTest.Pages;

using System.Text.Json;

public class CoffeeBeanService
{
    private List<CoffeBeans> _beans;
    private static int _lastBeanId = -1; // Stores last selected bean ID

    public CoffeeBeanService()
    {
        string json = File.ReadAllText("wwwroot/data/coffeeBeans.json");
        _beans = JsonSerializer.Deserialize<List<CoffeBeans>>(json);
    }

    public List<CoffeBeans> GetAllBeans() => _beans;

    public CoffeBeans GetBeanById(int id) => _beans.FirstOrDefault(b => b.Id == id);

    public CoffeBeans GetBeanOfTheDay()
    {
        if (_beans == null || _beans.Count == 0)
            return null;

        var random = new Random();
        CoffeBeans selectedBean;

        // Ensure the new bean is different from the last one
        do
        {
            selectedBean = _beans[random.Next(_beans.Count)];
        } while (selectedBean.Id == _lastBeanId);

        // Store the selected bean ID
        _lastBeanId = selectedBean.Id;

        return selectedBean;
    }
}

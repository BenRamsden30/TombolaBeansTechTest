namespace TombolaBeansTechTest.Models;

public class CoffeBeans
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Origin { get; set; }
    public string RoastType { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public bool IsBeanOfTheDay { get; set; }
}
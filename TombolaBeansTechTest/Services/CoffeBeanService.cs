using System.Text.Json;
using TombolaBeansTechTest.Models;

namespace TombolaBeansTechTest.Services
{
    public class CoffeBeanService
    {
        private readonly IWebHostEnvironment _env;
        private List<CoffeBeans> _beans = new();

        public CoffeBeanService(IWebHostEnvironment env)
        {
            _env = env;
            LoadBeansFromJson().Wait(); // Load data on startup
        }

        private async Task LoadBeansFromJson()
        {
            try
            {
                // Ensure correct file path
                string filePath = Path.Combine(_env.WebRootPath, "data", "coffeeBeans.json");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File not found at {filePath}");
                    return;
                }

                string json = await File.ReadAllTextAsync(filePath);
                _beans = JsonSerializer.Deserialize<List<CoffeBeans>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CoffeBeans>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
            }
        }

        public List<CoffeBeans> GetAllBeans() => _beans;
        public CoffeBeans GetBeanById(int id) => _beans.FirstOrDefault(b => b.Id == id);

        public CoffeBeans GetBeanOfTheDay()
        {
            var random = new Random();
            return _beans.Count > 0 ? _beans[random.Next(_beans.Count)] : null;
        }
    }
}
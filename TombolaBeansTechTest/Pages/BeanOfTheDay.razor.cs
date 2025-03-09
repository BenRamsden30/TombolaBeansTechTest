using Microsoft.AspNetCore.Components;
using TombolaBeansTechTest.Models;
using TombolaBeansTechTest.Services;

namespace TombolaBeansTechTest.Pages
{
    public partial class BeanOfTheDay
    {
        // Injecting the CoffeeBeansService
        [Inject] private CoffeBeanService CoffeeBeansService { get; set; }

        // Injecting the NavigationManager for navigation
        [Inject] private NavigationManager NavigationManager { get; set; }

        // The selected CoffeeBean for the "Bean of the Day"
        private CoffeBeans selectedBean;

        // This method is invoked when the component is initialized
        protected void OnInitialized()
        {
            // Get the random "Bean of the Day" and ensure it's not the same as the previous day
            selectedBean = GetBeanOfTheDay();
        }

        // Function to get the "Bean of the Day"
        private CoffeBeans GetBeanOfTheDay()
        {
            var beans = CoffeeBeansService.GetAllBeans(); // Get the list of beans
            var random = new Random();

            // Select a random coffee bean
            var todaysBean = beans[random.Next(beans.Count)];

            return todaysBean;
        }

        // Handler to navigate to more details about the current Bean of the Day
        private void ShowMoreDetails()
        {
            // Navigate to a page showing more details of the current coffee bean
            NavigationManager.NavigateTo($"/coffeebean/{selectedBean.Name}");
        }
    }
}
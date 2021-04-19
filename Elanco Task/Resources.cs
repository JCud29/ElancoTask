using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Elanco_Task.APIRequests;

namespace Elanco_Task
{
    static class Resources
    {
        private const string RESOURCE_URL = "https://engineering-task.elancoapps.com/api/resources";
        private const string RESOURCEDATA_URL = "https://engineering-task.elancoapps.com/api/resources/";

        public static async Task FindByResource(bool sortHighest)
        {
            var data = await GetRequest(RESOURCE_URL);
            var appNames = JsonConvert.DeserializeObject<List<String>>(data);
            var searchName = UserInput(appNames);
            await ReadResourceDetailsAsync(searchName, sortHighest);
        }

        private static async Task ReadResourceDetailsAsync(string searchName, bool sortHighest)
        {
            var data = await GetRequest(RESOURCEDATA_URL + searchName);
            var resourceDetails = JsonConvert.DeserializeObject<List<App>>(data);
            var sortedResources = new List<App>();
            if (sortHighest)
                sortedResources = resourceDetails.OrderByDescending(app => app.Cost).Take(5).ToList();
            else
                sortedResources = resourceDetails.OrderBy(app => app.Cost).Take(5).ToList();
            DisplayData(resourceDetails);
        }

        private static string UserInput(List<string> names)
        {
            while (true)
            {
                Console.WriteLine("Please enter a name of a resource: ");
                var input = Console.ReadLine();
                if (!names.Contains(input))
                    Console.WriteLine("That was invalid, please try again");
                else
                    return input;
            }
        }

        private static void DisplayData(List<App> apps)
        {
            foreach (var app in apps)
            {
                Console.WriteLine($"Instance Id: {app.InstanceId}");
                Console.WriteLine($"Meter Category: {app.MeterCategory}");
                Console.WriteLine($"Resource Group: {app.ResourceGroup}");
                Console.WriteLine($"Resource Location {app.ResourceLocation}");

                Console.WriteLine($"Service Name: {app.ServiceName}");
                Console.WriteLine($"Location: {app.Location}");
                Console.WriteLine($"Consumed Quantity: {app.Location}");
                Console.WriteLine($"Cost: {app.Cost}");
                Console.WriteLine($"Date: {app.Date}");

                Console.WriteLine($"Tags: {app.Tags.AppName}, {app.Tags.Environment}, {app.Tags.BusinessUnit}");
                Console.WriteLine($"Unit Of Measure: {app.UnitOfMeasure}\n");
            }
        }
    }
}

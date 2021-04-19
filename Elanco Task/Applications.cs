using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Elanco_Task.APIRequests;

namespace Elanco_Task
{
    static class Applications
    {
        private const string NAMES_URL = "https://engineering-task.elancoapps.com/api/applications";
        private const string APPDATA_URL = "https://engineering-task.elancoapps.com/api/applications/";

        public static async Task FindByApp(bool sortHighest)
        {
            var data = await GetRequest(NAMES_URL);
            var appNames = JsonConvert.DeserializeObject<List<String>>(data);
            var searchName = UserInput(appNames);
            await ReadAppDetailsAsync(searchName, sortHighest);
        }

        private static async Task ReadAppDetailsAsync(string searchName, bool sortHighest)
        {
            var data = await GetRequest(APPDATA_URL + searchName);
            var appDetails = JsonConvert.DeserializeObject<List<App>>(data);
            var sortedApps = new List<App>();
            if (sortHighest)
                sortedApps = appDetails.OrderByDescending(app => app.Cost).Take(5).ToList();
            else
                sortedApps = appDetails.OrderBy(app => app.Cost).Take(5).ToList();
            DisplayData(sortedApps);
        }

        private static string UserInput(List<string> names)
        {
            while (true)
            {
                Console.WriteLine("Please enter a name of an application: ");
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
                Console.WriteLine($"App Name: {app.Tags.AppName}");
                Console.WriteLine($"Consumed Quantity: {app.Location}");
                Console.WriteLine($"Cost: {app.Cost}");

                Console.WriteLine($"Service Name: {app.ServiceName}");
                Console.WriteLine($"Location: {app.Location}");
                Console.WriteLine($"Date: {app.Date}");

                Console.WriteLine($"Meter Category: {app.MeterCategory}");
                Console.WriteLine($"Resource Group: {app.ResourceGroup}");
                Console.WriteLine($"Resource Location {app.ResourceLocation}");

                Console.WriteLine($"Tags: {app.Tags.Environment}, {app.Tags.BusinessUnit}");
                Console.WriteLine($"Unit Of Measure: {app.UnitOfMeasure}\n");
            }
        }
    }
}

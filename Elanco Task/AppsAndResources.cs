using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Elanco_Task.APIRequests;
using static Elanco_Task.FileWriter;

namespace Elanco_Task
{
    static class AppsAndResources
    {
        private const string URL = "https://engineering-task.elancoapps.com/api/raw";

        public static async Task DisplayLowCost()
        {
            var body = await GetRequest(URL);
            var apps = JsonConvert.DeserializeObject<List<App>>(body);
            var sortedApps = apps.OrderBy(app => app.Cost).Take(5).ToList();
            DisplayData(sortedApps);
            WriteToFile(sortedApps, "apps with the lowest cost");
        }

        public static async Task DisplayHighCost()
        {
            var body = await GetRequest(URL);
            var apps = JsonConvert.DeserializeObject<List<App>>(body);
            var sortedApps = apps.OrderByDescending(app => app.Cost).Take(5).ToList();
            DisplayData(sortedApps);
            WriteToFile(sortedApps, "apps with the highest cost");
        }

        public static async Task AppsByQuantity()
        {
            var body = await GetRequest(URL);
            var apps = JsonConvert.DeserializeObject<List<App>>(body);
            var sortedApps = apps.OrderByDescending(app => app.ConsumedQuantity).Take(5).ToList();
            DisplayData(sortedApps);
            WriteToFile(sortedApps, "apps with the highest consumed quantity");
        }

        private static void DisplayData(List<App> apps)
        {
            foreach (var app in apps)
            {
                Console.WriteLine($"Instance ID: {app.InstanceId}");
                Console.WriteLine($"Consumed Quantity: {app.Location}");
                Console.WriteLine($"Cost: {app.Cost}");

                Console.WriteLine($"Service Name: {app.ServiceName}");
                Console.WriteLine($"Location: {app.Location}");
                Console.WriteLine($"Date: {app.Date}");

                Console.WriteLine($"Meter Category: {app.MeterCategory}");
                Console.WriteLine($"Resource Group: {app.ResourceGroup}");
                Console.WriteLine($"Resource Location {app.ResourceLocation}");

                Console.WriteLine($"Tags: {app.Tags.AppName}, {app.Tags.Environment}, {app.Tags.BusinessUnit}");
                Console.WriteLine($"Unit Of Measure: {app.UnitOfMeasure}\n");
            }
        }
    }
}

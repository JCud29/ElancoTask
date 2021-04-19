using System.Collections.Generic;
using System.IO;

namespace Elanco_Task
{
    class FileWriter
    {
        private const string FILEPATH = "../../../output.txt";
        public static void WriteToFile(List<App> apps, string fileTitle)
        {
            using StreamWriter writer = new(FILEPATH);
            writer.WriteLine("Output of " + fileTitle + "\n\n");
            foreach (var app in apps)
            {
                writer.WriteLine($"Instance ID: {app.InstanceId}");
                writer.WriteLine($"Cost: {app.Cost}");
                writer.WriteLine($"Date: {app.Date}");
                writer.WriteLine($"Meter Category: {app.MeterCategory}");
                writer.WriteLine($"Resource Group: {app.ResourceGroup}");
                writer.WriteLine($"Resource Location {app.ResourceLocation}");
                writer.WriteLine($"Tags: {app.Tags.AppName}, {app.Tags.Environment}, {app.Tags.BusinessUnit}");
                writer.WriteLine($"Unit Of Measure: {app.UnitOfMeasure}");
                writer.WriteLine($"Location: {app.Location}");
                writer.WriteLine($"Service Name: {app.ServiceName}\n\n");
            }
        }
    }
}

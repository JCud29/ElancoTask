using System;
using System.Threading.Tasks;

namespace Elanco_Task
{
    class Program
    {
        static async Task Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please select an option from the menu below:");
                Console.WriteLine("1 - Display apps and resources with the lowest cost");
                Console.WriteLine("2 - Display apps and resources with the highest cost");
                Console.WriteLine("3 - Display apps and resources with the highest consumed quantity");
                Console.WriteLine("4 - Display the lowest cost of a selected app");
                Console.WriteLine("5 - Display the highest cost of a selected app");
                Console.WriteLine("6 - Display the lowest cost of a selected resource");
                Console.WriteLine("7 - Display the highest cost of a selected resource");
                Console.WriteLine("9 - Exit");
                var input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        await AppsAndResources.DisplayLowCost();
                        break;
                    case 2:
                        await AppsAndResources.DisplayHighCost();
                        break;
                    case 3:
                        await AppsAndResources.AppsByQuantity();
                        break;
                    case 4:
                        await Applications.FindByApp(false);
                        break;
                    case 5:
                        await Applications.FindByApp(true);
                        break;
                    case 6:
                        await Resources.FindByResource(false);
                        break;
                    case 7:
                        await Resources.FindByResource(true);
                        break;
                    case 9:
                        exit = true;
                        Console.WriteLine("You have chosen to exit the program");
                        break;
                    default:
                        Console.WriteLine("That was an invalid input, please try again");
                        break;
                }
            }
            
            
            
            
       
            //await new AppsAndResources().DisplayHighCost();
            //await new Applications().FindByName(true);
        }
    }
}

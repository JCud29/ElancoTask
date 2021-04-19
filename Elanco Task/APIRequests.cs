using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Elanco_Task
{
    public static class APIRequests
    {
        public static async Task<string> GetRequest(string url)
        {
            var response = await new HttpClient().GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            Console.WriteLine("A Bad Status Code Was Returned");
            return null;
        }
    }
}

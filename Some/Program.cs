using System;

namespace Some 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://localhost:7185/api/Quize";
            HttpClient client = new HttpClient();   
            var result = client.GetAsync(url+ "/64139737bb6bd92289d70dd6").Result.Content;
            Console.WriteLine(result);
        }
    }
}
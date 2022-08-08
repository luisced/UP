using System.Net;
using Newtonsoft.Json;

namespace getrequest
{
    class Program
    {
        static void Main(string[] args)
        {
            string API_URL = "https://jsonplaceholder.typicode.com/posts?_limit=5";
            var client = new WebClient();
            var json = client.DownloadString(API_URL);
            dynamic posts = JsonConvert.DeserializeObject(json);

            foreach (var post in posts)
            {
                Console.WriteLine(post.id + ": " + post.title);
            }
        }
    }
}




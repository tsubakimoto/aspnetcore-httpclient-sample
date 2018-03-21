using System;
using System.Net.Http;

namespace MyApp.Models
{
    public class DocsService
    {
        public HttpClient Client { get; private set; }

        public DocsService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://docs.microsoft.com/");
            Client = client;
        }
    }
}

using Album.Api.Models;
using System;
using System.Net;

namespace Album.Api.Services
{

    public class GreetingService : ServiceBase
    {
        public string GetName(string name)
        {
            string version = "v2";
            var model = new HelloModel($"Hello {name}");

            //check if null or empty, change value if
            if ( String.IsNullOrEmpty(name ) || String.IsNullOrWhiteSpace(name)) {
                model = new HelloModel("Hello World");
            }

            //return value from model
            return $"{model.Name} - {Dns.GetHostName()} - {version}";
        }


    }
}

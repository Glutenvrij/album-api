using Album.Api.Models;
using System;

namespace Album.Api.Services
{

    public class GreetingService : ServiceBase
    {
        public string GetName(string name)
        {
            if ( String.IsNullOrEmpty(name ) ) {
                var model = new HelloModel("Hello World");
                return model.Name;
            }
            else
            {
                var model = new HelloModel("Hello " + name);
                return model.Name;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Models
{
    public class HelloModel
    {
        public string Name { get; set; }

        public HelloModel(string n)
        {
            this.Name = n;
        }
    }
}

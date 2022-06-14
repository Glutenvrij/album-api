using Album.Api.Services;
using System.Linq;
using System.Net;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Album.Api.Tests
{
    public class HelloTests
    {
        [Theory]
        [InlineData("myname", "Hello myname")]
        [InlineData("my", "Hello my")]
        [InlineData(" ", "Hello World")]
        [InlineData("", "Hello World")]
        [InlineData(null, "Hello World")]
        public void GreetingParamterTest(string name, string expected)
        {
            GreetingService greetingservice = new GreetingService();
            var result = greetingservice.GetName(name);

            Assert.Equal(result, expected + $" - {Dns.GetHostName()} - v2");
        }
    }
}

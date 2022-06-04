using Album.Api.Services;
using NUnit.Framework;
using System;
using Xunit;

namespace Album.Api.Tests
{
    class HelloTests
    {
        [Fact]
        public void GreetingParameterTesting()
        {
            var helloFunction = new GreetingService();
            string value = "";
            var name = helloFunction.GetName(value);

            //name test
            value = "test";
            Assert.Equals("Hello test", name);

            //white space test
            value = " ";
            Assert.Equals("Hello World", name);

            //null value test
            value = null;
            Assert.Equals("Hello World", name);


        }
    }
}

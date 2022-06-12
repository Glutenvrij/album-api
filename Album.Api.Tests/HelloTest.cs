using Album.Api.Services;
using System;
using Xunit;

namespace Album.Api.Tests
{
    public class HelloTests
    {
        [Fact]
        public void GreetingParameterTesting()
        {
            var helloFunction = new GreetingService();


            //no value test
            string value = "";
            var novalue = helloFunction.GetName(value);
            Assert.Equal("Hello World", novalue);

            //empty value test
            value = " ";
            var emptyvalue = helloFunction.GetName(value);
            Assert.Equal("Hello World", emptyvalue);

            //name test
            value = "test";
            var namevalue = helloFunction.GetName(value);
            Assert.Equal("Hello test", namevalue);

            //null value test
            value = null;
            var nullvalue = helloFunction.GetName(value);
            Assert.Equal("Hello World", nullvalue);



        }
    }
}

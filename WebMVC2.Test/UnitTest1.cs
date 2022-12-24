using Microsoft.Extensions.Logging;
using WebMVC2.Controllers;
using Xunit;

namespace WebMVC2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controler = new HomeController(Moq.Mock.Of<ILogger<HomeController>>());
            var result = controler.Index();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1, 1);
        }


        [Fact]
        public void Test3()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(1, 1);
        }
    }
}
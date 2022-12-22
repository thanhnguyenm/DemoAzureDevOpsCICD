using System.Linq;
using System.Threading.Tasks;
using WebApi2.Controllers;
using Xunit;

namespace WebApi2.Test
{
    public class UserControllerShould
    {
        [Fact]
        public async Task GetActionShouldReturnCorrectData()
        {

            var controller = new UserController();
            var rs = await controller.GetUsers(default);

            Assert.NotNull(rs);
            Assert.Equal(3, rs.Count());
        }
    }
}
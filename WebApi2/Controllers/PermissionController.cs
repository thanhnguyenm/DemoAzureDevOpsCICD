using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
        public async Task<IEnumerable<string>> GetUsers(CancellationToken cancellationToken)
        {

            await Task.Delay(100);

            return new List<string>
            {
                "User.All",
                "User.Read",
                "User.Write",
                "Product.All",
                "Product.Read",
                "Product.Write",
            };

        }
    }
}

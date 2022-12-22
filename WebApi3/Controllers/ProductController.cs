using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductModel>))]
        public async Task<IEnumerable<ProductModel>> GetUsers(CancellationToken cancellationToken)
        {

            await Task.Delay(100);
            var hostname = Dns.GetHostName();
            var url = configuration.GetValue<string>("Weburl");
            return new List<ProductModel>
            {
                new ProductModel{ ProductKey = Guid.NewGuid(), ProductName = "Asus laptop", Details = "Azure API Management is made up of an API gateway, a management plane, and a developer portal.", Price = 25500, Quantity = 10, Url = $"{url}/abc" },
                new ProductModel{ ProductKey = Guid.NewGuid(), ProductName = "Msi PC", Details = "All requests from client applications first reach the API gateway, which then forwards them to respective backend services.", Price = 1300, Quantity = 134, Url = $"{url}/abc" },
                new ProductModel{ ProductKey = Guid.NewGuid(), ProductName = "LG Monitor", Details = "The API gateway acts as a facade to the backend services, allowing API providers to abstract API implementations and evolve backend architecture without impacting API consumers. The gateway enables consistent configuration of routing,", Price = 3534, Quantity =53, Url = $"{url}/abc" },
            };

        }

    }
}

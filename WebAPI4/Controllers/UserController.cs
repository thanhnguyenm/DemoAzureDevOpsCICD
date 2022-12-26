using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public async Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken)
        {
            
            await Task.Delay(100);

            return new List<UserModel>
            {
                new UserModel{ UserKey = Guid.NewGuid(), FullName = "Nguyen Minh Thanh", Email = "thanhnm@yopmail.com", Address = "Thong Nhat, Go Vap", City = "Ho Chi Minh" },
                new UserModel{ UserKey = Guid.NewGuid(), FullName = "Nguyen Khoa Danh", Email = "danhnk@yopmail.com", Address = "Pham Van Chieu, Go Vap", City = "Ho Chi Minh" },
                new UserModel{ UserKey = Guid.NewGuid(), FullName = "Ronaldo", Email = "ronaldo@yopmail.com", Address = "Main Street, Alabela", City = "Portugal" },
                new UserModel{ UserKey = Guid.NewGuid(), FullName = "Thien Nhi", Email = "nhithien043@yopmail.com", Address = "Le Van Tho, Go Vap", City = "Ho Chi Minh" },
            };

        }

        [HttpGet("getuserdetail/{guid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public async Task<UserModel> GetUserDetail(Guid guid, CancellationToken cancellationToken)
        {

            await Task.Delay(100);

            return new UserModel { UserKey = guid, FullName = "Nguyen Minh Thanh", Email = "thanhnm@yopmail.com", Address = "Thong Nhat, Go Vap", City = "Ho Chi Minh" };

        }
    }
}

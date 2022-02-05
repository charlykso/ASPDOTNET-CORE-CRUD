using System.Linq;
using blog.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController: ControllerBase
    {
        private readonly BlogContext _blogConext;
        public AdminController(BlogContext blogContext)
        {
            _blogConext = blogContext;
        }
        [Route("get")]
        [HttpGet]
        public IActionResult Get() 
        {
            var admins = _blogConext.Admins.ToList();
            try
            {
                return Ok(admins);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
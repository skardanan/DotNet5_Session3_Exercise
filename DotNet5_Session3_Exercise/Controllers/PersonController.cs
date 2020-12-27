using DotNet5_Session3_Exercise.DB;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNet5_Session3_Exercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        public IActionResult Remove()
        {
            var ctx = new Context();
            var peaple = ctx.People.Where(x => x.Name.Contains("s"));
            ctx.RemoveRange(peaple);
            ctx.SaveChanges();
            return Ok();
        }
    }
}

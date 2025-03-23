using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Mvc;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        [HttpGet("/AllBasicData")]
        public IActionResult AllBasicData()
        {
            return NotFound();
        }

        [HttpPost("/NewStore")]
        public IActionResult NewStore([FromBody]Store store)
        {
            return Ok();
        }
    }
}

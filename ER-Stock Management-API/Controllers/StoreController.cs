using ER_Stock_Management_DAL.Repositories.StoreRepository;
using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class StoreController(IPost Post) : ControllerBase
    {
        [HttpGet("/AllBasicData")]
        public IActionResult AllBasicData()
        {
            return NotFound();
        }

        [HttpPost("/NewStore")]
        public IActionResult NewStore([FromBody]Store store)
        {
            var result = Post.NewStore(store);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.BadRequest)
            {
                return BadRequest();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}

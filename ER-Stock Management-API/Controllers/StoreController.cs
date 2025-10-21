using ER_Stock_Management_DAL.Repositories.StoreRepository;
using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class StoreController(IGet Get, IPost Post, IPut Put, IDelete Delete) : ControllerBase
    {
        [HttpGet("/AllBasicData")]
        public IActionResult AllBasicData()
        {
            var result = Get.AllBasicData();
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/GetStoreDataWithId/{id}")]
        public IActionResult GetStoreDataWithId(string id)
        {
            var result = Get.GetStoreDataWithId(id);
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
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

        [HttpPut("/ModifyStore")]
        public IActionResult ModifyStore(Store store)
        {
            var result = Put.ModifyStore(store);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/DeleteStore/{id}")]
        public IActionResult DeleteStore(string id)
        {
            var result = Delete.DeleteStore(id);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}

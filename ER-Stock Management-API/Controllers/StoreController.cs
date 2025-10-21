using ER_Stock_Management_DAL.Repositories.StoreRepository;
using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        public StoreController(IGet get, IPost post, IPut put, IDelete delete)
        {
            Get = get;
            Post = post;
            Put = put;
            Delete = delete;
        }

        IGet Get;
        IPost Post;
        IPut Put;
        IDelete Delete;

        [HttpGet("/AllBasicData")]
        public IActionResult AllBasicData()
        {
            return Ok("TOIMII!!!");
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

        [HttpPost("/NewStore/{name}/{city}/{address}/{supervisor}/{phone}/{email}")]
        public IActionResult NewStore(string name, string city, string address, string supervisor, string phone, string email)
        {
            var store = new Store(name, city, address, supervisor, phone, email);
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
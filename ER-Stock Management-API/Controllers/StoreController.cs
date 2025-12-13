using ER_Stock_Management_DAL.Repositories.StoreRepository;
using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
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
            var result = Get.AllBasicData();
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/GetStoreDataWithId")]
        public IActionResult GetStoreDataWithId([FromQuery]string id)
        {
            var result = Get.GetStoreDataWithId(id);
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/NewStore")]
        public IActionResult NewStore([FromBody]DtoStore dtoStore)
        {
            var result = Post.NewStore(dtoStore);
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
        public IActionResult ModifyStore([FromBody]DtoStore dtoStore)
        {
            var result = Put.ModifyStore(dtoStore);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.BadRequest)
            {
                return BadRequest();
            }
            else if (result.StatusCode == Status.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/DeleteStore")]
        public IActionResult DeleteStore([FromQuery]string id)
        {
            var result = Delete.DeleteStore(id);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
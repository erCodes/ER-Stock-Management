using ER_Stock_Management_DAL.Repositories.CategoryRepository;
using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(IGet get, IPost post, IPut put, IDelete delete)
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

        [HttpGet("/GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok("TOIMII!!!");
            var result = Get.GetAllCategories();
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

        [HttpPost("/NewCategory{name}")]
        public IActionResult NewCategory(string name)
        {
            var result = Post.NewCategory(name);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/ModifyCategory")]
        public IActionResult ModifyCategory(ModifiedProductCategory category)
        {
            var result = Put.ModifyCategory(category);
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

        [HttpDelete("/DeleteCategory{id}")]
        public IActionResult DeleteCategory(string id)
        {
            var result = Delete.DeleteCategory(id);
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

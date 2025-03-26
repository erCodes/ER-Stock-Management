using ER_Stock_Management_DAL.Repositories.CategoryRepository;
using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class CategoryController(IGet Get, IPost Post) : ControllerBase
    {
        [HttpGet("/GetAllCategories")]
        public IActionResult GetAllCategories()
        {
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

        [HttpPost("/NewCategory")]
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
            return NoContent();
        }
    }
}

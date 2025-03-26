using ER_Stock_Management_DAL.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class CategoryController(IGet Get) : ControllerBase
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
    }
}

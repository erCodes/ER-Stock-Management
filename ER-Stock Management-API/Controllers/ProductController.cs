using ER_Stock_Management_DAL.Repositories.ProductRepository;
using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using static ER_Stock_Management_DataLibrary.Result;


namespace ER_Stock_Management_API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IGet get, IPost post, IPut put, IDelete delete)
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

        [HttpGet("/GetProductWithId")]
        public IActionResult GetProductWithId([FromQuery] string storeId, string productId)
        {
            var result = Get.GetProductWithId(storeId, productId);
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
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

        [HttpPost("/NewProduct")]
        public IActionResult NewProduct([FromBody]DtoProduct product)
        {
            var result = Post.NewProduct(product);
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
    

        [HttpPut("/ModifyProduct")]
        public IActionResult ModifyProduct([FromQuery]string productId, DtoProduct product)
        {
            var result = Put.ModifyProduct(productId, product);
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

        [HttpDelete("/DeleteProduct")]
        public IActionResult DeleteProduct([FromQuery]string storeId, string productId)
        {
            var result = Delete.DeleteProduct(storeId, productId);
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
    }
}

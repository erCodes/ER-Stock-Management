using ER_Stock_Management_DataLibrary;
using Microsoft.EntityFrameworkCore;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.ProductRepository
{
    public interface IGet
    {
        Result GetProductWithId(string storeId, string productId);
    }

    public class Get : IGet
    {
        Context Db = new();

        public Result GetProductWithId(string storeId, string productId)
        {
            try
            {
                Db = new();

                var store = Db.StoresAndProducts
                    .Where(x => x.Id == storeId)
                    .Include(y => y.Products)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.BadRequest);
                }

                var product = store.Products.FirstOrDefault(x => x.Id == productId);

                if (product == null)
                {
                    return new Result(Status.NotFound);
                }

                return new Result(Status.OK, product);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}

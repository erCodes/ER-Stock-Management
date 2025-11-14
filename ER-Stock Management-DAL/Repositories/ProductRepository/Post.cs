using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.ProductRepository
{
    public interface IPost
    {
        Result NewProduct(DtoProduct dto);
    }

    public class Post : IPost
    {
        Context Db = new();

        public Result NewProduct(DtoProduct dto)
        {
            try
            {
                Db = new();

                var store = Db.StoresAndProducts
                    .Where(x => x.Id == dto.StoreId)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.BadRequest);
                }

                var product = new Product(dto)
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.UtcNow
                };

                store.Products.Add(product);
                Db.StoresAndProducts.Update(store);
                Db.SaveChanges();

                return new Result(Status.OK);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}

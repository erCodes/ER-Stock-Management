using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.ProductRepository
{
    public interface IPut
    {
        Result ModifyProduct(string storeId, string productId, DtoProduct dto);
    }

    public class Put : IPut
    {
        Context Db = new();

        public Result ModifyProduct(string storeId, string productId, DtoProduct dto)
        {
            try
            {
                Db = new();

                var store = Db.StoresAndProducts
                    .Where(x => x.Id == storeId)
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

                product.Name = dto.Name;
                product.CategoryIds = dto.CategoryIds.ToList();
                product.InStock = dto.InStock;
                product.Timestamp = DateTime.UtcNow;

                // Tarkista tarvitaanko tätä
                int index = store.Products.FindIndex(x => x.Id == productId);

                store.Products[index] = product;

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

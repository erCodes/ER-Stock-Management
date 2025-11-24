using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using Microsoft.EntityFrameworkCore;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.ProductRepository
{
    public interface IPut
    {
        Result ModifyProduct(DtoProduct dto);
    }

    public class Put : IPut
    {
        Context Db = new();

        public Result ModifyProduct(DtoProduct dto)
        {
            try
            {
                Db = new();

                var store = Db.StoresAndProducts
                    .Where(x => x.Id == dto.StoreId)
                    .Include(y => y.Products)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.BadRequest);
                }

                var product = store.Products.FirstOrDefault(x => x.Id == dto.ProductId);

                if (product == null)
                {
                    return new Result(Status.NotFound);
                }

                product.Name = dto.Name;
                product.CategoryIds = dto.CategoryIds.ToList();
                product.InStock = int.Parse(dto.InStock);
                product.Timestamp = DateTime.UtcNow;

                // Tarkista tarvitaanko tätä
                int index = store.Products.FindIndex(x => x.Id == dto.ProductId);

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

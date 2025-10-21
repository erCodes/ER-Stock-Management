using ER_Stock_Management_DataLibrary;
using Microsoft.EntityFrameworkCore;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IDelete
    {
        Result DeleteStore(string id);
    }

    public class Delete : IDelete
    {
        Context Db = new();

        public Result DeleteStore(string id)
        {
            try
            {
                var store = Db.StoresAndProducts
                    .Where(x => x.Id == id)
                    .Include(y => y.Products)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.NoContent);
                }

                Db.StoresAndProducts.Remove(store);
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

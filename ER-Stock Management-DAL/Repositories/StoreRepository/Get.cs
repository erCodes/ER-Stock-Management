using ER_Stock_Management_DataLibrary;
using Microsoft.EntityFrameworkCore;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IGet
    {
        Result AllBasicData();
        Result GetStoreDataWithId(string id);
    }

    public class Get : IGet
    {
        public Result AllBasicData()
        {
            try
            {
                var stores = db.StoresAndProducts.ToList();
                if (stores.Empty())
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, stores);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }

        public Result GetStoreDataWithId(string id)
        {
            try
            {
                var store = db.StoresAndProducts
                    .Where(x => x.Id == id)
                    .Include(y => y.Products)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, store);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}

using ER_Stock_Management_DAL;
using ER_Stock_Management_DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        Context Db = new();

        public Result AllBasicData()
        {
            try
            {
                Db = new();

                var stores = Db.StoresAndProducts.ToList();
                if (stores.Empty())
                {
                    return new Result(Status.NotFound);
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
                Db = new();

                var store = Db.StoresAndProducts
                    .Where(x => x.Id == id)
                    .Include(y => y.Products)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.NotFound);
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

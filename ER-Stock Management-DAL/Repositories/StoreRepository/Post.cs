using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IPost
    {
        Result NewStore(Store store);
    }

    public class Post : IPost
    {
        Context Db = new();

        public Result NewStore(Store store)
        {
            try
            {
                Db = new();

                store.CleanWhitespaces();
                store.Id = Guid.NewGuid().ToString();
                var existsWithSameName = Db.StoresAndProducts.Where(x => x.Name == store.Name)
                    .FirstOrDefault();

                if (existsWithSameName != null)
                {
                    return new Result(Status.BadRequest);
                }

                var existsWithSameId = Db.StoresAndProducts.Where(x => x.Id == store.Id)
                    .FirstOrDefault();

                if (existsWithSameId != null)
                {
                    return new Result(Status.ServerError);
                }

                Db.StoresAndProducts.Add(store);
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

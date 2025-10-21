using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IPut
    {
        Result ModifyStore(Store modified);
    }

    public class Put : IPut
    {
        Context Db = new();

        public Result ModifyStore(Store modified)
        {
            try
            {
                var exists = Db.StoresAndProducts
                    .Where(x => x.Id == modified.Id)
                    .FirstOrDefault();

                if (exists == null)
                {
                    return new Result(Status.NoContent);
                }

                exists = modified;
                Db.StoresAndProducts.Update(exists);

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

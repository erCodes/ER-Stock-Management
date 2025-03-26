using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IGet
    {
        Result GetAllCategories();
    }

    public class Get(Context db) : IGet
    {
        public Result GetAllCategories()
        {
            try
            {
                var categories = db.ProductCategories.ToList();
                if (categories.Empty())
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, categories);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}

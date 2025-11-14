using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IGet
    {
        Result GetAllCategories();
    }

    public class Get : IGet
    {
        Context Db = new();

        public Result GetAllCategories()
        {
            try
            {
                var categories = Db.ProductCategories.ToList();
                if (categories.Empty())
                {
                    return new Result(Status.NotFound);
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

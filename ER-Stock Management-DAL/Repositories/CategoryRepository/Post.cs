using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IPost
    {
        Result NewCategory(string name);
    }

    public class Post(Context db) : IPost
    {
        public Result NewCategory(string name)
        {
            try
            {
                var newEntry = new ProductCategory(name);
                db.ProductCategories.Add(newEntry);
                db.SaveChanges();

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

using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IPost
    {
        Result NewCategory(string name);
    }

    public class Post : IPost
    {
        Context Db = new();

        public Result NewCategory(string name)
        {
            try
            {
                var newEntry = new ProductCategory(name);
                Db.ProductCategories.Add(newEntry);
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

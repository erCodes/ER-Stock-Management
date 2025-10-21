using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IDelete
    {
        Result DeleteCategory(string id);
    }

    public class Delete : IDelete
    {
        Context Db = new();

        public Result DeleteCategory(string id)
        {
            try
            {
                var toRemove = Db.ProductCategories.FirstOrDefault(x => x.Id == id);
                if (toRemove == null)
                {
                    return new Result(Status.NoContent);
                }

                Db.ProductCategories.Remove(toRemove);

                var productsWithCategoryId = Db.StoresAndProducts
                    .SelectMany(x => x.Products
                    .Where(y => y.CategoryIds
                    .Contains(id)))
                    .ToList();

                foreach (var prod in productsWithCategoryId)
                {
                    prod.CategoryIds.Remove(id);
                }

                Db.UpdateRange(productsWithCategoryId);
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

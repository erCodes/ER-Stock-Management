using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IDelete
    {
        Result DeleteCategory(string id);
    }

    public class Delete(Context db) : IDelete
    {
        public Result DeleteCategory(string id)
        {
            try
            {
                var toRemove = db.ProductCategories.FirstOrDefault(x => x.Id == id);
                if (toRemove == null)
                {
                    return new Result(Status.NoContent);
                }

                db.ProductCategories.Remove(toRemove);

                var productsWithCategoryId = db.StoresAndProducts
                    .SelectMany(x => x.Products
                    .Where(y => y.CategoryIds
                    .Contains(id)))
                    .ToList();

                foreach (var prod in productsWithCategoryId)
                {
                    prod.CategoryIds.Remove(id);
                }

                db.UpdateRange(productsWithCategoryId);
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

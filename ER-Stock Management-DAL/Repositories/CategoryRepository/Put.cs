using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IPut
    {
        Result ModifyCategory(ModifiedProductCategory category);
    }

    public class Put(Context db) : IPut
    {
        public Result ModifyCategory(ModifiedProductCategory category)
        {
            try
            {
                var exists = db.ProductCategories.FirstOrDefault(x => x.Id == category.Original.Id);
                if (exists == null)
                {
                    return new Result(Status.BadRequest);
                }

                exists.Name = category.NewName;

                db.SaveChanges();

                return new Result(Status.OK);
                // Continue here, remember logs!!!
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}

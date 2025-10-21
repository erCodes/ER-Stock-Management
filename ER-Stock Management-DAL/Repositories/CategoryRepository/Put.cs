using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public interface IPut
    {
        Result ModifyCategory(ModifiedProductCategory category);
    }

    public class Put : IPut
    {
        Context Db = new();

        public Result ModifyCategory(ModifiedProductCategory category)
        {
            try
            {
                var exists = Db.ProductCategories.FirstOrDefault(x => x.Id == category.Original.Id);
                if (exists == null)
                {
                    return new Result(Status.BadRequest);
                }

                exists.Name = category.NewName;
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

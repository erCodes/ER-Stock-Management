using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.CategoryRepository
{
    public class Put(Context db)
    {
        public Result ModifyCategory(ModifiedProductCategory category)
        {
			try
			{
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

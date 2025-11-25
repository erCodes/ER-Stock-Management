using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IPost
    {
        Result NewStore(DtoStore dto);
    }

    public class Post : IPost
    {
        Context Db = new();

        public Result NewStore(DtoStore dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name)
                || string.IsNullOrWhiteSpace(dto.City)
                || string.IsNullOrWhiteSpace(dto.Address)
                || string.IsNullOrWhiteSpace(dto.Supervisor)
                || string.IsNullOrWhiteSpace(dto.Phone)
                || string.IsNullOrWhiteSpace(dto.Email))
                {
                    return new Result(Status.BadRequest);
                }

                var store = new Store(dto)
                {
                    Id = Guid.NewGuid().ToString()
                };
                store.CleanWhitespaces();

                Db = new();

                var existsWithSameName = Db.StoresAndProducts.Where(x => x.Name == store.Name)
                    .FirstOrDefault();

                if (existsWithSameName != null)
                {
                    return new Result(Status.BadRequest);
                }

                var existsWithSameId = Db.StoresAndProducts.Where(x => x.Id == store.Id)
                    .FirstOrDefault();

                if (existsWithSameId != null)
                {
                    return new Result(Status.ServerError);
                }

                Db.StoresAndProducts.Add(store);
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

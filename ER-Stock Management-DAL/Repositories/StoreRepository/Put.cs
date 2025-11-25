using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IPut
    {
        Result ModifyStore(DtoStore dto);
    }

    public class Put : IPut
    {
        Context Db = new();

        public Result ModifyStore(DtoStore dto)
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

                Db = new();

                var exists = Db.StoresAndProducts
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefault();

                if (exists == null)
                {
                    return new Result(Status.NotFound);
                }

                exists.Name = dto.Name;
                exists.City = dto.City;
                exists.Address = dto.Address;
                exists.Supervisor = dto.Supervisor;
                exists.Phone = dto.Phone;
                exists.Email = dto.Email;

                Db.StoresAndProducts.Update(exists);
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

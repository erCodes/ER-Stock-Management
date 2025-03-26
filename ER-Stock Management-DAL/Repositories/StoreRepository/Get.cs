﻿using ER_Stock_Management_DataLibrary;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IGet
    {
        Result AllBasicData();
    }

    public class Get(Context db) : IGet
    {
        public Result AllBasicData()
        {
            try
            {
                var stores = db.StoresAndProducts.ToList();
                if (stores.Empty())
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, stores);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}

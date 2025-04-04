﻿using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.LogDataObjects;
using Microsoft.EntityFrameworkCore;
using static ER_Stock_Management_DataLibrary.LogDataObjects.StoreLogData;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_DAL.Repositories.StoreRepository
{
    public interface IDelete
    {
        Result DeleteStore(string id);
    }

    public class Delete(Context db) : IDelete
    {
        public Result DeleteStore(string id)
        {
            try
            {
                var store = db.StoresAndProducts
                    .Where(x => x.Id == id)
                    .Include(y => y.Products)
                    .FirstOrDefault();

                if (store == null)
                {
                    return new Result(Status.NoContent);
                }

                db.StoresAndProducts.Remove(store);

                var logEntry = new StoreLogData(UserAction.Deleted, store);
                db.StoreLogs.Add(logEntry);

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

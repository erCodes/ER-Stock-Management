using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary.LogDataObjects
{
    public class ProductLogData
    {
        public enum UserAction
        {
            Added,
            Modified,
            Deleted
        }

        [Key]
        public required string Id { get; set; }

        public required UserAction Action { get; set; }
        public required string StoreId { get; set; }
        public required string ProductsId { get; set; }
        public required string ProductName { get; set; }
        public required List<ProductCategory> Categories { get; set; }
        public List<ProductCategory>? NewCategories { get; set; }
        public required int OldAmount { get; set; }
        public int? NewAmount { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}

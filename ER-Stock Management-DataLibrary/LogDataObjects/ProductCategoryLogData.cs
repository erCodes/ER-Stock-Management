using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary.LogDataObjects
{
    public class ProductCategoryLogData
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
        public required string OldName { get; set; }
        public string? NewName { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}

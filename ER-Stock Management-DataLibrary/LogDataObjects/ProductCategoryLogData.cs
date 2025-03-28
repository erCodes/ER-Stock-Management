using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary.LogDataObjects
{
    [method: SetsRequiredMembers]
    public class ProductCategoryLogData(ProductCategoryLogData.UserAction action, string oldName, string? newName = null)
    {
        public enum UserAction
        {
            Added,
            Modified,
            Deleted
        }

        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();
        public required UserAction Action { get; set; } = action;
        public required string OldName { get; set; } = oldName;
        public string? NewName { get; set; } = newName;
        public required DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

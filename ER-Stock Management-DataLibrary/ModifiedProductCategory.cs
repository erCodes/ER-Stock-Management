using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary
{
    [method: SetsRequiredMembers]
    public class ModifiedProductCategory(ProductCategory original, string? newName = null)
    {
        public required ProductCategory Original { get; set; } = original;
        public string? NewName { get; set; } = newName;
        public bool Delete { get; set; } = false;
    }
}

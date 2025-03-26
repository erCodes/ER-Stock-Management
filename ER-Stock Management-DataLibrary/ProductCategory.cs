using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary
{
    [method: SetsRequiredMembers]
    public class ProductCategory(string name)
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; } = name;
    }
}

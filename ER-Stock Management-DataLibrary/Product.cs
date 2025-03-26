using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary
{
    public class Product
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required List<string> CategoryIds { get; set; }
        public required int InStock { get; set; }
        public required DateTime QuantityChanged { get; set; }

        public Product()
        {
            CategoryIds ??= [];
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary
{
    public class ProductCategory
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}

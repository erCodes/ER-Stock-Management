using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary.DTO
{
    public class DtoProduct
    {
        public string StoreId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string[] CategoryIds { get; set; }
        public string InStock { get; set; }
    }
}

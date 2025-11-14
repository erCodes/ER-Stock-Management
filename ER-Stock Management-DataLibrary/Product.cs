using ER_Stock_Management_DataLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
        public required DateTime Timestamp { get; set; }

        public Product()
        {
            CategoryIds ??= [];
        }

        [SetsRequiredMembers]
        public Product(DtoProduct dto)
        {
            Name = dto.Name;
            CategoryIds = dto.CategoryIds.ToList();
            InStock = dto.InStock;
        }
    }
}

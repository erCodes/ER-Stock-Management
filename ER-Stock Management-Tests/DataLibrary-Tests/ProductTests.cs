using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_Tests.DataLibrary_Tests
{
    [TestFixture]
    internal class ProductTests
    {
        readonly DtoProduct dto = new()
        {
            ProductId = "1",
            Name = "Name",
            CategoryIds = ["123"],
            InStock = "10"
        };

        [Test]
        public void ConvertsDto()
        {
            var product = new Product(dto);

            Assert.IsNotNull(product);
            Assert.That(product.Id, Is.EqualTo("1"));
            Assert.That(product.Name, Is.EqualTo("Name"));
            Assert.That(product.CategoryIds.Contains("123"));
            Assert.That(product.InStock, Is.EqualTo(10));
        }
    }
}

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
    internal class StoreTests
    {
        readonly DtoStore dto = new()
        {
            Id = "1",
            Name = "Name",
            City = "City",
            Address = "2",
            Supervisor = "3",
            Phone = "4",
            Email = "5",
        };

        [Test]
        public void ConvertsDto()
        {
            var store = new Store(dto);

            Assert.IsNotNull(store);
            Assert.That(store.Id, Is.EqualTo("1"));
            Assert.That(store.Name, Is.EqualTo("Name"));
            Assert.That(store.City, Is.EqualTo("City"));
            Assert.That(store.Address, Is.EqualTo("2"));
            Assert.That(store.Supervisor, Is.EqualTo("3"));
            Assert.That(store.Phone, Is.EqualTo("4"));
            Assert.That(store.Email, Is.EqualTo("5"));
        }
    }
}

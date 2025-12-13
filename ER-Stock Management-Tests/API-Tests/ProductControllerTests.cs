using ER_Stock_Management_API.Controllers;
using ER_Stock_Management_DAL.Repositories.ProductRepository;
using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ER_Stock_Management_DataLibrary.Result;

namespace ER_Stock_Management_Tests.API_Tests
{
    [TestFixture]
    internal class ProductControllerTests
    {
        MockRepository Repository { get; set; }
        Mock<IGet> Get { get; set; }
        Mock<IPost> Post { get; set; }
        Mock<IPut> Put { get; set; }
        Mock<IDelete> Delete { get; set; }

        [SetUp]
        public void Init()
        {
            Repository = new MockRepository(MockBehavior.Strict);
            Get = Repository.Create<IGet>();
            Post = Repository.Create<IPost>();
            Put = Repository.Create<IPut>();
            Delete = Repository.Create<IDelete>();
        }

        private ProductController Create()
            => new(Get.Object, Post.Object, Put.Object, Delete.Object);

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        [TestCase(Status.NotFound)]
        public void GetWithId(Status status)
        {
            Get.Setup(x => x.GetProductWithId("1", "2")).Returns(new Result(status));

            var controller = Create();
            var result = controller.GetProductWithId("1", "2");
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.BadRequest)
            {
                Assert.That(result, Is.TypeOf<BadRequestResult>());
            }
            else if (status == Status.NotFound)
            {
                Assert.That(result, Is.TypeOf<NotFoundResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        [TestCase(Status.NotFound)]
        public void NewProduct(Status status)
        {
            var dto = new DtoProduct() { StoreId = "1" };

            Post.Setup(x => x.NewProduct(dto)).Returns(new Result(status));

            var controller = Create();
            var result = controller.NewProduct(dto);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.BadRequest)
            {
                Assert.That(result, Is.TypeOf<BadRequestResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        [TestCase(Status.NotFound)]
        public void ModifyProduct(Status status)
        {
            var dto = new DtoProduct() { StoreId = "1" };

            Put.Setup(x => x.ModifyProduct(dto)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ModifyProduct(dto);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.BadRequest)
            {
                Assert.That(result, Is.TypeOf<BadRequestResult>());
            }
            else if (status == Status.NotFound)
            {
                Assert.That(result, Is.TypeOf<NotFoundResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        [TestCase(Status.NotFound)]
        public void DeleteProduct(Status status)
        {
            Delete.Setup(x => x.DeleteProduct("1", "2")).Returns(new Result(status));

            var controller = Create();
            var result = controller.DeleteProduct("1", "2");
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.BadRequest)
            {
                Assert.That(result, Is.TypeOf<BadRequestResult>());
            }
            else if (status == Status.NotFound)
            {
                Assert.That(result, Is.TypeOf<NotFoundResult>());
            }
        }
    }
}

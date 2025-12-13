using ER_Stock_Management_API.Controllers;
using ER_Stock_Management_DAL.Repositories.StoreRepository;
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
    internal class StoreControllerTests
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

        private StoreController Create()
            => new(Get.Object, Post.Object, Put.Object, Delete.Object);

        [TestCase(Status.OK)]
        [TestCase(Status.NotFound)]
        public void AllBasicData(Status status)
        {
            Get.Setup(x => x.AllBasicData()).Returns(new Result(status));

            var controller = Create();
            var result = controller.AllBasicData();
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.NotFound)
            {
                Assert.That(result, Is.TypeOf<NotFoundResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.NotFound)]
        public void WithId(Status status)
        {
            Get.Setup(x => x.GetStoreDataWithId("1")).Returns(new Result(status));

            var controller = Create();
            var result = controller.GetStoreDataWithId("1");
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.NotFound)
            {
                Assert.That(result, Is.TypeOf<NotFoundResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        public void NewStore(Status status)
        {
            var dto = new DtoStore() { Id = "1" };
            Post.Setup(x => x.NewStore(dto)).Returns(new Result(status));

            var controller = Create();
            var result = controller.NewStore(dto);
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
        public void ModifyStore(Status status)
        {
            var dto = new DtoStore() { Id = "1" };
            Put.Setup(x => x.ModifyStore(dto)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ModifyStore(dto);
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
        [TestCase(Status.NotFound)]
        public void DeleteStore(Status status)
        {
            Delete.Setup(x => x.DeleteStore("1")).Returns(new Result(status));

            var controller = Create();
            var result = controller.DeleteStore("1");
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.NotFound)
            {
                Assert.That(result, Is.TypeOf<NotFoundResult>());
            }
        }
    }
}

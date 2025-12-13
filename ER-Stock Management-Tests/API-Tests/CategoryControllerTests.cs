using ER_Stock_Management_API.Controllers;
using ER_Stock_Management_DAL.Repositories.CategoryRepository;
using ER_Stock_Management_DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ER_Stock_Management_DataLibrary.Result;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ER_Stock_Management_Tests.API_Tests
{
    [TestFixture]
    internal class CategoryControllerTests
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

        private CategoryController Create()
            => new(Get.Object, Post.Object, Put.Object, Delete.Object);

        [TestCase(Status.OK)]
        [TestCase(Status.NotFound)]
        public void GetAll(Status status)
        {
            Get.Setup(x => x.GetAllCategories()).Returns(new Result(status));

            var controller = Create();
            var result = controller.GetAllCategories();
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
        public void NewCategory(Status status)
        {
            Post.Setup(x => x.NewCategory("New")).Returns(new Result(status));

            var controller = Create();
            var result = controller.NewCategory("New");
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        public void ModifyCategory(Status status)
        {
            var category = new ProductCategory("1");

            Put.Setup(x => x.ModifyCategory(category)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ModifyCategory(category);
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
        [TestCase(Status.NotFound)]
        public void DeleteCategory(Status status)
        {
            Delete.Setup(x => x.DeleteCategory("1")).Returns(new Result(status));

            var controller = Create();
            var result = controller.DeleteCategory("1");
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

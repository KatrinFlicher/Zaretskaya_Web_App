using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Zaretskaya_Html_Intro.Controllers;
using Zaretskaya_Html_Intro.DAL.Data;
using Zaretskaya_Html_Intro.DAL.Entities;

namespace Zaretskaya_Html_Intro.Tests
{
    public class ProductControllerTest
    {
        DbContextOptions<ApplicationDbContext> _options;

        public ProductControllerTest()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
        }

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            //Arrage

            ControllerContext mockContext = getMockContext();

            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }

            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context) { ControllerContext = mockContext };

                //Act
                var result = controller.Index(pageNo: page, group: null) as ViewResult;
                var model = result?.Model as List<Drug>;

                //Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].Id);
            }

            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public void ControllerSelectGroup()
        {
            //Arrange
            ControllerContext mockContext = getMockContext();

            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }

            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context) { ControllerContext = mockContext };

                var comparer = Comparer<Drug>
                    .GetComparer((d1, d2) => d1.Id.Equals(d2.Id));

                //Act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Drug>;

                //Assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Drugs
                    .ToArrayAsync()
                    .GetAwaiter()
                    .GetResult()[2], model[0], comparer);
            }

            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }

        private ControllerContext getMockContext() {
            // контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
                .Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;

            return controllerContext;
        }
    }
}
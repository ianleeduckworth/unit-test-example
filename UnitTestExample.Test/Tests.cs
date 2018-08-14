using Moq;
using NUnit.Framework;
using System;
using System.Net;
using System.Web.Http.Results;
using UnitTestExample.Core.Helpers.TestHelper;
using UnitTestExample.Core.Models;
using UnitTestExample.Web.Controllers;

namespace UnitTestExample.Test
{
    [TestFixture]
    public class Tests
    {
        private TestController _testController;
        private Mock<ITestHelper> _testHelperMock;

        [SetUp]
        public void SetUp()
        {
            _testHelperMock = new Mock<ITestHelper>();
            _testController = new TestController(_testHelperMock.Object);
        }

        [Test]
        public void TestGet_Null()
        {
            const string input = "input";

            //arrange
            _testHelperMock.Setup(x => x.DoWork(input)).Returns(default(TestModel));

            //act
            var result = _testController.GetTest(input);

            //assert
            Assert.IsInstanceOf<NegotiatedContentResult<string>>(result);
            var response = result as NegotiatedContentResult<string>;

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
            Assert.True(response.Content == $"No content found for input: {input}");
        }

        [Test]
        public void TestGet_Exception()
        {
            const string input = "input";
            const string exception = "exception";

            //arrange
            _testHelperMock.Setup(x => x.DoWork(input)).Throws(new Exception(exception));

            //act
            var result = _testController.GetTest(input);

            //assert
            Assert.IsInstanceOf<NegotiatedContentResult<string>>(result);
            var response = result as NegotiatedContentResult<string>;

            Assert.True(response.StatusCode == HttpStatusCode.InternalServerError);
            Assert.True(response.Content == exception);
        }

        [Test]
        public void TestGet_Ok()
        {
            const string input = "input";

            //arrange
            _testHelperMock.Setup(x => x.DoWork(input)).Returns(new TestModel());

            //act
            var result = _testController.GetTest(input);

            //assert
            Assert.IsInstanceOf<OkNegotiatedContentResult<TestModel>>(result);
        }
    }
}

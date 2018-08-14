using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using UnitTestExample.Core.Helpers.TestHelper;
using UnitTestExample.Core.Models;

namespace UnitTestExample.Web.Controllers
{
    /// <summary>
    /// Main entry point for GetTest method; to be used for controller testing
    /// </summary>
    public class TestController : ApiController
    {
        private readonly ITestHelper _testHelper;

        /// <summary>
        /// Constructor to be used either with dependency injection
        /// </summary>
        /// <param name="testHelper"></param>
        public TestController (ITestHelper testHelper)
        {
            _testHelper = testHelper;
        }

        /// <summary>
        /// Returns an object based the input passed in
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IHttpActionResult GetTest(string input)
        {
            try
            {
                TestModel result = _testHelper.DoWork(input);
                if (result == null)
                    return Content(HttpStatusCode.NoContent, $"No content found for input: {input}");

                return Ok(result);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
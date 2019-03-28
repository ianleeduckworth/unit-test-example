using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Core.Models;

namespace UnitTestExample.Core.Helpers.TestHelper
{
    public class TestHelper : ITestHelper
    {
        public TestModel DoWork(string input)
        {
			if (input == null)
				return null;

            return new TestModel
            {
                Output = input
            };
        }
    }
}

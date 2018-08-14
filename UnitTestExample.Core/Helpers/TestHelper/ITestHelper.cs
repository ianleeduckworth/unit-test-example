using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Core.Models;

namespace UnitTestExample.Core.Helpers.TestHelper
{
    public interface ITestHelper
    {
        TestModel DoWork(string input);
    }
}

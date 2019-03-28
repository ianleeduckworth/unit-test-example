using UnitTestExample.Core.Models;

namespace UnitTestExample.Core.Helpers.TestHelper
{
	/// <summary>
	/// TestHelper class.  This class is meant to show a helper layer and provides easy mocking
	/// </summary>
	public class TestHelper : ITestHelper
    {
		/// <summary>
		/// Does an arbitrary task.  In this case, it just parrots back the input string
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
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

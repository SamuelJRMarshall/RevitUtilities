using System;
using Xunit;

namespace GradeBookTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            String name = "hello";
            string name2 = name;
            Assert.Same(name, name2);
        }
    }
}

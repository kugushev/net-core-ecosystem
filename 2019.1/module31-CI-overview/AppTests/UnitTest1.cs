using System;
using Xunit;

namespace AppTests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldBeOk()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldBeFailed()
        {
            Assert.True(false);
        }

    }
}

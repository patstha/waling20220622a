using FluentAssertions;

namespace Waling.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            true.Should().Be(true);
        }
    }
}
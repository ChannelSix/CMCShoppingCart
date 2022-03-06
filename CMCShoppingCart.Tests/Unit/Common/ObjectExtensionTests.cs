using CMCShoppingCart.Common;

namespace CMCShoppingCart.Tests.Unit.Common;

public class ObjectExtensionTests
{
    [Fact]
    public async Task AsTask_ContainsValue()
    {
        // arrange
        var value = new object();
        var task = value.AsTask();

        // act
        var expected = await task;

        // assert
        expected.Should().Be(value);
    }
}


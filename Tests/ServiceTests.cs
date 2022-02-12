using Mvc.Exceptions;
using Mvc.Services;
using Xunit;

namespace Tests;

public class ServiceTests
{
    private readonly Service _service = new Service();

    [Theory]
    [InlineData("[1,1,1]", 1)]
    [InlineData("[1,2,3,4,5,1,1]", 1)]
    [InlineData("[9,3,3,2,1,1,1,2,9,9,9]", 9, 1)]
    [InlineData("[1,1,1,1,3,3,3,3,2,1,2,9,9,9]", 9, 3, 1)]
    public void When_InputIsValid_Should_Return_Array(string inputText, params int[] outputNumbers)
    {
        var result = _service.FindDuplicates(inputText);

        Assert.Equal(outputNumbers, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("[112, he3,2,1,9,9,8]")]
    public void When_InputIsInvalid_Should_Throw(string inputText)
    {
        Assert.Throws<InvalidInputFormatException>(() => _service.FindDuplicates(inputText));
    }
}
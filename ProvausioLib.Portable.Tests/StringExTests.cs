using FluentAssertions;
using ProvausioLib.Portable.Extensions;
using Xunit;

namespace ProvausioLib.Portable.Tests
{
    public class StringExTests
    {
        [Fact]
        public void ToSnakeCaseReturnsAsExpected()
        {
            // arrange
            const string testString = "ThisIsSnakeCase";

            // act
            var result = testString.ToSnakeCase();

            // assert
            result.ShouldBeEquivalentTo("This_Is_Snake_Case");
        }

        [Fact]
        public void ToScreamingSnakeCaseReturnsAsExpected()
        {
            // arrange
            var testString = "ThisIsScreamingSnakeCase";

            // act
            var result = testString.ToScreamingSnakeCase();

            // assert
            result.ShouldBeEquivalentTo("THIS_IS_SCREAMING_SNAKE_CASE");
        }
    }
}

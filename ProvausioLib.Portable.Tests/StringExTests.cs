using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using ProvausioLib.Portable.Extensions;
using Xunit;

namespace ProvausioLib.Portable.Tests
{
    [ExcludeFromCodeCoverage]
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
            const string testString = "ThisIsScreamingSnakeCase";

            // act
            var result = testString.ToScreamingSnakeCase();

            // assert
            result.ShouldBeEquivalentTo("THIS_IS_SCREAMING_SNAKE_CASE");
        }

        [Theory]
        [InlineData("45", 45)]
        [InlineData("2613", 2613)]
        [InlineData("-88", -88)]
        public void TryConvertIntConvertsAsExpected(string stringValue, int intValue)
        {
            // arrange

            // act
            int value;
            var succeeded = stringValue.TryConvert(out value);

            // assert
            succeeded.Should().BeTrue();
            intValue.ShouldBeEquivalentTo(intValue);
        }

        [Theory]
        [InlineData("4.5")]
        [InlineData("26.13")]
        [InlineData("Geoff")]
        public void TryConvertIntFailsReturnsFalse(string stringValue)
        {
            // arrange

            // act
            int value;
            var succeeded = stringValue.TryConvert(out value);

            // assert
            succeeded.Should().BeFalse();
        }

        [Theory]
        [InlineData("4.5", 4.5)]
        [InlineData("261.3", 261.3)]
        [InlineData("-8.8", -8.8)]
        public void TryConvertDecimalConvertsAsExpected(string stringValue, decimal intValue)
        {
            // arrange

            // act
            decimal value;
            var succeeded = stringValue.TryConvert(out value);

            // assert
            succeeded.Should().BeTrue();
            intValue.ShouldBeEquivalentTo(intValue);
        }

        [Theory]
        [InlineData("4.5M")]
        [InlineData("Geoff")]
        [InlineData("4.5M")]
        public void TryConvertDecimalFailsReturnsFalse(string stringValue)
        {
            // arrange

            // act
            decimal value;
            var succeeded = stringValue.TryConvert(out value);

            // assert
            succeeded.Should().BeFalse();
        }

        [Theory]
        [InlineData("4.5", 4.5)]
        [InlineData("261.3", 261.3)]
        [InlineData("-8.8", -8.8)]
        public void CastSucceedsWithDecimal(string stringValue, decimal decimalValue)
        {
            // arrange

            // act
            var value = stringValue.Cast<decimal>();

            // assert
            value.ShouldBeEquivalentTo(decimalValue);
        }

        [Fact]
        public void CastThrowsWithInvalidValue()
        {
            // arrange
            const string stringValue = "HelloWorld";

            // act

            // assert
            var ex = Assert.Throws<FormatException>(() => stringValue.Cast<decimal>());
        }
    }
}

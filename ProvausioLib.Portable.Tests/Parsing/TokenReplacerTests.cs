using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using ProvausioLib.Portable.Parsing;
using Xunit;

namespace ProvausioLib.Portable.Tests.Parsing
{
    [ExcludeFromCodeCoverage]
    public class TokenReplacerTests
    {
        [Theory]
        [InlineData("{{", "}}", "TestToken1", "Token1Replaced")]
        [InlineData("##", "##", "TestToken2", "Token2Replaced")]
        public void TokenReplacerReplacesToken(string openToken, string closeToken, string key, string newValue)
        {
            // arrange
            var token = new ReplacementToken(openToken, closeToken);
            var testSentence = $"This is a test sentence. {token.OpenToken}{key}{token.CloseToken}. With multiple instances of {token.OpenToken}{key}{token.CloseToken}!";
            var expectedResult = $"This is a test sentence. {newValue}. With multiple instances of {newValue}!";
            var testDict = new Dictionary<string, string> {{key, newValue}};

            // act
            var result = TokenReplacer.Process(testSentence, token, testDict);

            // assert
            result.ShouldBeEquivalentTo(expectedResult);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ProvausioLib.Portable.Extensions;
using Xunit;

namespace ProvausioLib.Portable.Tests
{
    public class EnumExTests
    {
        [Fact]
        public void UnMaskFindsAllValues()
        {
            // arrange
            const TestEnums flags = TestEnums.Value2 | TestEnums.Value3;

            // act
            var unmaskedFlags = flags.UnMaskFlags<TestEnums>().ToList();

            // assert
            unmaskedFlags.Should().HaveCount(2);
            unmaskedFlags.Should().Contain(TestEnums.Value2);
            unmaskedFlags.Should().Contain(TestEnums.Value3);
        }

        [Fact]
        public void UnMaskThrowsWhenTypeIsNotEnum()
        {
            // arrange
            const TestEnums flags = TestEnums.Value1 | TestEnums.Value2;

            // act
            
            // assert
            Assert.Throws<ArgumentException>(() => flags.UnMaskFlags<decimal>());
        }

        [Fact]
        public void EnumerableReturnsCount()
        {
            // arrange
            IEnumerable testList = new List<string> {"Hello", "World"};

            // act
            var count = testList.Count();

            // assert
            count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void IsNullOrEmptyReturnsTrueWhenNull()
        {
            // arrange
            List<string> names = null;

            // act
            
            // assert
            names.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyReturnsTrueWhenEmpty()
        {
            // arrange
            var names = new List<string>();

            // act

            // assert
            names.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyReturnsFalseNotNullOrEmpty()
        {
            // arrange
            var names = new List<string> { "Hello", "World"};

            // act

            // assert
            names.IsNullOrEmpty().Should().BeFalse();
        }

        [Flags]
        private enum TestEnums
        {
            Value1 = 1,

            Value2 = 2,

            Value3 = 4,

            Value4 = 8
        }
    }
}

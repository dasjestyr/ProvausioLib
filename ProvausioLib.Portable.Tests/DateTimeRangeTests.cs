using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
// ReSharper disable SuspiciousTypeConversion.Global

namespace ProvausioLib.Portable.Tests
{
    [ExcludeFromCodeCoverage]
    public class DateTimeRangeTests
    {
        [Fact]
        public void InitializesWithNoError()
        {
            // arrange
            var start = DateTime.MinValue;
            var end = DateTime.MaxValue;

            // act
            var range = new DateTimeRange(start, end);

            // assert
            range.Should().NotBeNull();
        }

        [Theory]
        [InlineData(-30, 30)]
        [InlineData(-15, 30)]
        [InlineData(-300, 30)]
        public void RangeIsAccurate(int startOffset, int endOffset)
        {
            // arrange
            var start = DateTime.Now.AddDays(startOffset);
            var end = DateTime.Now.AddDays(endOffset);
            var range = new DateTimeRange(start, end);

            // act
            var testRange = range.Range;

            // assert
            testRange.ShouldBeEquivalentTo(end - start);
        }

        [Theory]
        [InlineData(-30, 30)]
        [InlineData(-15, 30)]
        [InlineData(-300, 30)]
        public void EqualsWrongTypeReturnsFalseInsteadOfException(int startDayOffset, int endDayOffset)
        {
            // arrange
            var range = new DateTimeRange(DateTime.Now.AddDays(startDayOffset), DateTime.Now.AddDays(endDayOffset));

            // act
            var isEqual = range.Equals(34);

            // assert
            isEqual.Should().BeFalse();
        }

        [Fact]
        public void SameRangeReturnsTrue()
        {
            // arrange
            var range1 = new DateTimeRange(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(30));
            var range2 = new DateTimeRange(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(30));

            // act
            var isEqual = range1.Equals(range2);

            // assert
            isEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(-30, 30)]
        [InlineData(-15, 30)]
        [InlineData(-300, 30)]
        public void EqualsUnequalBoxedTypeReturnsFalse(int startDayOffset, int endDayOffset)
        {
            // arrange
            var range = new DateTimeRange(DateTime.Now.AddDays(startDayOffset), DateTime.Now.AddDays(endDayOffset));
            object range2 = new DateTimeRange(DateTime.MinValue, DateTime.MaxValue);

            // act
            var isEqual = range.Equals(range2);

            // assert
            isEqual.Should().BeFalse();
        }

        [Fact]
        public void HashCodeIsAccurate()
        {
            // arrange
            var start = DateTime.Now.AddDays(-30);
            var end = DateTime.Now.AddDays(30);
            var range = new DateTimeRange(start, end);

            // act
            var startHash = start.GetHashCode()*397;
            var endHash = end.GetHashCode();
            var rangeHash = range.GetHashCode();
            var areEqual = rangeHash == (startHash ^ endHash);

            // assert
            areEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(-30, 30)]
        [InlineData(-15, 30)]
        [InlineData(-300, 30)]
        public void OutOfRangeReturnsFalse(int startOffset, int endOffset)
        {
            // arrange
            var testDate = DateTime.MaxValue;
            var start = DateTime.Now.AddDays(startOffset);
            var end = DateTime.Now.AddDays(endOffset);
            var range = new DateTimeRange(start, end);

            // act
            var isInRange = range.InRange(testDate);

            // assert
            isInRange.Should().BeFalse();
        }

        [Theory]
        [InlineData(-30, 30)]
        [InlineData(-15, 30)]
        [InlineData(-300, 30)]
        public void InRangeReturnsTrue(int startOffset, int endOffset)
        {
            // arrange
            var testDate = DateTime.Now;
            var start = DateTime.Now.AddDays(startOffset);
            var end = DateTime.Now.AddDays(endOffset);
            var range = new DateTimeRange(start, end);

            // act
            var isInRange = range.InRange(testDate);

            // assert
            isInRange.Should().BeTrue();
        }

        [Fact]
        public void GetWeekReturnsCorrectRange()
        {
            // arrange
            var dayMember = new DateTime(2016, 1, 17);

            // act
            var range = DateTimeRange.GetWeek(dayMember, DayOfWeek.Monday);

            // assert
            range.StartDate.ShouldBeEquivalentTo(new DateTime(2016, 1, 11));
            range.EndDate.ShouldBeEquivalentTo(new DateTime(2016, 1, 17));
        }

        [Fact]
        public void AddDaysReturnsCorrectRange()
        {
            // arrange
            var startingRange = DateTimeRange.GetWeek(new DateTime(2016, 2, 15), DayOfWeek.Monday);

            // act
            var newRange = startingRange.AddDays(30);

            // assert
            newRange.StartDate.ShouldBeEquivalentTo(new DateTime(2016, 3, 16));
            newRange.EndDate.ShouldBeEquivalentTo(new DateTime(2016, 3, 22));
        }

        [Fact]
        public void AddWeeksReturnsCorrectRangeInCompleteWeeks()
        {
            // arrange
            var startRange = DateTimeRange.GetWeek(new DateTime(2016, 2, 15), DayOfWeek.Monday);

            // act
            var result = startRange.AddWeeks(3, DayOfWeek.Monday);

            // assert
            result.StartDate.ShouldBeEquivalentTo(new DateTime(2016, 3, 7), "Start day should have been march 7");
            result.EndDate.ShouldBeEquivalentTo(new DateTime(2016, 3, 13), "End day should have been march 13");
        }
    }
}

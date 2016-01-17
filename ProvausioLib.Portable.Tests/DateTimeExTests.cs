using System;
using FluentAssertions;
using Xunit;

namespace ProvausioLib.Portable.Tests
{
    public class DateTimeExTests
    {
        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(-6)]
        [InlineData(-10)]
        public void SameDayReturnsTrue(int hourOffset)
        {
            // arrange
            var baseDate = new DateTime(2016, 1, 14, 12, 0, 0);
            var testDate = baseDate.AddHours(hourOffset);

            // act
            var isSameDay = baseDate.IsSameDay(testDate);

            // assert
            isSameDay.Should().BeTrue();
        }

        [Theory]
        [InlineData(12)]
        [InlineData(-13)]
        public void DifferentDayReturnsFalse(int hourOffset)
        {
            // arrange
            var baseDate = new DateTime(2016, 1, 14, 12, 0, 0);
            var testDate = baseDate.AddHours(hourOffset);

            // act
            var isSameDay = baseDate.IsSameDay(testDate);

            // assert
            isSameDay.Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(-1)]
        [InlineData(-50)]
        public void SameDayDifferentYearReturnsFalse(int yearOffset)
        {
            // arrange
            var baseDate = new DateTime(2016, 1, 14, 12, 0, 0);
            var testDate = baseDate.AddYears(yearOffset);

            // act
            var isSameDay = baseDate.IsSameDay(testDate);

            // assert
            isSameDay.Should().BeFalse();
        }

        // TODO: not sure how to get a more dynamic test
        [Fact]
        public void StartOfWeekIsCorrect()
        {
            // arrange
            var baseDate = new DateTime(2016, 1, 17); // sunday
            
            // act
            var startOfWeek = baseDate.StartOfWeek(DayOfWeek.Monday);

            // assert
            startOfWeek.ShouldBeEquivalentTo(new DateTime(2016, 1, 11));
        }
    }
}
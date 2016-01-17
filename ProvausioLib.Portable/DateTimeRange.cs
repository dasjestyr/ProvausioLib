using System;
using ProvausioLib.Portable.Extensions;

namespace ProvausioLib.Portable
{
    public struct DateTimeRange
    {
        public readonly DateTime StartDate;
        public readonly DateTime EndDate;

        public TimeSpan Range => EndDate - StartDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange" /> struct.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        public DateTimeRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Returns whether or not the specified date falls within the range of this instance of <see cref="DateTimeRange"/>
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public bool InRange(DateTime date)
        {
            return
                date >= StartDate
                && date <= EndDate;
        }

        /// <summary>
        /// Returns the week range of the specified date
        /// </summary>
        /// <returns></returns>
        public static DateTimeRange GetWeek(DateTime weekMember, DayOfWeek startDay)
        {
            var start = weekMember.StartOfWeek(startDay);
            var end = start.AddDays(6);
            return new DateTimeRange(start, end);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeRange" /> that adds the specified number of months to the value of this instance's start day. 
        /// This operation returns exact dates and does not constrain to complete weeks.
        /// </summary>
        /// <param name="count">The number of days to add to the start and end dates</param>
        /// <returns></returns>
        public DateTimeRange AddDays(int count)
        {
            var start = StartDate.AddDays(count);
            var end = EndDate.AddDays(count);
            return new DateTimeRange(start, end);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeRange"/> that adds the specified number of weeks to the value of the start day of this instance. 
        /// This operation returns a range that encapsulates the week range of the new start day as if you were calling GetWeek()
        /// </summary>
        /// <param name="count">The number of weeks to add.</param>
        /// <param name="startOfWeek">The start of week.</param>
        /// <returns></returns>
        public DateTimeRange AddWeeks(int count, DayOfWeek startOfWeek)
        {
            var newStartRef = StartDate.AddDays(count * 7);
            var actualStartDay = newStartRef.StartOfWeek(startOfWeek);
            return GetWeek(actualStartDay, startOfWeek);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                var range = (DateTimeRange)obj;
                return Equals(range);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns whether or not the specified <see cref="DateTimeRange"/> is equal to this instance
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(DateTimeRange other)
        {
            return
                StartDate.Equals(other.StartDate)
                && EndDate.Equals(other.EndDate);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (StartDate.GetHashCode() * 397) ^ EndDate.GetHashCode();
            }
        }
    }
}

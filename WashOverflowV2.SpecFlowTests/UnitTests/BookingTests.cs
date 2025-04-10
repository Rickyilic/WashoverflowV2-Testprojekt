using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashOverflowV2.Models;


namespace WashOverflowV2.SpecFlowTests
{
    public class BookingTests
    {
        [Fact]
        public void Booking_Date_ShouldBeInFuture()
        {
            var booking = new Booking { Date = DateTime.Now.AddDays(1) };
            Assert.True(booking.Date > DateTime.Now);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        public void Booking_StationId_ShouldBeValid(int stationId)
        {
            var booking = new Booking { StationId = stationId };
            Assert.True(booking.StationId > 0);
        }
    }
}

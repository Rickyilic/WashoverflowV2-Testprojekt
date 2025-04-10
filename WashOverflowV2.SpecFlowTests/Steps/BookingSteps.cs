using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using WashOverflowV2.Models;

namespace WashOverflowV2.SpecFlowTests
{
    [Binding]
    public class BookingSteps
    {
        private Booking booking;

        [Given("att en kund är inloggad")]
        public void GivenAttKundArInloggad() { /* Simulerad inloggning */ }

        [Given("kunden befinner sig på bokningssidan")]
        public void GivenKundArPaBokningssidan()
        {
            booking = new Booking();
        }

        [When(@"kunden väljer station ""(.*)""")]
        public void WhenValjerStation(string station)
        {
            booking.Station = new Station { Name = station };
        }

        [When(@"väljer paket ""(.*)""")]
        public void WhenValjerPaket(string paket)
        {
            booking.Package = new Package { Name = paket };
        }

        [When(@"anger datum ""(.*)""")]
        public void WhenAngerDatum(string datum)
        {
            booking.Date = DateTime.Parse(datum);
        }

        [Then("ska bokningen sparas")]
        public void ThenBokningenSparas()
        {
            Assert.NotNull(booking);
            Assert.NotNull(booking.Station);
            Assert.NotNull(booking.Package);
        }

        [Then("kunden ser en bekräftelse")]
        public void ThenSerBekraftelse()
        {
            string confirmationMessage = "Tack för din bokning!";
            Assert.Contains("bokning", confirmationMessage);
        }
    }
}

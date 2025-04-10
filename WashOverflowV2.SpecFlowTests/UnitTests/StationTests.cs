using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using WashOverflowV2.Models;



namespace WashOverflowV2.SpecFlowTests
{
    public class StationTests
    {
        [Fact]
        public void Station_ShouldHaveCorrectName()
        {
            // Arrange
            var station = new Station { Id = 1, Name = "Malmö Västra" };

            // Act
            var actualName = station.Name;

            // Assert
            Assert.Equal("Malmö Västra", actualName);
        }
    }
}

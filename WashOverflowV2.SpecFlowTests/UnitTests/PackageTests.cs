using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashOverflowV2.Models;


namespace WashOverflowV2.SpecFlowTests
{
    public class PackageTests
    {
        [Fact]
        public void Package_Name_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            var package = new Package { Name = "Premium" };

            // Act & Assert
            Assert.False(string.IsNullOrEmpty(package.Name));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Package_Name_ShouldFail_WhenNullOrEmpty(string name)
        {
            var package = new Package { Name = name };

            Assert.True(string.IsNullOrEmpty(package.Name));
        }
    }
}

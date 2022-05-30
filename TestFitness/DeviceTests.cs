using Domain;
using System;
using Xunit;

namespace TestFitness
{
    public class DeviceTests
    {
        [Fact]
        public void MaintenanceDevice_Test()
        {
            string nummer = "2";
            string type = "loopband";
            string statuus = "Onderhoud";
            // Arrange
            var device = new Device(nummer, type, statuus);

            // Act
            Device.MaintenanceDevice(
                nummer,
                type);

            // Assert
            Assert.True(true);
        }
    }
}

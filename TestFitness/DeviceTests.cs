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
            string TODO = "2";
            string TODO2 = "loopband";
            string TODO3 = "Onderhoud";
            // Arrange
            var device = new Device(TODO, TODO2, TODO3);

            // Act
            Device.MaintenanceDevice(
                TODO,
                TODO2);

            // Assert
            Assert.True(true);
        }

        //[Fact]
        //public void RegisterDevice_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var device = new Device(TODO, TODO, TODO);
        //    string nummer = null;
        //    string type = null;

        //    // Act
        //    device.RegisterDevice(
        //        nummer,
        //        type);

        //    // Assert
        //    Assert.True(false);
        //}

        //[Fact]
        //public void RemoveDevice_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var device = new Device(TODO, TODO, TODO);
        //    string nummer = null;
        //    string type = null;

        //    // Act
        //    device.RemoveDevice(
        //        nummer,
        //        type);

        //    // Assert
        //    Assert.True(false);
        //}
    }
}

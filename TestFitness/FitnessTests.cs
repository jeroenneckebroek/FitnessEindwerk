using Domain;
using Domain.Contracts;
using Infrastructure;
using System;
using Xunit;

namespace TestFitness
{
    public class FitnessTests
    {
        [Fact]
        public void ControleerDeviceGegevens_Test()
        {
            IDeviceRepository repo = new DeviceRepository();
            
            var fitness = new Fitness(repo);
            string nummer = "7";
            string type = "fiets";

            fitness.ControleerDeviceGegevens(
                nummer,
                type);

            Assert.True(true);
        }

        [Fact]
        public void RegistreerDevice_Test()
        {
            IDeviceRepository repo = new DeviceRepository();

            var fitness = new Fitness(repo);
            string type = "fiets";

            // Act
            fitness.RegistreerDevice(
                type);

            // Assert
            Assert.True(true);
        }

        //[Fact]
        //public void GeefDevices_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var fitness = new Fitness(TODO);

        //    // Act
        //    var result = fitness.GeefDevices();

        //    // Assert
        //    Assert.True(false);
        //}

        //[Fact]
        //public void GeefDevices_StateUnderTest_ExpectedBehavior1()
        //{
        //    // Arrange
        //    var fitness = new Fitness(TODO);
        //    string type = null;

        //    // Act
        //    var result = fitness.GeefDevices(
        //        type);

        //    // Assert
        //    Assert.True(false);
        //}

        //[Fact]
        //public void WijzigDevice_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var fitness = new Fitness(TODO);
        //    string nummer = null;
        //    string type = null;

        //    // Act
        //    fitness.WijzigDevice(
        //        nummer,
        //        type);

        //    // Assert
        //    Assert.True(false);
        //}

        //[Fact]
        //public void VerwijderDevice_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var fitness = new Fitness(TODO);
        //    string nummer = null;
        //    string type = null;

        //    // Act
        //    fitness.VerwijderDevice(
        //        nummer,
        //        type);

        //    // Assert
        //    Assert.True(false);
        //}
    }
}

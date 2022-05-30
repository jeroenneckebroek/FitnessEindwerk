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
    }
}

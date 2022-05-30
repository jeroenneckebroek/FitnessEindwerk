using Domain;
using Domain.Contracts;
using System;
using Xunit;

namespace TestFitness
{
    public class DomeinControllerTests
    {
        [Theory]
        [InlineData("7", "fiets")]
        public void RegistreerDevice_Test(string nummer, string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (!string.IsNullOrEmpty(nummer))
                {
                    
                }
                else
                {
                    throw new ArgumentException($"'{nameof(nummer)}' cannot be null or empty.", nameof(nummer));
                }
            }
            else
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or empty.", nameof(type));
            }
        }

        [Theory]
        [InlineData(null, null)]
        public void GeefDevices_StateUnderTest_ExpectedBehavior(string nummer, string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (!string.IsNullOrEmpty(nummer))
                {

                }
                else
                {
                    throw new ArgumentException($"'{nameof(nummer)}' cannot be null or empty.", nameof(nummer));
                }
            }
            else
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or empty.", nameof(type));
            }
        }
    }
}

using System;
using Xunit;
using Lab.Models;
namespace Lab.Tests
{
    public class UnitTest1
    {
       /// <summary>
        /// Test Unitario para rut sin guion
        /// </summary>
        [Fact]
        public void retornarExcepcionPorGuionVerificador()
        {
            var test = new Persona();
            test.Rut = "19446088-0";

            Exception ex = Assert.Throws<ArgumentException>(() => test.isValidPersona);

            Assert.Equal("RUT INVALIDO", ex.Message);
        }

        
    }
}

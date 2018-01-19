using System;
using Xunit;
using Lab.Models;
/// <summary>
/// Pruebas Unitarias aplicadas para la validacion del RUT de la persona, junto a las reestrinciones del modelo de dominio
/// </summary>
namespace Lab.Tests
{
    public class UnitTest1
    {   

        
           /// <summary>
        /// Test Unitario RUT con DV malo y formato incorrecto
        /// </summary>
        [Theory]
        [InlineData("19.446.088-1")] //
        [InlineData("10.087.571-5")]
        [InlineData("13.688.770-K")]
        [InlineData("15.048.7831")]  
        public void RetornaFalseRutMalFormatoDV(string rut)
        {
            var test = new Persona();
            test.Rut = rut;
            
            bool result = test.isValidPersona();

            Assert.False(result, $"{test.Rut} no cumple con el formato XXXXXXX-X");
        }

        /// <summary>
        /// Test Unitario para Ruts DV valido con formato correcto
        /// </summary>
        [Theory]
        [InlineData("19446088-0")]
        [InlineData("10087571-3")]
        [InlineData("13688770-K")]
        [InlineData("15048783-8")] 

        public void RetornaTrueRutValidos(string rutTest)
        {
            Persona test = new Persona();
            test.Rut = rutTest;
            
            bool result = test.isValidPersona();
           
            Assert.True(result,$"{test.Rut} es un rut valido");
            
            
        }

           /// <summary>
        /// Test Unitario de RUT con DV malo
        /// </summary>
        [Theory]
        [InlineData("19446088-1")] //
        [InlineData("10087571-5")]
        [InlineData("13688770-0")]
        [InlineData("15048783-1")]  
        public void RetornaFalseRutDVmalo(string rut)
        {
            var test = new Persona();
            test.Rut = rut;
            
            bool result = test.isValidPersona();

            Assert.False(result, $"{test.Rut} Tiene DV erroneo");
        }
       


       /// <summary>
        /// Test Unitario para rut sin guion, reenstrincion de dominio
        /// </summary>
        [Fact]
        public void ReturnFalseRutSinGuion()
        {
            Persona test = new Persona();
            test.Rut = "194460880";

           var result = test.isValidPersona();

            Assert.False(result, "Rut DEBE contener guion");
        }

         /// <summary>
        /// Test Unitario para rut con DV malo, reenstrincion de dominio
        /// </summary>
        [Fact]
        public void ReturFalseRutDvMalo()
        {
            Persona test = new Persona();
            test.Rut = "19446088-1";

           var result = test.isValidPersona();

            Assert.False(result, "DV del rut erroneo");
        }

        
        
    }
}

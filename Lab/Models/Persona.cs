using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>
namespace Lab.Models
{

    /// <summary>
    /// Clase que representa a una persona en el Sistema.
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// EL Rut debe tener un DV valido
    /// y cumplir el formato XXXXXXXX-DV
    /// Ejemplo : 19446088-0
    /// </remarks>
    public class Persona
    {   
        public String Rut { get; set; }

        public string Nombre { get; set; }

        public string Paterno { get; set; }

        public string Materno { get; set; }   

        public List<Cotizacion> listCotizaciones {get; set;}

        public Boolean isValidPersona() => validarRut(this.Rut);

        /// <summary>
        /// Metodo que contiene el algoritmo de validacion de RUT, valida DV y que cumpla con el formato
        /// </summary>
        public static Boolean validarRut(String rut)
        {
		    Regex regex = new Regex("^([0-9]+-[0-9K])$");
		    
            string dv = Char.ToString(rut[rut.Length-1]);
    		
            if (!regex.IsMatch(rut))
            {
			    return false;
		    }
            int rutNum = int.Parse(rut.Split('-')[0]);
            string dvCalculado;

            int sum = 0;
		    int factor = 1;
		    while (rutNum != 0) {
		    	factor++;
			    if (factor == 8)
                {
			        factor = 2;
                }
		        sum += (rutNum % 10)*factor;
			    rutNum = rutNum / 10;
		    }
		    sum = 11 - (sum % 11);
		    if (sum == 11)	{
			    dvCalculado="0";
		    } else if (sum==10) {
			    dvCalculado="K";
		    } else {
			    dvCalculado=sum.ToString();
		    }


    		if (dv != dvCalculado) {
			    return false;
		    }
		return true;
        }

    }  
}
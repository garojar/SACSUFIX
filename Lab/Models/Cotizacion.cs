using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>
namespace Lab.Models{
     /// <summary>
    /// Clase que representa a una Cotizacion en el Sistema.
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// </remarks>
    public class Cotizacion
    {
        public int ID { get; set; }

       
        public Persona persona { get; set; }

        public string NombreCliente { get; set; }
        public string Monto { get; set; }
        public DateTime fechaCreacion {get; set;}
        
        public DateTime fechaRevision {get; set;}
        public string Estado { get; set; }

        public string Descripcion {get; set ;} 
        
        [ForeignKey("RUT")]   
        public String RUT {get; set;}
        

    }   
}
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Models{

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
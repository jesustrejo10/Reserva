using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_boletos
{
    public class CModificarBoleto
    {
         public int _id {get; set;}

        public String _primer_nombre {get; set;}

        public String _primer_apellido {get; set;}

        public String _segundo_nombre {get; set;}

        public String _segundo_apellido {get; set;}

        public DateTime _fecha_nac { get; set; }

        public String _fecha { get; set; }

        public String _sexo {get; set;}

        public String _correo {get; set;}

        //Constructor por default por si acaso
        public CModificarBoleto() { }

        //Constructor para pasarle los valores a la vista
        public CModificarBoleto(CBoleto boleto)
        {
            _id = boleto._pasajero._id;
            _primer_nombre =  boleto._pasajero._primer_nombre;
            _segundo_nombre =  boleto._pasajero._segundo_nombre;
            _primer_apellido = boleto._pasajero._primer_apellido;
            _segundo_apellido = boleto._pasajero._segundo_apellido;
            _correo =  boleto._pasajero._correo;
            _sexo =  boleto._pasajero._sexo;
            _fecha_nac =  boleto._pasajero._fecha_nac;
        }
    
    }
}
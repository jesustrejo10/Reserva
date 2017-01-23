using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain.M14
{
    public class Camarote : Entidad
    {
        public Camarote() { }
        

        public int _cantidadCama { get; set; }
        public String _tipoCama { get; set; }
        public String _estatus { get; set; }        
        public int _fkCabina { get; set; }
        public String _nombreCabina { get; set; }


        public Camarote(int id,int cantidadcama, String tipocama, String estatus, int cabina)
        {
            _id = id;
            _cantidadCama= cantidadcama;
            _tipoCama = tipocama;
            _estatus = estatus;
            _fkCabina = cabina;
            
        }

        public Camarote(int id,int cantidadcama, String tipocama, String estatus, String cabina)
        {
            _id = id;
            _cantidadCama= cantidadcama;
            _tipoCama = tipocama;
            _estatus = estatus;
            _nombreCabina = cabina;
            
        }        

    }
}
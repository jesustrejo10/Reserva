using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain.M14
{
    public class Camarote : Entidad
    {
        public Camarote() { }
        
        public int _cantidadCama;
        public string _tipoCama;
        public string _estatus;
        public int _fkCabina;

        public Camarote(int id,int cantidadcama, string tipocama, String estatus, int cabina)
        {
            _id = id;
            _cantidadCama= cantidadcama;
            _tipoCama = tipocama;
            _estatus = estatus;
            _fkCabina = cabina;
            
        }
    }
}
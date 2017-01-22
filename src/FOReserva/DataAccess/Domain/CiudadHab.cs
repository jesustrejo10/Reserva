using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class CiudadHab : Entidad
    {
        public int _idR;
        public String _lugar;
           public CiudadHab(int idlugar,String lugar) 
        {
            this._idR = idlugar;
            this._lugar = lugar;
        }

    }
}
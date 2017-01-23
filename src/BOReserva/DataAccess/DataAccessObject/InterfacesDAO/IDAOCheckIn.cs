using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOCheckIn : IDAO
    {
        List<Entidad> ListarPasesPasajero(int pasaporte);
        List<Entidad> M05ListarVuelosBoleto(int pasaporte);
        int MConteoMaletas(int pase);
        int CrearEquipaje(int id, int peso);
        int MConteoBoarding(int num_bol, int num_vue);
    }
}

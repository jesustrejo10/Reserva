﻿using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;


namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOBoleto : IDAO
    {
        int MBuscarIdaVuelta(int id);
        int MConteoCategoria(int codigo_vuelo, String tipo);
        int MConteoCapacidad(int codigo_vuelo, String tipo);
        int EliminarBoleto(int id);
        List<Entidad> ConsultarBoletos(int id);
    }
}

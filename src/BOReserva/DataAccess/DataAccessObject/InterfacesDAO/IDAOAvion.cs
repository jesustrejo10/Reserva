﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOAvion : IDAO
    {
        //metodos detallados
        //int Eliminar(int id);
        String eliminarAvion(int id);

    }
}

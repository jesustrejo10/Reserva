﻿using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    interface IDAORol : IDAO
    {
        int AgregarRolPermiso(Entidad e);
        List<Entidad> ConsultarRoles();
        List<Entidad> ConsultarPermisos(int id);
        List<Entidad> ListarPermisos();
        String eliminarRol(int id);
        String eliminarPermiso(int id);
        List<Entidad> consultarLosPermisosAsignados(int id);
        String MBuscarid_IdRol(String rolBuscar);
        String MBuscarid_Permiso(String permisoBucar);
        List<Entidad> consultarPermisosNoAsignados(int id);
        List<int> consultarPermisosUsuario(int idUsuario);
        String quitarPermiso(int idRol, int idPermiso);
        List<int> validacionRol(int id);
    }
}
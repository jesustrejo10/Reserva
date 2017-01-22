using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;

namespace FOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Intefaz de los metodos detallados del modulo de Registro y auntenticación
    /// </summary>
    interface IDAORegistroU
    {
        int ConsultarUsuarioLogin(Entidad e);
        int AgregarUsuario(Entidad e);
        int VerificarCorreo(Entidad e);

        bool ModificarPerfil(Entidad _cliente);
        bool IniciarSesion(Entidad _cliente);

        Entidad ConsultarUsuarioPerfil(Entidad e);
    }
}

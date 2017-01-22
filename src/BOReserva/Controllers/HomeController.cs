using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Servicio;
using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Controllers
{
    ///<summary>
    ///Clase que carga los permisos para el usuario que inicia sesion
    ///</summary>
    public class HomeController : Controller
    {
        ///<summary>
        ///Nueva instancia a lista de permisos
        ///</summary>
        public static List<string> permisos;
        ///<summary>
        ///Metodo que carga los permisos para un usuario
        ///</summary>
        public ActionResult Index()
        {
            if (Session["Cgestion_seguridad_ingreso"] == null)
            {
                return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
            }
            var usuario = Session["Cgestion_seguridad_ingreso"] as Cgestion_seguridad_ingreso;
            Command<List<String>> comando_permisos = FabricaComando.crearM13_ConsultarPermisosUsuario(usuario.idUsuario);
            permisos = comando_permisos.ejecutar();
            Session["Permisos"] = permisos;
            return View();
        }

    }
}

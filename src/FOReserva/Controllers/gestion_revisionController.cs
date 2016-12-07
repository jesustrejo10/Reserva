using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Controllers
{
    public class gestion_revisionController : Controller
    {
        //
        // GET: /gestion_revision/

        public ActionResult gestion_revision()
        {

            CRevision modelo = new CRevision();
            return PartialView(modelo);


        }

        public ActionResult gestion_ListRevicion()
        {

            CListRevision modelo = new CListRevision();
            return PartialView(modelo);

                        //probando
        }

        public ActionResult Consultar_Revision (string usuario)
        {
           // int search_val = Int32.Parse(Request.QueryString["search_val"]);
            string search_txt = Request.QueryString["search_text"];
            
            List<CRevision> lista ;                   // mostrar revision cuando estoy en el perfil del usuario
            if (search_txt == usuario)
            {
                
                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                //lista = manejador.ConsultaRevision(usuario);                               //las revisiones de ese usuario
                
                //return View(lista);
            }

            else
            {

                Console.Write("No se tienen revisiones");       //mostrar mensaje al usuario y no mostrar nada
                //return View(lista);
            }
            return null;
        }


    }
}

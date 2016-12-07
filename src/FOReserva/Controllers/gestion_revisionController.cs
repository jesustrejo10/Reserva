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
          // string Usuario = Request.QueryString["Usuario"];
            
            
            List<CRevision> lista ;


            ManejadorSQLRevision manejador = new ManejadorSQLRevision();   
                lista = manejador.ConsultarRevision(usuario);                              

                return PartialView(lista);
            }


        
        public ActionResult Eliminar_Revision(string usuario, CRevision revision)
        {

            string Usuario;
            CRevision rev;
            List<CRevision> lista;


            ManejadorSQLRevision manejador = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 
            lista = manejador.ConsultarRevision2(usuario, revision);   


            if (lista == null)
            {

                return PartialView(lista);

            }

                else 
                {

              ManejadorSQLRevision manejador2 = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 
            lista = manejador2.Eliminar_Revision(usuario, revision);   

                    return PartialView(lista);

                
                }

               
            }


       // public ActionResult Crear_Revsion()
       // {

                





       // }    //  hasta aca crear Rev

        }
            
        }

  
        




        


   


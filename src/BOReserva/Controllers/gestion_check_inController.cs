using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_check_inController : Controller
    {

        // GET 
        public ActionResult M05_CheckIn()
        {
            return PartialView();
        }

        // GET 
        public ActionResult M05_VerBoletosCheckIn()
        {
            return PartialView();
        }

        // GET 
        public ActionResult M05_VerDetalleBoleto()
        {
            return PartialView();
        }

        // GET 
        public ActionResult M05_Equipaje()
        {
            return PartialView();
        }

        // GET 
        public ActionResult M05_VerBoardingPass()
        {
            return PartialView();
        }
    }
}

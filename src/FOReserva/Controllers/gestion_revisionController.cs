using FOReserva.Models.Revision;
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
            CRevision model = new CRevision();
            return PartialView(model);

        }


    }
}

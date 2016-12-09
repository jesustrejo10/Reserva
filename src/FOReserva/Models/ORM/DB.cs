using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ORM
{
    public class DB
    {
        private static DBReserva instancia;

        public static DBReserva Singleton() {
            if (DB.instancia == null)
                DB.instancia = new DBReserva();
            return DB.instancia;
        }
    }
}
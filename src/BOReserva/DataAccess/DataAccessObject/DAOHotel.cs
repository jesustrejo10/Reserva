using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    public class DAOHotel: DAO {

        /* Metodos del Contrato IDAOHotel*/
        private String t;

        public DAOHotel() {
            
        }

        public int Insertar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidad Actualizar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidad Consultar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        
    }
}
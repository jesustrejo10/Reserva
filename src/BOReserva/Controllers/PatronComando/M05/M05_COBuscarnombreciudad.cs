using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    public class M05_COBuscarnombreciudad : Command<String>
    {

        int idciudad;

        public M05_COBuscarnombreciudad(Entidad e)
        {
            this.idciudad = e._id;
        }

        public override String ejecutar()
        {
            IDAOLugar daoLugar = (IDAOLugar) FabricaDAO.instanciarDaoLugar();
            String nombreCiudad = daoLugar.ciudad(idciudad);
            return nombreCiudad;
        }
    }
}
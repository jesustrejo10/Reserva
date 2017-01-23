using System;
using System.Collections.Generic;
using BOReserva.DataAccess.Domain;


namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOBoleto : IDAO
    {
        int MBuscarIdaVuelta(int id);
        int MConteoCategoria(int codigo_vuelo, String tipo);
        int MConteoCapacidad(int codigo_vuelo, String tipo);
        int EliminarBoleto(int id);
        List<Entidad> ConsultarBoletosPasajero(int id);
        Entidad M05MostrarReservaBD(int id_reserva);
        List<Entidad> ConsultarBoletos(int id);
        List<Entidad> M05ListarVuelosIdaBD(string fecha_ida, string fecha_vuelta, int id_origen, int id_destino, string tipo);
    }
}

using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.Datos
{
    /// <summary>
    /// Interface Metodos generales en Base de Datos 
    /// la variable tipo entidad con el nombre objeto 
    /// es un nombre general, cuando se implemente la 
    /// interface se puede cambiar por el nombre de la 
    /// clase a utilizar e.g: Entidad Lugar
    /// </summary>
    public interface IDAO
    {
        bool Crear(Entidad objeto);
        bool Modificar(Entidad objeto);
        bool Eliminar(Entidad objeto);
        List<Entidad> Consultar(Entidad objeto);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOReserva.Models.ORM
{
    using System;
    
    public partial class M20_BuscarHotelesPorCiudad_Result
    {
        public int hot_id { get; set; }
        public string hot_nombre { get; set; }
        public string hot_email { get; set; }
        public Nullable<int> hot_fk_ciudad { get; set; }
        public Nullable<int> hot_cantidad_habitaciones_disponible { get; set; }
    }
}
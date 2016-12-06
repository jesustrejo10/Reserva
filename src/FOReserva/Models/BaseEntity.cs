using System.Data.Entity;


namespace FOReserva.Models
{
    /*Clase Base para manejo de ID y nombre*/
    public class BaseEntity : DbContext
    {
        /*id del objeto en BD*/
        private int _id;
        /*nombre del objeto */
        private string _name;

        /*Constructor Completo*/
        public BaseEntity(int id, string _owner)
        {
            this._id = id;
            this._name = _owner;
        }
        /*Constructor Vacio*/
        public BaseEntity() { }

        /*Metodos Get y Set para el ID del Objeto*/
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /*Metodos Get y Set Para el nombre del Objeto*/
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
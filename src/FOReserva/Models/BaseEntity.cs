using System.Data.Entity;


namespace FOReserva.Models
{
    public class BaseEntity : DbContext
    {
        private int _id { get; set; }
        private string _name { get; set; }

        public BaseEntity(string owner)
        {
            this._name = owner;
        }

        public BaseEntity(int id, string _owner)
        {
            this._id = id;
            this._name = _owner;
        }

    }
}
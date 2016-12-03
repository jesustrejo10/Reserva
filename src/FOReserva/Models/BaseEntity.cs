using System.Data.Entity;


namespace FOReserva.Models
{
    public class BaseEntity : DbContext
    {
        /*id del objeto en BD*/
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /*nombre del objeto*/
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public BaseEntity(string owner)
        {
            this._name = owner;
        }

        public BaseEntity(int id, string _owner)
        {
            this._id = id;
            this._name = _owner;
        }

        public BaseEntity() { }


    }
}
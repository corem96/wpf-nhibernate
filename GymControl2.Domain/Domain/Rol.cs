using System;

namespace GymControl2.Domain.Domain
{
    public class Rol : ICloneable
    {
        public virtual int Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name must not be empty");
                _name = value;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

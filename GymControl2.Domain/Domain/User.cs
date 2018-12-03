using System;

namespace GymControl2.Domain.Domain
{
    public class User : ICloneable
    {
        public virtual int Id { get; set; }

        private string _userName;

        public virtual string UserName
        {
            get => _userName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Username must not be empty");
                _userName = value;
            }
        }

        private string _password;

        public virtual string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Password must not be empty");
                _password = value;
            }
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}

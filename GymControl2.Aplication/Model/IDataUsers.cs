using GymControl2.Domain.Domain;
using System.Collections.Generic;

namespace GymControl2.Models
{
    public interface IDataUsers
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int Id);
        IList<User> GetAll();
    }
}

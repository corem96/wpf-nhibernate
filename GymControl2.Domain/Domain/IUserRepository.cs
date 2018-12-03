using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymControl2.Domain.Domain
{
    public interface IUserRepository
    {
        void Add(User user);

        void AddMany(ICollection<User> users);

        void Update(User user);

        void Delete(User user);

        User GetById(int Id);

        IList<User> GetAll();

        long RowCount();
    }
}

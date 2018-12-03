using GymControl2.Domain.Domain;
using GymControl2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymControl2.Aplication.Model
{
    public class DataUsersDesign : IDataUsers
    {
        private DataUsersDB _dataUsersDB;

        public DataUsersDesign(DataUsersDB dataUsersDB)
        {
            _dataUsersDB = dataUsersDB;
        }

        public void Add(User user)
        {
            _dataUsersDB.Add(user);
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

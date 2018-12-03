using System;
using System.Collections.Generic;
using GymControl2.Domain.DBException;
using GymControl2.Domain.Domain;
using GymControl2.Domain.Repositories;

namespace GymControl2.Models
{
    public class DataUsersDB : IDataUsers
    {
        private IUserRepository userRepository = new UserRepository();

        public void Add(User user)
        {
            userRepository.Add(user);
        }

        public void Delete(User user)
        {
            userRepository.Delete(user);
        }

        public ICollection<User> GetAll()
        {
            try
            {
                return userRepository.GetAll();
            }
            catch (Exception ex)
            {
                if(ex is ReadDBError)
                {
                    throw new ReadDBError("Can't read entities in DB");
                }
                throw;
            }
        }

        public User GetById(int Id)
        {
            return userRepository.GetById(Id);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
    }
}

using GymControl2.Domain.DBException;
using GymControl2.Domain.Domain;
using NHibernate;
using System;
using System.Collections.Generic;

namespace GymControl2.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        public void AddMany(ICollection<User> users)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach(var user in users)
                    {
                        session.Save(user);
                    }
                    transaction.Commit();
                }
            }
        }

        public void Delete(User user)
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        public IList<User> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.QueryOver<User>()
                        .List();
                }
                catch (ADOException ex)
                {
                    throw new ReadDBError("can't read table users", ex);
                }
            }
        }

        public User GetById(int Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<User>(Id);
            }
        }

        public long RowCount()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                    .RowCountInt64();
            }
        }

        public void Update(User user)
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }
    }
}

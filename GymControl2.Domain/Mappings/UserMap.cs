using FluentNHibernate.Mapping;
using GymControl2.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymControl2.Domain.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");
            Id(x => x.Id).Column("id");
            Map(x => x.UserName).Column("username");
            Map(x => x.Password).Column("password");
        }
    }
}

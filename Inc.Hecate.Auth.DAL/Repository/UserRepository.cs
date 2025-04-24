using Azure.Core;
using Inc.Hecate.Auth.Domain.Entity;
using Inc.Hecate.Auth.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByEmailAndPassword(string password, string email)
        {
            throw new Exception();

            //return new User(,2,"","");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(int id, string name, string login, string email, string password)
        {
            Id = id;
            Name = name;
            Login = login;
            Email = email;
            Password = password;
        }
    }
}

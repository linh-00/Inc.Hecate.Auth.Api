using Inc.Hecate.Auth.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Interface
{
    public interface IUserRepository
    {
        User GetUserByEmailAndPassword(string email, string password);
    }
}

using Inc.Hecate.Auth.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEntity = Inc.Hecate.Auth.Domain.Entity.User;

namespace Inc.Hecate.Auth.Domain.Interface
{
    public interface IUserRepository
    {
        Task<UserEntity> CreateUser(UserEntity request);
    }
}

using Azure.Core;
using Inc.Hecate.Auth.DAL.Context;
using Inc.Hecate.Auth.DAL.Models;
using Inc.Hecate.Auth.Domain.Entity;
using Inc.Hecate.Auth.Domain.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEntity = Inc.Hecate.Auth.Domain.Entity.User;

namespace Inc.Hecate.Auth.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly dbHecateContext _Context;
        public UserRepository(dbHecateContext context)
        {
            _Context = context;
        }

        public async Task<UserEntity> CreateUser(UserEntity request)
        {
            Models.User newUser = new Models.User
            {
                ACCOUNT_ID = request.AccountId,
                EMAIL = request.Email,
                PASSWORD = request.Password,
                CREATED_AT = request.CreatedAt,
                CREATED_BY = request.UpdatedBy
            };
            _Context.Users.Add(newUser);
            await _Context.SaveChangesAsync();
            request.SetId(newUser.ID);
            return request;
        }

    }
}

using Azure.Core;
using Inc.Hecate.Auth.DAL.Context;
using Inc.Hecate.Auth.Domain.Interface;
using Microsoft.EntityFrameworkCore;
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
            return request;
        }
        public async Task<UserEntity> Update(UserEntity request)
        {
            var user = await _Context.Users.Where(x => x.ID.Equals(request.Id)).FirstOrDefaultAsync();
            if(user is not null)
            {
                user.EMAIL = request.Email;
                user.PASSWORD = request.Password;
                user.UPDATED_AT = request.UpdatedAt;
                user.UPDATED_BY = request.UpdatedBy;

                _Context.Users.Update(user);
                await _Context.SaveChangesAsync();
                return request;
            }
            else { throw new Exception("Não foi possível atualizar o usuário"); }
        }
    }
}

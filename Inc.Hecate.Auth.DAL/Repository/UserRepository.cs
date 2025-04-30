using Azure.Core;
using Inc.Hecate.Auth.DAL.Context;
using Inc.Hecate.Auth.DAL.Models;
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
        public async Task<UserEntity> GetById(UserEntity request)
        {
            var user = await _Context.Users.Where(x => x.ID.Equals(request.Id)).FirstOrDefaultAsync();
            if (user is not null)
            {
                return new UserEntity(user.ID, user.ACCOUNT_ID, user.EMAIL, user.PASSWORD, user.CREATED_AT, user.CREATED_BY, user.UPDATED_AT, user.UPDATED_BY);
            }
            else { throw new Exception("Usuário não encontrado"); }
        }
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            List<User> user = await _Context.Users.ToListAsync();
            if (user is not null)
            {
                return user.Select(res => new UserEntity(res.ID, res.ACCOUNT_ID, res.EMAIL, res.PASSWORD, res.CREATED_AT, res.CREATED_BY, res.UPDATED_AT, res.UPDATED_BY));
            }
            else { throw new Exception("Não foi possível atualizar o usuário"); }
        }
        public async Task<bool> Delete(int id)
        {
            var user = await _Context.Users.Where(x => x.ID.Equals(id)).FirstOrDefaultAsync();

            if (user is not null)
            {
                _Context.Users.Remove(user);
                await _Context.SaveChangesAsync();
                return true;
            }
            else { throw new Exception("Não foi possível deletar o usuário"); }
        }
    }
}

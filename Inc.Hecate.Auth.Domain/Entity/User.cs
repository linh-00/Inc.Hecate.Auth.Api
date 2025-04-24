using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class User : BaseEntities
    {
        public Guid AccountId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //public ICollection<ScopeUser> Scopes { get; set; }
        //public ICollection<RulesUser> Rules { get; set; }


        public User(Guid id, Guid accountId, string email, string password) : base(id)
        {
            AccountId = accountId;
            Email = email;
            Password = password;
        }
        public User(Guid accountId, string email, string password)
        {
            AccountId = accountId;
            Email = email;
            Password = password;
        }
    }
}

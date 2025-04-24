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
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        //public ICollection<ScopeUser> Scopes { get; set; }
        //public ICollection<RulesUser> Rules { get; set; }


        public User(Guid id, Guid accountId, string email, string password, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy) : base(id)
        {
            AccountId = accountId;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
        public User(Guid accountId, string email, string password)
        {
            AccountId = accountId;
            Email = email;
            Password = password;
        }
    }
}

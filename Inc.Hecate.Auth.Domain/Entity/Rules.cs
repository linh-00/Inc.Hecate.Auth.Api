using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class Rules : BaseEntities
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ScopeId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public IEnumerable<ScopeUser> ID { get; private set; } = new List<ScopeUser>();

        private Rules(int id, string name, string description, Guid scopeId, DateTime createdAt, string createdBy, DateTime updatedAt, string updatedBy) : base(id)
        {
            Name = name;
            Description = description;
            ScopeId = scopeId;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }

        public Rules(string name, string description, Guid scopeId, string createdBy)
        {
            Name = name;
            Description = description;
            ScopeId = scopeId;
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
        }
        public void Update(string name, string description, Guid scopeId, string updatedBy)
        {
            Name = name;
            Description = description;
            ScopeId = scopeId;
            UpdatedAt = DateTime.Now;
            UpdatedBy = updatedBy;
        }
    }
}

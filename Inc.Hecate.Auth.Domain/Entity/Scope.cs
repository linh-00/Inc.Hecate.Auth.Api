using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class Scope : BaseEntities
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        public Scope(Guid id, string name, string description, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy) : base(id)
        {
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }

        public Scope(string name, string description, string createdBy)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;            
        }
        public void Update(string name, string description, string updatedBy)
        {
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            UpdatedBy = updatedBy;            
        }
    }
}

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

        public Scope(Guid id, string name, string description): base(id)
        {
            Name = name;
            Description = description;
        }

        public Scope(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}

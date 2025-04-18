using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class BaseEntities
    {
        public Guid? Id { get; private set; }
        public BaseEntities(Guid? id)
        {
            Id = id;
        }
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}

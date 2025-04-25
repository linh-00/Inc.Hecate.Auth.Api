using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    class RulesUser
    {
        public IEnumerable<User> UserId { get; private set; } = new List<User>();
        public IEnumerable<Rules> RulesId { get; private set; } = new List<Rules>();

        public void SetUsers(IEnumerable<User> userId)
        {
            UserId = userId ?? new List<User>();
        }

        public void SetRulers(IEnumerable<Rules> rulesId)
        {
            RulesId = rulesId ?? new List<Rules>();
        }
    }
}

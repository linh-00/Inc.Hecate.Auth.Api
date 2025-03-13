using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class InviteEmail
    {
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public string Status { get; private set; }
        public DateTime Envio { get; private set; }
        public int UserIdInvite { get; private set; }

        public InviteEmail(string email, string fullName, int userIdInvite)
        {
            Email = email;
            FullName = fullName;
            Status = "Pendente";
            Envio = DateTime.Now;
            UserIdInvite = userIdInvite;
        }

        public void ComfirmAccount()
        {
            Status = "Confirmado";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.DTO.Reponse
{
    class LoginRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}

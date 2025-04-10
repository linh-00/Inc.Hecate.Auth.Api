﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.DTO.Reponse
{
    public record UserResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Login { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Domain.Entity
{
    public class BaseEntities
    {
        public int? Id { get; private set; }
        public BaseEntities(int? id)
        {
            Id = id;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}

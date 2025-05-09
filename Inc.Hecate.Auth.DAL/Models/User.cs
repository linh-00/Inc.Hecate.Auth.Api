﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Hecate.Auth.DAL.Models;

[Table("User")]
public partial class User
{
    [Key]
    public Guid ID { get; set; }

    public Guid ACCOUNT_ID { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string EMAIL { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string PASSWORD { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CREATED_AT { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string CREATED_BY { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UPDATED_AT { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? UPDATED_BY { get; set; }

    [InverseProperty("USER")]
    public virtual ICollection<RulesUser> RulesUsers { get; set; } = new List<RulesUser>();

    [InverseProperty("USER")]
    public virtual ICollection<ScopeUser> ScopeUsers { get; set; } = new List<ScopeUser>();
}

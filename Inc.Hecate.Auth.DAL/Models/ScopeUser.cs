using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Hecate.Auth.DAL.Models;

[Table("ScopeUser")]
public partial class ScopeUser
{
    [Key]
    public Guid ID { get; set; }

    public Guid USER_ID { get; set; }

    public Guid SCOPE_ID { get; set; }

    [ForeignKey("SCOPE_ID")]
    [InverseProperty("ScopeUsers")]
    public virtual Scope SCOPE { get; set; } = null!;

    [ForeignKey("USER_ID")]
    [InverseProperty("ScopeUsers")]
    public virtual User USER { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Hecate.Auth.DAL.Models;

[Table("Scope")]
public partial class Scope
{
    [Key]
    public Guid ID { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string DESCRIPTION { get; set; } = null!;

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

    [InverseProperty("SCOPE")]
    public virtual ICollection<Rule> Rules { get; set; } = new List<Rule>();

    [InverseProperty("SCOPE")]
    public virtual ICollection<ScopeUser> ScopeUsers { get; set; } = new List<ScopeUser>();
}

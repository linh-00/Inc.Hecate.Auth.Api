using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Hecate.Auth.DAL.Models;

public partial class Rule
{
    [Key]
    public Guid ID { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string DESCRIPTION { get; set; } = null!;

    public Guid SCOPE_ID { get; set; }

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

    [InverseProperty("RULES")]
    public virtual ICollection<RulesUser> RulesUsers { get; set; } = new List<RulesUser>();

    [ForeignKey("SCOPE_ID")]
    [InverseProperty("Rules")]
    public virtual Scope SCOPE { get; set; } = null!;
}

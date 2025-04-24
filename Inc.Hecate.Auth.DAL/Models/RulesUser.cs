using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Hecate.Auth.DAL.Models;

[Table("RulesUser")]
public partial class RulesUser
{
    [Key]
    public Guid ID { get; set; }

    public Guid USER_ID { get; set; }

    public Guid RULES_ID { get; set; }

    [ForeignKey("RULES_ID")]
    [InverseProperty("RulesUsers")]
    public virtual Rule RULES { get; set; } = null!;

    [ForeignKey("USER_ID")]
    [InverseProperty("RulesUsers")]
    public virtual User USER { get; set; } = null!;
}

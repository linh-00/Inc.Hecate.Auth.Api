using System;
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
}

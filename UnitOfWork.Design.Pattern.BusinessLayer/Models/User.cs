using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Design.Pattern.BusinessLayer.Models;

public partial class User
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public byte Age { get; set; }
    [Required]
    public string? Gender { get; set; }
}

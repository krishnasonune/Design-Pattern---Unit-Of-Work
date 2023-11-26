using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Design.Pattern.BusinessLayer.Models;

public partial class Movie
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public decimal Ratings { get; set; }
}

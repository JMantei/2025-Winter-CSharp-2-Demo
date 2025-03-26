using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models;

[Table("instructors")]
public partial class Instructor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [InverseProperty("Instructor")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

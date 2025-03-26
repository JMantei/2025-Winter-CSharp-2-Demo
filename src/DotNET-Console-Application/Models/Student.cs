using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models;

[Keyless]
[Table("students")]
public partial class Student
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("course_id")]
    public int? CourseId { get; set; }

    [ForeignKey("CourseId")]
    public virtual Course? Course { get; set; }
}

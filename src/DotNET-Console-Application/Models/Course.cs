using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models;

[Table("courses")]
public partial class Course
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("course_code")]
    public string? CourseCode { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("instructor_id")]
    public int? InstructorId { get; set; }

    [ForeignKey("InstructorId")]
    [InverseProperty("Courses")]
    public virtual Instructor? Instructor { get; set; }
}

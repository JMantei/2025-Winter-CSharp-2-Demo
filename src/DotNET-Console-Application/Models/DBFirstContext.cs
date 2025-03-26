using System;
using System.Collections.Generic;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models;

public partial class DBFirstContext : DbContext
{
    public DBFirstContext()
    {
    }

    public DBFirstContext(DbContextOptions<DBFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string envPath = ".env";
        int tries = 10;
        while (!File.Exists(envPath) && tries > 0)
        {
            tries--;
            envPath = $"../{envPath}";
        }
        Env.Load(envPath);
        if (!optionsBuilder.IsConfigured)
        {
            if (Environment.GetEnvironmentVariable("DB_TYPE") == "sqlite")
            {
                optionsBuilder.UseSqlite($"Data Source={Environment.GetEnvironmentVariable("DB_NAME")}.db");
            }
            else if (Environment.GetEnvironmentVariable("DB_TYPE") == "mariadb")
            {
                optionsBuilder.UseMySql($"server=localhost;database={Environment.GetEnvironmentVariable("DB_NAME")};user=root;password={Environment.GetEnvironmentVariable("DB_PASSWORD")}", new MySqlServerVersion(new Version(11, 8, 1)));
            }
            else if (Environment.GetEnvironmentVariable("DB_TYPE") == "postgres")
            {
                optionsBuilder.UseNpgsql($"Host=localhost;Port=5454;Username={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};Database={Environment.GetEnvironmentVariable("DB_NAME")};");
            }
            else
            {
                throw new Exception("Unsupported DB_TYPE.");
            }
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

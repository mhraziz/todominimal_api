using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todominimal_api.Models;

public partial class TododbContext : DbContext
{
    public TododbContext()
    {
    }

    public TododbContext(DbContextOptions<TododbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=AZIZ-MHR\\SQLEXPRESS; database=tododb; trusted_connection=true;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__todo__3213E83FD7D8E5B5");

            entity.ToTable("todo");

            entity.Property(e => e.Id)
                //.ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Completed)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("completed");
            entity.Property(e => e.Todo1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("todo");
            //entity.Property(e => e.UserId).HasColumnName("userId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

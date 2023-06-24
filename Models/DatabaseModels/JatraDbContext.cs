using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JatraApplication.Models.DatabaseModels;

public partial class JatraDbContext : DbContext
{
    public JatraDbContext()
    {
    }

    public JatraDbContext(DbContextOptions<JatraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MATRIX\\SQLEXPRESS;Database=JatraDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__events__2DC7BD0921B44BF8");

            entity.ToTable("events");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.EventCommunity)
                .IsUnicode(false)
                .HasColumnName("eventCommunity");
            entity.Property(e => e.EventDescription)
                .IsUnicode(false)
                .HasColumnName("eventDescription");
            entity.Property(e => e.EventEndDate)
                .HasColumnType("datetime")
                .HasColumnName("eventEndDate");
            entity.Property(e => e.EventHighlights)
                .IsUnicode(false)
                .HasColumnName("eventHighlights");
            entity.Property(e => e.EventLocation)
                .IsUnicode(false)
                .HasColumnName("eventLocation");
            entity.Property(e => e.EventName)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.EventStartDate)
                .HasColumnType("datetime")
                .HasColumnName("eventStartDate");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FE467E8AD");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Internship_App2.AppDbContext;

public partial class InternshipDb2Context : DbContext
{
    public InternshipDb2Context()
    {
    }

    public InternshipDb2Context(DbContextOptions<InternshipDb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminCalendar> AdminCalendars { get; set; }

    public virtual DbSet<Advisor> Advisors { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<InternshipApplication> InternshipApplications { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-1COQFRR0\ZA2000004081;Initial Catalog=InternshipDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E8CD1C9AC0");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.AdminNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admins__AdminID__46E78A0C");
        });

        modelBuilder.Entity<AdminCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminCal__3214EC0736EC37F5");

            entity.ToTable("AdminCalendar");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Advisor>(entity =>
        {
            entity.HasKey(e => e.AdvisorId).HasName("PK__Advisor__9DE0B60748F574EF");

            entity.ToTable("Advisor");

            entity.Property(e => e.AdvisorId)
                .ValueGeneratedNever()
                .HasColumnName("AdvisorID");
            entity.Property(e => e.AdvisorInformation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("advisorInformation");
            entity.Property(e => e.StudentInformation)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdateStudentInformation)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AdvisorNavigation).WithOne(p => p.Advisor)
                .HasForeignKey<Advisor>(d => d.AdvisorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Advisor__Advisor__49C3F6B7");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PK__Calendar__77387D06F097C06B");

            entity.ToTable("Calendar");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.IsWorkDay).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6F7B2D8782");

            entity.ToTable("Document");

            entity.Property(e => e.DocumentId)
                .ValueGeneratedNever()
                .HasColumnName("DocumentID");
            entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.DocumentNavigation).WithOne(p => p.Document)
                .HasForeignKey<Document>(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__Docume__4D94879B");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF65D226AA8");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("FeedbackID");
            entity.Property(e => e.FeedbackInformation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("feedback_information");

            entity.HasOne(d => d.FeedbackNavigation).WithOne(p => p.Feedback)
                .HasForeignKey<Feedback>(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Feedba__5070F446");
        });

        modelBuilder.Entity<InternshipApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Internsh__C93A4F79B3D46316");

            entity.ToTable("Internship_Application");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.AdvisorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Company_Email");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyPhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Company_PhoneNumber");
            entity.Property(e => e.EmployerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployerPhone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployerSurname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FieldOfActivity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InternshipEndDate).HasColumnType("date");
            entity.Property(e => e.InternshipStartDate).HasColumnType("date");
            entity.Property(e => e.InternshipType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequiredDocuments)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.InternshipApplications)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Internshi__Advis__503BEA1C");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79D24813CA");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePhoto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentNo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userProf__3214EC27E6A1C79B");

            entity.ToTable("userProfile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.UserType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

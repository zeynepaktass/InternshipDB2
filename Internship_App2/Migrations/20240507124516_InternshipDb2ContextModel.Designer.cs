﻿// <auto-generated />
using System;
using Internship_App2.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternshipApp2.Migrations
{
    [DbContext(typeof(InternshipDb2Context))]
    [Migration("20240507124516_InternshipDb2ContextModel")]
    partial class InternshipDb2ContextModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Internship_App2.AppDbContext.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int")
                        .HasColumnName("AdminID");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("username");

                    b.HasKey("AdminId")
                        .HasName("PK__Admins__719FE4E8CD1C9AC0");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.AdminCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdminCalendars");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Advisor", b =>
                {
                    b.Property<int>("AdvisorId")
                        .HasColumnType("int")
                        .HasColumnName("AdvisorID");

                    b.Property<string>("AdvisorInformation")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("advisorInformation");

                    b.Property<string>("StudentInformation")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UpdateStudentInformation")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("AdvisorId")
                        .HasName("PK__Advisor__9DE0B60748F574EF");

                    b.ToTable("Advisor", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Calendar", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool?>("IsWorkDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Date")
                        .HasName("PK__Calendar__77387D06FB94E293");

                    b.ToTable("Calendar", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .HasColumnType("int")
                        .HasColumnName("DocumentID");

                    b.Property<bool?>("IsApproved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("DocumentId")
                        .HasName("PK__Document__1ABEEF6F7B2D8782");

                    b.ToTable("Document", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .HasColumnType("int")
                        .HasColumnName("FeedbackID");

                    b.Property<string>("FeedbackInformation")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("feedback_information");

                    b.HasKey("FeedbackId")
                        .HasName("PK__Feedback__6A4BEDF65D226AA8");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.InternshipApplication", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ApplicationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"));

                    b.Property<bool>("ApplicationStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Company_Email");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CompanyPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Company_PhoneNumber");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EmployerEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmployerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmployerPhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmployerSurname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FieldOfActivity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("InternshipEndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("InternshipStartDate")
                        .HasColumnType("date");

                    b.Property<string>("InternshipType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RequiredDocuments")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.HasKey("ApplicationId")
                        .HasName("PK__Internsh__C93A4F7979E98F10");

                    b.HasIndex("StudentId");

                    b.ToTable("Internship_Application", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ProfilePhoto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StudentNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("StudentId")
                        .HasName("PK__Student__32C52A79D24813CA");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userType");

                    b.HasKey("Id")
                        .HasName("PK__userProf__3214EC27E6A1C79B");

                    b.ToTable("userProfile", (string)null);
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Admin", b =>
                {
                    b.HasOne("Internship_App2.AppDbContext.UserProfile", "AdminNavigation")
                        .WithOne("Admin")
                        .HasForeignKey("Internship_App2.AppDbContext.Admin", "AdminId")
                        .IsRequired()
                        .HasConstraintName("FK__Admins__AdminID__46E78A0C");

                    b.Navigation("AdminNavigation");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Advisor", b =>
                {
                    b.HasOne("Internship_App2.AppDbContext.UserProfile", "AdvisorNavigation")
                        .WithOne("Advisor")
                        .HasForeignKey("Internship_App2.AppDbContext.Advisor", "AdvisorId")
                        .IsRequired()
                        .HasConstraintName("FK__Advisor__Advisor__49C3F6B7");

                    b.Navigation("AdvisorNavigation");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Document", b =>
                {
                    b.HasOne("Internship_App2.AppDbContext.Advisor", "DocumentNavigation")
                        .WithOne("Document")
                        .HasForeignKey("Internship_App2.AppDbContext.Document", "DocumentId")
                        .IsRequired()
                        .HasConstraintName("FK__Document__Docume__4D94879B");

                    b.Navigation("DocumentNavigation");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Feedback", b =>
                {
                    b.HasOne("Internship_App2.AppDbContext.UserProfile", "FeedbackNavigation")
                        .WithOne("Feedback")
                        .HasForeignKey("Internship_App2.AppDbContext.Feedback", "FeedbackId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__Feedba__5070F446");

                    b.Navigation("FeedbackNavigation");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.InternshipApplication", b =>
                {
                    b.HasOne("Internship_App2.AppDbContext.Student", "Student")
                        .WithMany("InternshipApplications")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__Internshi__Stude__2B0A656D");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Advisor", b =>
                {
                    b.Navigation("Document");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.Student", b =>
                {
                    b.Navigation("InternshipApplications");
                });

            modelBuilder.Entity("Internship_App2.AppDbContext.UserProfile", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Advisor");

                    b.Navigation("Feedback");
                });
#pragma warning restore 612, 618
        }
    }
}

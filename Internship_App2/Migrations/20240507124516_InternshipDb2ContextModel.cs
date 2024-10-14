using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipApp2.Migrations
{
    /// <inheritdoc />
    public partial class InternshipDb2ContextModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCalendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    IsWorkDay = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Calendar__77387D06FB94E293", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProfilePhoto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StudentNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__32C52A79D24813CA", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "userProfile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    userType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userProf__3214EC27E6A1C79B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Internship_Application",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternshipType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CompanyAddress = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    FieldOfActivity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyPhoneNumber = table.Column<string>(name: "Company_PhoneNumber", type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CompanyEmail = table.Column<string>(name: "Company_Email", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InternshipStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    InternshipEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    RequiredDocuments = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EmployerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployerSurname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployerPhone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EmployerEmail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ApplicationStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Internsh__C93A4F7979E98F10", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK__Internshi__Stude__2B0A656D",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins__719FE4E8CD1C9AC0", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK__Admins__AdminID__46E78A0C",
                        column: x => x.AdminID,
                        principalTable: "userProfile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Advisor",
                columns: table => new
                {
                    AdvisorID = table.Column<int>(type: "int", nullable: false),
                    StudentInformation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    UpdateStudentInformation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    advisorInformation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Advisor__9DE0B60748F574EF", x => x.AdvisorID);
                    table.ForeignKey(
                        name: "FK__Advisor__Advisor__49C3F6B7",
                        column: x => x.AdvisorID,
                        principalTable: "userProfile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false),
                    feedbackinformation = table.Column<string>(name: "feedback_information", type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDF65D226AA8", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Feedback__Feedba__5070F446",
                        column: x => x.FeedbackID,
                        principalTable: "userProfile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__1ABEEF6F7B2D8782", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK__Document__Docume__4D94879B",
                        column: x => x.DocumentID,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Internship_Application_StudentID",
                table: "Internship_Application",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminCalendars");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Internship_Application");

            migrationBuilder.DropTable(
                name: "Advisor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "userProfile");
        }
    }
}

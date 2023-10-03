using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDB",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDB", x => x.RegNo);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.RegNo);
                });

            migrationBuilder.InsertData(
                table: "LoginDB",
                columns: new[] { "RegNo", "Password", "Role" },
                values: new object[] { "2016-2-60-147", "12345", "Admin" });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "RegNo", "DOB", "Email", "Phone", "StudentName" },
                values: new object[] { "2016-2-60-147", "30/08/1996", "tariqulshuvon@gmail.com", "01679784089", "Tariqul" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginDB");

            migrationBuilder.DropTable(
                name: "StudentInfo");
        }
    }
}

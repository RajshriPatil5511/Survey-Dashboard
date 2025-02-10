using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRS3LOGIN_AUTHENTICATION.Migrations
{
    public partial class manageSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyManager",
                columns: table => new
                {
                    ManageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surveyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quetions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyManager", x => x.ManageID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyManager");
        }
    }
}

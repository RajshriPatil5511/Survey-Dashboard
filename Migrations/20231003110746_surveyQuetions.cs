using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRS3LOGIN_AUTHENTICATION.Migrations
{
    public partial class surveyQuetions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "SurveyQuetions",
                columns: table => new
                {
                    Quetionsid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quetions = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    QuetionsWeightage = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuetions", x => x.Quetionsid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyQuetions");

           
              
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DavetiyeDataAccess.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Davetiyes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Davetiyes",
                table: "Davetiyes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Davetiyes",
                table: "Davetiyes");

            migrationBuilder.RenameTable(
                name: "Davetiyes",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "id");
        }
    }
}

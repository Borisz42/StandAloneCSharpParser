using Microsoft.EntityFrameworkCore.Migrations;

namespace StandAloneCSharpParser.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__sharpEntitys",
                table: "_sharpEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK__csharpAstNodes",
                table: "_csharpAstNodes");

            migrationBuilder.RenameTable(
                name: "_sharpEntitys",
                newName: "sharpEntitys");

            migrationBuilder.RenameTable(
                name: "_csharpAstNodes",
                newName: "csharpAstNodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sharpEntitys",
                table: "sharpEntitys",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_csharpAstNodes",
                table: "csharpAstNodes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sharpEntitys",
                table: "sharpEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csharpAstNodes",
                table: "csharpAstNodes");

            migrationBuilder.RenameTable(
                name: "sharpEntitys",
                newName: "_sharpEntitys");

            migrationBuilder.RenameTable(
                name: "csharpAstNodes",
                newName: "_csharpAstNodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK__sharpEntitys",
                table: "_sharpEntitys",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__csharpAstNodes",
                table: "_csharpAstNodes",
                column: "id");
        }
    }
}

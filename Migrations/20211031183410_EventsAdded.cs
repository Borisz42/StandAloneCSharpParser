using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StandAloneCSharpParser.Migrations
{
    public partial class EventsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccessor",
                table: "CsharpMethod",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecord",
                table: "CsharpClasses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CsharpEtcEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsEvent = table.Column<bool>(type: "boolean", nullable: false),
                    CsharpClassId = table.Column<long>(type: "bigint", nullable: true),
                    CsharpStructId = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    TypeHash = table.Column<long>(type: "bigint", nullable: false),
                    QualifiedType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpEtcEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpEtcEntity_CsharpAstNodes_AstNodeId",
                        column: x => x.AstNodeId,
                        principalTable: "CsharpAstNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CsharpEtcEntity_CsharpClasses_CsharpClassId",
                        column: x => x.CsharpClassId,
                        principalTable: "CsharpClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CsharpEtcEntity_CsharpStructs_CsharpStructId",
                        column: x => x.CsharpStructId,
                        principalTable: "CsharpStructs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEtcEntity_AstNodeId",
                table: "CsharpEtcEntity",
                column: "AstNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEtcEntity_CsharpClassId",
                table: "CsharpEtcEntity",
                column: "CsharpClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEtcEntity_CsharpStructId",
                table: "CsharpEtcEntity",
                column: "CsharpStructId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CsharpEtcEntity");

            migrationBuilder.DropColumn(
                name: "IsAccessor",
                table: "CsharpMethod");

            migrationBuilder.DropColumn(
                name: "IsRecord",
                table: "CsharpClasses");
        }
    }
}

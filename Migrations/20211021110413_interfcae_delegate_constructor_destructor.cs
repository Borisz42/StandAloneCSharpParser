using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StandAloneCSharpParser.Migrations
{
    public partial class interfcae_delegate_constructor_destructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CsharpStructId",
                table: "CsharpVariable",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CsharpClassId1",
                table: "CsharpMethod",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CsharpClassId2",
                table: "CsharpMethod",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CsharpStructId",
                table: "CsharpMethod",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelegate",
                table: "CsharpMethod",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInterface",
                table: "CsharpClasses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CsharpStructs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CsharpNamespaceId = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpStructs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpStructs_CsharpAstNodes_AstNodeId",
                        column: x => x.AstNodeId,
                        principalTable: "CsharpAstNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CsharpStructs_CsharpNamespaces_CsharpNamespaceId",
                        column: x => x.CsharpNamespaceId,
                        principalTable: "CsharpNamespaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CsharpVariable_CsharpStructId",
                table: "CsharpVariable",
                column: "CsharpStructId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpMethod_CsharpClassId1",
                table: "CsharpMethod",
                column: "CsharpClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpMethod_CsharpClassId2",
                table: "CsharpMethod",
                column: "CsharpClassId2");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpMethod_CsharpStructId",
                table: "CsharpMethod",
                column: "CsharpStructId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpStructs_AstNodeId",
                table: "CsharpStructs",
                column: "AstNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpStructs_CsharpNamespaceId",
                table: "CsharpStructs",
                column: "CsharpNamespaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpMethod_CsharpClasses_CsharpClassId1",
                table: "CsharpMethod",
                column: "CsharpClassId1",
                principalTable: "CsharpClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpMethod_CsharpClasses_CsharpClassId2",
                table: "CsharpMethod",
                column: "CsharpClassId2",
                principalTable: "CsharpClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpMethod_CsharpStructs_CsharpStructId",
                table: "CsharpMethod",
                column: "CsharpStructId",
                principalTable: "CsharpStructs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpVariable_CsharpStructs_CsharpStructId",
                table: "CsharpVariable",
                column: "CsharpStructId",
                principalTable: "CsharpStructs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CsharpMethod_CsharpClasses_CsharpClassId1",
                table: "CsharpMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpMethod_CsharpClasses_CsharpClassId2",
                table: "CsharpMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpMethod_CsharpStructs_CsharpStructId",
                table: "CsharpMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpVariable_CsharpStructs_CsharpStructId",
                table: "CsharpVariable");

            migrationBuilder.DropTable(
                name: "CsharpStructs");

            migrationBuilder.DropIndex(
                name: "IX_CsharpVariable_CsharpStructId",
                table: "CsharpVariable");

            migrationBuilder.DropIndex(
                name: "IX_CsharpMethod_CsharpClassId1",
                table: "CsharpMethod");

            migrationBuilder.DropIndex(
                name: "IX_CsharpMethod_CsharpClassId2",
                table: "CsharpMethod");

            migrationBuilder.DropIndex(
                name: "IX_CsharpMethod_CsharpStructId",
                table: "CsharpMethod");

            migrationBuilder.DropColumn(
                name: "CsharpStructId",
                table: "CsharpVariable");

            migrationBuilder.DropColumn(
                name: "CsharpClassId1",
                table: "CsharpMethod");

            migrationBuilder.DropColumn(
                name: "CsharpClassId2",
                table: "CsharpMethod");

            migrationBuilder.DropColumn(
                name: "CsharpStructId",
                table: "CsharpMethod");

            migrationBuilder.DropColumn(
                name: "IsDelegate",
                table: "CsharpMethod");

            migrationBuilder.DropColumn(
                name: "IsInterface",
                table: "CsharpClasses");
        }
    }
}

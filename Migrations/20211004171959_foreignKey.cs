using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StandAloneCSharpParser.Migrations
{
    public partial class foreignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CsharpVariable_CsharpClasses_CsharpClassId",
                table: "CsharpVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpVariable_CsharpMethod_CsharpMethodId",
                table: "CsharpVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpVariable_CsharpMethod_CsharpMethodId1",
                table: "CsharpVariable");

            migrationBuilder.DropTable(
                name: "CsharpEnumMember");

            migrationBuilder.DropTable(
                name: "CsharpMethod");

            migrationBuilder.DropTable(
                name: "CsharpEnums");

            migrationBuilder.DropTable(
                name: "CsharpClasses");

            migrationBuilder.DropTable(
                name: "CsharpNamespaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsharpAstNodes",
                table: "CsharpAstNodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsharpVariable",
                table: "CsharpVariable");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CsharpAstNodes");

            migrationBuilder.RenameTable(
                name: "CsharpVariable",
                newName: "CsharpEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CsharpVariable_CsharpMethodId1",
                table: "CsharpEntity",
                newName: "IX_CsharpEntity_CsharpMethodId1");

            migrationBuilder.RenameIndex(
                name: "IX_CsharpVariable_CsharpMethodId",
                table: "CsharpEntity",
                newName: "IX_CsharpEntity_CsharpMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_CsharpVariable_CsharpClassId",
                table: "CsharpEntity",
                newName: "IX_CsharpEntity_CsharpClassId");

            migrationBuilder.AddColumn<long>(
                name: "AstNodeId",
                table: "CsharpAstNodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "TypeHash",
                table: "CsharpEntity",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsProperty",
                table: "CsharpEntity",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<long>(
                name: "CsharpEnumId",
                table: "CsharpEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CsharpEnum_CsharpNamespaceId",
                table: "CsharpEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CsharpNamespaceId",
                table: "CsharpEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CsharpVariable_CsharpClassId",
                table: "CsharpEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CsharpEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EqualsValue",
                table: "CsharpEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsharpAstNodes",
                table: "CsharpAstNodes",
                column: "AstNodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsharpEntity",
                table: "CsharpEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEntity_AstNodeId",
                table: "CsharpEntity",
                column: "AstNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEntity_CsharpEnum_CsharpNamespaceId",
                table: "CsharpEntity",
                column: "CsharpEnum_CsharpNamespaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEntity_CsharpEnumId",
                table: "CsharpEntity",
                column: "CsharpEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEntity_CsharpNamespaceId",
                table: "CsharpEntity",
                column: "CsharpNamespaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEntity_CsharpVariable_CsharpClassId",
                table: "CsharpEntity",
                column: "CsharpVariable_CsharpClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpAstNodes_AstNodeId",
                table: "CsharpEntity",
                column: "AstNodeId",
                principalTable: "CsharpAstNodes",
                principalColumn: "AstNodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpClassId",
                table: "CsharpEntity",
                column: "CsharpClassId",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpEnum_CsharpNamespaceId",
                table: "CsharpEntity",
                column: "CsharpEnum_CsharpNamespaceId",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpEnumId",
                table: "CsharpEntity",
                column: "CsharpEnumId",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpMethodId",
                table: "CsharpEntity",
                column: "CsharpMethodId",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpMethodId1",
                table: "CsharpEntity",
                column: "CsharpMethodId1",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpNamespaceId",
                table: "CsharpEntity",
                column: "CsharpNamespaceId",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpVariable_CsharpClassId",
                table: "CsharpEntity",
                column: "CsharpVariable_CsharpClassId",
                principalTable: "CsharpEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpAstNodes_AstNodeId",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpClassId",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpEnum_CsharpNamespaceId",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpEnumId",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpMethodId",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpMethodId1",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpNamespaceId",
                table: "CsharpEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CsharpEntity_CsharpEntity_CsharpVariable_CsharpClassId",
                table: "CsharpEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsharpAstNodes",
                table: "CsharpAstNodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsharpEntity",
                table: "CsharpEntity");

            migrationBuilder.DropIndex(
                name: "IX_CsharpEntity_AstNodeId",
                table: "CsharpEntity");

            migrationBuilder.DropIndex(
                name: "IX_CsharpEntity_CsharpEnum_CsharpNamespaceId",
                table: "CsharpEntity");

            migrationBuilder.DropIndex(
                name: "IX_CsharpEntity_CsharpEnumId",
                table: "CsharpEntity");

            migrationBuilder.DropIndex(
                name: "IX_CsharpEntity_CsharpNamespaceId",
                table: "CsharpEntity");

            migrationBuilder.DropIndex(
                name: "IX_CsharpEntity_CsharpVariable_CsharpClassId",
                table: "CsharpEntity");

            migrationBuilder.DropColumn(
                name: "AstNodeId",
                table: "CsharpAstNodes");

            migrationBuilder.DropColumn(
                name: "CsharpEnumId",
                table: "CsharpEntity");

            migrationBuilder.DropColumn(
                name: "CsharpEnum_CsharpNamespaceId",
                table: "CsharpEntity");

            migrationBuilder.DropColumn(
                name: "CsharpNamespaceId",
                table: "CsharpEntity");

            migrationBuilder.DropColumn(
                name: "CsharpVariable_CsharpClassId",
                table: "CsharpEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CsharpEntity");

            migrationBuilder.DropColumn(
                name: "EqualsValue",
                table: "CsharpEntity");

            migrationBuilder.RenameTable(
                name: "CsharpEntity",
                newName: "CsharpVariable");

            migrationBuilder.RenameIndex(
                name: "IX_CsharpEntity_CsharpMethodId1",
                table: "CsharpVariable",
                newName: "IX_CsharpVariable_CsharpMethodId1");

            migrationBuilder.RenameIndex(
                name: "IX_CsharpEntity_CsharpMethodId",
                table: "CsharpVariable",
                newName: "IX_CsharpVariable_CsharpMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_CsharpEntity_CsharpClassId",
                table: "CsharpVariable",
                newName: "IX_CsharpVariable_CsharpClassId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CsharpAstNodes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "TypeHash",
                table: "CsharpVariable",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsProperty",
                table: "CsharpVariable",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsharpAstNodes",
                table: "CsharpAstNodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsharpVariable",
                table: "CsharpVariable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CsharpNamespaces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpNamespaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CsharpClasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    CsharpNamespaceId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpClasses_CsharpNamespaces_CsharpNamespaceId",
                        column: x => x.CsharpNamespaceId,
                        principalTable: "CsharpNamespaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CsharpEnums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    CsharpNamespaceId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpEnums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpEnums_CsharpNamespaces_CsharpNamespaceId",
                        column: x => x.CsharpNamespaceId,
                        principalTable: "CsharpNamespaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CsharpMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    CsharpClassId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    QualifiedType = table.Column<string>(type: "text", nullable: true),
                    TypeHash = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpMethod_CsharpClasses_CsharpClassId",
                        column: x => x.CsharpClassId,
                        principalTable: "CsharpClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CsharpEnumMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    CsharpEnumId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    EqualsValue = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpEnumMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpEnumMember_CsharpEnums_CsharpEnumId",
                        column: x => x.CsharpEnumId,
                        principalTable: "CsharpEnums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CsharpClasses_CsharpNamespaceId",
                table: "CsharpClasses",
                column: "CsharpNamespaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEnumMember_CsharpEnumId",
                table: "CsharpEnumMember",
                column: "CsharpEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpEnums_CsharpNamespaceId",
                table: "CsharpEnums",
                column: "CsharpNamespaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpMethod_CsharpClassId",
                table: "CsharpMethod",
                column: "CsharpClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpVariable_CsharpClasses_CsharpClassId",
                table: "CsharpVariable",
                column: "CsharpClassId",
                principalTable: "CsharpClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpVariable_CsharpMethod_CsharpMethodId",
                table: "CsharpVariable",
                column: "CsharpMethodId",
                principalTable: "CsharpMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CsharpVariable_CsharpMethod_CsharpMethodId1",
                table: "CsharpVariable",
                column: "CsharpMethodId1",
                principalTable: "CsharpMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

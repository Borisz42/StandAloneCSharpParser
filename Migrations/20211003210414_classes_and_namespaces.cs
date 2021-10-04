using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StandAloneCSharpParser.Migrations
{
    public partial class classes_and_namespaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sharpEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csharpAstNodes",
                table: "csharpAstNodes");

            migrationBuilder.DropColumn(
                name: "astType",
                table: "csharpAstNodes");

            migrationBuilder.DropColumn(
                name: "location_file",
                table: "csharpAstNodes");

            migrationBuilder.DropColumn(
                name: "symbolType",
                table: "csharpAstNodes");

            migrationBuilder.DropColumn(
                name: "visibleInSourceCode",
                table: "csharpAstNodes");

            migrationBuilder.RenameTable(
                name: "csharpAstNodes",
                newName: "CsharpAstNodes");

            migrationBuilder.RenameColumn(
                name: "rawKind",
                table: "CsharpAstNodes",
                newName: "RawKind");

            migrationBuilder.RenameColumn(
                name: "location_range_start_line",
                table: "CsharpAstNodes",
                newName: "Location_range_start_line");

            migrationBuilder.RenameColumn(
                name: "location_range_start_column",
                table: "CsharpAstNodes",
                newName: "Location_range_start_column");

            migrationBuilder.RenameColumn(
                name: "location_range_end_line",
                table: "CsharpAstNodes",
                newName: "Location_range_end_line");

            migrationBuilder.RenameColumn(
                name: "location_range_end_column",
                table: "CsharpAstNodes",
                newName: "Location_range_end_column");

            migrationBuilder.RenameColumn(
                name: "entityHash",
                table: "CsharpAstNodes",
                newName: "EntityHash");

            migrationBuilder.RenameColumn(
                name: "astValue",
                table: "CsharpAstNodes",
                newName: "AstValue");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CsharpAstNodes",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "CsharpAstNodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsharpAstNodes",
                table: "CsharpAstNodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CsharpNamespaces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true)
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
                    CsharpNamespaceId = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true)
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
                    CsharpNamespaceId = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true)
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
                    CsharpClassId = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    TypeHash = table.Column<long>(type: "bigint", nullable: false),
                    QualifiedType = table.Column<string>(type: "text", nullable: true)
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
                    EqualsValue = table.Column<int>(type: "integer", nullable: false),
                    CsharpEnumId = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CsharpVariable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsProperty = table.Column<bool>(type: "boolean", nullable: false),
                    CsharpClassId = table.Column<long>(type: "bigint", nullable: true),
                    CsharpMethodId = table.Column<long>(type: "bigint", nullable: true),
                    CsharpMethodId1 = table.Column<long>(type: "bigint", nullable: true),
                    AstNodeId = table.Column<long>(type: "bigint", nullable: false),
                    EntityHash = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QualifiedName = table.Column<string>(type: "text", nullable: true),
                    DocumentationCommentXML = table.Column<string>(type: "text", nullable: true),
                    TypeHash = table.Column<long>(type: "bigint", nullable: false),
                    QualifiedType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsharpVariable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsharpVariable_CsharpClasses_CsharpClassId",
                        column: x => x.CsharpClassId,
                        principalTable: "CsharpClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CsharpVariable_CsharpMethod_CsharpMethodId",
                        column: x => x.CsharpMethodId,
                        principalTable: "CsharpMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CsharpVariable_CsharpMethod_CsharpMethodId1",
                        column: x => x.CsharpMethodId1,
                        principalTable: "CsharpMethod",
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

            migrationBuilder.CreateIndex(
                name: "IX_CsharpVariable_CsharpClassId",
                table: "CsharpVariable",
                column: "CsharpClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpVariable_CsharpMethodId",
                table: "CsharpVariable",
                column: "CsharpMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CsharpVariable_CsharpMethodId1",
                table: "CsharpVariable",
                column: "CsharpMethodId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CsharpEnumMember");

            migrationBuilder.DropTable(
                name: "CsharpVariable");

            migrationBuilder.DropTable(
                name: "CsharpEnums");

            migrationBuilder.DropTable(
                name: "CsharpMethod");

            migrationBuilder.DropTable(
                name: "CsharpClasses");

            migrationBuilder.DropTable(
                name: "CsharpNamespaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsharpAstNodes",
                table: "CsharpAstNodes");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "CsharpAstNodes");

            migrationBuilder.RenameTable(
                name: "CsharpAstNodes",
                newName: "csharpAstNodes");

            migrationBuilder.RenameColumn(
                name: "RawKind",
                table: "csharpAstNodes",
                newName: "rawKind");

            migrationBuilder.RenameColumn(
                name: "Location_range_start_line",
                table: "csharpAstNodes",
                newName: "location_range_start_line");

            migrationBuilder.RenameColumn(
                name: "Location_range_start_column",
                table: "csharpAstNodes",
                newName: "location_range_start_column");

            migrationBuilder.RenameColumn(
                name: "Location_range_end_line",
                table: "csharpAstNodes",
                newName: "location_range_end_line");

            migrationBuilder.RenameColumn(
                name: "Location_range_end_column",
                table: "csharpAstNodes",
                newName: "location_range_end_column");

            migrationBuilder.RenameColumn(
                name: "EntityHash",
                table: "csharpAstNodes",
                newName: "entityHash");

            migrationBuilder.RenameColumn(
                name: "AstValue",
                table: "csharpAstNodes",
                newName: "astValue");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "csharpAstNodes",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "astType",
                table: "csharpAstNodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "location_file",
                table: "csharpAstNodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "symbolType",
                table: "csharpAstNodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "visibleInSourceCode",
                table: "csharpAstNodes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_csharpAstNodes",
                table: "csharpAstNodes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "sharpEntitys",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    astNodeId = table.Column<long>(type: "bigint", nullable: false),
                    entityHash = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    qualifiedName = table.Column<string>(type: "text", nullable: true),
                    qualifiedType = table.Column<string>(type: "text", nullable: true),
                    typeHash = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sharpEntitys", x => x.id);
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StandAloneCSharpParser.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "javaastnodes");

            migrationBuilder.CreateTable(
                name: "_csharpAstNodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    astValue = table.Column<string>(type: "text", nullable: true),
                    location_range_start_line = table.Column<long>(type: "bigint", nullable: false),
                    location_range_start_column = table.Column<long>(type: "bigint", nullable: false),
                    location_range_end_line = table.Column<long>(type: "bigint", nullable: false),
                    location_range_end_column = table.Column<long>(type: "bigint", nullable: false),
                    location_file = table.Column<long>(type: "bigint", nullable: false),
                    entityHash = table.Column<long>(type: "bigint", nullable: false),
                    rawKind = table.Column<int>(type: "integer", nullable: false),
                    symbolType = table.Column<int>(type: "integer", nullable: false),
                    astType = table.Column<int>(type: "integer", nullable: false),
                    visibleInSourceCode = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__csharpAstNodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_sharpEntitys",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    astNodeId = table.Column<long>(type: "bigint", nullable: false),
                    entityHash = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    qualifiedName = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    typeHash = table.Column<long>(type: "bigint", nullable: true),
                    qualifiedType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sharpEntitys", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_csharpAstNodes");

            migrationBuilder.DropTable(
                name: "_sharpEntitys");

            migrationBuilder.CreateTable(
                name: "javaastnodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entityHash = table.Column<long>(type: "bigint", nullable: false),
                    rawKind = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_javaastnodes", x => x.id);
                });
        }
    }
}

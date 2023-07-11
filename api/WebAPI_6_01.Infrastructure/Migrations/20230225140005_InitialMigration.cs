using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_6_01.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeSections",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameInRussian = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSections", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GeoObjectTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameInRussian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionInEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionInRussian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeSectionCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoObjectTypes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_GeoObjectTypes_TypeSections_TypeSectionCode",
                        column: x => x.TypeSectionCode,
                        principalTable: "TypeSections",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeoObjectTypes_TypeSectionCode",
                table: "GeoObjectTypes",
                column: "TypeSectionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoObjectTypes");

            migrationBuilder.DropTable(
                name: "TypeSections");
        }
    }
}

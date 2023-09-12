using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JpLoto.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loto6Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loto6Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loto7Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loto7Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiniLotoResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniLotoResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loto6Results");

            migrationBuilder.DropTable(
                name: "Loto7Results");

            migrationBuilder.DropTable(
                name: "MiniLotoResults");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JpLoto.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Prize1Value = table.Column<int>(type: "int", nullable: false),
                    Prize2Value = table.Column<int>(type: "int", nullable: false),
                    Prize3Value = table.Column<int>(type: "int", nullable: false),
                    Prize4Value = table.Column<int>(type: "int", nullable: false),
                    Prize5Value = table.Column<int>(type: "int", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numbers = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: true),
                    Bonus = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
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
                    Prize1Value = table.Column<int>(type: "int", nullable: false),
                    Prize2Value = table.Column<int>(type: "int", nullable: false),
                    Prize3Value = table.Column<int>(type: "int", nullable: false),
                    Prize4Value = table.Column<int>(type: "int", nullable: false),
                    Prize5Value = table.Column<int>(type: "int", nullable: false),
                    Prize6Value = table.Column<int>(type: "int", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numbers = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Bonus = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
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
                    Prize1Value = table.Column<int>(type: "int", nullable: false),
                    Prize2Value = table.Column<int>(type: "int", nullable: false),
                    Prize3Value = table.Column<int>(type: "int", nullable: false),
                    Prize4Value = table.Column<int>(type: "int", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numbers = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    Bonus = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniLotoResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ColorClass = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    NotBefore = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidThru = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationFactor = table.Column<int>(type: "int", nullable: false),
                    ExpirationDescriptor = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    TrialBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrialFinish = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: true),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PlanId",
                table: "Subscriptions",
                column: "PlanId");
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

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Trials");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}

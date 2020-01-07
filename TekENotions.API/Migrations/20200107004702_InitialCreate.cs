using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekENotions.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspiredPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Needles = table.Column<string>(nullable: true),
                    YarnWeight = table.Column<string>(nullable: true),
                    Yardage = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    RavelryURL = table.Column<string>(nullable: true),
                    Knitting = table.Column<bool>(nullable: false),
                    Crochet = table.Column<bool>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    RavelryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspiredPatterns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspiredPatterns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

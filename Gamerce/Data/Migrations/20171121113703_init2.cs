using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gamerce.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameSystemID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameSystems",
                columns: table => new
                {
                    GameSystemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductSystem = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSystems", x => x.GameSystemID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GameSystemID",
                table: "Products",
                column: "GameSystemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GameSystems_GameSystemID",
                table: "Products",
                column: "GameSystemID",
                principalTable: "GameSystems",
                principalColumn: "GameSystemID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GameSystems_GameSystemID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "GameSystems");

            migrationBuilder.DropIndex(
                name: "IX_Products_GameSystemID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GameSystemID",
                table: "Products");
        }
    }
}

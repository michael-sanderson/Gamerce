using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Gamerce.Data.Migrations
{
    public partial class ProuctTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeRequests");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    ConditionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCondition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.ConditionID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductGenre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "SaleStatuses",
                columns: table => new
                {
                    SaleStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductSaleStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleStatuses", x => x.SaleStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConditionID = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: false),
                    SaleStatusID = table.Column<int>(nullable: false),
                    System = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Conditions_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Conditions",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SaleStatuses_SaleStatusID",
                        column: x => x.SaleStatusID,
                        principalTable: "SaleStatuses",
                        principalColumn: "SaleStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ConditionID",
                table: "Products",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenreID",
                table: "Products",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleStatusID",
                table: "Products",
                column: "SaleStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "SaleStatuses");

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    PriorityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriorityLevel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.PriorityID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "ChangeRequests",
                columns: table => new
                {
                    ChangeRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BriefDescription = table.Column<string>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    PriorityID = table.Column<int>(nullable: false),
                    RequiredBy = table.Column<DateTime>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRequests", x => x.ChangeRequestID);
                    table.ForeignKey(
                        name: "FK_ChangeRequests_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "PriorityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeRequests_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeRequests_PriorityID",
                table: "ChangeRequests",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeRequests_StatusID",
                table: "ChangeRequests",
                column: "StatusID");
        }
    }
}

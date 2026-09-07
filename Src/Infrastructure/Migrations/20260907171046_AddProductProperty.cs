using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperties_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductProperties_AspNetUsers_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_CreatedBy",
                table: "ProductProperties",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ModifiedBy",
                table: "ProductProperties",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");
        }
    }
}

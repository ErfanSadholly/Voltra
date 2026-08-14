using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalExceptionHandler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EndpointName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RequestMethod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerException = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlPath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Queries = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");
        }
    }
}

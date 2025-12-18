using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeExpenseControl.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORY",
                columns: table => new
                {
                    ID_CATEGORY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CATEGORY_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATEGORY_PURPOSE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORY", x => x.ID_CATEGORY);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID_USER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USER_AGE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRANSACTION",
                columns: table => new
                {
                    ID_TRANSACTION = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TRANSACTION_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANSACTION_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TRANSACTION_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATEGORY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRANSACTION", x => x.ID_TRANSACTION);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTION_TB_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "TB_CATEGORY",
                        principalColumn: "ID_CATEGORY",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTION_TB_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "TB_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_CATEGORY_ID",
                table: "TB_TRANSACTION",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_USER_ID",
                table: "TB_TRANSACTION",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TB_CATEGORY");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}

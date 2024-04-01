using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chillpayGateway.Migrations
{
    public partial class create_PaymentHistory_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trn_payment_history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaidPoint = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    PointConversionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyConversionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChillpayTransactionId = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    ChillpayExpiredDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_payment_history", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trn_payment_history");
        }
    }
}

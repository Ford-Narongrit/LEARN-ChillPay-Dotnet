using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chillpayGateway.Migrations
{
    /// <inheritdoc />
    public partial class edit_orderId_to_unique_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "trn_payment_history",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_trn_payment_history_OrderId",
                table: "trn_payment_history",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_trn_payment_history_OrderId",
                table: "trn_payment_history");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "trn_payment_history",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

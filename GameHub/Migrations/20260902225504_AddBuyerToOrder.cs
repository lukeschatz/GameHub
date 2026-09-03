using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class AddBuyerToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Buyer_ID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Buyer_ID",
                table: "Orders",
                column: "Buyer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_Buyer_ID",
                table: "Orders",
                column: "Buyer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_Buyer_ID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Buyer_ID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Buyer_ID",
                table: "Orders");
        }
    }
}

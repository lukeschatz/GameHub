using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrderColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_Buyer_ID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_User_ID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Buyer_ID",
                table: "Orders",
                newName: "BuyerId");

            migrationBuilder.RenameColumn(
                name: "Account_Info_Private",
                table: "Orders",
                newName: "AccountInfoPrivate");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_User_ID",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Buyer_ID",
                table: "Orders",
                newName: "IX_Orders_BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_BuyerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Orders",
                newName: "Buyer_ID");

            migrationBuilder.RenameColumn(
                name: "AccountInfoPrivate",
                table: "Orders",
                newName: "Account_Info_Private");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_User_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                newName: "IX_Orders_Buyer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_Buyer_ID",
                table: "Orders",
                column: "Buyer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_User_ID",
                table: "Orders",
                column: "User_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

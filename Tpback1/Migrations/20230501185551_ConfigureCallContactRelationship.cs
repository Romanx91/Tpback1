using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tpback1.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCallContactRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calls_ContactId",
                table: "Calls");

            migrationBuilder.AddColumn<int>(
                name: "ContactsId",
                table: "Calls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ContactId",
                table: "Calls",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ContactsId",
                table: "Calls",
                column: "ContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_ContactsId",
                table: "Calls",
                column: "ContactsId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_ContactsId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_ContactId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_ContactsId",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "ContactsId",
                table: "Calls");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ContactId",
                table: "Calls",
                column: "ContactId");
        }
    }
}

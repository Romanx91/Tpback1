using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tpback1.Migrations
{
    /// <inheritdoc />
    public partial class problema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace farkli1001fikir.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateCardModelv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cards");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebAppCodeFirst.Migrations
{
    public partial class AddHasRadiotoCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasRadio",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasRadio",
                table: "Cars");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GoonsComicShop.Migrations
{
    public partial class updatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Comics",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Comics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

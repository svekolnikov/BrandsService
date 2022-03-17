using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrandsService.Migrations
{
    public partial class BrandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Brands_BrandId",
                table: "Sizes");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Brands_BrandId",
                table: "Sizes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Brands_BrandId",
                table: "Sizes");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Sizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Brands_BrandId",
                table: "Sizes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}

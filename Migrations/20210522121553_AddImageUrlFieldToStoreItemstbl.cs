using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOnlineStore.Migrations
{
    public partial class AddImageUrlFieldToStoreItemstbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "StoreItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "StoreItems");
        }
    }
}

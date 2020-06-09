using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionApp.api.Migrations
{
    public partial class addedPublicIdPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "UserPhotos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "CollectionGundamPhotos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "UserPhotos");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "CollectionGundamPhotos");
        }
    }
}

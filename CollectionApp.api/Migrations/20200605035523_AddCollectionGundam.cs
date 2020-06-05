using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionApp.api.Migrations
{
    public partial class AddCollectionGundam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionGundams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelName = table.Column<string>(nullable: true),
                    LaunchDate = table.Column<DateTime>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionGundams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionGundamPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    collectionGundamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionGundamPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionGundamPhotos_CollectionGundams_collectionGundamId",
                        column: x => x.collectionGundamId,
                        principalTable: "CollectionGundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionGundamPhotos_collectionGundamId",
                table: "CollectionGundamPhotos",
                column: "collectionGundamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionGundamPhotos");

            migrationBuilder.DropTable(
                name: "CollectionGundams");
        }
    }
}

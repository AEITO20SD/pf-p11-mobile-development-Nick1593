using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tamagotchi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    PetTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageTypes_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Attention = table.Column<int>(type: "INTEGER", nullable: false),
                    Nutrition = table.Column<int>(type: "INTEGER", nullable: false),
                    Sleep = table.Column<int>(type: "INTEGER", nullable: false),
                    Death = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PetTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 1, "Basic" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 1, 1, "Happy", "images.pets.basic.tamagotchi_happy.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 2, 1, "Neutral", "images.pets.basic.tamagotchi_normal.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 3, 1, "Sad", "images.pets.basic.tamagotchi_sad.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 4, 1, "Sleep", "images.pets.basic.tamagotchi_sleep.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 5, 1, "Dead", "images.pets.basic.tamagotchi_dead.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 6, 1, "Egg_Fase_1", "images.eggs.egg_fase_1.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 7, 1, "Egg_Fase_2", "images.eggs.egg_fase_2.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 8, 1, "Egg_Fase_3", "images.eggs.egg_fase_3.png" });

            migrationBuilder.InsertData(
                table: "ImageTypes",
                columns: new[] { "Id", "PetTypeId", "Tag", "URL" },
                values: new object[] { 9, 1, "Egg_Fase_4", "images.eggs.egg_fase_4.png" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_PetTypeId",
                table: "ImageTypes",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets",
                column: "PetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageTypes");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "PetTypes");
        }
    }
}

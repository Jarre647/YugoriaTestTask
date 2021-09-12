using Microsoft.EntityFrameworkCore.Migrations;

namespace YugoriaTestTask.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "SkinColors",
             columns: new[] { "Id", "SkinColorName" },
             values: new object[,]
             {
                    {1, "серый" },
                    {2, "белый" },
                    {3, "черный" },
                    {4, "коричневый" }
             });
            migrationBuilder.InsertData(
              table: "Regions",
              columns: new[] { "Id", "RegionName" },
              values: new object[,]
              {
                    {1, "Регион 1" },
                    {2, "Регион 2" },
                    {3, "Регион 3" },
                    {4, "Регион 4" }
              });
            migrationBuilder.InsertData(
              table: "Locations",
              columns: new[] { "Id", "LocationName" },
              values: new object[,]
              {
                    {1, "Место 1" },
                    {2, "Место 2" },
                    {3, "Место 3" },
                    {4, "Место 4" }
              });
            migrationBuilder.InsertData(
              table: "KindAnimals",
              columns: new[] { "Id", "KindAnimalName" },
              values: new object[,]
              {
                    {1, "Вид 1" },
                    {2, "Вид 2" },
                    {3, "Вид 3" },
                    {4, "Вид 4" }
              });
            migrationBuilder.InsertData(
              table: "Animals",
              columns: new[] { "Id", "AnimalName", "KindAnimalId", "LocationId", "RegionId", "SkinColorId" },
              values: new object[,]
              {
                    {1, "Животное 1", 1, 1, 1, 1 },
                    {2, "Животное 2", 1, 1, 2, 2 },
                    {3, "Животное 3", 2, 2, 1, 1 },
                    {4, "Животное 4", 1, 2, 2, 1 },
                    {5, "Животное 5", 3, 3, 2, 2 },
                    {6, "Животное 6", 2, 2, 3, 3 },
                    {7, "Животное 7", 4, 4, 4, 4 },
                    {8, "Животное 8", 2, 2, 2, 2 },
                    {9, "Животное 9", 4, 3, 2, 1 },
                    {10, "Животное 10", 1, 2, 3, 4 }
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

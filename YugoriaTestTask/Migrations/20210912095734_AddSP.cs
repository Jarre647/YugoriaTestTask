using Microsoft.EntityFrameworkCore.Migrations;
using YugoriaTestTask.Extensions;

namespace YugoriaTestTask.Migrations
{
    public partial class AddSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SQLFromFileForProcedure("SearchAnimal.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [SearchAnimal]");
        }
    }
}

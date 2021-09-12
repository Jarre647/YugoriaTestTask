using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace YugoriaTestTask.Extensions
{
    public static class BuilderExtensions
    {
        public static void SQLFromFileForProcedure(this MigrationBuilder builder, string filename)
        {
            string path = Directory.GetCurrentDirectory() + "/StoredProcedures/";
            builder.Sql(File.ReadAllText(path + filename));
        }
    }
}

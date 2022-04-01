using Microsoft.EntityFrameworkCore.Migrations;

namespace EventExplorer.Api.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categories () VALUES ();");
            migrationBuilder.Sql("INSERT INTO events () VALUES ();");
            migrationBuilder.Sql("INSERT INTO locations () VALUES ();");
            migrationBuilder.Sql("INSERT INTO organizers () VALUES ();");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categories WHERE ;");
            migrationBuilder.Sql("DELETE FROM events WHERE ;");
            migrationBuilder.Sql("DELETE FROM locations WHERE ;");
            migrationBuilder.Sql("DELETE FROM organizers WHERE ;");
        }
    }
}

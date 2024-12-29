using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS12___Migration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticleTag_ArticleId",
                table: "ArticleTag");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId_TagId",
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex
                (
                name: "IX_ArticleTag_ArticleId_TagId",
                table: "ArticleTag");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId",
                table: "ArticleTag",
                column: "ArticleId");
        }
    }
}

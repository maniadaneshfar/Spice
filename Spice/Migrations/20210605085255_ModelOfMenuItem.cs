using Microsoft.EntityFrameworkCore.Migrations;

namespace Spice.Migrations
{
    public partial class ModelOfMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Spicyness = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoeyId = table.Column<int>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    SubCategoeyId = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_Category_CategoeyId",
                        column: x => x.CategoeyId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItem_SubCategory_SubCategoeyId",
                        column: x => x.SubCategoeyId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoeyId",
                table: "MenuItem",
                column: "CategoeyId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_SubCategoeyId",
                table: "MenuItem",
                column: "SubCategoeyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");
        }
    }
}

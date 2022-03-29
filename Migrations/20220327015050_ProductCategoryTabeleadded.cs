using Microsoft.EntityFrameworkCore.Migrations;

namespace mobile_api.Migrations
{
    public partial class ProductCategoryTabeleadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryID",
                table: "products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductCategoryID",
                table: "products",
                column: "ProductCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductCategories_ProductCategoryID",
                table: "products",
                column: "ProductCategoryID",
                principalTable: "ProductCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductCategories_ProductCategoryID",
                table: "products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductCategoryID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryID",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "products",
                type: "TEXT",
                nullable: true);
        }
    }
}

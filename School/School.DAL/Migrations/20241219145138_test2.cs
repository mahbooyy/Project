using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_category_id_category",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_orders_OrdersDbId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_picture_product_PictureProductDbId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_id_category",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_OrdersDbId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_PictureProductDbId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "OrdersDbId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "PictureProductDbId",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "opisanie",
                table: "Products",
                newName: "Opisanie");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id_category",
                table: "Products",
                newName: "Id_Category");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "pathImg",
                table: "Products",
                newName: "PathImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_user = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_category = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    pathImg = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    opisanie = table.Column<string>(type: "text", nullable: true),
                    OrdersDbId = table.Column<Guid>(type: "uuid", nullable: true),
                    PictureProductDbId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_category_id_category",
                        column: x => x.id_category,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_orders_OrdersDbId",
                        column: x => x.OrdersDbId,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_picture_product_PictureProductDbId",
                        column: x => x.PictureProductDbId,
                        principalTable: "picture_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CartDbId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductsDbId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartDbId",
                        column: x => x.CartDbId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_products_ProductsDbId",
                        column: x => x.ProductsDbId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartDbId",
                table: "CartItems",
                column: "CartDbId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductsDbId",
                table: "CartItems",
                column: "ProductsDbId");

            migrationBuilder.CreateIndex(
                name: "IX_products_id_category",
                table: "products",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_products_OrdersDbId",
                table: "products",
                column: "OrdersDbId");

            migrationBuilder.CreateIndex(
                name: "IX_products_PictureProductDbId",
                table: "products",
                column: "PictureProductDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Opisanie",
                table: "products",
                newName: "opisanie");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id_Category",
                table: "products",
                newName: "id_category");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "products",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PathImage",
                table: "products",
                newName: "pathImg");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "products",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdersDbId",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PictureProductDbId",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_products_id_category",
                table: "products",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_products_OrdersDbId",
                table: "products",
                column: "OrdersDbId");

            migrationBuilder.CreateIndex(
                name: "IX_products_PictureProductDbId",
                table: "products",
                column: "PictureProductDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_category_id_category",
                table: "products",
                column: "id_category",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_orders_OrdersDbId",
                table: "products",
                column: "OrdersDbId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_picture_product_PictureProductDbId",
                table: "products",
                column: "PictureProductDbId",
                principalTable: "picture_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

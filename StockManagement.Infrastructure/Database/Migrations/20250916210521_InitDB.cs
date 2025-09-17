using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockManagement.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Reference);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Reference);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    EncodedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerRef = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Reference);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerRef",
                        column: x => x.CustomerRef,
                        principalTable: "Customers",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRef = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    ProductRef = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "MONEY", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderRef",
                        column: x => x.OrderRef,
                        principalTable: "Orders",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductRef",
                        column: x => x.ProductRef,
                        principalTable: "Products",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Reference", "Deleted", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { "BALO0001", false, "loic.baudoux@bstorm.be", "Loïc", "Baudoux", null },
                    { "COJU0001", false, "julien.coppin@bstorm.be", "Julien", "Coppin", null },
                    { "COJU0002", false, "julie@courtois.be", "Julie", "Courtois", null },
                    { "COJU0003", false, "jules@constant.be", "Jules", "Constant", null },
                    { "LAST0001", false, "steve.laurent@bstorm.be", "Steve", "Laurent", null },
                    { "LYKH0001", false, "lykhun@gmail.com", "Khun", "Ly", null },
                    { "LYPI0001", false, "piv.ly@bstorm.be", "Piv", "Ly", null },
                    { "MOTH0001", false, "tierry.morre@cognitic.be", "Thierry", "Morre", null },
                    { "OVFL0001", false, "flavian.ovyn@bstorm.be", "Flavian", "Ovyn", null },
                    { "PEMI0001", false, "michael.person@cognitic.be", "Mike", "Person", null },
                    { "PEMI0002", false, "michel@pedro.be", "Michel", "Pedro", null },
                    { "STAU0001", false, "aurelien.strimelle@bstorm.be", "Aurélien", "Strimelle", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Reference", "Deleted", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { "CARL0001", false, "CAN. 24X33cl", "Carlsberg 33cl", 32.4m, 1000 },
                    { "CHIM0001", false, "BOUT. 24X33cl", "Chimay Bleue 33cl", 45.6m, 1000 },
                    { "CHIM0002", false, "BOUT. 24X33cl", "Chimay Rouge 33cl", 45.6m, 1000 },
                    { "CHIM0003", false, "BOUT. 24X33cl", "Chimay Blanche 33cl", 30.24m, 1000 },
                    { "COCA0001", false, "CAN. 24X33cl", "Coca Cola 33cl", 16.8m, 1000 },
                    { "COCA0002", false, "CAN. 24X50cl", "Coca Cola 50cl", 19.92m, 1000 },
                    { "COCA0003", false, "BOUT. 6X1l", "Coca Cola 1l", 10.92m, 1000 },
                    { "EVIA0001", false, "BOUT. 8X1l", "Evian 1l", 8.96m, 1000 },
                    { "EVIA0002", false, "BOUT. 24X50cl", "Evian 50cl", 5.6m, 1000 },
                    { "FANT0001", false, "CAN. 24X33cl", "Fanta Orange 33cl", 16.8m, 1000 },
                    { "FANT0002", false, "CAN. 24X33cl", "Fanta Citron 33cl", 16.8m, 1000 },
                    { "FANT0003", false, "CAN. 24X50cl", "Fanta Orange 50cl", 16.8m, 1000 },
                    { "FANT0004", false, "CAN. 24X50cl", "Fanta Citron 50cl", 19.92m, 1000 },
                    { "JUPI0001", false, "CAN. 24X33cl", "Jupiler 33cl", 29.04m, 1000 },
                    { "JUPI0002", false, "CAN. 24X50cl", "Jupiler 50cl", 35.52m, 1000 },
                    { "NALU0001", false, "CAN. 24X25cl", "Nalu Vert 25cl", 16.8m, 1000 },
                    { "OASI0001", false, "BOUT. 6X2l", "Oasis Orange 2l", 13.44m, 1000 },
                    { "OASI0002", false, "BOUT. 6X2l", "Oasis Tropical 2l", 13.44m, 1000 },
                    { "VITT0001", false, "BOUT. 8X1l", "Vittel 1l", 8.72m, 1000 },
                    { "VITT0002", false, "BOUT. 24X50cl", "Vittel 50cl", 5.44m, 1000 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EncodedPassword", "Role" },
                values: new object[,]
                {
                    { 1, "admin@yopmail.com", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 96, 240, 90, 84, 232, 219, 216, 81, 35, 95, 61, 42, 78, 64, 163, 128, 22, 235, 163, 191, 31, 240, 51, 87, 22, 24, 214, 186, 177, 237, 222, 74 }, 0 },
                    { 2, "seller@yopmail.com", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 13, 182, 13, 16, 8, 49, 246, 54, 48, 166, 192, 136, 39, 231, 87, 81, 36, 143, 125, 239, 148, 34, 27, 162, 49, 24, 144, 171, 252, 73, 211, 188 }, 1 },
                    { 3, "restocker@yopmail.com", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 250, 245, 79, 68, 199, 90, 97, 103, 241, 243, 132, 98, 202, 190, 140, 216, 34, 238, 181, 14, 85, 55, 92, 83, 128, 64, 107, 214, 234, 169, 36, 223 }, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderRef",
                table: "OrderLines",
                column: "OrderRef");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductRef",
                table: "OrderLines",
                column: "ProductRef");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerRef",
                table: "Orders",
                column: "CustomerRef");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

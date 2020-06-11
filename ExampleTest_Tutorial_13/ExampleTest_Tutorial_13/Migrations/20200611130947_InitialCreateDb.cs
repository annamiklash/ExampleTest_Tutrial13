using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleTest_Tutorial_13.Migrations
{
    public partial class InitialCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "apbd_order");

            migrationBuilder.CreateTable(
                name: "Confectionery",
                schema: "apbd_order",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerItem = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Confectionery_pk", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "apbd_order",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Customer_pk", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "apbd_order",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_pk", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "apbd_order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "date", nullable: false),
                    DateFinished = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pk", x => x.IdOrder);
                    table.ForeignKey(
                        name: "Customer_Order",
                        column: x => x.IdCustomer,
                        principalSchema: "apbd_order",
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Employee_Order",
                        column: x => x.IdEmployee,
                        principalSchema: "apbd_order",
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                schema: "apbd_order",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdConfectionery, x.IdOrder });
                    table.ForeignKey(
                        name: "Confectionery_Confectionery_Order",
                        column: x => x.IdConfectionery,
                        principalSchema: "apbd_order",
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Order_Confectionery_Order",
                        column: x => x.IdOrder,
                        principalSchema: "apbd_order",
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                schema: "apbd_order",
                table: "Confectionery_Order",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCustomer",
                schema: "apbd_order",
                table: "Order",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployee",
                schema: "apbd_order",
                table: "Order",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order",
                schema: "apbd_order");

            migrationBuilder.DropTable(
                name: "Confectionery",
                schema: "apbd_order");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "apbd_order");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "apbd_order");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "apbd_order");
        }
    }
}

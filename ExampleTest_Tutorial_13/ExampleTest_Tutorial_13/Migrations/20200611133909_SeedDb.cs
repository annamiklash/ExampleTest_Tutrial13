using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleTest_Tutorial_13.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "apbd_order",
                table: "Confectionery",
                columns: new[] { "IdConfectionery", "Name", "PricePerItem", "Type" },
                values: new object[,]
                {
                    { 1, "Birthday Cake", 30.99f, "Cake" },
                    { 2, "Wedding Cake", 49.99f, "Cake" },
                    { 3, "Chocolate Muffin", 8.99f, "Muffin" },
                    { 4, "Caramel Brittle", 15.89f, "Brittle" }
                });

            migrationBuilder.InsertData(
                schema: "apbd_order",
                table: "Customer",
                columns: new[] { "IdCustomer", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Kelly", "Kapour" },
                    { 2, "Michael", "Scott" },
                    { 3, "Dwight", "Schrute" }
                });

            migrationBuilder.InsertData(
                schema: "apbd_order",
                table: "Employee",
                columns: new[] { "IdEmployee", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Jon", "Doe" },
                    { 2, "Anna", "Smith" },
                    { 3, "Jack", "Daniels" }
                });

            migrationBuilder.InsertData(
                schema: "apbd_order",
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdCustomer", "IdEmployee", "Notes" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "notes ccccc" },
                    { 2, new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "notes aaaaa" },
                    { 3, new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "notes bbbbb" },
                    { 5, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "notes slhgkdshk" },
                    { 4, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "notes qqqqq" }
                });

            migrationBuilder.InsertData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "happy bday", 1 },
                    { 1, 2, "happy anniversary", 2 },
                    { 2, 2, "happy retirement", 2 },
                    { 4, 3, "--", 1 },
                    { 2, 5, "happy 12 bday", 1 },
                    { 3, 4, "happy graduation", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Customer",
                keyColumn: "IdCustomer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Customer",
                keyColumn: "IdCustomer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Customer",
                keyColumn: "IdCustomer",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_order",
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGestor.Migrations
{
    public partial class AddOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrdersID",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductsID",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "NumOrder",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ProductsID",
                table: "OrderProduct",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "OrdersID",
                table: "OrderProduct",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsID",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Order",
                newName: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrderID",
                table: "OrderProduct",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductID",
                table: "OrderProduct",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderID",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductID",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderProduct",
                newName: "ProductsID");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrderProduct",
                newName: "OrdersID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsID");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Order",
                newName: "ProductID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "NumOrder",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrdersID",
                table: "OrderProduct",
                column: "OrdersID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductsID",
                table: "OrderProduct",
                column: "ProductsID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace InsurancePortal.Migrations
{
    public partial class EditedOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "OrderDetails");
        }
    }
}

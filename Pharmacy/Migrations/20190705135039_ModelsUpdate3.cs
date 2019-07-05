using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class ModelsUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Pesel",
                table: "Prescriptions",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pesel",
                table: "Prescriptions",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}

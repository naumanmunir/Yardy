using Microsoft.EntityFrameworkCore.Migrations;

namespace Yardy.Migrations
{
    public partial class modelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YardSales_UserProfiles_UserId",
                table: "YardSales");

            migrationBuilder.DropIndex(
                name: "IX_YardSales_UserId",
                table: "YardSales");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "YardSales",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SaleStartDateTime",
                table: "YardSales",
                newName: "SaleStart");

            migrationBuilder.RenameColumn(
                name: "SaleEndDateTime",
                table: "YardSales",
                newName: "SaleEnd");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "YardSales",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "YardSales",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "YardSales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserProfiles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "UserProfiles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "UserProfiles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "YardSales");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "YardSales");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "YardSales",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SaleStart",
                table: "YardSales",
                newName: "SaleStartDateTime");

            migrationBuilder.RenameColumn(
                name: "SaleEnd",
                table: "YardSales",
                newName: "SaleEndDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "YardSales",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YardSales_UserId",
                table: "YardSales",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_YardSales_UserProfiles_UserId",
                table: "YardSales",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

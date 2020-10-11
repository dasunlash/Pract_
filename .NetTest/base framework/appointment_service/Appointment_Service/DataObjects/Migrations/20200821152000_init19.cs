using Microsoft.EntityFrameworkCore.Migrations;

namespace DataObjects.Migrations
{
    public partial class init19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointedUser",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointedUserId",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointedUser",
                table: "Appointment",
                column: "AppointedUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_User_AppointedUser",
                table: "Appointment",
                column: "AppointedUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_User_AppointedUser",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_AppointedUser",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "AppointedUser",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "AppointedUserId",
                table: "Appointment");
        }
    }
}

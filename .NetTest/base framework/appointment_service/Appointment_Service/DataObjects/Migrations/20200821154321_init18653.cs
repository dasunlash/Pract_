using Microsoft.EntityFrameworkCore.Migrations;

namespace DataObjects.Migrations
{
    public partial class init18653 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointedUserId",
                table: "Appointment",
                column: "AppointedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_User_AppointedUserId",
                table: "Appointment",
                column: "AppointedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_User_AppointedUserId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_AppointedUserId",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "AppointedUser",
                table: "Appointment",
                type: "int",
                nullable: true);

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
    }
}

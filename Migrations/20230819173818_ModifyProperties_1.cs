using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProperties_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Game_GameId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Event",
                newName: "PlayerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Event_GameId",
                table: "Event",
                newName: "IX_Event_PlayerId1");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MetricId1",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_MetricId1",
                table: "Event",
                column: "MetricId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Analytic_MetricId1",
                table: "Event",
                column: "MetricId1",
                principalTable: "Analytic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Player_PlayerId1",
                table: "Event",
                column: "PlayerId1",
                principalTable: "Player",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Analytic_MetricId1",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Player_PlayerId1",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_MetricId1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "MetricId1",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "PlayerId1",
                table: "Event",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_PlayerId1",
                table: "Event",
                newName: "IX_Event_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Game_GameId",
                table: "Event",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");
        }
    }
}

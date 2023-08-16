using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Analytic",
                table: "Analytic");

            migrationBuilder.DropColumn(
                name: "AnalyticId",
                table: "Analytic");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Analytic",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Analytic",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analytic",
                table: "Analytic",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Analytic",
                table: "Analytic");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Analytic",
                newName: "EventId");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Analytic",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AnalyticId",
                table: "Analytic",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analytic",
                table: "Analytic",
                column: "AnalyticId");
        }
    }
}

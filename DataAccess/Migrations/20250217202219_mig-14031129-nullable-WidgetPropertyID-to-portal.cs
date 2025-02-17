using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig14031129nullableWidgetPropertyIDtoportal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portal_WidgetProperty_WidgetPropertyID",
                table: "Portal");

            migrationBuilder.AlterColumn<int>(
                name: "WidgetPropertyID",
                table: "Portal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Portal_WidgetProperty_WidgetPropertyID",
                table: "Portal",
                column: "WidgetPropertyID",
                principalTable: "WidgetProperty",
                principalColumn: "WidgetPropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portal_WidgetProperty_WidgetPropertyID",
                table: "Portal");

            migrationBuilder.AlterColumn<int>(
                name: "WidgetPropertyID",
                table: "Portal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Portal_WidgetProperty_WidgetPropertyID",
                table: "Portal",
                column: "WidgetPropertyID",
                principalTable: "WidgetProperty",
                principalColumn: "WidgetPropertyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

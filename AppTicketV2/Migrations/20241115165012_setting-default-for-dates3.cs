using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTicketV2.Migrations
{
    /// <inheritdoc />
    public partial class settingdefaultfordates3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedDateFa",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValueSql: "dbo.M2S(GETDATE())",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedDateFa",
                table: "Organizations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "dbo.M2S(GETDATE())");
        }
    }
}

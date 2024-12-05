using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTicketV2.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portal_Organization_OrgID",
                table: "Portal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portal_Organizations_OrgID",
                table: "Portal",
                column: "OrgID",
                principalTable: "Organizations",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portal_Organizations_OrgID",
                table: "Portal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portal_Organization_OrgID",
                table: "Portal",
                column: "OrgID",
                principalTable: "Organization",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

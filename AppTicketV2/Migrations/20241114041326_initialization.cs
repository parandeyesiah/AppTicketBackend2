using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTicketV2.Migrations
{
    /// <inheritdoc />
    public partial class initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    OperatorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.OperatorID);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateFa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    WidgetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WidgetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.WidgetID);
                });

            migrationBuilder.CreateTable(
                name: "WidgetProperty",
                columns: table => new
                {
                    WidgetPropertyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WidgetID = table.Column<int>(type: "int", nullable: false),
                    WidgetColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WidgetIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WidgetPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateFa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetProperty", x => x.WidgetPropertyID);
                });

            migrationBuilder.CreateTable(
                name: "OperatorRole",
                columns: table => new
                {
                    OperatorRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateFa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorRole", x => x.OperatorRoleID);
                    table.ForeignKey(
                        name: "FK_OperatorRole_Operator_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operator",
                        principalColumn: "OperatorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portal",
                columns: table => new
                {
                    PortalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortalUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPortalID = table.Column<int>(type: "int", nullable: false),
                    OrgID = table.Column<int>(type: "int", nullable: false),
                    WidgetPropertyID = table.Column<int>(type: "int", nullable: false),
                    WidgetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portal", x => x.PortalID);
                    table.ForeignKey(
                        name: "FK_Portal_Organization_OrgID",
                        column: x => x.OrgID,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portal_WidgetProperty_WidgetPropertyID",
                        column: x => x.WidgetPropertyID,
                        principalTable: "WidgetProperty",
                        principalColumn: "WidgetPropertyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portal_Widget_WidgetID",
                        column: x => x.WidgetID,
                        principalTable: "Widget",
                        principalColumn: "WidgetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatorRole_OperatorID",
                table: "OperatorRole",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorRole_RoleID",
                table: "OperatorRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Portal_OrgID",
                table: "Portal",
                column: "OrgID");

            migrationBuilder.CreateIndex(
                name: "IX_Portal_WidgetID",
                table: "Portal",
                column: "WidgetID");

            migrationBuilder.CreateIndex(
                name: "IX_Portal_WidgetPropertyID",
                table: "Portal",
                column: "WidgetPropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatorRole");

            migrationBuilder.DropTable(
                name: "Portal");

            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "WidgetProperty");

            migrationBuilder.DropTable(
                name: "Widget");
        }
    }
}

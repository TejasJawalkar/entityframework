using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    M_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    M_F_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    M_L_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    M_Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.M_Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Project_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrjectName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Project_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    E_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_F_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    E_L_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    M_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.E_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Managers_M_Id",
                        column: x => x.M_Id,
                        principalTable: "Managers",
                        principalColumn: "M_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EP_Id = table.Column<long>(type: "bigint", nullable: false),
                    E_Id = table.Column<long>(type: "bigint", nullable: false),
                    Projects_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => new { x.E_Id, x.Projects_Id, x.EP_Id });
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_E_Id",
                        column: x => x.E_Id,
                        principalTable: "Employees",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_Projects_Id",
                        column: x => x.Projects_Id,
                        principalTable: "Projects",
                        principalColumn: "Project_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EployeeDetails",
                columns: table => new
                {
                    E_D_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_Id = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EployeeDetails", x => x.E_D_Id);
                    table.ForeignKey(
                        name: "FK_EployeeDetails_Employees_E_Id",
                        column: x => x.E_Id,
                        principalTable: "Employees",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_Projects_Id",
                table: "EmployeeProjects",
                column: "Projects_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_M_Id",
                table: "Employees",
                column: "M_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EployeeDetails_E_Id",
                table: "EployeeDetails",
                column: "E_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "EployeeDetails");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHEAPRIDES.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    pId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.pId);
                });

            migrationBuilder.CreateTable(
                name: "CarRegShows",
                columns: table => new
                {
                    Carid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cRegNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pId = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avialability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRegShows", x => x.Carid);
                    table.ForeignKey(
                        name: "FK_CarRegShows_Persons_pId",
                        column: x => x.pId,
                        principalTable: "Persons",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLogin",
                columns: table => new
                {
                    pId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLogin", x => x.pId);
                    table.ForeignKey(
                        name: "FK_PersonLogin_Persons_pId",
                        column: x => x.pId,
                        principalTable: "Persons",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RideBookings",
                columns: table => new
                {
                    Bookingid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pickuplocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Droplocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false),
                    Carid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideBookings", x => x.Bookingid);
                    table.ForeignKey(
                        name: "FK_RideBookings_CarRegShows_Carid",
                        column: x => x.Carid,
                        principalTable: "CarRegShows",
                        principalColumn: "Carid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRegShows_pId",
                table: "CarRegShows",
                column: "pId");

            migrationBuilder.CreateIndex(
                name: "IX_RideBookings_Carid",
                table: "RideBookings",
                column: "Carid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLogin");

            migrationBuilder.DropTable(
                name: "RideBookings");

            migrationBuilder.DropTable(
                name: "CarRegShows");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

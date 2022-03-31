using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDPT.Application.GraphQL.Migrations
{
    public partial class UpdateHousing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Housings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsMin = table.Column<int>(type: "int", nullable: false),
                    RoomsMax = table.Column<int>(type: "int", nullable: false),
                    AvailableTimeEarliest = table.Column<long>(type: "bigint", nullable: false),
                    AvailableTimeLatest = table.Column<long>(type: "bigint", nullable: false),
                    WithParking = table.Column<bool>(type: "bit", nullable: false),
                    IndependentWashroom = table.Column<bool>(type: "bit", nullable: false),
                    HousingType = table.Column<int>(type: "int", nullable: false),
                    AllowPets = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Housings");
        }
    }
}

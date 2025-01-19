using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CannaWatch.Migrations
{
    /// <inheritdoc />
    public partial class StrainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strains",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThcLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelaxedValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HappyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EuphoricValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpliftedValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SleepyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DryMouthValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DryEyeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DizzyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParanoidValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnxiousValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StressValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PainValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepressionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnxietyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsonmiaValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strains");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisaoDoTempo.Infra.Migrations
{
    public partial class ajustebanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Previsao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Previsao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Previsao");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Previsao");
        }
    }
}

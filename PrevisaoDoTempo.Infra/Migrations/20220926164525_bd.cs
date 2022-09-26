using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisaoDoTempo.Infra.Migrations
{
    public partial class bd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Previsao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperaturaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperaturaMinina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataHoraPrevisao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previsao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Previsao");
        }
    }
}

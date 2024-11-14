using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitutoBack.Migrations
{
    /// <inheritdoc />
    public partial class PeriodoHorariosEnHorarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         



      

            migrationBuilder.UpdateData(
                table: "inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2024, 11, 14, 8, 30, 19, 964, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "turnosexamenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CicloLectivoId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_horarios_periodoshorarios_PeriodoHorarioId",
                table: "horarios",
                column: "PeriodoHorarioId",
                principalTable: "periodoshorarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horarios_periodoshorarios_PeriodoHorarioId",
                table: "horarios");

            migrationBuilder.RenameColumn(
                name: "PeriodoHorarioId",
                table: "horarios",
                newName: "CicloLectivoId");

            migrationBuilder.RenameIndex(
                name: "IX_horarios_PeriodoHorarioId",
                table: "horarios",
                newName: "IX_horarios_CicloLectivoId");

            migrationBuilder.UpdateData(
                table: "inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2024, 10, 30, 21, 13, 44, 833, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "turnosexamenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CicloLectivoId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_horarios_cicloslectivos_CicloLectivoId",
                table: "horarios",
                column: "CicloLectivoId",
                principalTable: "cicloslectivos",
                principalColumn: "Id");
        }
    }
}

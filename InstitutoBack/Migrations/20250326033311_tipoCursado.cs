using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitutoBack.Migrations
{
    /// <inheritdoc />
    public partial class tipoCursado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMateria",
                table: "materias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCursado",
                table: "detallesinscripciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "detallesinscripciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoCursado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 3, 26, 0, 33, 9, 298, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 6,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 7,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 8,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 9,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 10,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 11,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 12,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 13,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 14,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 15,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 16,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 17,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 18,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 19,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 20,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 21,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 22,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 23,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 24,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 25,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 26,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 27,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 28,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 29,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 30,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 31,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 32,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 33,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 34,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 35,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 36,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 37,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 38,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 39,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 40,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 41,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 42,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 43,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 44,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 45,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 46,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 47,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 48,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 49,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 50,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 51,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 52,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 53,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 54,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 55,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 56,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 57,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 58,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 59,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 60,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 61,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 62,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 63,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 64,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 65,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 66,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 67,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 68,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 69,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 70,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 71,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 72,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 73,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 74,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 75,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 76,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 77,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 78,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 79,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 80,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 81,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 82,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 83,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 84,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 85,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 86,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 87,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 88,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 89,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 90,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 91,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 92,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 93,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 94,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 95,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 96,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 97,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 98,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 99,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 100,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 101,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 102,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 103,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 104,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 105,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 106,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 107,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 108,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 109,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 110,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 111,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 112,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 113,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 114,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 115,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 116,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 117,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 118,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 119,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 120,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 121,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 122,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 123,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 124,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 125,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 126,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 127,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 128,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 129,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 130,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 131,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 132,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 133,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 134,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 135,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 136,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 137,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 138,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 139,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 140,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 141,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 142,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 143,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 144,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 145,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 146,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 147,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 148,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 149,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 150,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 151,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 152,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 153,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 154,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 155,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 156,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 157,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 158,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 159,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 160,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 161,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 162,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 163,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 164,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 165,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 166,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 167,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 168,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 169,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 170,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 171,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 172,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 173,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 174,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 175,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 176,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 177,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 178,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 179,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 180,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 181,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 182,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 183,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 184,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 185,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 186,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 187,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 188,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 189,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 190,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 191,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 192,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 193,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 194,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 195,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 196,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 197,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 198,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 199,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 200,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 201,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 202,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 203,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 204,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 205,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 206,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 207,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 208,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 209,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 210,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 211,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 212,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 213,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 214,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 215,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 216,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 217,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 218,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 219,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 220,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 221,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 222,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 223,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 224,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 225,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 226,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 227,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 228,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 229,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 230,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 231,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 232,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 233,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 234,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 235,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 236,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 237,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 238,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 239,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 240,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 241,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 242,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 243,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 244,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 245,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 246,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 247,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 248,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 249,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 250,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 251,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 252,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 253,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 254,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 255,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 256,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 257,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 258,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 259,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 260,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 261,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 262,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 263,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 264,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 265,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 266,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 267,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 268,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 269,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 270,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 271,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 272,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 273,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 274,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 275,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 276,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 277,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 278,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 279,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 280,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 281,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 282,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 283,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 284,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 285,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 286,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 287,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 288,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 289,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 290,
                column: "TipoMateria",
                value: 0);

            migrationBuilder.UpdateData(
                table: "materias",
                keyColumn: "Id",
                keyValue: 291,
                column: "TipoMateria",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMateria",
                table: "materias");

            migrationBuilder.DropColumn(
                name: "TipoCursado",
                table: "detallesinscripciones");

            migrationBuilder.UpdateData(
                table: "inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 3, 25, 19, 53, 3, 999, DateTimeKind.Local).AddTicks(6642));
        }
    }
}

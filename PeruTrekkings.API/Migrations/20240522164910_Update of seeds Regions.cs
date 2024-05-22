using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeruTrekkings.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateofseedsRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("853696d0-49c4-4479-91c3-19e1fcaebfcc"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "LBY", "Lambayeque" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "TRU", "Trujillo" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "PIU", "Piura" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("853696d0-49c4-4479-91c3-19e1fcaebfcc"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "RCH", "Ruta Chimu - Lambayeque" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "RMC", "Ruta Moche" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "PSH", "Piura Sechura" });
        }
    }
}

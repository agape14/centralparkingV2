using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBD.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToTbFormCotizanos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "tipoAbonado",
            table: "tb_form_cotizanos",
            type: "varchar(30)",
            nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estacionamiento",
                table: "tb_form_cotizanos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "tb_form_cotizanos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "tipoAbonado",
            table: "tb_form_cotizanos");

            migrationBuilder.DropColumn(
                name: "estacionamiento",
                table: "tb_form_cotizanos");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "tb_form_cotizanos");
        }
    }
}

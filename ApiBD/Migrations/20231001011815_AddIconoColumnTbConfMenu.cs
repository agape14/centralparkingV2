using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBD.Migrations
{
    /// <inheritdoc />
    public partial class AddIconoColumnTbConfMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "icono",
            table: "tb_conf_menu",
            type: "varchar(80)",
            nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "icono",
            table: "tb_conf_menu");
        }
    }
}

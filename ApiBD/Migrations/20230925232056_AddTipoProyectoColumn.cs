using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBD.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoProyectoColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "tipoProyecto",
            table: "tb_conf_menu",
            type: "char(3)",
            nullable: true,
            defaultValue: "web");
            migrationBuilder.Sql("COMMENT ON COLUMN tb_conf_menu.tipoProyecto IS 'web, cms'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "tipoProyecto",
            table: "tb_conf_menu");
        }
    }
}

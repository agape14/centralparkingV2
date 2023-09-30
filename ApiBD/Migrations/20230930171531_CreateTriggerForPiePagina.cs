using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBD.Migrations
{
    /// <inheritdoc />
    public partial class CreateTriggerForPiePagina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER `tr_actualizar_piepagina` AFTER UPDATE ON `tb_conf_modalcab`
            FOR EACH ROW BEGIN
              UPDATE tb_conf_piepaginadet
              SET titulo = NEW.titulo,
                  ruta = NEW.btn_ruta
              WHERE id = NEW.idDetallePie;
            END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER `tr_actualizar_piepagina`");
        }
    }
}

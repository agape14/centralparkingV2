using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBD.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposTablaConfEntidad : Migration
    {
        /// <inheritdoc />
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE tb_conf_entidad
                ADD COLUMN servidor VARCHAR(120),
                ADD COLUMN puerto INT,
                ADD COLUMN correoNotifica VARCHAR(180),
                ADD COLUMN claveNotifica VARCHAR(250),
                ADD COLUMN correoConCopia VARCHAR(180);
            ");
        }
    }
}

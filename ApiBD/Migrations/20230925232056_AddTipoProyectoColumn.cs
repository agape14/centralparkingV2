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
            if (!migrationBuilder.ActiveProvider.Equals("Microsoft.EntityFrameworkCore.MySql"))
            {
                bool columnExists = migrationBuilder.Sql(@"SELECT COUNT(*) 
                    FROM information_schema.columns 
                    WHERE table_name = 'tb_conf_menu' 
                    AND column_name = 'tipoProyecto' 
                    AND table_schema = 'centralparking';").ToString() == "1";
                if (!columnExists)
                {
                    migrationBuilder.AddColumn<string>(
                            name: "tipoProyecto",
                            table: "tb_conf_menu",
                            type: "char(3)",
                            nullable: true,
                            defaultValue: "web");
                    migrationBuilder.Sql("COMMENT ON COLUMN tb_conf_menu.tipoProyecto IS 'web, cms'");
                }
            }
                
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

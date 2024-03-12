using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBD.Migrations
{
    /// <inheritdoc />
    public partial class CreateUbigeoServicioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Iniciales",
                table: "tb_serv_cabecera",
                type: "longtext",
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "prov",
                table: "tb_conf_ubigeo",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "dpto",
                table: "tb_conf_ubigeo",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "dist",
                table: "tb_conf_ubigeo",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "tb_conf_menu",
                type: "longtext",
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "tb_conf_ubigeo",
                column: "codUbi");

            migrationBuilder.CreateTable(
                name: "tb_conf_ubigeo_servicio",
                columns: table => new
                {
                    codUbi = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    idServicio = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.codUbi, x.idServicio });
                    table.ForeignKey(
                        name: "tb_conf_ubigeo_servicio_ibfk_1",
                        column: x => x.codUbi,
                        principalTable: "tb_conf_ubigeo",
                        principalColumn: "codUbi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tb_conf_ubigeo_servicio_ibfk_2",
                        column: x => x.idServicio,
                        principalTable: "tb_serv_cabecera",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tb_conf_ubigeo_servicio_idServicio",
                table: "tb_conf_ubigeo_servicio",
                column: "idServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_conf_ubigeo_servicio");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "tb_conf_ubigeo");

            migrationBuilder.DropColumn(
                name: "Iniciales",
                table: "tb_serv_cabecera");

            migrationBuilder.DropColumn(
                name: "Icono",
                table: "tb_conf_menu");

            migrationBuilder.AlterColumn<string>(
                name: "prov",
                table: "tb_conf_ubigeo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "dpto",
                table: "tb_conf_ubigeo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "dist",
                table: "tb_conf_ubigeo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");
        }
    }
}

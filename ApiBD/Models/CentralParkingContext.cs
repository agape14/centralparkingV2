using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Models;

public partial class CentralParkingContext : DbContext
{
    public CentralParkingContext()
    {
    }

    public CentralParkingContext(DbContextOptions<CentralParkingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbConfBanco> TbConfBancos { get; set; }

    public virtual DbSet<TbConfBotone> TbConfBotones { get; set; }

    public virtual DbSet<TbConfDocelectronico> TbConfDocelectronicos { get; set; }

    public virtual DbSet<TbConfEntidad> TbConfEntidads { get; set; }

    public virtual DbSet<TbConfMenu> TbConfMenus { get; set; }

    public virtual DbSet<TbConfModalcab> TbConfModalcabs { get; set; }

    public virtual DbSet<TbConfModaldet> TbConfModaldets { get; set; }

    public virtual DbSet<TbConfMonedum> TbConfMoneda { get; set; }

    public virtual DbSet<TbConfPaginascab> TbConfPaginascabs { get; set; }

    public virtual DbSet<TbConfPaginasdet> TbConfPaginasdets { get; set; }

    public virtual DbSet<TbConfPermiso> TbConfPermisos { get; set; }

    public virtual DbSet<TbConfPersona> TbConfPersonas { get; set; }

    public virtual DbSet<TbConfPiepaginacab> TbConfPiepaginacabs { get; set; }

    public virtual DbSet<TbConfPiepaginadet> TbConfPiepaginadets { get; set; }

    public virtual DbSet<TbConfRole> TbConfRoles { get; set; }

    public virtual DbSet<TbConfTimepago> TbConfTimepagos { get; set; }

    public virtual DbSet<TbConfTipomenu> TbConfTipomenus { get; set; }

    public virtual DbSet<TbConfTipopago> TbConfTipopagos { get; set; }

    public virtual DbSet<TbConfUbigeo> TbConfUbigeos { get; set; }

    public virtual DbSet<TbConfUser> TbConfUsers { get; set; }

    public virtual DbSet<TbFormContactano> TbFormContactanos { get; set; }

    public virtual DbSet<TbFormHojareclamacione> TbFormHojareclamaciones { get; set; }

    public virtual DbSet<TbFormParkingcard> TbFormParkingcards { get; set; }

    public virtual DbSet<TbFormProveedore> TbFormProveedores { get; set; }

    public virtual DbSet<TbFormServicio> TbFormServicios { get; set; }

    public virtual DbSet<TbFormTbcnosotro> TbFormTbcnosotros { get; set; }

    public virtual DbSet<TbIndCaracteristica> TbIndCaracteristicas { get; set; }

    public virtual DbSet<TbIndRedsocial> TbIndRedsocials { get; set; }

    public virtual DbSet<TbIndServiciocab> TbIndServiciocabs { get; set; }

    public virtual DbSet<TbIndServiciodet> TbIndServiciodets { get; set; }

    public virtual DbSet<TbIndSlidecab> TbIndSlidecabs { get; set; }

    public virtual DbSet<TbNosCabecera> TbNosCabeceras { get; set; }

    public virtual DbSet<TbNosDetalle> TbNosDetalles { get; set; }

    public virtual DbSet<TbProvRegistro> TbProvRegistros { get; set; }

    public virtual DbSet<TbServCabecera> TbServCabeceras { get; set; }

    public virtual DbSet<TbServDetalle> TbServDetalles { get; set; }

    public virtual DbSet<TbServFormulario> TbServFormularios { get; set; }

    public virtual DbSet<TbTraPuesto> TbTraPuestos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseMySql("server=localhost;port=3310;user=root;password=admin;database=centralparking", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.19-mariadb"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbConfBanco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_banco")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Banco)
                .HasMaxLength(120)
                .HasColumnName("banco");
        });

        modelBuilder.Entity<TbConfBotone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_botones")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BtnClase)
                .HasMaxLength(100)
                .HasColumnName("btnClase");
            entity.Property(e => e.BtnRuta)
                .HasMaxLength(120)
                .HasColumnName("btnRuta");
            entity.Property(e => e.BtnTitulo)
                .HasMaxLength(50)
                .HasColumnName("btnTitulo");
            entity.Property(e => e.Icono)
                .HasMaxLength(80)
                .HasColumnName("icono");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(11)")
                .HasColumnName("menu_id");
            entity.Property(e => e.Orden)
                .HasColumnType("int(11)")
                .HasColumnName("orden");
            entity.Property(e => e.PaginadetId)
                .HasColumnType("int(11)")
                .HasColumnName("paginadet_id");
        });

        modelBuilder.Entity<TbConfDocelectronico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_docelectronico")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DocumentoElectronico)
                .HasMaxLength(100)
                .HasColumnName("documentoElectronico");
        });

        modelBuilder.Entity<TbConfEntidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_entidad")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Celular)
                .HasMaxLength(12)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("direccion");
            entity.Property(e => e.Favicon)
                .HasMaxLength(80)
                .HasColumnName("favicon");
            entity.Property(e => e.Horario)
                .HasMaxLength(150)
                .HasColumnName("horario");
            entity.Property(e => e.LogoBlanco)
                .HasMaxLength(180)
                .HasColumnName("logoBlanco");
            entity.Property(e => e.LogoMini)
                .HasMaxLength(180)
                .HasColumnName("logoMini");
            entity.Property(e => e.LogoOscuro)
                .HasMaxLength(180)
                .HasColumnName("logoOscuro");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.NameComercial)
                .HasMaxLength(250)
                .HasColumnName("nameComercial");
            entity.Property(e => e.RedesSociales).HasColumnName("redesSociales");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.RutaPagWeb)
                .HasColumnType("text")
                .HasColumnName("rutaPagWeb");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TbConfMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_menu")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Idtipomenu, "menu_ibfk_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Acceso)
                .HasColumnType("int(11)")
                .HasColumnName("acceso");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("estado");
            entity.Property(e => e.Idtipomenu)
                .HasColumnType("int(11)")
                .HasColumnName("idtipomenu");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Padre)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("padre");
            entity.Property(e => e.Ruta)
                .HasMaxLength(120)
                .HasColumnName("ruta");

            entity.HasOne(d => d.IdtipomenuNavigation).WithMany(p => p.TbConfMenus)
                .HasForeignKey(d => d.Idtipomenu)
                .HasConstraintName("tb_conf_menu_ibfk_1");
        });

        modelBuilder.Entity<TbConfModalcab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_modalcab")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BtnRuta)
                .HasMaxLength(250)
                .HasColumnName("btn_ruta");
            entity.Property(e => e.Estado)
                .HasColumnType("int(11)")
                .HasColumnName("estado");
            entity.Property(e => e.IdDetallePie)
                .HasColumnType("int(11)")
                .HasColumnName("idDetallePie");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbConfModaldet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_modaldet")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Link)
                .HasColumnType("text")
                .HasColumnName("link");
            entity.Property(e => e.ModalcabId)
                .HasColumnType("int(11)")
                .HasColumnName("modalcab_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbConfMonedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_moneda")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Moneda)
                .HasMaxLength(100)
                .HasColumnName("moneda");
        });

        modelBuilder.Entity<TbConfPaginascab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_paginascab")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ImagenMision)
                .HasMaxLength(250)
                .HasColumnName("imagenMision");
            entity.Property(e => e.ImagenValores)
                .HasMaxLength(250)
                .HasColumnName("imagenValores");
            entity.Property(e => e.MisionDetalle)
                .HasColumnType("text")
                .HasColumnName("misionDetalle");
            entity.Property(e => e.MisionTitulo)
                .HasMaxLength(250)
                .HasColumnName("misionTitulo");
            entity.Property(e => e.ReconocDetalle)
                .HasColumnType("text")
                .HasColumnName("reconocDetalle");
            entity.Property(e => e.ReconocTitulo)
                .HasMaxLength(250)
                .HasColumnName("reconocTitulo");
            entity.Property(e => e.ReseniaDetalle)
                .HasColumnType("text")
                .HasColumnName("reseniaDetalle");
            entity.Property(e => e.ReseniaTitulo)
                .HasMaxLength(250)
                .HasColumnName("reseniaTitulo");
            entity.Property(e => e.Subtitulo)
                .HasMaxLength(250)
                .HasColumnName("subtitulo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
            entity.Property(e => e.ValoresDetalle)
                .HasColumnType("text")
                .HasColumnName("valoresDetalle");
            entity.Property(e => e.ValoresTitulo)
                .HasMaxLength(250)
                .HasColumnName("valoresTitulo");
            entity.Property(e => e.VisionDetalle)
                .HasColumnType("text")
                .HasColumnName("visionDetalle");
            entity.Property(e => e.VisionTitulo)
                .HasMaxLength(250)
                .HasColumnName("visionTitulo");
        });

        modelBuilder.Entity<TbConfPaginasdet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_paginasdet")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("detalle");
            entity.Property(e => e.Imagen)
                .HasMaxLength(250)
                .HasColumnName("imagen");
            entity.Property(e => e.PaginaId)
                .HasColumnType("int(11)")
                .HasColumnName("pagina_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbConfPermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_permisos")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.MenuId, "permisos_ibfk_1");

            entity.HasIndex(e => e.RolId, "permisos_ibfk_2");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Creacion)
                .HasColumnType("datetime")
                .HasColumnName("creacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("estado");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(11)")
                .HasColumnName("menu_id");
            entity.Property(e => e.Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("modificacion");
            entity.Property(e => e.Permiso)
                .HasMaxLength(80)
                .HasColumnName("permiso");
            entity.Property(e => e.RolId)
                .HasColumnType("int(11)")
                .HasColumnName("rol_id");

            entity.HasOne(d => d.Menu).WithMany(p => p.TbConfPermisos)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("tb_conf_permisos_ibfk_1");

            entity.HasOne(d => d.Rol).WithMany(p => p.TbConfPermisos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("tb_conf_permisos_ibfk_2");
        });

        modelBuilder.Entity<TbConfPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_personas")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CodDistrito, "codDistrito");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApMaterno).HasMaxLength(250);
            entity.Property(e => e.ApPaterno).HasMaxLength(250);
            entity.Property(e => e.Cargo)
                .HasMaxLength(250)
                .HasColumnName("cargo");
            entity.Property(e => e.Celular)
                .HasMaxLength(11)
                .HasColumnName("celular");
            entity.Property(e => e.CodDistrito)
                .HasMaxLength(6)
                .HasColumnName("codDistrito");
            entity.Property(e => e.CodPostal)
                .HasMaxLength(8)
                .HasColumnName("codPostal");
            entity.Property(e => e.CodRubro)
                .HasColumnType("int(11)")
                .HasColumnName("codRubro");
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni");
            entity.Property(e => e.Fax).HasMaxLength(11);
            entity.Property(e => e.Nombres).HasMaxLength(250);
            entity.Property(e => e.RazonSocial).HasMaxLength(250);
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono).HasMaxLength(7);
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(1)
                .HasComment("N: Natural, J:Juridica")
                .HasColumnName("tipoPersona");
            entity.Property(e => e.TipoRegistro)
                .HasComment("1:Solicitante,2:InforFiscal,3:RepresLegal,4:ContactoComer,5:Cobranza")
                .HasColumnType("int(11)")
                .HasColumnName("tipoRegistro");
        });

        modelBuilder.Entity<TbConfPiepaginacab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_piepaginacab")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasColumnType("int(11)")
                .HasColumnName("estado");
            entity.Property(e => e.Imagen)
                .HasMaxLength(250)
                .HasColumnName("imagen");
            entity.Property(e => e.Orden)
                .HasColumnType("int(11)")
                .HasColumnName("orden");
            entity.Property(e => e.Titulo)
                .HasMaxLength(180)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbConfPiepaginadet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_piepaginadet")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.Imagen)
                .HasMaxLength(250)
                .HasColumnName("imagen");
            entity.Property(e => e.PiepaginaId)
                .HasColumnType("int(11)")
                .HasColumnName("piepagina_id");
            entity.Property(e => e.Ruta)
                .HasMaxLength(250)
                .HasColumnName("ruta");
            entity.Property(e => e.TipoRuta)
                .HasComment("1: Link nueva pestaña; 2: Modal")
                .HasColumnType("int(11)")
                .HasColumnName("tipo_ruta");
            entity.Property(e => e.Titulo)
                .HasMaxLength(180)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbConfRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_roles")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Creacion)
                .HasColumnType("datetime")
                .HasColumnName("creacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("estado");
            entity.Property(e => e.Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("modificacion");
            entity.Property(e => e.PermisoId)
                .HasColumnType("int(11)")
                .HasColumnName("permiso_id");
            entity.Property(e => e.Rol)
                .HasMaxLength(120)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<TbConfTimepago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_timepago")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TimePago)
                .HasMaxLength(50)
                .HasColumnName("timePago");
        });

        modelBuilder.Entity<TbConfTipomenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_tipomenu")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .HasColumnName("descripcion");
            entity.Property(e => e.Opcion)
                .HasMaxLength(20)
                .HasColumnName("opcion");
        });

        modelBuilder.Entity<TbConfTipopago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_tipopago")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(100)
                .HasColumnName("tipoPago");
        });

        modelBuilder.Entity<TbConfUbigeo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_conf_ubigeo")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CodUbi, "codUbi");

            entity.Property(e => e.CodUbi)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnName("codUbi");
            entity.Property(e => e.Dist)
                .HasMaxLength(100)
                .HasColumnName("dist");
            entity.Property(e => e.Dpto)
                .HasMaxLength(100)
                .HasColumnName("dpto");
            entity.Property(e => e.Prov)
                .HasMaxLength(100)
                .HasColumnName("prov");
        });

        modelBuilder.Entity<TbConfUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_conf_users")
                .HasCharSet("utf8")
                .UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => e.RolId, "users_ibfk_1");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Amaterno)
                .HasMaxLength(250)
                .HasColumnName("amaterno");
            entity.Property(e => e.Apaterno)
                .HasMaxLength(250)
                .HasColumnName("apaterno");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentTeamId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("current_team_id");
            entity.Property(e => e.Dni)
                .HasMaxLength(12)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerifiedAt)
                .HasColumnType("timestamp")
                .HasColumnName("email_verified_at");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePhotoPath)
                .HasMaxLength(2048)
                .HasColumnName("profile_photo_path");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.RolId)
                .HasColumnType("int(11)")
                .HasColumnName("rol_id");
            entity.Property(e => e.TwoFactorConfirmedAt)
                .HasColumnType("timestamp")
                .HasColumnName("two_factor_confirmed_at");
            entity.Property(e => e.TwoFactorRecoveryCodes)
                .HasColumnType("text")
                .HasColumnName("two_factor_recovery_codes");
            entity.Property(e => e.TwoFactorSecret)
                .HasColumnType("text")
                .HasColumnName("two_factor_secret");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Rol).WithMany(p => p.TbConfUsers)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("tb_conf_users_ibfk_1");
        });

        modelBuilder.Entity<TbFormContactano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tb_form_contactanos");

            entity.HasIndex(e => e.TipoServicio, "FK_FormContactanos_IndServicioDet");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Asunto)
                .HasMaxLength(500)
                .HasColumnName("asunto");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(1000)
                .HasColumnName("mensaje");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoServicio)
                .HasColumnType("int(11)")
                .HasColumnName("tipoServicio");

            entity.HasOne(d => d.TipoServicioNavigation).WithMany(p => p.TbFormContactanos)
                .HasForeignKey(d => d.TipoServicio)
                .HasConstraintName("FK_FormContactanos_IndServicioDet");
        });

        modelBuilder.Entity<TbFormHojareclamacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tb_form_hojareclamaciones");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.Departamento)
                .HasMaxLength(255)
                .HasColumnName("departamento");
            entity.Property(e => e.Detalle)
                .HasMaxLength(400)
                .HasColumnName("detalle");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Distrito)
                .HasMaxLength(255)
                .HasColumnName("distrito");
            entity.Property(e => e.Estacionamiento)
                .HasMaxLength(255)
                .HasColumnName("estacionamiento");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Fechaindicente)
                .HasColumnType("datetime")
                .HasColumnName("fechaindicente");
            entity.Property(e => e.Menordeedad)
                .HasColumnType("tinyint(4)")
                .HasColumnName("menordeedad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Numerodocumento)
                .HasMaxLength(255)
                .HasColumnName("numerodocumento");
            entity.Property(e => e.Provincia)
                .HasMaxLength(255)
                .HasColumnName("provincia");
            entity.Property(e => e.Reclamo)
                .HasMaxLength(255)
                .HasColumnName("reclamo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipodocumento)
                .HasMaxLength(255)
                .HasColumnName("tipodocumento");
            entity.Property(e => e.Tiposervicio)
                .HasMaxLength(255)
                .HasColumnName("tiposervicio");
        });

        modelBuilder.Entity<TbFormParkingcard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_form_parkingcard")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CodSeguridad)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasComment("codigo de seguridad aleatorio que genera el sistema de 20 caracteres")
                .HasColumnName("codSeguridad");
            entity.Property(e => e.Correo)
                .HasMaxLength(180)
                .HasComment("correo del usuario")
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasComment("dni del usuario")
                .HasColumnName("dni");
            entity.Property(e => e.FecRegistro)
                .HasComment("fecha actual de registro")
                .HasColumnType("datetime")
                .HasColumnName("fecRegistro");
            entity.Property(e => e.Notificado)
                .HasComment("valida si esta notificacion fue verificado")
                .HasColumnType("int(11)")
                .HasColumnName("notificado");
        });

        modelBuilder.Entity<TbFormProveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tb_form_proveedores");

            entity.HasIndex(e => e.CodCuentaBancaria, "FK_tipoBanco");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AfectoDetraccionDeIgv).HasColumnName("afectoDetraccionDeIGV");
            entity.Property(e => e.AfectoRetencionDeIgv).HasColumnName("afectoRetencionDeIGV");
            entity.Property(e => e.CcCargo)
                .HasMaxLength(255)
                .HasColumnName("cc_cargo");
            entity.Property(e => e.CcCelular)
                .HasMaxLength(255)
                .HasColumnName("cc_celular");
            entity.Property(e => e.CcEmail)
                .HasMaxLength(255)
                .HasColumnName("cc_email");
            entity.Property(e => e.CcNombre)
                .HasMaxLength(255)
                .HasColumnName("cc_nombre");
            entity.Property(e => e.CcTelefono)
                .HasMaxLength(255)
                .HasColumnName("cc_telefono");
            entity.Property(e => e.CcobranzaCargo)
                .HasMaxLength(255)
                .HasColumnName("ccobranza_cargo");
            entity.Property(e => e.CcobranzaCelular)
                .HasMaxLength(255)
                .HasColumnName("ccobranza_celular");
            entity.Property(e => e.CcobranzaEmail)
                .HasMaxLength(255)
                .HasColumnName("ccobranza_email");
            entity.Property(e => e.CcobranzaNombre)
                .HasMaxLength(255)
                .HasColumnName("ccobranza_nombre");
            entity.Property(e => e.CcobranzaTelefono)
                .HasMaxLength(255)
                .HasColumnName("ccobranza_telefono");
            entity.Property(e => e.CodCuentaBancaria)
                .HasColumnType("int(11)")
                .HasColumnName("codCuentaBancaria");
            entity.Property(e => e.ComprobanteExoneracion)
                .HasMaxLength(255)
                .HasColumnName("comprobanteExoneracion");
            entity.Property(e => e.CuentaBancaria)
                .HasMaxLength(255)
                .HasColumnName("cuentaBancaria");
            entity.Property(e => e.CuentaBancariaCci)
                .HasMaxLength(255)
                .HasColumnName("cuentaBancariaCCI");
            entity.Property(e => e.CuentaBancariaTitular)
                .HasMaxLength(255)
                .HasColumnName("cuentaBancariaTitular");
            entity.Property(e => e.DatosCompraAmbas).HasColumnName("datosCompraAmbas");
            entity.Property(e => e.DatosCompraDolares).HasColumnName("datosCompraDolares");
            entity.Property(e => e.DatosCompraSoles).HasColumnName("datosCompraSoles");
            entity.Property(e => e.FCodigoPostal)
                .HasMaxLength(255)
                .HasColumnName("f_codigoPostal");
            entity.Property(e => e.FDireccion)
                .HasMaxLength(255)
                .HasColumnName("f_direccion");
            entity.Property(e => e.FDistrito)
                .HasMaxLength(255)
                .HasColumnName("f_distrito");
            entity.Property(e => e.FDni)
                .HasMaxLength(255)
                .HasColumnName("f_dni");
            entity.Property(e => e.FFax)
                .HasMaxLength(255)
                .HasColumnName("f_fax");
            entity.Property(e => e.FNombre)
                .HasMaxLength(255)
                .HasColumnName("f_nombre");
            entity.Property(e => e.FRubro)
                .HasMaxLength(255)
                .HasColumnName("f_rubro");
            entity.Property(e => e.FRuc)
                .HasMaxLength(255)
                .HasColumnName("f_ruc");
            entity.Property(e => e.FTelefono)
                .HasMaxLength(255)
                .HasColumnName("f_telefono");
            entity.Property(e => e.FTipoPersona)
                .HasColumnType("int(11)")
                .HasColumnName("f_tipoPersona");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.InformacionPagoProveedor30dias).HasColumnName("informacionPagoProveedor30dias");
            entity.Property(e => e.InformacionPagoProveedor60dias).HasColumnName("informacionPagoProveedor60dias");
            entity.Property(e => e.InformacionPagoProveedorEfectivo).HasColumnName("informacionPagoProveedorEfectivo");
            entity.Property(e => e.InformacionPagoProveedorOtros)
                .HasMaxLength(255)
                .HasColumnName("informacionPagoProveedorOtros");
            entity.Property(e => e.InformacionPagoProveedorTranferenciaBancaria).HasColumnName("informacionPagoProveedorTranferenciaBancaria");
            entity.Property(e => e.PorcentajeDetraccion).HasColumnName("porcentajeDetraccion");
            entity.Property(e => e.RlCargo)
                .HasMaxLength(255)
                .HasColumnName("rl_cargo");
            entity.Property(e => e.RlCelular)
                .HasMaxLength(255)
                .HasColumnName("rl_celular");
            entity.Property(e => e.RlEmail)
                .HasMaxLength(255)
                .HasColumnName("rl_email");
            entity.Property(e => e.RlNombre)
                .HasMaxLength(255)
                .HasColumnName("rl_nombre");
            entity.Property(e => e.RlTelefono)
                .HasMaxLength(255)
                .HasColumnName("rl_telefono");
            entity.Property(e => e.SolicitadoPor)
                .HasMaxLength(255)
                .HasColumnName("solicitadoPor");
            entity.Property(e => e.TipoDocumentoFactura).HasColumnName("tipoDocumentoFactura");
            entity.Property(e => e.TipoDocumentoOtros).HasColumnName("tipoDocumentoOtros");
            entity.Property(e => e.TipoDocumentoReciboHonorarios).HasColumnName("tipoDocumentoReciboHonorarios");

            entity.HasOne(d => d.CodCuentaBancariaNavigation).WithMany(p => p.TbFormProveedores)
                .HasForeignKey(d => d.CodCuentaBancaria)
                .HasConstraintName("FK_tipoBanco");
        });

        modelBuilder.Entity<TbFormServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tb_form_servicios");

            entity.HasIndex(e => e.TipoServicio, "FK_FormServicios_IndServicioDet");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Celular)
                .HasMaxLength(500)
                .HasColumnName("celular");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(500)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.DatosContacto)
                .HasMaxLength(500)
                .HasColumnName("datosContacto");
            entity.Property(e => e.DireccionEstacionamiento)
                .HasMaxLength(500)
                .HasColumnName("direccionEstacionamiento");
            entity.Property(e => e.Distrito)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnName("distrito");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(500)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Ruc)
                .HasMaxLength(500)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(500)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoServicio)
                .HasColumnType("int(11)")
                .HasColumnName("tipoServicio");

            entity.HasOne(d => d.TipoServicioNavigation).WithMany(p => p.TbFormServicios)
                .HasForeignKey(d => d.TipoServicio)
                .HasConstraintName("FK_FormServicios_IndServicioDet");
        });

        modelBuilder.Entity<TbFormTbcnosotro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tb_form_tbcnosotros");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(500)
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(500)
                .HasColumnName("celular");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(500)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Departamento)
                .HasMaxLength(500)
                .HasColumnName("departamento");
            entity.Property(e => e.Distrito)
                .HasColumnType("int(11)")
                .HasColumnName("distrito");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.InformacionAdicional)
                .HasMaxLength(500)
                .HasColumnName("informacionAdicional");
            entity.Property(e => e.Medio)
                .HasMaxLength(500)
                .HasColumnName("medio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(500)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.Provincia)
                .HasMaxLength(500)
                .HasColumnName("provincia");
            entity.Property(e => e.Puesto)
                .HasMaxLength(500)
                .HasColumnName("puesto");
            entity.Property(e => e.TipoDocumento)
                .HasColumnType("int(11)")
                .HasColumnName("tipoDocumento");
        });

        modelBuilder.Entity<TbIndCaracteristica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_ind_caracteristica")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Detalle).HasColumnType("text");
            entity.Property(e => e.Icono)
                .HasMaxLength(80)
                .HasColumnName("icono");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbIndRedsocial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_ind_redsocial")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Clasefoot)
                .HasMaxLength(200)
                .HasColumnName("clasefoot");
            entity.Property(e => e.Clasehead)
                .HasMaxLength(200)
                .HasColumnName("clasehead");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("estado");
            entity.Property(e => e.Icono)
                .HasMaxLength(120)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruta)
                .HasMaxLength(500)
                .HasColumnName("ruta");
        });

        modelBuilder.Entity<TbIndServiciocab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_ind_serviciocab")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.ImagenGrande)
                .HasMaxLength(180)
                .HasColumnName("imagenGrande");
            entity.Property(e => e.ImagenPeque)
                .HasMaxLength(180)
                .HasColumnName("imagenPeque");
            entity.Property(e => e.Ruta)
                .HasMaxLength(250)
                .HasColumnName("ruta");
            entity.Property(e => e.TituloGrande)
                .HasMaxLength(250)
                .HasColumnName("tituloGrande");
            entity.Property(e => e.TituloPeque)
                .HasMaxLength(250)
                .HasColumnName("tituloPeque");
        });

        modelBuilder.Entity<TbIndServiciodet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_ind_serviciodet")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdCab, "indexserviciodet_ibfk_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("detalle");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.IdCab)
                .HasColumnType("int(11)")
                .HasColumnName("idCab");
            entity.Property(e => e.Imagen)
                .HasMaxLength(250)
                .HasColumnName("imagen");
            entity.Property(e => e.Ruta)
                .HasMaxLength(250)
                .HasColumnName("ruta");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdCabNavigation).WithMany(p => p.TbIndServiciodets)
                .HasForeignKey(d => d.IdCab)
                .HasConstraintName("tb_ind_serviciodet_ibfk_1");
        });

        modelBuilder.Entity<TbIndSlidecab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_ind_slidecab")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdBtn1, "idBtn1");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.IdBtn1)
                .HasColumnType("int(11)")
                .HasColumnName("idBtn1");
            entity.Property(e => e.Imagen)
                .HasMaxLength(180)
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdBtn1Navigation).WithMany(p => p.TbIndSlidecabs)
                .HasForeignKey(d => d.IdBtn1)
                .HasConstraintName("tb_ind_slidecab_ibfk_1");
        });

        modelBuilder.Entity<TbNosCabecera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_nos_cabecera")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbNosDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_nos_detalle")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("detalle");
            entity.Property(e => e.Espacio)
                .HasColumnType("int(11)")
                .HasColumnName("espacio");
            entity.Property(e => e.Icono)
                .HasMaxLength(255)
                .HasColumnName("icono");
            entity.Property(e => e.Imagen)
                .HasColumnType("text")
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<TbProvRegistro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_prov_registro")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CodBanco, "codBanco");

            entity.HasIndex(e => e.CodPersonaCobranza, "codPersonaCobranza");

            entity.HasIndex(e => e.CodPersonaContactoComercial, "codPersonaContactoComercial");

            entity.HasIndex(e => e.CodPersonaInforFiscal, "codPersonaInforFiscal");

            entity.HasIndex(e => e.CodPersonaRepLegal, "codPersonaRepLegal");

            entity.HasIndex(e => e.CodPersonaSolicita, "codPersonaSolicita");

            entity.HasIndex(e => e.TiempoPago, "tiempoPago");

            entity.HasIndex(e => e.TipoDocElectronicoRemite, "tipoDocElectronicoRemite");

            entity.HasIndex(e => e.TipoMonedaCompra, "tipoMonedaCompra");

            entity.HasIndex(e => e.TipoPagoDinero, "tipoPagoDinero");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AfectoDetraccionIgv)
                .HasColumnType("int(11)")
                .HasColumnName("AfectoDetraccionIGV");
            entity.Property(e => e.AfectoRenta4taCat).HasColumnType("int(11)");
            entity.Property(e => e.AfectoRetencionIgv)
                .HasColumnType("int(11)")
                .HasColumnName("AfectoRetencionIGV");
            entity.Property(e => e.Cci)
                .HasMaxLength(50)
                .HasColumnName("CCI");
            entity.Property(e => e.CodBanco)
                .HasColumnType("int(11)")
                .HasColumnName("codBanco");
            entity.Property(e => e.CodPersonaCobranza)
                .HasColumnType("int(11)")
                .HasColumnName("codPersonaCobranza");
            entity.Property(e => e.CodPersonaContactoComercial)
                .HasColumnType("int(11)")
                .HasColumnName("codPersonaContactoComercial");
            entity.Property(e => e.CodPersonaInforFiscal)
                .HasColumnType("int(11)")
                .HasColumnName("codPersonaInforFiscal");
            entity.Property(e => e.CodPersonaRepLegal)
                .HasColumnType("int(11)")
                .HasColumnName("codPersonaRepLegal");
            entity.Property(e => e.CodPersonaSolicita)
                .HasColumnType("int(11)")
                .HasColumnName("codPersonaSolicita");
            entity.Property(e => e.ComprobanteExonera).HasMaxLength(250);
            entity.Property(e => e.ExoneradoRenta4taCat).HasColumnType("int(11)");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.NroCuenta).HasMaxLength(50);
            entity.Property(e => e.OtroTiempoPago)
                .HasMaxLength(120)
                .HasColumnName("otroTiempoPago");
            entity.Property(e => e.PorcentajeDetraccion).HasColumnType("int(11)");
            entity.Property(e => e.TiempoPago)
                .HasColumnType("int(11)")
                .HasColumnName("tiempoPago");
            entity.Property(e => e.TipoDocElectronicoRemite)
                .HasColumnType("int(11)")
                .HasColumnName("tipoDocElectronicoRemite");
            entity.Property(e => e.TipoMonedaCompra)
                .HasColumnType("int(11)")
                .HasColumnName("tipoMonedaCompra");
            entity.Property(e => e.TipoPagoDinero)
                .HasColumnType("int(11)")
                .HasColumnName("tipoPagoDinero");
            entity.Property(e => e.Titular).HasMaxLength(250);

            entity.HasOne(d => d.CodBancoNavigation).WithMany(p => p.TbProvRegistros)
                .HasForeignKey(d => d.CodBanco)
                .HasConstraintName("tb_prov_registro_ibfk_10");

            entity.HasOne(d => d.CodPersonaCobranzaNavigation).WithMany(p => p.TbProvRegistroCodPersonaCobranzaNavigations)
                .HasForeignKey(d => d.CodPersonaCobranza)
                .HasConstraintName("tb_prov_registro_ibfk_5");

            entity.HasOne(d => d.CodPersonaContactoComercialNavigation).WithMany(p => p.TbProvRegistroCodPersonaContactoComercialNavigations)
                .HasForeignKey(d => d.CodPersonaContactoComercial)
                .HasConstraintName("tb_prov_registro_ibfk_4");

            entity.HasOne(d => d.CodPersonaInforFiscalNavigation).WithMany(p => p.TbProvRegistroCodPersonaInforFiscalNavigations)
                .HasForeignKey(d => d.CodPersonaInforFiscal)
                .HasConstraintName("tb_prov_registro_ibfk_2");

            entity.HasOne(d => d.CodPersonaRepLegalNavigation).WithMany(p => p.TbProvRegistroCodPersonaRepLegalNavigations)
                .HasForeignKey(d => d.CodPersonaRepLegal)
                .HasConstraintName("tb_prov_registro_ibfk_3");

            entity.HasOne(d => d.CodPersonaSolicitaNavigation).WithMany(p => p.TbProvRegistroCodPersonaSolicitaNavigations)
                .HasForeignKey(d => d.CodPersonaSolicita)
                .HasConstraintName("tb_prov_registro_ibfk_1");

            entity.HasOne(d => d.TiempoPagoNavigation).WithMany(p => p.TbProvRegistros)
                .HasForeignKey(d => d.TiempoPago)
                .HasConstraintName("tb_prov_registro_ibfk_7");

            entity.HasOne(d => d.TipoDocElectronicoRemiteNavigation).WithMany(p => p.TbProvRegistros)
                .HasForeignKey(d => d.TipoDocElectronicoRemite)
                .HasConstraintName("tb_prov_registro_ibfk_8");

            entity.HasOne(d => d.TipoMonedaCompraNavigation).WithMany(p => p.TbProvRegistros)
                .HasForeignKey(d => d.TipoMonedaCompra)
                .HasConstraintName("tb_prov_registro_ibfk_6");

            entity.HasOne(d => d.TipoPagoDineroNavigation).WithMany(p => p.TbProvRegistros)
                .HasForeignKey(d => d.TipoPagoDinero)
                .HasConstraintName("tb_prov_registro_ibfk_9");
        });

        modelBuilder.Entity<TbServCabecera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_serv_cabecera")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdBtnConoce, "idBtnConoce");

            entity.HasIndex(e => e.IdBtnSolicitar, "idBtnSolicitar");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DescCorto)
                .HasMaxLength(350)
                .HasColumnName("desc_corto");
            entity.Property(e => e.IdBtnConoce)
                .HasColumnType("int(11)")
                .HasColumnName("idBtnConoce");
            entity.Property(e => e.IdBtnSolicitar)
                .HasColumnType("int(11)")
                .HasColumnName("idBtnSolicitar");
            entity.Property(e => e.Imagen).HasMaxLength(250);
            entity.Property(e => e.IsMenu)
                .HasComment("true:Esta en el menu, false: No esta en el menu")
                .HasColumnType("int(11)");
            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdBtnConoceNavigation).WithMany(p => p.TbServCabeceraIdBtnConoceNavigations)
                .HasForeignKey(d => d.IdBtnConoce)
                .HasConstraintName("tb_serv_cabecera_ibfk_2");

            entity.HasOne(d => d.IdBtnSolicitarNavigation).WithMany(p => p.TbServCabeceraIdBtnSolicitarNavigations)
                .HasForeignKey(d => d.IdBtnSolicitar)
                .HasConstraintName("tb_serv_cabecera_ibfk_1");
        });

        modelBuilder.Entity<TbServDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_serv_detalle")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdBtnSolicitalo, "idBtnSolicitalo");

            entity.HasIndex(e => e.IdServicio, "idServicio");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdBtnSolicitalo)
                .HasColumnType("int(11)")
                .HasColumnName("idBtnSolicitalo");
            entity.Property(e => e.IdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("idServicio");
            entity.Property(e => e.Subtitulo)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("subtitulo");

            entity.HasOne(d => d.IdBtnSolicitaloNavigation).WithMany(p => p.TbServDetalles)
                .HasForeignKey(d => d.IdBtnSolicitalo)
                .HasConstraintName("tb_serv_detalle_ibfk_2");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.TbServDetalles)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_serv_detalle_ibfk_1");
        });

        modelBuilder.Entity<TbServFormulario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_serv_formularios")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CodUbigeo, "codUbigeo");

            entity.HasIndex(e => e.IdServicio, "idServicio");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApellidosNombres)
                .HasMaxLength(250)
                .HasColumnName("apellidosNombres");
            entity.Property(e => e.Celular)
                .HasMaxLength(11)
                .HasColumnName("celular");
            entity.Property(e => e.CodUbigeo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("codUbigeo");
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .HasColumnName("correo");
            entity.Property(e => e.IdEstacionamiento)
                .HasColumnType("int(11)")
                .HasColumnName("idEstacionamiento");
            entity.Property(e => e.IdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("idServicio");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(180)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(11)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.TbServFormularios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("tb_serv_formularios_ibfk_1");
        });

        modelBuilder.Entity<TbTraPuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_tra_puestos")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ocupado)
                .HasComment("0: Sin ocupar; 1: ocupado")
                .HasColumnType("int(11)")
                .HasColumnName("ocupado");
            entity.Property(e => e.Requisitos)
                .HasColumnType("text")
                .HasColumnName("requisitos");
            entity.Property(e => e.Ruta)
                .HasMaxLength(255)
                .HasColumnName("ruta");
            entity.Property(e => e.Subtitulo)
                .HasMaxLength(250)
                .HasColumnName("subtitulo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

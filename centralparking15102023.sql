/*
 Navicat Premium Data Transfer

 Source Server         : MARIA DB
 Source Server Type    : MySQL
 Source Server Version : 50717 (5.7.17-log)
 Source Host           : localhost:3306
 Source Schema         : centralparking

 Target Server Type    : MySQL
 Target Server Version : 50717 (5.7.17-log)
 File Encoding         : 65001

 Date: 15/10/2023 22:07:14
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20230925131329_AgregarCamposTablaConfEntidad', '7.0.5');
INSERT INTO `__efmigrationshistory` VALUES ('20230925232056_AddTipoProyectoColumn', '7.0.5');
INSERT INTO `__efmigrationshistory` VALUES ('20230926125812_AddColumnsToTbFormCotizanos', '7.0.5');
INSERT INTO `__efmigrationshistory` VALUES ('20230930171531_CreateTriggerForPiePagina', '7.0.5');
INSERT INTO `__efmigrationshistory` VALUES ('20231001011815_AddIconoColumnTbConfMenu', '7.0.5');

-- ----------------------------
-- Table structure for tb_conf_banco
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_banco`;
CREATE TABLE `tb_conf_banco`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `banco` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_banco
-- ----------------------------
INSERT INTO `tb_conf_banco` VALUES (1, 'Interbank');
INSERT INTO `tb_conf_banco` VALUES (2, 'Banco de Credito');
INSERT INTO `tb_conf_banco` VALUES (3, 'Scotiabank');
INSERT INTO `tb_conf_banco` VALUES (4, 'Continental');

-- ----------------------------
-- Table structure for tb_conf_botones
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_botones`;
CREATE TABLE `tb_conf_botones`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `menu_id` int(11) NULL DEFAULT NULL,
  `paginadet_id` int(11) NULL DEFAULT NULL,
  `btnTitulo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `btnRuta` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `btnClase` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `icono` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `orden` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 14 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_botones
-- ----------------------------
INSERT INTO `tb_conf_botones` VALUES (1, 1, NULL, 'Nosotros', '/Home/Nosotros', 'btn btn-primary', 'fa fa-arrow-circle-right', 0);
INSERT INTO `tb_conf_botones` VALUES (2, 2, NULL, 'Abonados', '/Home/Abonados', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (3, 3, NULL, 'Otros Servicios', '/Home/Otrosservicios', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (6, NULL, NULL, 'Cotización Valet Parking', '/Home/CotizacionValetParking', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (7, NULL, NULL, 'Valet Parking', '/Home/ValetParking', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (8, NULL, NULL, 'Cotización Eventos', '/Home/CotizacionEventos', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (9, NULL, NULL, 'Eventos', '/Home/Eventos', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (10, NULL, NULL, 'Cotización Prevención', '/Home/CotizacionPrevencion', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (11, NULL, NULL, 'Prevención', '/Home/Prevencion', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (12, NULL, NULL, 'Cotización Rentabilizacion', '/Home/CotizacionRentabilizacion', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);
INSERT INTO `tb_conf_botones` VALUES (13, NULL, NULL, 'Rentabilizacion', '/Home/Rentabilizacion', 'btn btn-primary', 'fa fa-arrow-circle-right', NULL);

-- ----------------------------
-- Table structure for tb_conf_docelectronico
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_docelectronico`;
CREATE TABLE `tb_conf_docelectronico`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `documentoElectronico` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_docelectronico
-- ----------------------------
INSERT INTO `tb_conf_docelectronico` VALUES (1, 'Factura');
INSERT INTO `tb_conf_docelectronico` VALUES (2, 'Boleta');
INSERT INTO `tb_conf_docelectronico` VALUES (3, 'Recibo por Honorarios');
INSERT INTO `tb_conf_docelectronico` VALUES (4, 'Otros');

-- ----------------------------
-- Table structure for tb_conf_entidad
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_entidad`;
CREATE TABLE `tb_conf_entidad`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `nameComercial` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ruc` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `direccion` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `horario` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `telefono` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `celular` varchar(12) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `correo` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `favicon` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `logoBlanco` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `logoOscuro` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `logoMini` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `rutaPagWeb` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `redesSociales` tinyint(1) NULL DEFAULT NULL,
  `servidor` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `puerto` int(11) NULL DEFAULT NULL,
  `correoNotifica` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `claveNotifica` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `correoConCopia` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_entidad
-- ----------------------------
INSERT INTO `tb_conf_entidad` VALUES (1, 'Central Parking System', 'Nombre comercial SAC', '20124565981', 'Av. Javier Prado Oeste 1650 San Isidro - Lima - Peru', 'Lun - Dom : 08.00 AM - 10.00 PM', '+511 505 5000', '987654874', 'info@centralparking.com', 'favicon.png', 'logoCP_white.png', 'logoCP.png', 'logoCP_mini.png', NULL, 0, 'smtp.gmail.com', 465, 'centralparking153@gmail.com', 'mwabukzuumewdbhn', 'carlos.soraluz@gmail.com');

-- ----------------------------
-- Table structure for tb_conf_menu
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_menu`;
CREATE TABLE `tb_conf_menu`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ruta` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `idtipomenu` int(11) NULL DEFAULT NULL,
  `acceso` int(11) NULL DEFAULT NULL,
  `padre` int(11) NULL DEFAULT 0,
  `estado` int(11) NULL DEFAULT 1,
  `tipoProyecto` char(3) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'web',
  `icono` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `menu_ibfk_1`(`idtipomenu`) USING BTREE,
  CONSTRAINT `tb_conf_menu_ibfk_1` FOREIGN KEY (`idtipomenu`) REFERENCES `tb_conf_tipomenu` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 47 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_menu
-- ----------------------------
INSERT INTO `tb_conf_menu` VALUES (1, 'INICIO', '/Home/Index', 1, 0, 0, 0, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (2, 'NOSOTROS', '/Home/Nosotros', 1, 0, 0, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (3, 'SERVICIOS', '#', 5, 0, 0, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (4, 'CONTÁCTANOS', '/Home/Contactanos', 1, 0, 0, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (5, 'TRABAJA CON NOSOTROS', '/Home/Trabajaconnosotros', 1, 0, 0, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (6, 'Acceder', '/Dashbord/Index', 1, 1, 0, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (7, 'Administracion de estacionamiento', '/Home/Adminestacionamiento', 1, 0, 3, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (8, 'Gestion de Abonos', '/Home/Abonados', 1, 0, 3, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (9, 'Otros servicios', '/Home/Otrosservicios', 1, 0, 3, 1, 'web', NULL);
INSERT INTO `tb_conf_menu` VALUES (10, 'Panel Control', '/DashbordCms/Inicio', 1, 0, 0, 1, 'cms', 'icon-grid');
INSERT INTO `tb_conf_menu` VALUES (11, 'Inicio', '#', 5, 0, 0, 1, 'cms', 'icon-layout');
INSERT INTO `tb_conf_menu` VALUES (12, 'Banner', '/SlideCms', 1, 0, 11, 1, 'cms', NULL);
INSERT INTO `tb_conf_menu` VALUES (13, 'Valores', '/CaracteristicaCms', 1, 0, 11, 1, 'cms', NULL);
INSERT INTO `tb_conf_menu` VALUES (14, 'Texto Servicios', '/IServiciosCms', 1, 0, 11, 1, 'cms', NULL);
INSERT INTO `tb_conf_menu` VALUES (15, 'Nosotros', '#', 5, 0, 0, 1, 'cms', 'icon-umbrella');
INSERT INTO `tb_conf_menu` VALUES (16, 'Paginas', '/PaginasCms', 1, 0, 15, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (17, 'Servicios', '#', 5, 0, 0, 1, 'cms', 'icon-paper');
INSERT INTO `tb_conf_menu` VALUES (18, 'Servicios', '/ServicioCabeceraCms', 1, 0, 17, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (19, 'Contactanos', '#', 5, 0, 0, 1, 'cms', 'icon-share');
INSERT INTO `tb_conf_menu` VALUES (20, 'Registro Contactos', '/ContactosCms', 1, 0, 19, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (21, 'Cotizanos', '#', 5, 0, 0, 1, 'cms', 'icon-share');
INSERT INTO `tb_conf_menu` VALUES (22, 'Estacionamiento', '/CotizanosCms/Index?codigo=1', 1, 0, 21, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (23, 'Abonados', '/CotizanosCms/Index?codigo=2', 1, 0, 21, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (24, 'Valet Parking', '/CotizanosCms/Index?codigo=3', 1, 0, 21, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (25, 'Eventos', '/CotizanosCms/Index?codigo=4', 1, 0, 21, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (26, 'Prevención', '/CotizanosCms/Index?codigo=5', 1, 0, 21, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (27, 'Rentabilización', '/CotizanosCms/Index?codigo=6', 1, 0, 21, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (28, 'Proveedores', '#', 5, 0, 0, 1, 'cms', 'icon-share');
INSERT INTO `tb_conf_menu` VALUES (29, 'Registro Proveedores', '/ProveedoresCms', 1, 0, 28, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (30, 'Rubros', '/RubroCms', 1, 0, 28, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (31, 'Hoja Reclamaciones', '/HojaReclamacionCms', 5, 0, 0, 1, 'cms', 'icon-share');
INSERT INTO `tb_conf_menu` VALUES (32, 'Registro Hoja Reclamaciones', '/HojaReclamacionCms', 1, 0, 31, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (33, 'Parking Card Vip', '#', 5, 0, 0, 1, 'cms', 'icon-share');
INSERT INTO `tb_conf_menu` VALUES (34, 'Registro Parking Card Vip', '/ParkingCardVipCms', 1, 0, 33, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (35, 'Trabaja con Nosotros', '#', 5, 0, 0, 1, 'cms', 'icon-star');
INSERT INTO `tb_conf_menu` VALUES (36, 'Puestos', '/PuestoCms', 1, 0, 35, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (37, 'Configuraciones', '#', 5, 0, 0, 1, 'cms', 'icon-cog');
INSERT INTO `tb_conf_menu` VALUES (38, 'Entidad', '/EntidadCms/Index', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (39, 'Usuarios', '/UsuarioCms', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (40, 'Roles', '/RolCms', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (41, 'Permisos', '/PermisoCms/Index?tipoRol=1', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (42, 'Menu', '/MenuCms/Index?tipoProyecto=web', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (43, 'Pie Pagina', '/PiePaginaCms', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (44, 'Modales', '/ModaleCms', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (45, 'Redes Sociales', '/RedesSocialesCms', 1, 0, 37, 1, 'cms', '#');
INSERT INTO `tb_conf_menu` VALUES (46, 'Correo', '/EntidadCms/Indexcorreo', 1, 0, 37, 1, 'cms', '#');

-- ----------------------------
-- Table structure for tb_conf_modalcab
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_modalcab`;
CREATE TABLE `tb_conf_modalcab`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idDetallePie` int(11) NULL DEFAULT NULL,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `btn_ruta` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `estado` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_modalcab
-- ----------------------------
INSERT INTO `tb_conf_modalcab` VALUES (1, 5, 'Trabaja con nosotros', '/Home/Trabajaconnosotros', 1);
INSERT INTO `tb_conf_modalcab` VALUES (2, 6, 'Colaboradores', '#modal_colaboradores', 1);
INSERT INTO `tb_conf_modalcab` VALUES (3, 7, 'Proveedores', '/Home/Proveedores', 1);
INSERT INTO `tb_conf_modalcab` VALUES (4, 8, 'Contáctanos', '/Home/Contactanos', 1);
INSERT INTO `tb_conf_modalcab` VALUES (5, 9, 'Comprobantes Electrónicos', '#modal_comprobantes', 1);
INSERT INTO `tb_conf_modalcab` VALUES (6, 10, 'Parking card vip', '#modal_cardvip', 1);
INSERT INTO `tb_conf_modalcab` VALUES (7, 12, 'Condiciones de Uso', '#condiciones_uso', 1);
INSERT INTO `tb_conf_modalcab` VALUES (8, 13, 'Políticas de Cookies', '#politicas_cookies', 1);
INSERT INTO `tb_conf_modalcab` VALUES (9, 14, 'Políticas de Privacidad', '#politicas_privacidad', 1);
INSERT INTO `tb_conf_modalcab` VALUES (10, 15, 'Información Legal', '#informacion_legal', 1);
INSERT INTO `tb_conf_modalcab` VALUES (11, 16, 'Políticas de Calidad', '/docs/Avellaneda_Castro_Gosdinski_Pillpe.pdf', 1);

-- ----------------------------
-- Table structure for tb_conf_modaldet
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_modaldet`;
CREATE TABLE `tb_conf_modaldet`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `modalcab_id` int(11) NULL DEFAULT NULL,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `descripcion` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `link` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 36 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_modaldet
-- ----------------------------
INSERT INTO `tb_conf_modaldet` VALUES (1, 2, 'Boleta', NULL, 'https://centralparking.ecotek.pe/');
INSERT INTO `tb_conf_modaldet` VALUES (2, 2, 'Capacitacion 1', NULL, 'https://www.youtube.com/watch?v=3VROhqXiwO8');
INSERT INTO `tb_conf_modaldet` VALUES (3, 2, 'Capacitacion 2', NULL, 'https://www.youtube.com/watch?v=3VROhqXiwO8');
INSERT INTO `tb_conf_modaldet` VALUES (4, 5, 'Centro Comercial Polo 1', NULL, 'https://factura.ecomprobantes.pe/CPARKING/(S(xwqd0qwuqunbrvp1cgcpji34))/formularios/frmInicio.aspx');
INSERT INTO `tb_conf_modaldet` VALUES (5, 5, 'Centro Comercial Polo 2', NULL, 'https://factura.ecomprobantes.pe/CPARKING/(S(c2kwxnslrwbhxanjjxyqko0y))/formularios/frmInicio.aspx');
INSERT INTO `tb_conf_modaldet` VALUES (6, 5, 'Banco BBVA', NULL, 'https://factura.ecomprobantes.pe/CPARKING/(S(ekaxn0tom3vns2t2z1n2g3do))/formularios/frmInicio.aspx');
INSERT INTO `tb_conf_modaldet` VALUES (7, 5, 'Iglesia Sagrado Corazón de Jesús', NULL, 'https://intelliefact.intellisoftsa.com/FE-CPS/');
INSERT INTO `tb_conf_modaldet` VALUES (8, 5, 'Hotel Marriot', NULL, 'https://intelliefact.intellisoftsa.com/FE-CPS/');
INSERT INTO `tb_conf_modaldet` VALUES (9, 5, 'Clínica El Golf', NULL, 'https://intelliefact.intellisoftsa.com/FE-CPS/');
INSERT INTO `tb_conf_modaldet` VALUES (10, 5, 'Otros', NULL, 'https://ozsolutions.pse.pe/20505205791');
INSERT INTO `tb_conf_modaldet` VALUES (11, 7, '1. 1. INFORMACIÓN GENERAL', 'Las condiciones siguientes regulan la información y el uso permitido del sitio Web , que la empresa Central Parking System S.A., en adelante Central Parking System, pone a disposición de clientes, proveedores y otros Usuarios de Internet, en adelante los Usuarios. El sitio Web ha sido creado y diseñado con la finalidad de publicitar los productos y servicios que comercializamos y dar información sobre los mismos, así como facilitar otro tipo de información que creemos puede ser de interés y crear así un espacio de comunicación para los Usuarios.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (12, 7, '2. 2. CONDICIONES GENERALES', 'El acceso al sitio Web y la navegación por el mismo implica la aceptación, sin reservas, de todas las condiciones incluidas en este documento. La utilización de determinados productos y/o servicios ofrecidos en este sitio Web se regirá, además, por las condiciones particulares previstas en cada caso, las cuales se entenderán aceptadas por el solo uso de estos productos y/o servicios.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (13, 7, '3. 3. CONDICIONES DE USO', 'El Usuario se obliga a hacer un uso correcto del sitio Web de conformidad con la legislación peruana vigente y con las condiciones incluidas en este documento. El Usuario responderá frente a Central Parking System o frente a terceros, por cualquier daño y/o perjuicio que pudiera causarse como consecuencia del incumplimiento de dichas obligaciones. Queda expresamente prohibido el uso del sitio Web con fines lesivos de bienes o intereses de Central Parking System o terceros o que sobrecarguen, dañen o inutilicen las redes, servidores y demás equipos informáticos o productos y aplicaciones informáticas de Central Parking System o de terceros. Central Parking System se reserva la facultad de efectuar, en cualquier momento y sin necesidad de previo aviso las modificaciones y actualizaciones de la información contenida en el sitio Web que resulten pertinentes, así como de la configuración y presentación de este y de sus Condiciones de Uso. La prestación del servicio del sitio Web tiene una duración limitada al momento en el que el Usuario se encuentre conectado al mismo o a alguno de los servicios que a través de éste se facilitan. Por eso se recomienda que los Usuario lean atenta y detenidamente estas Condiciones de Uso en cada ocasión en que se proponga entrar y hacer uso del sitio Web, puesto que pueden estar sujetas a modificaciones. Central Parking System no garantiza la inexistencia de interrupciones o errores en el acceso al sitio Web o a su contenido, ni que éste se encuentre actualizado. Central Parking System llevará a cabo, siempre que no implique causas que lo hagan imposible o de difícil ejecución, y tan pronto tenga noticia de los errores, desconexiones o falta de actualización en los contenidos, todas aquellas tareas necesarias para resolver los errores, restablecer la comunicación y actualizar los contenidos. Tanto el acceso al sitio Web como el uso no autorizado que pueda efectuarse de la información contenida en el mismo es responsabilidad exclusiva de quien lo realiza. Central Parking System no responderá de ninguna consecuencia, daño o perjuicio que pudieran derivarse de este acceso o uso. Central Parking System no se hace responsable de los errores de seguridad, que se puedan producir ni de los daños que puedan producirse en el sistema informático del Usuario, o a los ficheros o documentos almacenados en el mismo, como consecuencia: de la presencia de un software malicioso en el ordenador del Usuario que sea utilizado para la conexión a los contenidos del sitio Web, de un mal funcionamiento del navegador o del uso de versiones no actualizadas del navegador. Central Parking System no asume ninguna responsabilidad derivada de los contenidos enlazados desde el sitio Web, siempre que sean ajenos al mismo, ni garantiza la ausencia de software malicioso u otros elementos en los mismos que puedan producir alteraciones en el sistema informático, en los documentos o en los ficheros del Usuario, excluyendo cualquier responsabilidad por los daños de cualquier tipo causados por este motivo. Si cualquier Usuario considerara que el contenido o los servicios prestados por los sitios Webs enlazados son ilícitos o lesionan bienes o derechos del propio Usuario o de un tercero, y que esto puede dar mérito del pago de una indemnización, tendrá que notificarlo a Central Parking System.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (14, 7, '4. 4. PROCEDIMIENTO EN CASO DE REALIZACIÓN DE ACTIVIDADES DE CARÁCTER ILÍCITO', 'Si un Usuario considera que existen hechos o circunstancias que revelen el carácter ilícito de la utilización de cualquier contenido y/o de la realización de cualquier actividad en el sitio Web, y en particular, de la violación de derechos de propiedad intelectual o industrial u otros derechos, tendrá que enviar una notificación a Central Parking System con el siguiente contenido: I. Datos de la persona o entidad que hace la reclamación: nombre, dirección, teléfono y dirección de correo electrónico. II. Descripción de la supuesta actividad ilícita llevada a cabo en el sitio Web y, en particular, cuando se trate de una supuesta violación de derechos, la indicación precisa y concreta de los contenidos protegidos así como de su localización en el sitio Web, y los hechos o circunstancias que revelan el carácter ilícito de esta actividad. III. Firma manuscrita o equivalente, con datos personales del titular de los derechos supuestamente infringidos o de la persona autorizada para actuar en nombre y por cuenta de esta.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (15, 7, '5. 5. DATOS DE CONTACTO', 'Se pone a disposición de los Usuarios de Internet la siguiente información para poder dirigir sus peticiones, cuestiones y quejas', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (16, 7, '6. 6. DATOS FACILITADOS POR EL USUARIO DE INTERNET', 'A todos los efectos el acceso al sitio Web no exige la previa suscripción o registro de los Usuario. Central Parking System condiciona el uso del acceso a la parte privada del sitio Web a los clientes y proveedores, mediante la introducción de un usuario y contraseña, que Central Parking System facilita directamente. Para contactar con Central Parking System por correo electrónico, se requiere que el Usuario facilite sus datos mediante un formulario. Los datos facilitados por el Usuario pasarán a integrarse en un banco de datos, los cuales serán tratados según la Política de Privacidad que puede encontrar en este mismo sitio Web.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (17, 7, '7. 7. ENLACES', 'El establecimiento de un enlace al sitio Web, implica la existencia de relaciones pasadas o presentes entre Central Parking System y el propietario del sitio Web donde se establezca, no implica por parte de Central Parking System ni la aceptación ni la aprobación de sus contenidos o servicios. Queda expresamente prohibido cualquier otro aprovechamiento de los contenidos del sitio Web, a favor de terceros no autorizados. Central Parking System no asume ninguna responsabilidad por la información contenida en sitios Webs de terceros a los que se pueda acceder por enlaces o buscadores desde el Web.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (18, 7, '8. 8. PROPIEDAD INTELECTUAL E INDUSTRIAL', 'Central Parking System es titular de los derechos de propiedad intelectual que hacen referencia a sus productos y servicios, respecto a las citas de terceros. Está prohibida la reproducción, transformación, distribución, comunicación pública, puesta a disposición, extracción, reutilización, o la utilización de cualquier naturaleza, por cualquier medio o procedimiento, de cualquiera de ellos, salvo en los casos en que sea autorizado por el titular de los correspondientes derechos. La utilización no autorizada de la información contenida en el sitio Web, su reventa y la lesión de los derechos de Propiedad Intelectual de Central Parking System dará lugar a las responsabilidades legalmente establecidas. Los Usuarios tendrán que respetar todos los derechos de propiedad intelectual e industrial sobre el sitio Web.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (19, 7, '9. 9. PROTECCIÓN DE DATOS PERSONALES', 'Toda la información referente al tratamiento y la protección de los datos personales, que nos son facilitados, se encuentra en nuestra Política de Privacidad.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (20, 7, '10. 10. COOKIES', 'Toda la información sobre las cookies en general y sobre las que se utilizan en el sitio Web en particular se encuentra en nuestra Política de Cookies.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (21, 7, '11. 11. JURISDICCIÓN', 'Las presentes Condiciones de Uso Web se interpretarán conforme a la legislación peruana vigente sobre la materia, que se aplicará subsidiariamente en todo lo que no se haya previsto en las mismas. Para la resolución de todas las controversias o cuestiones relacionadas con el sitio Web o de las actividades en él desarrolladas, será de aplicación la legislación peruana vigente, a la cual se someten expresamente Central Parking System y los Usuarios, con renuncia expresa a cualquier otro fuero, siendo competentes para la resolución de todos los conflictos derivados o relacionados con su uso los Juzgados y Tribunales del Distrito Judicial del Cercado de Lima.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (22, 8, '1. INTRODUCCIÓN', 'La empresa Central Parking System S.A., en adelante Central Parking System, describe en este documento la â€œPolítica de uso de Cookiesâ€ que regula el sitio web con URL http://www.losportales.com.pe/, en adelante el sitio Web, con el objetivo de garantizar la privacidad de los Usuarios de Internet. Informamos a los Usuarios que en el sitio Web utilizamos cookies, tanto propias como de terceros. Estas cookies nos permiten facilitar el uso y navegación, garantizar el acceso a determinadas funcionalidades y adicionalmente, nos ayudan a mejorar la calidad del sitio Web de acuerdo a los hábitos y estilos de navegación de los Usuarios. Central Parking System utiliza las cookies estrictamente necesarias y esenciales para que usted utilice el sitio Web y le permitan moverse libremente, utilizar áreas seguras u opciones personalizadas. El sitio Web dispone de enlaces a redes sociales como Facebook, Instagram, Google+, foursquare, Twitter, YouTube y TripAdvisor. Central Parking System no controla las cookies utilizadas por estos sitios Web externos. Para más información sobre estos, aconsejamos revisar sus propias políticas de cookies.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (23, 8, '2. ¿QUÉ TIPO DE COOKIES UTILIZA ESTE SITIO WEB?', '2. ¿QUÉ TIPO DE COOKIES UTILIZA ESTE SITIO WEB? Las cookies siguientes no identifican personalmente a los Usuarios, sólo proporcionan información estadística anónima sobre la navegación en este sitio Web; sin embargo puede deshabilitarlas directamente configurando su navegador. A continuación se relacionan las cookies que están siendo utilizadas en este sitio Web: Nombre: _ga Tipo: Analítica Permanencia: 2 años. Finalidad: Estas Cookies recopilan información de tu experiencia de navegación en nuestros portales web de forma totalmente anónima. Podemos contabilizar el número de visitantes de la página o los contenidos más vistos. Nombre: __utmb Tipo: Estado de la sesión Permanencia: Hasta finalizar la sesión. Finalidad: Se utiliza para guardar el momento en que el visitante ingresa al sitio web. Nombre: __utmc Tipo: Estado de la sesión Permanencia: 30 minutos después de finalizar la sesión. Finalidad: Se utiliza para guardar el momento en que el visitante deja el sitio web. Nombre: __utmt Tipo: Estado de la sesión Permanencia: 2 años. Finalidad: La cookie __utmt pasa la información hacia el método setVar(), el cual crea un segmente específico para los usuarios. Nombre: __utmz Tipo: Analítica Permanencia: 6 meses Finalidad: Rastrea donde viene el visitante, motor de búsqueda utilizado, palabra clave que utilizó y dónde estaban en el mundo cuando usted accede a un sitio web. Se usa para asignar el costo de publicidad de Google. Nombre: NID Tipo: Preferencias Permanencia: 2 años. Finalidad: La cookie NID contiene un ID único que Google utiliza para recordar tus preferencias y otra información, como tu idioma preferido (por ejemplo, el español), el número de resultados de búsqueda que quieres que se muestren por página (por ejemplo, 10 o 20) y si quieres que el filtro SafeSearch de Google esté activado o desactivado. Nombre: ASP.NET_SessionId Tipo: Cookies de sesión Permanencia: Al finalizar la sesión de navegación. Finalidad: No almacena datos especiales del usuario que visita la página. La primera vez que un usuario accede a una aplicación ASP.NET con sesión habilitada se crea esta cookie. Cada vez que un usuario quiere autentificarse en nuestra aplicación se limpia la sesión y se sobrescribe esta cookie en el navegador. Es una medida de seguridad en el control de sesiones de aplicaciones ASP.NET Nombre: ASPXANONYMOUS Tipo: Cookies de tercero Permanencia: 3 meses Finalidad: Cookie creada por el proveedor de chat de Vivienda Mylivechat, sirve para almacenar datos de sesión de los usuarios que utilizan el chat.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (24, 8, '3. GESTIÓN DE LAS COOKIES', 'Si acepta nuestras cookies, nos permite la mejora del sitio Web de Central Parking System para ofrecerle un acceso óptimo y darle un servicio más eficaz y personalizado. Si usted como Usuario decide no autorizar el tratamiento indicándonos su no conformidad, sólo usaríamos las cookies técnicas puesto que son imprescindibles para la navegación por nuestro sitio Web. Podrá seguir usando nuestro sitio Web, aunque el uso de algunos de sus servicios podrá ser limitado y por tanto la experiencia puede ser menos satisfactoria. Tenga en cuenta que si rechaza o borra las cookies de navegación por el sitio Web, no podremos mantener sus preferencias, algunas características de las páginas no estarán operativas, no podremos ofrecerle servicios personalizados y cada vez que vaya a navegar por nuestro sitio Web tendremos que solicitarle de nuevo su autorización para el uso de cookies. En el caso de seguir navegando por nuestro sitio Web sin denegar su autorización implica que acepta su uso.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (25, 8, '4. VIGENCIA Y MODIFICACIÓN DE LA PRESENTE POLÍTICA DE PRIVACIDAD', 'La Política de Cookies Web de Central Parking System ha sido actualizada el mes de Junio. Central Parking System puede modificar esta Política de Cookies en función de exigencias legislativas, reglamentarias, jurisprudenciales o con la finalidad de adaptar dicha política a las instrucciones dictadas por la Autoridad Nacional de Protección de Datos Personales, así como por criterios propios empresariales. Por ello, y dado que dicha política puede ser actualizada periódicamente, sugerimos a nuestros Usuarios que la revisen de forma regular y que la encontrarán en el sitio Web http://www.centralparking.com.pe/.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (26, 9, '1. INTRODUCCIÓN', 'La empresa Central Parking System S.A., en adelante Central Parking System, describe en este documento la â€œPolítica de uso de Cookiesâ€ que regula el sitio web con URL http://www.losportales.com.pe/, en adelante el sitio Web, con el objetivo de garantizar la privacidad de los Usuarios de Internet. Informamos a los Usuarios que en el sitio Web utilizamos cookies, tanto propias como de terceros. Estas cookies nos permiten facilitar el uso y navegación, garantizar el acceso a determinadas funcionalidades y adicionalmente, nos ayudan a mejorar la calidad del sitio Web de acuerdo a los hábitos y estilos de navegación de los Usuarios. Central Parking System utiliza las cookies estrictamente necesarias y esenciales para que usted utilice el sitio Web y le permitan moverse libremente, utilizar áreas seguras u opciones personalizadas. El sitio Web dispone de enlaces a redes sociales como Facebook, Instagram, Google+, foursquare, Twitter, YouTube y TripAdvisor. Central Parking System no controla las cookies utilizadas por estos sitios Web externos. Para más información sobre estos, aconsejamos revisar sus propias políticas de cookies.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (27, 9, '2. ¿QUÉ TIPO DE COOKIES UTILIZA ESTE SITIO WEB?', '2. ¿QUÉ TIPO DE COOKIES UTILIZA ESTE SITIO WEB? Las cookies siguientes no identifican personalmente a los Usuarios, sólo proporcionan información estadística anónima sobre la navegación en este sitio Web; sin embargo puede deshabilitarlas directamente configurando su navegador. A continuación se relacionan las cookies que están siendo utilizadas en este sitio Web: Nombre: _ga Tipo: Analítica Permanencia: 2 años. Finalidad: Estas Cookies recopilan información de tu experiencia de navegación en nuestros portales web de forma totalmente anónima. Podemos contabilizar el número de visitantes de la página o los contenidos más vistos. Nombre: __utmb Tipo: Estado de la sesión Permanencia: Hasta finalizar la sesión. Finalidad: Se utiliza para guardar el momento en que el visitante ingresa al sitio web. Nombre: __utmc Tipo: Estado de la sesión Permanencia: 30 minutos después de finalizar la sesión. Finalidad: Se utiliza para guardar el momento en que el visitante deja el sitio web. Nombre: __utmt Tipo: Estado de la sesión Permanencia: 2 años. Finalidad: La cookie __utmt pasa la información hacia el método setVar(), el cual crea un segmente específico para los usuarios. Nombre: __utmz Tipo: Analítica Permanencia: 6 meses Finalidad: Rastrea donde viene el visitante, motor de búsqueda utilizado, palabra clave que utilizó y dónde estaban en el mundo cuando usted accede a un sitio web. Se usa para asignar el costo de publicidad de Google. Nombre: NID Tipo: Preferencias Permanencia: 2 años. Finalidad: La cookie NID contiene un ID único que Google utiliza para recordar tus preferencias y otra información, como tu idioma preferido (por ejemplo, el español), el número de resultados de búsqueda que quieres que se muestren por página (por ejemplo, 10 o 20) y si quieres que el filtro SafeSearch de Google esté activado o desactivado. Nombre: ASP.NET_SessionId Tipo: Cookies de sesión Permanencia: Al finalizar la sesión de navegación. Finalidad: No almacena datos especiales del usuario que visita la página. La primera vez que un usuario accede a una aplicación ASP.NET con sesión habilitada se crea esta cookie. Cada vez que un usuario quiere autentificarse en nuestra aplicación se limpia la sesión y se sobrescribe esta cookie en el navegador. Es una medida de seguridad en el control de sesiones de aplicaciones ASP.NET Nombre: ASPXANONYMOUS Tipo: Cookies de tercero Permanencia: 3 meses Finalidad: Cookie creada por el proveedor de chat de Vivienda Mylivechat, sirve para almacenar datos de sesión de los usuarios que utilizan el chat.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (28, 9, '3. GESTIÓN DE LAS COOKIES', 'Si acepta nuestras cookies, nos permite la mejora del sitio Web de Central Parking System para ofrecerle un acceso óptimo y darle un servicio más eficaz y personalizado. Si usted como Usuario decide no autorizar el tratamiento indicándonos su no conformidad, sólo usaríamos las cookies técnicas puesto que son imprescindibles para la navegación por nuestro sitio Web. Podrá seguir usando nuestro sitio Web, aunque el uso de algunos de sus servicios podrá ser limitado y por tanto la experiencia puede ser menos satisfactoria. Tenga en cuenta que si rechaza o borra las cookies de navegación por el sitio Web, no podremos mantener sus preferencias, algunas características de las páginas no estarán operativas, no podremos ofrecerle servicios personalizados y cada vez que vaya a navegar por nuestro sitio Web tendremos que solicitarle de nuevo su autorización para el uso de cookies. En el caso de seguir navegando por nuestro sitio Web sin denegar su autorización implica que acepta su uso.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (29, 9, '4. VIGENCIA Y MODIFICACIÓN DE LA PRESENTE POLÍTICA DE PRIVACIDAD', 'La Política de Cookies Web de Central Parking System ha sido actualizada el mes de Junio. Central Parking System puede modificar esta Política de Cookies en función de exigencias legislativas, reglamentarias, jurisprudenciales o con la finalidad de adaptar dicha política a las instrucciones dictadas por la Autoridad Nacional de Protección de Datos Personales, así como por criterios propios empresariales. Por ello, y dado que dicha política puede ser actualizada periódicamente, sugerimos a nuestros Usuarios que la revisen de forma regular y que la encontrarán en el sitio Web http://www.centralparking.com.pe/.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (30, 10, '1. Información Genérica de la Empresa', 'Identificación del proveedor inmobiliario: Central Parking System S.A., con RUC N° 20301837896, domicilio legal en Jirón Mariscal La Mar 991, piso 7, distrito de Magdalena del Mar, provincia y departamento de Lima, con representantes legales inscritos en la Partida Electrónica N° 11008436 del Registro de Personas Jurídicas de Lima. Teléfono de contacto: 211-4470. Antecedentes del proveedor y su comportamiento en el mercado de productos y servicios inmobiliarios: Tenemos más de 50 años, hemos aportado con mejorar la calidad de vida de miles de familias, dándoles la oportunidad de acceder a una vivienda digna. Nuestra misión es desarrollar proyectos inmobiliarios a nivel nacional en los rubros de habilitación urbana, edificaciones multifamiliares y viviendas de interés social, diferenciados por la alta calidad y ubicación estratégica de nuestros proyectos con la garantía y prestigio de nuestra empresa. Canales para atención de quejas, reclamos o denuncias: pueden presentarse a través de: www.losportales.com.pe/vivienda/micuenta o www.losportales.com.pe/vivienda/contáctanos, mediante medio físico directamente en las oficinas de Servicio al Cliente de la empresa o a través de los Libros de Reclamaciones. Se deja constancia de la existencia de la Central de información de Promotores Inmobiliarios y/o Empresas Constructoras de Unidades Inmobiliarias, del Registro de Infracciones y Sanciones por el incumplimiento de las disposiciones del Código de Protección y Defensa del Consumidor a cargo del Indecopi, y del portal Mira a Quien le Compras, a cargo, también, del Indecopi.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (31, 10, '2. Financiamiento del Precio de Venta (Crédito Directo) ofrecido por la Empresa', 'Central Parking System S.A. ofrece a los clientes interesados en adquirir inmuebles, el financiamiento del precio de venta de algunos de sus productos (Crédito Directo), que consiste en el fraccionamiento del precio de venta en cuotas mensuales, todas las cuales incluyen los intereses y gastos administrativos que cobra la empresa en virtud al Crédito Directo. La cantidad máxima de cuotas mensuales es establecida por la empresa y dependerá del producto ofrecido. Asimismo, existen restricciones para el financiamiento de más de un inmueble. Los documentos que deben presentarse para acceder al Crédito Directo son: i) Documento Nacional de Identidad Vigente y ii) Recibos de Luz, Agua y/o Teléfono. En caso el cliente y Central Parking System S.A. convengan en contratar bajo la modalidad de Crédito Directo, los pagos se efectuarán de manera mensual, incluyendo los intereses y gastos administrativos correspondientes, los cuales se aplican a todo el cronograma de pagos, desde la primera hasta la última cuota pactada. Asimismo, el cliente aceptará letras de cambio que representen cada una de las cuotas mensuales que se obliga a abonar a favor de la empresa. El crédito directo se formaliza mediante la firma de un contrato con la empresa, del cual forma parte como anexo la Hoja Resumen de la Operación (Proforma de Ventas), con las firmas del cliente y de la empresa. En dicha hoja resumen consta el detalle de cada operación específica, el cual dependerá del monto que abone el cliente al momento de la firma del contrato y la cantidad de cuotas que representen el saldo del precio de venta. Además la Hoja Resumen de la Operación (Proforma de Ventas) se incluyen los siguientes puntos: precio de venta del inmueble, con mención específica de los montos correspondientes a intereses y gastos administrativos, tasas de interés, gastos administrativos, penalidades, detalle sobre pre-pago de saldos, etc.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (32, 10, '3. Respecto al Crédito Directo de manera genérica', 'a. Tasa de Costo Efectivo Anual de las operaciones con Crédito Directo: 23 % b. Monto de los intereses: dependerá de cada operación concreta, en base al monto que abone el cliente al momento de la firma del contrato y número de cuotas que representen el saldo de precio de venta. Quedará detallada expresamente en la Hoja Resumen de la Operación (Proforma de Ventas). c. Número de cuotas o pagos a realizar: el número máximo de cuotas es establecido por la empresa y dependerá del producto elegido. Dentro de este límite máximo el cliente puede escoger la cantidad de cuotas en las desee fraccionar el precio de venta del inmueble. d. Periodicidad de las cuotas: mensual e. Fecha de pago de las cuotas: primer día hábil de cada mes. f. Cantidad total a pagar por el inmueble: dependerá de cada operación concreta, en base al monto que abone el cliente al momento de la firma del contrato y número de cuotas que representen el saldo de precio de venta. Quedará detallada expresamente, incluyendo el precio al contado, intereses y gastos administrativos en la Hoja Resumen de la Operación (Proforma de Ventas). g. Prepago: El cliente tiene derecho a solicitar a la empresa el prepago del saldo del precio de venta pendiente de pago, en cuyo caso deberá manifestar este requerimiento y solicitar se efectúe el cálculo y liquidación del saldo de la deuda pendiente de pago. La empresa preparará la liquidación correspondiente, procediendo al descuento de los intereses y gastos administrativos no pagados a la fecha en que se efectúe dicho prepago. Aquellos intereses y gastos administrativos pagados a la fecha del pre-pago no serán materia de devolución. h. Intereses Moratorios y Comisiones de Cobranza: Si el cliente no cumpliera con pagar en su fecha alguna de las cuotas fraccionadas del precio de venta deberá abonar a la empresa intereses moratorios sobre el monto de las obligaciones vencidas, sin que sea necesaria la constitución en mora, en base a la tasa máxima que tiene establecida el Banco Central de Reserva del Perú para las personas ajenas al sistema financiero, al día de realización del pago. Asimismo, en caso de incumplimiento de pago, la empresa queda facultada a cobrar comisiones de cobranza y los intereses compensatorios convencionales que pudieren generarse. Las cifras de la comisión de cobranza son las siguientes: i) desde el primer día de incumplimiento hasta el tercer día, la comisión asciende a US$ 5.00 (Cinco y 00/100 Dólares Americanos); ii) desde el cuarto día de incumplimiento hasta el quinto la comisión asciende a US$ 10.00 (Diez y 00/100 Dólares Americanos); desde el sexto día de incumplimiento hasta el octavo, la comisión asciende a US$ 15.00 (Quince y 00/100 Dólares Americanos). Las cantidades previamente indicadas se cobrarán por día de incumplimiento, efectuando la sumatoria de los días de atraso en el pago y monto de comisión de cobranza que corresponde a cada día. i. Cláusulas penales: i) Resolución por incumplimiento de pago: En caso el cliente incumpla con el abono de tres cualesquiera de las cuotas establecidas en la Hoja Resumen de la Operación (Proforma de Ventas) o cualesquiera de las dos últimas, la empresa podrá optar, a su sola decisión, por cualquiera de las dos siguientes posibilidades: 1.- Dar por resuelto unilateralmente y de pleno derecho el contrato suscrito mediante el envío de una carta notarial, en los términos establecidos en el Artículo N° 1430 del Código Civil, en cuyo caso retendrá el 30% del precio de venta pactado por concepto de penalidad, el cual será descontado del monto pagado a cuenta del capital abonado por el cliente. Los intereses compensatorios y gastos administrativos pagados por éste a la fecha de la resolución, no serán materia de devolución, circunstancia que éste declara conocer y aceptar. 2.- Dar por vencidas todas las cuotas pendientes de pago y exigir judicialmente el pago del total adeudado, incluyendo intereses compensatorios y moratorios, gastos administrativos, comisiones de cobranza, además de los daños y perjuicios que pudieren corresponder. En el supuesto de envío de cartas notariales, éstas serán dirigidas al domicilio expresado por el cliente en la introducción del contrato suscrito. j. Monto y detalle de cualquier cargo adicional: En el supuesto que las letras de cambio suscritas por el cliente sean ingresadas a una institución bancaria o financiera para facilitar su labor de cobranza, los gastos que cobre el banco por el retiro de las letras en casos de prepago serán asumidos por el cliente. k. Las letras de cambio que aceptará el cliente podrán ser ingresadas por la empresa a una entidad bancaria o financiera del sistema para la gestión de cobranza, en calidad de garantía o fideicomiso. Las letras contienen las siguientes cláusulas: i) En caso de mora, ésta Letra de Cambio, generará las tasas de interés compensatorio y moratorios convencionales más altos, que establezca el BCR para personas ajenas al sistema financiero; ii) El plazo de vencimiento podrá ser prorrogado por el tenedor por el plazo que este señale, sin que sea necesaria la intervención del obligado principal ni de los solidarios; iii) Esta letra de Cambio no requiere ser protestada por falta de pago; iv) Esta letra podrá ser girada, endosada y/o transferida con firmas impresas, digitalizadas u otros medios de seguridad gráficos (art. 6° Ley 2787).23% l. Las letras de cambio ingresadas a las entidades bancarias y/o financieras no serán devueltas físicamente al cliente, por ser esta la política más común entre dichas entidades, quienes están facultadas a dejar constancia del pago o extinción de las letras de cambio mediante otros medios legales autorizados, como por ejemplo, el comprobante de pago entregado en la ventanilla del banco, el cual debe ser verificado y conservado por el cliente. En caso la entidad bancaria o financiera cuente con un procedimiento de devolución física de letras de cambio, si el cliente requiere su devolución deberá asumir los gastos que la misma signifique, dependiendo de la política de cobros de cada entidad.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (33, 10, '4. Financiamiento del Precio de Venta otorgado por Entidades Bancarias o Financieras', 'En caso que el financiamiento del precio de venta o parte de este sea otorgado por una entidad bancaria o financiera para la adquisición de cualquiera de nuestros productos inmobiliarios, será esta entidad la que detalle las condiciones de dicho financiamiento, de acuerdo a las disposiciones del Código de Protección y Defensa del Consumidor y de las emitidas por la Superintendencia de Banca, Seguros y Administradoras Privadas de Fondos de Pensiones.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (34, 10, '5. Política de Calidad', 'Somos Central Parking System Estacionamientos, una organización líder en el sector. Contamos con una moderna infraestructura, tecnología de punta y personal altamente calificado para brindar un servicio de calidad, facilitándole la vida a las personas, las empresas y la sociedad. En nuestra empresa estamos comprometidos a: - Brindar y mantener los más altos estándares de calidad mediante cultura de servicio centrada en el cliente, garantizando su satisfacción a todas horas y en todos los días del año. - Cumplir las normas y requisitos aplicables a nuestro sector, promoviendo la mejora continua de nuestros procesos y las buenas prácticas de gestión de calidad, implementadas durante años de trabajo y experiencia. Esta política se encuentra a disposición de todos los interesados para su divulgación y utilización hacia la mejora continua. Ha sido revisada y aprobada por la Gerencia de Operaciones y Experiencia del Cliente de Central Parking System ESTACIONAMIENTOS el 09 del mes de noviembre del año 2017.', NULL);
INSERT INTO `tb_conf_modaldet` VALUES (35, 1, '1', '1', '1');

-- ----------------------------
-- Table structure for tb_conf_moneda
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_moneda`;
CREATE TABLE `tb_conf_moneda`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `moneda` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_moneda
-- ----------------------------
INSERT INTO `tb_conf_moneda` VALUES (1, 'SOLES');
INSERT INTO `tb_conf_moneda` VALUES (2, 'DOLARES');
INSERT INTO `tb_conf_moneda` VALUES (3, 'AMBAS');

-- ----------------------------
-- Table structure for tb_conf_paginascab
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_paginascab`;
CREATE TABLE `tb_conf_paginascab`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `subtitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reseniaTitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reseniaDetalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `misionTitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `misionDetalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `visionTitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `visionDetalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `valoresTitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `valoresDetalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `reconocTitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `reconocDetalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `imagenMision` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `imagenValores` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_paginascab
-- ----------------------------
INSERT INTO `tb_conf_paginascab` VALUES (1, 'Nosotros', 'QUIENES SOMOS estamos', 'RESEÑA HISTÓRICA', 'Central Parking System se fundó en el año 1968 en Nashville, Tenesse, EE.U, llegó al Perú en 1992, somos una empresa líder en la administración de estacionamientos y operamos los Centros Comerciales, Edificios Corporativos y Hoteles más importantes del país además de brindar Servicio de Valet Parking en empresas y eventos.', 'MISIÓN', 'Administrar estacionamientos a través de personas comprometidas con integridad y excelencia.', 'VISIÓN', 'Ser reconocidos como un socio confiable e innovador, que agrega valor a la experiencia de nuestros colaboradores, clientes y usuarios.', 'VALORES', 'Integridad, Respeto, Iniciativa y Comunicación', 'RECONOCIMIENTO', 'Empresa líder en la administración de estacionamientos.gastrttitis', '/images/playa_estacionamiento2.jpg', '/images/playa_estacionamiento.jpg');

-- ----------------------------
-- Table structure for tb_conf_paginasdet
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_paginasdet`;
CREATE TABLE `tb_conf_paginasdet`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pagina_id` int(11) NULL DEFAULT NULL,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `detalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `imagen` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_paginasdet
-- ----------------------------

-- ----------------------------
-- Table structure for tb_conf_permisos
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_permisos`;
CREATE TABLE `tb_conf_permisos`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `permiso` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `descripcion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `menu_id` int(11) NULL DEFAULT NULL,
  `rol_id` int(11) NULL DEFAULT NULL,
  `estado` int(11) NULL DEFAULT 1,
  `creacion` datetime NULL DEFAULT NULL,
  `modificacion` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `permisos_ibfk_1`(`menu_id`) USING BTREE,
  INDEX `permisos_ibfk_2`(`rol_id`) USING BTREE,
  CONSTRAINT `tb_conf_permisos_ibfk_1` FOREIGN KEY (`menu_id`) REFERENCES `tb_conf_menu` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_conf_permisos_ibfk_2` FOREIGN KEY (`rol_id`) REFERENCES `tb_conf_roles` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 84 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_permisos
-- ----------------------------
INSERT INTO `tb_conf_permisos` VALUES (39, NULL, 'Agregado multiple', 15, 2, 1, '2023-10-07 21:29:53', NULL);
INSERT INTO `tb_conf_permisos` VALUES (40, NULL, 'Agregado multiple', 11, 2, 1, '2023-10-07 21:29:53', NULL);
INSERT INTO `tb_conf_permisos` VALUES (41, NULL, 'Agregado multiple', 14, 2, 1, '2023-10-07 21:29:54', NULL);
INSERT INTO `tb_conf_permisos` VALUES (42, NULL, 'Agregado multiple', 13, 2, 1, '2023-10-07 21:29:54', NULL);
INSERT INTO `tb_conf_permisos` VALUES (43, NULL, 'Agregado multiple', 12, 2, 1, '2023-10-07 21:29:54', NULL);
INSERT INTO `tb_conf_permisos` VALUES (45, NULL, 'Agregado multiple', 15, 3, 1, '2023-10-07 21:30:20', NULL);
INSERT INTO `tb_conf_permisos` VALUES (46, NULL, 'Agregado multiple', 10, 3, 1, '2023-10-07 21:30:20', NULL);
INSERT INTO `tb_conf_permisos` VALUES (47, NULL, 'Agregado multiple', 37, 1, 1, '2023-10-09 11:13:01', NULL);
INSERT INTO `tb_conf_permisos` VALUES (48, NULL, 'Agregado multiple', 35, 1, 1, '2023-10-09 11:13:02', NULL);
INSERT INTO `tb_conf_permisos` VALUES (49, NULL, 'Agregado multiple', 33, 1, 1, '2023-10-09 11:13:02', NULL);
INSERT INTO `tb_conf_permisos` VALUES (50, NULL, 'Agregado multiple', 31, 1, 1, '2023-10-09 11:13:02', NULL);
INSERT INTO `tb_conf_permisos` VALUES (51, NULL, 'Agregado multiple', 28, 1, 1, '2023-10-09 11:13:03', NULL);
INSERT INTO `tb_conf_permisos` VALUES (52, NULL, 'Agregado multiple', 21, 1, 1, '2023-10-09 11:13:03', NULL);
INSERT INTO `tb_conf_permisos` VALUES (53, NULL, 'Agregado multiple', 19, 1, 1, '2023-10-09 11:13:03', NULL);
INSERT INTO `tb_conf_permisos` VALUES (54, NULL, 'Agregado multiple', 17, 1, 1, '2023-10-09 11:13:03', NULL);
INSERT INTO `tb_conf_permisos` VALUES (55, NULL, 'Agregado multiple', 15, 1, 1, '2023-10-09 11:13:03', NULL);
INSERT INTO `tb_conf_permisos` VALUES (56, NULL, 'Agregado multiple', 11, 1, 1, '2023-10-09 11:13:04', NULL);
INSERT INTO `tb_conf_permisos` VALUES (57, NULL, 'Agregado multiple', 10, 1, 1, '2023-10-09 11:13:04', NULL);
INSERT INTO `tb_conf_permisos` VALUES (58, NULL, 'Agregado multiple', 46, 1, 1, '2023-10-09 11:13:04', NULL);
INSERT INTO `tb_conf_permisos` VALUES (59, NULL, 'Agregado multiple', 45, 1, 1, '2023-10-09 11:13:04', NULL);
INSERT INTO `tb_conf_permisos` VALUES (60, NULL, 'Agregado multiple', 44, 1, 1, '2023-10-09 11:13:04', NULL);
INSERT INTO `tb_conf_permisos` VALUES (61, NULL, 'Agregado multiple', 43, 1, 1, '2023-10-09 11:13:05', NULL);
INSERT INTO `tb_conf_permisos` VALUES (62, NULL, 'Agregado multiple', 42, 1, 1, '2023-10-09 11:13:05', NULL);
INSERT INTO `tb_conf_permisos` VALUES (63, NULL, 'Agregado multiple', 41, 1, 1, '2023-10-09 11:13:05', NULL);
INSERT INTO `tb_conf_permisos` VALUES (64, NULL, 'Agregado multiple', 40, 1, 1, '2023-10-09 11:13:05', NULL);
INSERT INTO `tb_conf_permisos` VALUES (65, NULL, 'Agregado multiple', 39, 1, 1, '2023-10-09 11:13:05', NULL);
INSERT INTO `tb_conf_permisos` VALUES (66, NULL, 'Agregado multiple', 38, 1, 1, '2023-10-09 11:13:06', NULL);
INSERT INTO `tb_conf_permisos` VALUES (67, NULL, 'Agregado multiple', 36, 1, 1, '2023-10-09 11:13:06', NULL);
INSERT INTO `tb_conf_permisos` VALUES (68, NULL, 'Agregado multiple', 34, 1, 1, '2023-10-09 11:13:06', NULL);
INSERT INTO `tb_conf_permisos` VALUES (69, NULL, 'Agregado multiple', 32, 1, 1, '2023-10-09 11:13:06', NULL);
INSERT INTO `tb_conf_permisos` VALUES (70, NULL, 'Agregado multiple', 30, 1, 1, '2023-10-09 11:13:06', NULL);
INSERT INTO `tb_conf_permisos` VALUES (71, NULL, 'Agregado multiple', 29, 1, 1, '2023-10-09 11:13:06', NULL);
INSERT INTO `tb_conf_permisos` VALUES (72, NULL, 'Agregado multiple', 27, 1, 1, '2023-10-09 11:13:07', NULL);
INSERT INTO `tb_conf_permisos` VALUES (73, NULL, 'Agregado multiple', 26, 1, 1, '2023-10-09 11:13:07', NULL);
INSERT INTO `tb_conf_permisos` VALUES (74, NULL, 'Agregado multiple', 25, 1, 1, '2023-10-09 11:13:07', NULL);
INSERT INTO `tb_conf_permisos` VALUES (75, NULL, 'Agregado multiple', 24, 1, 1, '2023-10-09 11:13:07', NULL);
INSERT INTO `tb_conf_permisos` VALUES (76, NULL, 'Agregado multiple', 23, 1, 1, '2023-10-09 11:13:07', NULL);
INSERT INTO `tb_conf_permisos` VALUES (77, NULL, 'Agregado multiple', 22, 1, 1, '2023-10-09 11:13:08', NULL);
INSERT INTO `tb_conf_permisos` VALUES (78, NULL, 'Agregado multiple', 20, 1, 1, '2023-10-09 11:13:08', NULL);
INSERT INTO `tb_conf_permisos` VALUES (79, NULL, 'Agregado multiple', 18, 1, 1, '2023-10-09 11:13:08', NULL);
INSERT INTO `tb_conf_permisos` VALUES (80, NULL, 'Agregado multiple', 16, 1, 1, '2023-10-09 11:13:08', NULL);
INSERT INTO `tb_conf_permisos` VALUES (81, NULL, 'Agregado multiple', 14, 1, 1, '2023-10-09 11:13:08', NULL);
INSERT INTO `tb_conf_permisos` VALUES (82, NULL, 'Agregado multiple', 13, 1, 1, '2023-10-09 11:13:08', NULL);
INSERT INTO `tb_conf_permisos` VALUES (83, NULL, 'Agregado multiple', 12, 1, 1, '2023-10-09 11:13:09', NULL);

-- ----------------------------
-- Table structure for tb_conf_personas
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_personas`;
CREATE TABLE `tb_conf_personas`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoPersona` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'N: Natural, J:Juridica',
  `tipoRegistro` int(11) NULL DEFAULT NULL COMMENT '1:Solicitante,2:InforFiscal,3:RepresLegal,4:ContactoComer,5:Cobranza',
  `ruc` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `dni` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Nombres` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ApPaterno` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ApMaterno` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `RazonSocial` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Direccion` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `codDistrito` varchar(6) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `codPostal` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Telefono` varchar(7) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Fax` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `codRubro` int(11) NULL DEFAULT NULL,
  `celular` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `correo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `cargo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `codDistrito`(`codDistrito`) USING BTREE,
  CONSTRAINT `tb_conf_personas_ibfk_1` FOREIGN KEY (`codDistrito`) REFERENCES `tb_conf_ubigeo` (`codUbi`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_personas
-- ----------------------------

-- ----------------------------
-- Table structure for tb_conf_piepaginacab
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_piepaginacab`;
CREATE TABLE `tb_conf_piepaginacab`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `imagen` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `orden` int(11) NULL DEFAULT NULL,
  `estado` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_piepaginacab
-- ----------------------------
INSERT INTO `tb_conf_piepaginacab` VALUES (1, 'Empresa', '/images/logoCP_white.png', 1, 1);
INSERT INTO `tb_conf_piepaginacab` VALUES (2, 'Nosotros', NULL, 2, 1);
INSERT INTO `tb_conf_piepaginacab` VALUES (3, 'Atención al Cliente', NULL, 3, 1);
INSERT INTO `tb_conf_piepaginacab` VALUES (4, 'Políticas y Términos', NULL, 4, 1);

-- ----------------------------
-- Table structure for tb_conf_piepaginadet
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_piepaginadet`;
CREATE TABLE `tb_conf_piepaginadet`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `piepagina_id` int(11) NULL DEFAULT NULL,
  `icono` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `titulo` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ruta` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `imagen` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `tipo_ruta` int(11) NULL DEFAULT NULL COMMENT '1: Link nueva pestaña; 2: Modal',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_piepaginadet
-- ----------------------------
INSERT INTO `tb_conf_piepaginadet` VALUES (1, 1, NULL, NULL, NULL, '/images/logoCP_white.png', 1);
INSERT INTO `tb_conf_piepaginadet` VALUES (2, 1, 'fa fa-map-marker-alt', 'Av. Javier Prado Oeste 1650, San Isidro -\r\n                    Lima - Peru', NULL, NULL, NULL);
INSERT INTO `tb_conf_piepaginadet` VALUES (3, 1, 'fa fa-phone-alt', '+511 505 5000', NULL, NULL, NULL);
INSERT INTO `tb_conf_piepaginadet` VALUES (4, 1, 'fa fa-envelope', 'info@centralparking.com', NULL, NULL, NULL);
INSERT INTO `tb_conf_piepaginadet` VALUES (5, 2, NULL, 'Trabaja con nosotros', '/Home/Trabajaconnosotros', NULL, 1);
INSERT INTO `tb_conf_piepaginadet` VALUES (6, 2, NULL, 'Colaboradores', '#modal_colaboradores', NULL, 2);
INSERT INTO `tb_conf_piepaginadet` VALUES (7, 2, NULL, 'Proveedores', '/Home/Proveedores', NULL, 1);
INSERT INTO `tb_conf_piepaginadet` VALUES (8, 3, NULL, 'Contáctanos', '/Home/Contactanos', NULL, 1);
INSERT INTO `tb_conf_piepaginadet` VALUES (9, 3, NULL, 'Comprobantes Electrónicos', '#modal_comprobantes', NULL, 2);
INSERT INTO `tb_conf_piepaginadet` VALUES (10, 3, NULL, 'Parking card vip', '#modal_cardvip', NULL, 3);
INSERT INTO `tb_conf_piepaginadet` VALUES (11, 3, NULL, NULL, '/Home/HojaReclamaciones', '/images/libro-reclamaciones.png', 1);
INSERT INTO `tb_conf_piepaginadet` VALUES (12, 4, NULL, 'Condiciones de Uso', '#condiciones_uso', NULL, 2);
INSERT INTO `tb_conf_piepaginadet` VALUES (13, 4, NULL, 'Políticas de Cookies', '#politicas_cookies', NULL, 2);
INSERT INTO `tb_conf_piepaginadet` VALUES (14, 4, NULL, 'Políticas de Privacidad', '#politicas_privacidad', NULL, 2);
INSERT INTO `tb_conf_piepaginadet` VALUES (15, 4, NULL, 'Información Legal', '#informacion_legal', NULL, 2);
INSERT INTO `tb_conf_piepaginadet` VALUES (16, 4, NULL, 'Políticas de Calidad', '/docs/Avellaneda_Castro_Gosdinski_Pillpe.pdf', NULL, 4);

-- ----------------------------
-- Table structure for tb_conf_roles
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_roles`;
CREATE TABLE `tb_conf_roles`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rol` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `descripcion` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `permiso_id` int(11) NULL DEFAULT NULL,
  `estado` int(11) NULL DEFAULT 1,
  `creacion` datetime NULL DEFAULT NULL,
  `modificacion` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_roles
-- ----------------------------
INSERT INTO `tb_conf_roles` VALUES (1, 'Administrador', 'El administrador tiene todo el poder', NULL, 1, NULL, NULL);
INSERT INTO `tb_conf_roles` VALUES (2, 'Editor', 'Rol del editor', NULL, 1, NULL, NULL);
INSERT INTO `tb_conf_roles` VALUES (3, 'Visualizador', 'Tukuy rikuy', NULL, 1, NULL, NULL);

-- ----------------------------
-- Table structure for tb_conf_rubros
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_rubros`;
CREATE TABLE `tb_conf_rubros`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rubro` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_rubros
-- ----------------------------
INSERT INTO `tb_conf_rubros` VALUES (1, 'PROVEEDOR SERVICIOS GENERALES');
INSERT INTO `tb_conf_rubros` VALUES (2, 'PROVEEDOR EQUIPOS DE OPERACION');
INSERT INTO `tb_conf_rubros` VALUES (3, 'PROVEEDOR EPP Y CONSUMIBLES P/ SST');
INSERT INTO `tb_conf_rubros` VALUES (4, 'PROVEEDOR ELEMENTOS DE SEGURIDAD');
INSERT INTO `tb_conf_rubros` VALUES (5, 'PROVEEDOR EQUIPOS DE COMPUTO');
INSERT INTO `tb_conf_rubros` VALUES (7, 'PROVEEDOR EQUIPOS DE COMUNICACION');

-- ----------------------------
-- Table structure for tb_conf_timepago
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_timepago`;
CREATE TABLE `tb_conf_timepago`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `timePago` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_timepago
-- ----------------------------
INSERT INTO `tb_conf_timepago` VALUES (1, '30 DÍAS');
INSERT INTO `tb_conf_timepago` VALUES (2, '60 DÍAS');
INSERT INTO `tb_conf_timepago` VALUES (3, 'OTRO');

-- ----------------------------
-- Table structure for tb_conf_tipomenu
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_tipomenu`;
CREATE TABLE `tb_conf_tipomenu`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `opcion` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_tipomenu
-- ----------------------------
INSERT INTO `tb_conf_tipomenu` VALUES (1, 'no_tienesubmenu', 'NO TIENE');
INSERT INTO `tb_conf_tipomenu` VALUES (5, 'tiene_submenu', 'SI TIENE');

-- ----------------------------
-- Table structure for tb_conf_tipopago
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_tipopago`;
CREATE TABLE `tb_conf_tipopago`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoPago` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_tipopago
-- ----------------------------
INSERT INTO `tb_conf_tipopago` VALUES (1, 'Efectivo');
INSERT INTO `tb_conf_tipopago` VALUES (2, 'Transferencia Bancaria');

-- ----------------------------
-- Table structure for tb_conf_ubigeo
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_ubigeo`;
CREATE TABLE `tb_conf_ubigeo`  (
  `codUbi` varchar(6) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `dpto` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `prov` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `dist` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  INDEX `codUbi`(`codUbi`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_ubigeo
-- ----------------------------
INSERT INTO `tb_conf_ubigeo` VALUES ('010101', 'AMAZONAS', 'CHACHAPOYAS', 'CHACHAPOYAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010102', 'AMAZONAS', 'CHACHAPOYAS', 'ASUNCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010103', 'AMAZONAS', 'CHACHAPOYAS', 'BALSAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010104', 'AMAZONAS', 'CHACHAPOYAS', 'CHETO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010105', 'AMAZONAS', 'CHACHAPOYAS', 'CHILIQUIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010106', 'AMAZONAS', 'CHACHAPOYAS', 'CHUQUIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010107', 'AMAZONAS', 'CHACHAPOYAS', 'GRANADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010108', 'AMAZONAS', 'CHACHAPOYAS', 'HUANCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010109', 'AMAZONAS', 'CHACHAPOYAS', 'LA JALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010110', 'AMAZONAS', 'CHACHAPOYAS', 'LEIMEBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010111', 'AMAZONAS', 'CHACHAPOYAS', 'LEVANTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010112', 'AMAZONAS', 'CHACHAPOYAS', 'MAGDALENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010113', 'AMAZONAS', 'CHACHAPOYAS', 'MARISCAL CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010114', 'AMAZONAS', 'CHACHAPOYAS', 'MOLINOPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010115', 'AMAZONAS', 'CHACHAPOYAS', 'MONTEVIDEO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010116', 'AMAZONAS', 'CHACHAPOYAS', 'OLLEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010117', 'AMAZONAS', 'CHACHAPOYAS', 'QUINJALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010118', 'AMAZONAS', 'CHACHAPOYAS', 'SAN FRANCISCO DE DAGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010119', 'AMAZONAS', 'CHACHAPOYAS', 'SAN ISIDRO DE MAINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010120', 'AMAZONAS', 'CHACHAPOYAS', 'SOLOCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010121', 'AMAZONAS', 'CHACHAPOYAS', 'SONCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010201', 'AMAZONAS', 'BAGUA', 'BAGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010202', 'AMAZONAS', 'BAGUA', 'ARAMANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010203', 'AMAZONAS', 'BAGUA', 'COPALLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010204', 'AMAZONAS', 'BAGUA', 'EL PARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010205', 'AMAZONAS', 'BAGUA', 'IMAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010206', 'AMAZONAS', 'BAGUA', 'LA PECA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010301', 'AMAZONAS', 'BONGARÁ', 'JUMBILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010302', 'AMAZONAS', 'BONGARÁ', 'CHISQUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010303', 'AMAZONAS', 'BONGARÁ', 'CHURUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010304', 'AMAZONAS', 'BONGARÁ', 'COROSHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010305', 'AMAZONAS', 'BONGARÁ', 'CUISPES');
INSERT INTO `tb_conf_ubigeo` VALUES ('010306', 'AMAZONAS', 'BONGARÁ', 'FLORIDA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010307', 'AMAZONAS', 'BONGARÁ', 'JAZAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010308', 'AMAZONAS', 'BONGARÁ', 'RECTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010309', 'AMAZONAS', 'BONGARÁ', 'SAN CARLOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010310', 'AMAZONAS', 'BONGARÁ', 'SHIPASBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010311', 'AMAZONAS', 'BONGARÁ', 'VALERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010312', 'AMAZONAS', 'BONGARÁ', 'YAMBRASBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010401', 'AMAZONAS', 'CONDORCANQUI', 'NIEVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010402', 'AMAZONAS', 'CONDORCANQUI', 'EL CENEPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010403', 'AMAZONAS', 'CONDORCANQUI', 'RÍO SANTIAGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010501', 'AMAZONAS', 'LUYA', 'LAMUD');
INSERT INTO `tb_conf_ubigeo` VALUES ('010502', 'AMAZONAS', 'LUYA', 'CAMPORREDONDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010503', 'AMAZONAS', 'LUYA', 'COCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010504', 'AMAZONAS', 'LUYA', 'COLCAMAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('010505', 'AMAZONAS', 'LUYA', 'CONILA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010506', 'AMAZONAS', 'LUYA', 'INGUILPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010507', 'AMAZONAS', 'LUYA', 'LONGUITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010508', 'AMAZONAS', 'LUYA', 'LONYA CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010509', 'AMAZONAS', 'LUYA', 'LUYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010510', 'AMAZONAS', 'LUYA', 'LUYA VIEJO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010511', 'AMAZONAS', 'LUYA', 'MARÍA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010512', 'AMAZONAS', 'LUYA', 'OCALLI');
INSERT INTO `tb_conf_ubigeo` VALUES ('010513', 'AMAZONAS', 'LUYA', 'OCUMAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('010514', 'AMAZONAS', 'LUYA', 'PISUQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010515', 'AMAZONAS', 'LUYA', 'PROVIDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010516', 'AMAZONAS', 'LUYA', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('010517', 'AMAZONAS', 'LUYA', 'SAN FRANCISCO DE YESO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010518', 'AMAZONAS', 'LUYA', 'SAN JERÓNIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010519', 'AMAZONAS', 'LUYA', 'SAN JUAN DE LOPECANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010520', 'AMAZONAS', 'LUYA', 'SANTA CATALINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010521', 'AMAZONAS', 'LUYA', 'SANTO TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010522', 'AMAZONAS', 'LUYA', 'TINGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010523', 'AMAZONAS', 'LUYA', 'TRITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010601', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'SAN NICOLÁS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010602', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'CHIRIMOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010603', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'COCHAMAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('010604', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'HUAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010605', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'LIMABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010606', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'LONGAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('010607', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'MARISCAL BENAVIDES');
INSERT INTO `tb_conf_ubigeo` VALUES ('010608', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'MILPUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('010609', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'OMIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010610', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010611', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'TOTORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010612', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'VISTA ALEGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010701', 'AMAZONAS', 'UTCUBAMBA', 'BAGUA GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010702', 'AMAZONAS', 'UTCUBAMBA', 'CAJARURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010703', 'AMAZONAS', 'UTCUBAMBA', 'CUMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010704', 'AMAZONAS', 'UTCUBAMBA', 'EL MILAGRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010705', 'AMAZONAS', 'UTCUBAMBA', 'JAMALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010706', 'AMAZONAS', 'UTCUBAMBA', 'LONYA GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010707', 'AMAZONAS', 'UTCUBAMBA', 'YAMON');
INSERT INTO `tb_conf_ubigeo` VALUES ('020101', 'ÁNCASH', 'HUARAZ', 'HUARAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('020102', 'ÁNCASH', 'HUARAZ', 'COCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020103', 'ÁNCASH', 'HUARAZ', 'COLCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020104', 'ÁNCASH', 'HUARAZ', 'HUANCHAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('020105', 'ÁNCASH', 'HUARAZ', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020106', 'ÁNCASH', 'HUARAZ', 'JANGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020107', 'ÁNCASH', 'HUARAZ', 'LA LIBERTAD');
INSERT INTO `tb_conf_ubigeo` VALUES ('020108', 'ÁNCASH', 'HUARAZ', 'OLLEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020109', 'ÁNCASH', 'HUARAZ', 'PAMPAS GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('020110', 'ÁNCASH', 'HUARAZ', 'PARIACOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020111', 'ÁNCASH', 'HUARAZ', 'PIRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020112', 'ÁNCASH', 'HUARAZ', 'TARICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020201', 'ÁNCASH', 'AIJA', 'AIJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020202', 'ÁNCASH', 'AIJA', 'CORIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020203', 'ÁNCASH', 'AIJA', 'HUACLLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020204', 'ÁNCASH', 'AIJA', 'LA MERCED');
INSERT INTO `tb_conf_ubigeo` VALUES ('020205', 'ÁNCASH', 'AIJA', 'SUCCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020301', 'ÁNCASH', 'ANTONIO RAYMONDI', 'LLAMELLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020302', 'ÁNCASH', 'ANTONIO RAYMONDI', 'ACZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020303', 'ÁNCASH', 'ANTONIO RAYMONDI', 'CHACCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020304', 'ÁNCASH', 'ANTONIO RAYMONDI', 'CHINGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020305', 'ÁNCASH', 'ANTONIO RAYMONDI', 'MIRGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020306', 'ÁNCASH', 'ANTONIO RAYMONDI', 'SAN JUAN DE RONTOY');
INSERT INTO `tb_conf_ubigeo` VALUES ('020401', 'ÁNCASH', 'ASUNCIÓN', 'CHACAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020402', 'ÁNCASH', 'ASUNCIÓN', 'ACOCHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020501', 'ÁNCASH', 'BOLOGNESI', 'CHIQUIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020502', 'ÁNCASH', 'BOLOGNESI', 'ABELARDO PARDO LEZAMETA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020503', 'ÁNCASH', 'BOLOGNESI', 'ANTONIO RAYMONDI');
INSERT INTO `tb_conf_ubigeo` VALUES ('020504', 'ÁNCASH', 'BOLOGNESI', 'AQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020505', 'ÁNCASH', 'BOLOGNESI', 'CAJACAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('020506', 'ÁNCASH', 'BOLOGNESI', 'CANIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020507', 'ÁNCASH', 'BOLOGNESI', 'COLQUIOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('020508', 'ÁNCASH', 'BOLOGNESI', 'HUALLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020509', 'ÁNCASH', 'BOLOGNESI', 'HUASTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020510', 'ÁNCASH', 'BOLOGNESI', 'HUAYLLACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020511', 'ÁNCASH', 'BOLOGNESI', 'LA PRIMAVERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020512', 'ÁNCASH', 'BOLOGNESI', 'MANGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020513', 'ÁNCASH', 'BOLOGNESI', 'PACLLON');
INSERT INTO `tb_conf_ubigeo` VALUES ('020514', 'ÁNCASH', 'BOLOGNESI', 'SAN MIGUEL DE CORPANQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('020515', 'ÁNCASH', 'BOLOGNESI', 'TICLLOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020601', 'ÁNCASH', 'CARHUAZ', 'CARHUAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('020602', 'ÁNCASH', 'CARHUAZ', 'ACOPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020603', 'ÁNCASH', 'CARHUAZ', 'AMASHCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020604', 'ÁNCASH', 'CARHUAZ', 'ANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020605', 'ÁNCASH', 'CARHUAZ', 'ATAQUERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020606', 'ÁNCASH', 'CARHUAZ', 'MARCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020607', 'ÁNCASH', 'CARHUAZ', 'PARIAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020608', 'ÁNCASH', 'CARHUAZ', 'SAN MIGUEL DE ACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020609', 'ÁNCASH', 'CARHUAZ', 'SHILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020610', 'ÁNCASH', 'CARHUAZ', 'TINCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020611', 'ÁNCASH', 'CARHUAZ', 'YUNGAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('020701', 'ÁNCASH', 'CARLOS FERMÍN FITZCARRALD', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020702', 'ÁNCASH', 'CARLOS FERMÍN FITZCARRALD', 'SAN NICOLÁS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020703', 'ÁNCASH', 'CARLOS FERMÍN FITZCARRALD', 'YAUYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020801', 'ÁNCASH', 'CASMA', 'CASMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020802', 'ÁNCASH', 'CASMA', 'BUENA VISTA ALTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020803', 'ÁNCASH', 'CASMA', 'COMANDANTE NOEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('020804', 'ÁNCASH', 'CASMA', 'YAUTAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020901', 'ÁNCASH', 'CORONGO', 'CORONGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020902', 'ÁNCASH', 'CORONGO', 'ACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020903', 'ÁNCASH', 'CORONGO', 'BAMBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020904', 'ÁNCASH', 'CORONGO', 'CUSCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020905', 'ÁNCASH', 'CORONGO', 'LA PAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020906', 'ÁNCASH', 'CORONGO', 'YANAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('020907', 'ÁNCASH', 'CORONGO', 'YUPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021001', 'ÁNCASH', 'HUARI', 'HUARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021002', 'ÁNCASH', 'HUARI', 'ANRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021003', 'ÁNCASH', 'HUARI', 'CAJAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('021004', 'ÁNCASH', 'HUARI', 'CHAVIN DE HUANTAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('021005', 'ÁNCASH', 'HUARI', 'HUACACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021006', 'ÁNCASH', 'HUARI', 'HUACCHIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021007', 'ÁNCASH', 'HUARI', 'HUACHIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021008', 'ÁNCASH', 'HUARI', 'HUANTAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('021009', 'ÁNCASH', 'HUARI', 'MASIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021010', 'ÁNCASH', 'HUARI', 'PAUCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021011', 'ÁNCASH', 'HUARI', 'PONTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021012', 'ÁNCASH', 'HUARI', 'RAHUAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021013', 'ÁNCASH', 'HUARI', 'RAPAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021014', 'ÁNCASH', 'HUARI', 'SAN MARCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021015', 'ÁNCASH', 'HUARI', 'SAN PEDRO DE CHANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021016', 'ÁNCASH', 'HUARI', 'UCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021101', 'ÁNCASH', 'HUARMEY', 'HUARMEY');
INSERT INTO `tb_conf_ubigeo` VALUES ('021102', 'ÁNCASH', 'HUARMEY', 'COCHAPETI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021103', 'ÁNCASH', 'HUARMEY', 'CULEBRAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021104', 'ÁNCASH', 'HUARMEY', 'HUAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021105', 'ÁNCASH', 'HUARMEY', 'MALVAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021201', 'ÁNCASH', 'HUAYLAS', 'CARAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('021202', 'ÁNCASH', 'HUAYLAS', 'HUALLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021203', 'ÁNCASH', 'HUAYLAS', 'HUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021204', 'ÁNCASH', 'HUAYLAS', 'HUAYLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021205', 'ÁNCASH', 'HUAYLAS', 'MATO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021206', 'ÁNCASH', 'HUAYLAS', 'PAMPAROMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021207', 'ÁNCASH', 'HUAYLAS', 'PUEBLO LIBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021208', 'ÁNCASH', 'HUAYLAS', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('021209', 'ÁNCASH', 'HUAYLAS', 'SANTO TORIBIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021210', 'ÁNCASH', 'HUAYLAS', 'YURACMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021301', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'PISCOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021302', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'CASCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021303', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'ELEAZAR GUZMÁN BARRON');
INSERT INTO `tb_conf_ubigeo` VALUES ('021304', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'FIDEL OLIVAS ESCUDERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021305', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'LLAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021306', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'LLUMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021307', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'LUCMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021308', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'MUSGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021401', 'ÁNCASH', 'OCROS', 'OCROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021402', 'ÁNCASH', 'OCROS', 'ACAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021403', 'ÁNCASH', 'OCROS', 'CAJAMARQUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021404', 'ÁNCASH', 'OCROS', 'CARHUAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021405', 'ÁNCASH', 'OCROS', 'COCHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021406', 'ÁNCASH', 'OCROS', 'CONGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021407', 'ÁNCASH', 'OCROS', 'LLIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021408', 'ÁNCASH', 'OCROS', 'SAN CRISTÓBAL DE RAJAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021409', 'ÁNCASH', 'OCROS', 'SAN PEDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021410', 'ÁNCASH', 'OCROS', 'SANTIAGO DE CHILCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021501', 'ÁNCASH', 'PALLASCA', 'CABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021502', 'ÁNCASH', 'PALLASCA', 'BOLOGNESI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021503', 'ÁNCASH', 'PALLASCA', 'CONCHUCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021504', 'ÁNCASH', 'PALLASCA', 'HUACASCHUQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021505', 'ÁNCASH', 'PALLASCA', 'HUANDOVAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('021506', 'ÁNCASH', 'PALLASCA', 'LACABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021507', 'ÁNCASH', 'PALLASCA', 'LLAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021508', 'ÁNCASH', 'PALLASCA', 'PALLASCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021509', 'ÁNCASH', 'PALLASCA', 'PAMPAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021510', 'ÁNCASH', 'PALLASCA', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021511', 'ÁNCASH', 'PALLASCA', 'TAUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021601', 'ÁNCASH', 'POMABAMBA', 'POMABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021602', 'ÁNCASH', 'POMABAMBA', 'HUAYLLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021603', 'ÁNCASH', 'POMABAMBA', 'PAROBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021604', 'ÁNCASH', 'POMABAMBA', 'QUINUABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021701', 'ÁNCASH', 'RECUAY', 'RECUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('021702', 'ÁNCASH', 'RECUAY', 'CATAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('021703', 'ÁNCASH', 'RECUAY', 'COTAPARACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021704', 'ÁNCASH', 'RECUAY', 'HUAYLLAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021705', 'ÁNCASH', 'RECUAY', 'LLACLLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021706', 'ÁNCASH', 'RECUAY', 'MARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021707', 'ÁNCASH', 'RECUAY', 'PAMPAS CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021708', 'ÁNCASH', 'RECUAY', 'PARARIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021709', 'ÁNCASH', 'RECUAY', 'TAPACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021710', 'ÁNCASH', 'RECUAY', 'TICAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021801', 'ÁNCASH', 'SANTA', 'CHIMBOTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021802', 'ÁNCASH', 'SANTA', 'CÁCERES DEL PERÚ');
INSERT INTO `tb_conf_ubigeo` VALUES ('021803', 'ÁNCASH', 'SANTA', 'COISHCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021804', 'ÁNCASH', 'SANTA', 'MACATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021805', 'ÁNCASH', 'SANTA', 'MORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021806', 'ÁNCASH', 'SANTA', 'NEPEÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021807', 'ÁNCASH', 'SANTA', 'SAMANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021808', 'ÁNCASH', 'SANTA', 'SANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021809', 'ÁNCASH', 'SANTA', 'NUEVO CHIMBOTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021901', 'ÁNCASH', 'SIHUAS', 'SIHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021902', 'ÁNCASH', 'SIHUAS', 'ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021903', 'ÁNCASH', 'SIHUAS', 'ALFONSO UGARTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021904', 'ÁNCASH', 'SIHUAS', 'CASHAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021905', 'ÁNCASH', 'SIHUAS', 'CHINGALPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021906', 'ÁNCASH', 'SIHUAS', 'HUAYLLABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021907', 'ÁNCASH', 'SIHUAS', 'QUICHES');
INSERT INTO `tb_conf_ubigeo` VALUES ('021908', 'ÁNCASH', 'SIHUAS', 'RAGASH');
INSERT INTO `tb_conf_ubigeo` VALUES ('021909', 'ÁNCASH', 'SIHUAS', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021910', 'ÁNCASH', 'SIHUAS', 'SICSIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('022001', 'ÁNCASH', 'YUNGAY', 'YUNGAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('022002', 'ÁNCASH', 'YUNGAY', 'CASCAPARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('022003', 'ÁNCASH', 'YUNGAY', 'MANCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('022004', 'ÁNCASH', 'YUNGAY', 'MATACOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('022005', 'ÁNCASH', 'YUNGAY', 'QUILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('022006', 'ÁNCASH', 'YUNGAY', 'RANRAHIRCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('022007', 'ÁNCASH', 'YUNGAY', 'SHUPLUY');
INSERT INTO `tb_conf_ubigeo` VALUES ('022008', 'ÁNCASH', 'YUNGAY', 'YANAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030101', 'APURÍMAC', 'ABANCAY', 'ABANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030102', 'APURÍMAC', 'ABANCAY', 'CHACOCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('030103', 'APURÍMAC', 'ABANCAY', 'CIRCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030104', 'APURÍMAC', 'ABANCAY', 'CURAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030105', 'APURÍMAC', 'ABANCAY', 'HUANIPACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030106', 'APURÍMAC', 'ABANCAY', 'LAMBRAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030107', 'APURÍMAC', 'ABANCAY', 'PICHIRHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030108', 'APURÍMAC', 'ABANCAY', 'SAN PEDRO DE CACHORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030109', 'APURÍMAC', 'ABANCAY', 'TAMBURCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030201', 'APURÍMAC', 'ANDAHUAYLAS', 'ANDAHUAYLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030202', 'APURÍMAC', 'ANDAHUAYLAS', 'ANDARAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030203', 'APURÍMAC', 'ANDAHUAYLAS', 'CHIARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030204', 'APURÍMAC', 'ANDAHUAYLAS', 'HUANCARAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030205', 'APURÍMAC', 'ANDAHUAYLAS', 'HUANCARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030206', 'APURÍMAC', 'ANDAHUAYLAS', 'HUAYANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030207', 'APURÍMAC', 'ANDAHUAYLAS', 'KISHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030208', 'APURÍMAC', 'ANDAHUAYLAS', 'PACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030209', 'APURÍMAC', 'ANDAHUAYLAS', 'PACUCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030210', 'APURÍMAC', 'ANDAHUAYLAS', 'PAMPACHIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030211', 'APURÍMAC', 'ANDAHUAYLAS', 'POMACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030212', 'APURÍMAC', 'ANDAHUAYLAS', 'SAN ANTONIO DE CACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030213', 'APURÍMAC', 'ANDAHUAYLAS', 'SAN JERÓNIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030214', 'APURÍMAC', 'ANDAHUAYLAS', 'SAN MIGUEL DE CHACCRAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030215', 'APURÍMAC', 'ANDAHUAYLAS', 'SANTA MARÍA DE CHICMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030216', 'APURÍMAC', 'ANDAHUAYLAS', 'TALAVERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030217', 'APURÍMAC', 'ANDAHUAYLAS', 'TUMAY HUARACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030218', 'APURÍMAC', 'ANDAHUAYLAS', 'TURPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030219', 'APURÍMAC', 'ANDAHUAYLAS', 'KAQUIABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030220', 'APURÍMAC', 'ANDAHUAYLAS', 'JOSÉ MARÍA ARGUEDAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030301', 'APURÍMAC', 'ANTABAMBA', 'ANTABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030302', 'APURÍMAC', 'ANTABAMBA', 'EL ORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030303', 'APURÍMAC', 'ANTABAMBA', 'HUAQUIRCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030304', 'APURÍMAC', 'ANTABAMBA', 'JUAN ESPINOZA MEDRANO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030305', 'APURÍMAC', 'ANTABAMBA', 'OROPESA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030306', 'APURÍMAC', 'ANTABAMBA', 'PACHACONAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030307', 'APURÍMAC', 'ANTABAMBA', 'SABAINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030401', 'APURÍMAC', 'AYMARAES', 'CHALHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030402', 'APURÍMAC', 'AYMARAES', 'CAPAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030403', 'APURÍMAC', 'AYMARAES', 'CARAYBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030404', 'APURÍMAC', 'AYMARAES', 'CHAPIMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030405', 'APURÍMAC', 'AYMARAES', 'COLCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030406', 'APURÍMAC', 'AYMARAES', 'COTARUSE');
INSERT INTO `tb_conf_ubigeo` VALUES ('030407', 'APURÍMAC', 'AYMARAES', 'IHUAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030408', 'APURÍMAC', 'AYMARAES', 'JUSTO APU SAHUARAURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030409', 'APURÍMAC', 'AYMARAES', 'LUCRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('030410', 'APURÍMAC', 'AYMARAES', 'POCOHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030411', 'APURÍMAC', 'AYMARAES', 'SAN JUAN DE CHACÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030412', 'APURÍMAC', 'AYMARAES', 'SAÑAYCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030413', 'APURÍMAC', 'AYMARAES', 'SORAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030414', 'APURÍMAC', 'AYMARAES', 'TAPAIRIHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030415', 'APURÍMAC', 'AYMARAES', 'TINTAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030416', 'APURÍMAC', 'AYMARAES', 'TORAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030417', 'APURÍMAC', 'AYMARAES', 'YANACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030501', 'APURÍMAC', 'COTABAMBAS', 'TAMBOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030502', 'APURÍMAC', 'COTABAMBAS', 'COTABAMBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030503', 'APURÍMAC', 'COTABAMBAS', 'COYLLURQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030504', 'APURÍMAC', 'COTABAMBAS', 'HAQUIRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030505', 'APURÍMAC', 'COTABAMBAS', 'MARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030506', 'APURÍMAC', 'COTABAMBAS', 'CHALLHUAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030601', 'APURÍMAC', 'CHINCHEROS', 'CHINCHEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030602', 'APURÍMAC', 'CHINCHEROS', 'ANCO_HUALLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030603', 'APURÍMAC', 'CHINCHEROS', 'COCHARCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030604', 'APURÍMAC', 'CHINCHEROS', 'HUACCANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030605', 'APURÍMAC', 'CHINCHEROS', 'OCOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030606', 'APURÍMAC', 'CHINCHEROS', 'ONGOY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030607', 'APURÍMAC', 'CHINCHEROS', 'URANMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030608', 'APURÍMAC', 'CHINCHEROS', 'RANRACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030609', 'APURÍMAC', 'CHINCHEROS', 'ROCCHACC');
INSERT INTO `tb_conf_ubigeo` VALUES ('030610', 'APURÍMAC', 'CHINCHEROS', 'EL PORVENIR');
INSERT INTO `tb_conf_ubigeo` VALUES ('030701', 'APURÍMAC', 'GRAU', 'CHUQUIBAMBILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030702', 'APURÍMAC', 'GRAU', 'CURPAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030703', 'APURÍMAC', 'GRAU', 'GAMARRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030704', 'APURÍMAC', 'GRAU', 'HUAYLLATI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030705', 'APURÍMAC', 'GRAU', 'MAMARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030706', 'APURÍMAC', 'GRAU', 'MICAELA BASTIDAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030707', 'APURÍMAC', 'GRAU', 'PATAYPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030708', 'APURÍMAC', 'GRAU', 'PROGRESO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030709', 'APURÍMAC', 'GRAU', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030710', 'APURÍMAC', 'GRAU', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030711', 'APURÍMAC', 'GRAU', 'TURPAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030712', 'APURÍMAC', 'GRAU', 'VILCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030713', 'APURÍMAC', 'GRAU', 'VIRUNDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030714', 'APURÍMAC', 'GRAU', 'CURASCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040101', 'AREQUIPA', 'AREQUIPA', 'AREQUIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040102', 'AREQUIPA', 'AREQUIPA', 'ALTO SELVA ALEGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040103', 'AREQUIPA', 'AREQUIPA', 'CAYMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040104', 'AREQUIPA', 'AREQUIPA', 'CERRO COLORADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040105', 'AREQUIPA', 'AREQUIPA', 'CHARACATO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040106', 'AREQUIPA', 'AREQUIPA', 'CHIGUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040107', 'AREQUIPA', 'AREQUIPA', 'JACOBO HUNTER');
INSERT INTO `tb_conf_ubigeo` VALUES ('040108', 'AREQUIPA', 'AREQUIPA', 'LA JOYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040109', 'AREQUIPA', 'AREQUIPA', 'MARIANO MELGAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('040110', 'AREQUIPA', 'AREQUIPA', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('040111', 'AREQUIPA', 'AREQUIPA', 'MOLLEBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040112', 'AREQUIPA', 'AREQUIPA', 'PAUCARPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040113', 'AREQUIPA', 'AREQUIPA', 'POCSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040114', 'AREQUIPA', 'AREQUIPA', 'POLOBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040115', 'AREQUIPA', 'AREQUIPA', 'QUEQUEÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040116', 'AREQUIPA', 'AREQUIPA', 'SABANDIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040117', 'AREQUIPA', 'AREQUIPA', 'SACHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040118', 'AREQUIPA', 'AREQUIPA', 'SAN JUAN DE SIGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040119', 'AREQUIPA', 'AREQUIPA', 'SAN JUAN DE TARUCANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040120', 'AREQUIPA', 'AREQUIPA', 'SANTA ISABEL DE SIGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040121', 'AREQUIPA', 'AREQUIPA', 'SANTA RITA DE SIGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040122', 'AREQUIPA', 'AREQUIPA', 'SOCABAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040123', 'AREQUIPA', 'AREQUIPA', 'TIABAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040124', 'AREQUIPA', 'AREQUIPA', 'UCHUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040125', 'AREQUIPA', 'AREQUIPA', 'VITOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('040126', 'AREQUIPA', 'AREQUIPA', 'YANAHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040127', 'AREQUIPA', 'AREQUIPA', 'YARABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040128', 'AREQUIPA', 'AREQUIPA', 'YURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040129', 'AREQUIPA', 'AREQUIPA', 'JOSÉ LUIS BUSTAMANTE Y RIVERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040201', 'AREQUIPA', 'CAMANÁ', 'CAMANÁ');
INSERT INTO `tb_conf_ubigeo` VALUES ('040202', 'AREQUIPA', 'CAMANÁ', 'JOSÉ MARÍA QUIMPER');
INSERT INTO `tb_conf_ubigeo` VALUES ('040203', 'AREQUIPA', 'CAMANÁ', 'MARIANO NICOLÁS VALCÁRCEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('040204', 'AREQUIPA', 'CAMANÁ', 'MARISCAL CÁCERES');
INSERT INTO `tb_conf_ubigeo` VALUES ('040205', 'AREQUIPA', 'CAMANÁ', 'NICOLÁS DE PIEROLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040206', 'AREQUIPA', 'CAMANÁ', 'OCOÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040207', 'AREQUIPA', 'CAMANÁ', 'QUILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040208', 'AREQUIPA', 'CAMANÁ', 'SAMUEL PASTOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('040301', 'AREQUIPA', 'CARAVELÍ', 'CARAVELÍ');
INSERT INTO `tb_conf_ubigeo` VALUES ('040302', 'AREQUIPA', 'CARAVELÍ', 'ACARÍ');
INSERT INTO `tb_conf_ubigeo` VALUES ('040303', 'AREQUIPA', 'CARAVELÍ', 'ATICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040304', 'AREQUIPA', 'CARAVELÍ', 'ATIQUIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040305', 'AREQUIPA', 'CARAVELÍ', 'BELLA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('040306', 'AREQUIPA', 'CARAVELÍ', 'CAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040307', 'AREQUIPA', 'CARAVELÍ', 'CHALA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040308', 'AREQUIPA', 'CARAVELÍ', 'CHAPARRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040309', 'AREQUIPA', 'CARAVELÍ', 'HUANUHUANU');
INSERT INTO `tb_conf_ubigeo` VALUES ('040310', 'AREQUIPA', 'CARAVELÍ', 'JAQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040311', 'AREQUIPA', 'CARAVELÍ', 'LOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040312', 'AREQUIPA', 'CARAVELÍ', 'QUICACHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040313', 'AREQUIPA', 'CARAVELÍ', 'YAUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040401', 'AREQUIPA', 'CASTILLA', 'APLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040402', 'AREQUIPA', 'CASTILLA', 'ANDAGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040403', 'AREQUIPA', 'CASTILLA', 'AYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040404', 'AREQUIPA', 'CASTILLA', 'CHACHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040405', 'AREQUIPA', 'CASTILLA', 'CHILCAYMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040406', 'AREQUIPA', 'CASTILLA', 'CHOCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040407', 'AREQUIPA', 'CASTILLA', 'HUANCARQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040408', 'AREQUIPA', 'CASTILLA', 'MACHAGUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040409', 'AREQUIPA', 'CASTILLA', 'ORCOPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040410', 'AREQUIPA', 'CASTILLA', 'PAMPACOLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040411', 'AREQUIPA', 'CASTILLA', 'TIPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('040412', 'AREQUIPA', 'CASTILLA', 'UÑON');
INSERT INTO `tb_conf_ubigeo` VALUES ('040413', 'AREQUIPA', 'CASTILLA', 'URACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040414', 'AREQUIPA', 'CASTILLA', 'VIRACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040501', 'AREQUIPA', 'CAYLLOMA', 'CHIVAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040502', 'AREQUIPA', 'CAYLLOMA', 'ACHOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040503', 'AREQUIPA', 'CAYLLOMA', 'CABANACONDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040504', 'AREQUIPA', 'CAYLLOMA', 'CALLALLI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040505', 'AREQUIPA', 'CAYLLOMA', 'CAYLLOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040506', 'AREQUIPA', 'CAYLLOMA', 'COPORAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040507', 'AREQUIPA', 'CAYLLOMA', 'HUAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040508', 'AREQUIPA', 'CAYLLOMA', 'HUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040509', 'AREQUIPA', 'CAYLLOMA', 'ICHUPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040510', 'AREQUIPA', 'CAYLLOMA', 'LARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040511', 'AREQUIPA', 'CAYLLOMA', 'LLUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040512', 'AREQUIPA', 'CAYLLOMA', 'MACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040513', 'AREQUIPA', 'CAYLLOMA', 'MADRIGAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('040514', 'AREQUIPA', 'CAYLLOMA', 'SAN ANTONIO DE CHUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040515', 'AREQUIPA', 'CAYLLOMA', 'SIBAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040516', 'AREQUIPA', 'CAYLLOMA', 'TAPAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040517', 'AREQUIPA', 'CAYLLOMA', 'TISCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040518', 'AREQUIPA', 'CAYLLOMA', 'TUTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040519', 'AREQUIPA', 'CAYLLOMA', 'YANQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040520', 'AREQUIPA', 'CAYLLOMA', 'MAJES');
INSERT INTO `tb_conf_ubigeo` VALUES ('040601', 'AREQUIPA', 'CONDESUYOS', 'CHUQUIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040602', 'AREQUIPA', 'CONDESUYOS', 'ANDARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040603', 'AREQUIPA', 'CONDESUYOS', 'CAYARANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040604', 'AREQUIPA', 'CONDESUYOS', 'CHICHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040605', 'AREQUIPA', 'CONDESUYOS', 'IRAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040606', 'AREQUIPA', 'CONDESUYOS', 'RÍO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040607', 'AREQUIPA', 'CONDESUYOS', 'SALAMANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040608', 'AREQUIPA', 'CONDESUYOS', 'YANAQUIHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040701', 'AREQUIPA', 'ISLAY', 'MOLLENDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040702', 'AREQUIPA', 'ISLAY', 'COCACHACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040703', 'AREQUIPA', 'ISLAY', 'DEAN VALDIVIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040704', 'AREQUIPA', 'ISLAY', 'ISLAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040705', 'AREQUIPA', 'ISLAY', 'MEJIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040706', 'AREQUIPA', 'ISLAY', 'PUNTA DE BOMBÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('040801', 'AREQUIPA', 'LA UNIÒN', 'COTAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040802', 'AREQUIPA', 'LA UNIÒN', 'ALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040803', 'AREQUIPA', 'LA UNIÒN', 'CHARCANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040804', 'AREQUIPA', 'LA UNIÒN', 'HUAYNACOTAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040805', 'AREQUIPA', 'LA UNIÒN', 'PAMPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040806', 'AREQUIPA', 'LA UNIÒN', 'PUYCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040807', 'AREQUIPA', 'LA UNIÒN', 'QUECHUALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040808', 'AREQUIPA', 'LA UNIÒN', 'SAYLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040809', 'AREQUIPA', 'LA UNIÒN', 'TAURIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040810', 'AREQUIPA', 'LA UNIÒN', 'TOMEPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040811', 'AREQUIPA', 'LA UNIÒN', 'TORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050101', 'AYACUCHO', 'HUAMANGA', 'AYACUCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050102', 'AYACUCHO', 'HUAMANGA', 'ACOCRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050103', 'AYACUCHO', 'HUAMANGA', 'ACOS VINCHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050104', 'AYACUCHO', 'HUAMANGA', 'CARMEN ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050105', 'AYACUCHO', 'HUAMANGA', 'CHIARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050106', 'AYACUCHO', 'HUAMANGA', 'OCROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050107', 'AYACUCHO', 'HUAMANGA', 'PACAYCASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050108', 'AYACUCHO', 'HUAMANGA', 'QUINUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050109', 'AYACUCHO', 'HUAMANGA', 'SAN JOSÉ DE TICLLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050110', 'AYACUCHO', 'HUAMANGA', 'SAN JUAN BAUTISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050111', 'AYACUCHO', 'HUAMANGA', 'SANTIAGO DE PISCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050112', 'AYACUCHO', 'HUAMANGA', 'SOCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050113', 'AYACUCHO', 'HUAMANGA', 'TAMBILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050114', 'AYACUCHO', 'HUAMANGA', 'VINCHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050115', 'AYACUCHO', 'HUAMANGA', 'JESÚS NAZARENO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050116', 'AYACUCHO', 'HUAMANGA', 'ANDRÉS AVELINO CÁCERES DORREGARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050201', 'AYACUCHO', 'CANGALLO', 'CANGALLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050202', 'AYACUCHO', 'CANGALLO', 'CHUSCHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050203', 'AYACUCHO', 'CANGALLO', 'LOS MOROCHUCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050204', 'AYACUCHO', 'CANGALLO', 'MARÍA PARADO DE BELLIDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050205', 'AYACUCHO', 'CANGALLO', 'PARAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050206', 'AYACUCHO', 'CANGALLO', 'TOTOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050301', 'AYACUCHO', 'HUANCA SANCOS', 'SANCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050302', 'AYACUCHO', 'HUANCA SANCOS', 'CARAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050303', 'AYACUCHO', 'HUANCA SANCOS', 'SACSAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050304', 'AYACUCHO', 'HUANCA SANCOS', 'SANTIAGO DE LUCANAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050401', 'AYACUCHO', 'HUANTA', 'HUANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050402', 'AYACUCHO', 'HUANTA', 'AYAHUANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050403', 'AYACUCHO', 'HUANTA', 'HUAMANGUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050404', 'AYACUCHO', 'HUANTA', 'IGUAIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('050405', 'AYACUCHO', 'HUANTA', 'LURICOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050406', 'AYACUCHO', 'HUANTA', 'SANTILLANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050407', 'AYACUCHO', 'HUANTA', 'SIVIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050408', 'AYACUCHO', 'HUANTA', 'LLOCHEGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050409', 'AYACUCHO', 'HUANTA', 'CANAYRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('050410', 'AYACUCHO', 'HUANTA', 'UCHURACCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050411', 'AYACUCHO', 'HUANTA', 'PUCACOLPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050412', 'AYACUCHO', 'HUANTA', 'CHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050501', 'AYACUCHO', 'LA MAR', 'SAN MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('050502', 'AYACUCHO', 'LA MAR', 'ANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050503', 'AYACUCHO', 'LA MAR', 'AYNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050504', 'AYACUCHO', 'LA MAR', 'CHILCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050505', 'AYACUCHO', 'LA MAR', 'CHUNGUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050506', 'AYACUCHO', 'LA MAR', 'LUIS CARRANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050507', 'AYACUCHO', 'LA MAR', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050508', 'AYACUCHO', 'LA MAR', 'TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050509', 'AYACUCHO', 'LA MAR', 'SAMUGARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050510', 'AYACUCHO', 'LA MAR', 'ANCHIHUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050601', 'AYACUCHO', 'LUCANAS', 'PUQUIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050602', 'AYACUCHO', 'LUCANAS', 'AUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050603', 'AYACUCHO', 'LUCANAS', 'CABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050604', 'AYACUCHO', 'LUCANAS', 'CARMEN SALCEDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050605', 'AYACUCHO', 'LUCANAS', 'CHAVIÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050606', 'AYACUCHO', 'LUCANAS', 'CHIPAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050607', 'AYACUCHO', 'LUCANAS', 'HUAC-HUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050608', 'AYACUCHO', 'LUCANAS', 'LARAMATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('050609', 'AYACUCHO', 'LUCANAS', 'LEONCIO PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050610', 'AYACUCHO', 'LUCANAS', 'LLAUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050611', 'AYACUCHO', 'LUCANAS', 'LUCANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050612', 'AYACUCHO', 'LUCANAS', 'OCAÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050613', 'AYACUCHO', 'LUCANAS', 'OTOCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050614', 'AYACUCHO', 'LUCANAS', 'SAISA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050615', 'AYACUCHO', 'LUCANAS', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('050616', 'AYACUCHO', 'LUCANAS', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('050617', 'AYACUCHO', 'LUCANAS', 'SAN PEDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050618', 'AYACUCHO', 'LUCANAS', 'SAN PEDRO DE PALCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050619', 'AYACUCHO', 'LUCANAS', 'SANCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050620', 'AYACUCHO', 'LUCANAS', 'SANTA ANA DE HUAYCAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050621', 'AYACUCHO', 'LUCANAS', 'SANTA LUCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050701', 'AYACUCHO', 'PARINACOCHAS', 'CORACORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050702', 'AYACUCHO', 'PARINACOCHAS', 'CHUMPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050703', 'AYACUCHO', 'PARINACOCHAS', 'CORONEL CASTAÑEDA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050704', 'AYACUCHO', 'PARINACOCHAS', 'PACAPAUSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050705', 'AYACUCHO', 'PARINACOCHAS', 'PULLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050706', 'AYACUCHO', 'PARINACOCHAS', 'PUYUSCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050707', 'AYACUCHO', 'PARINACOCHAS', 'SAN FRANCISCO DE RAVACAYCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050708', 'AYACUCHO', 'PARINACOCHAS', 'UPAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050801', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'PAUSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050802', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'COLTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050803', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'CORCULLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050804', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'LAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050805', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'MARCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050806', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'OYOLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050807', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'PARARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050808', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'SAN JAVIER DE ALPABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050809', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'SAN JOSÉ DE USHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050810', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'SARA SARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050901', 'AYACUCHO', 'SUCRE', 'QUEROBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050902', 'AYACUCHO', 'SUCRE', 'BELÉN');
INSERT INTO `tb_conf_ubigeo` VALUES ('050903', 'AYACUCHO', 'SUCRE', 'CHALCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050904', 'AYACUCHO', 'SUCRE', 'CHILCAYOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('050905', 'AYACUCHO', 'SUCRE', 'HUACAÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050906', 'AYACUCHO', 'SUCRE', 'MORCOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050907', 'AYACUCHO', 'SUCRE', 'PAICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050908', 'AYACUCHO', 'SUCRE', 'SAN PEDRO DE LARCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050909', 'AYACUCHO', 'SUCRE', 'SAN SALVADOR DE QUIJE');
INSERT INTO `tb_conf_ubigeo` VALUES ('050910', 'AYACUCHO', 'SUCRE', 'SANTIAGO DE PAUCARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050911', 'AYACUCHO', 'SUCRE', 'SORAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('051001', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUANCAPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('051002', 'AYACUCHO', 'VÍCTOR FAJARDO', 'ALCAMENCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051003', 'AYACUCHO', 'VÍCTOR FAJARDO', 'APONGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('051004', 'AYACUCHO', 'VÍCTOR FAJARDO', 'ASQUIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051005', 'AYACUCHO', 'VÍCTOR FAJARDO', 'CANARIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051006', 'AYACUCHO', 'VÍCTOR FAJARDO', 'CAYARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051007', 'AYACUCHO', 'VÍCTOR FAJARDO', 'COLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051008', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUAMANQUIQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051009', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUANCARAYLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051010', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051011', 'AYACUCHO', 'VÍCTOR FAJARDO', 'SARHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051012', 'AYACUCHO', 'VÍCTOR FAJARDO', 'VILCANCHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('051101', 'AYACUCHO', 'VILCAS HUAMÁN', 'VILCAS HUAMAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('051102', 'AYACUCHO', 'VILCAS HUAMÁN', 'ACCOMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051103', 'AYACUCHO', 'VILCAS HUAMÁN', 'CARHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051104', 'AYACUCHO', 'VILCAS HUAMÁN', 'CONCEPCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('051105', 'AYACUCHO', 'VILCAS HUAMÁN', 'HUAMBALPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051106', 'AYACUCHO', 'VILCAS HUAMÁN', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051107', 'AYACUCHO', 'VILCAS HUAMÁN', 'SAURAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051108', 'AYACUCHO', 'VILCAS HUAMÁN', 'VISCHONGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060101', 'CAJAMARCA', 'CAJAMARCA', 'CAJAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060102', 'CAJAMARCA', 'CAJAMARCA', 'ASUNCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060103', 'CAJAMARCA', 'CAJAMARCA', 'CHETILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060104', 'CAJAMARCA', 'CAJAMARCA', 'COSPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060105', 'CAJAMARCA', 'CAJAMARCA', 'ENCAÑADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060106', 'CAJAMARCA', 'CAJAMARCA', 'JESÚS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060107', 'CAJAMARCA', 'CAJAMARCA', 'LLACANORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060108', 'CAJAMARCA', 'CAJAMARCA', 'LOS BAÑOS DEL INCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060109', 'CAJAMARCA', 'CAJAMARCA', 'MAGDALENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060110', 'CAJAMARCA', 'CAJAMARCA', 'MATARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060111', 'CAJAMARCA', 'CAJAMARCA', 'NAMORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060112', 'CAJAMARCA', 'CAJAMARCA', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060201', 'CAJAMARCA', 'CAJABAMBA', 'CAJABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060202', 'CAJAMARCA', 'CAJABAMBA', 'CACHACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('060203', 'CAJAMARCA', 'CAJABAMBA', 'CONDEBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060204', 'CAJAMARCA', 'CAJABAMBA', 'SITACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060301', 'CAJAMARCA', 'CELENDÍN', 'CELENDÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060302', 'CAJAMARCA', 'CELENDÍN', 'CHUMUCH');
INSERT INTO `tb_conf_ubigeo` VALUES ('060303', 'CAJAMARCA', 'CELENDÍN', 'CORTEGANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060304', 'CAJAMARCA', 'CELENDÍN', 'HUASMIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060305', 'CAJAMARCA', 'CELENDÍN', 'JORGE CHÁVEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('060306', 'CAJAMARCA', 'CELENDÍN', 'JOSÉ GÁLVEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('060307', 'CAJAMARCA', 'CELENDÍN', 'MIGUEL IGLESIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060308', 'CAJAMARCA', 'CELENDÍN', 'OXAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060309', 'CAJAMARCA', 'CELENDÍN', 'SOROCHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060310', 'CAJAMARCA', 'CELENDÍN', 'SUCRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060311', 'CAJAMARCA', 'CELENDÍN', 'UTCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060312', 'CAJAMARCA', 'CELENDÍN', 'LA LIBERTAD DE PALLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060401', 'CAJAMARCA', 'CHOTA', 'CHOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060402', 'CAJAMARCA', 'CHOTA', 'ANGUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060403', 'CAJAMARCA', 'CHOTA', 'CHADIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060404', 'CAJAMARCA', 'CHOTA', 'CHIGUIRIP');
INSERT INTO `tb_conf_ubigeo` VALUES ('060405', 'CAJAMARCA', 'CHOTA', 'CHIMBAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060406', 'CAJAMARCA', 'CHOTA', 'CHOROPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060407', 'CAJAMARCA', 'CHOTA', 'COCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060408', 'CAJAMARCA', 'CHOTA', 'CONCHAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060409', 'CAJAMARCA', 'CHOTA', 'HUAMBOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060410', 'CAJAMARCA', 'CHOTA', 'LAJAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060411', 'CAJAMARCA', 'CHOTA', 'LLAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060412', 'CAJAMARCA', 'CHOTA', 'MIRACOSTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060413', 'CAJAMARCA', 'CHOTA', 'PACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060414', 'CAJAMARCA', 'CHOTA', 'PION');
INSERT INTO `tb_conf_ubigeo` VALUES ('060415', 'CAJAMARCA', 'CHOTA', 'QUEROCOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060416', 'CAJAMARCA', 'CHOTA', 'SAN JUAN DE LICUPIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060417', 'CAJAMARCA', 'CHOTA', 'TACABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060418', 'CAJAMARCA', 'CHOTA', 'TOCMOCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060419', 'CAJAMARCA', 'CHOTA', 'CHALAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060501', 'CAJAMARCA', 'CONTUMAZÁ', 'CONTUMAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060502', 'CAJAMARCA', 'CONTUMAZÁ', 'CHILETE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060503', 'CAJAMARCA', 'CONTUMAZÁ', 'CUPISNIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060504', 'CAJAMARCA', 'CONTUMAZÁ', 'GUZMANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060505', 'CAJAMARCA', 'CONTUMAZÁ', 'SAN BENITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060506', 'CAJAMARCA', 'CONTUMAZÁ', 'SANTA CRUZ DE TOLEDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060507', 'CAJAMARCA', 'CONTUMAZÁ', 'TANTARICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060508', 'CAJAMARCA', 'CONTUMAZÁ', 'YONAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060601', 'CAJAMARCA', 'CUTERVO', 'CUTERVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060602', 'CAJAMARCA', 'CUTERVO', 'CALLAYUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('060603', 'CAJAMARCA', 'CUTERVO', 'CHOROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060604', 'CAJAMARCA', 'CUTERVO', 'CUJILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060605', 'CAJAMARCA', 'CUTERVO', 'LA RAMADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060606', 'CAJAMARCA', 'CUTERVO', 'PIMPINGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060607', 'CAJAMARCA', 'CUTERVO', 'QUEROCOTILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060608', 'CAJAMARCA', 'CUTERVO', 'SAN ANDRÉS DE CUTERVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060609', 'CAJAMARCA', 'CUTERVO', 'SAN JUAN DE CUTERVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060610', 'CAJAMARCA', 'CUTERVO', 'SAN LUIS DE LUCMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060611', 'CAJAMARCA', 'CUTERVO', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('060612', 'CAJAMARCA', 'CUTERVO', 'SANTO DOMINGO DE LA CAPILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060613', 'CAJAMARCA', 'CUTERVO', 'SANTO TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060614', 'CAJAMARCA', 'CUTERVO', 'SOCOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060615', 'CAJAMARCA', 'CUTERVO', 'TORIBIO CASANOVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060701', 'CAJAMARCA', 'HUALGAYOC', 'BAMBAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060702', 'CAJAMARCA', 'HUALGAYOC', 'CHUGUR');
INSERT INTO `tb_conf_ubigeo` VALUES ('060703', 'CAJAMARCA', 'HUALGAYOC', 'HUALGAYOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('060801', 'CAJAMARCA', 'JAÉN', 'JAÉN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060802', 'CAJAMARCA', 'JAÉN', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060803', 'CAJAMARCA', 'JAÉN', 'CHONTALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('060804', 'CAJAMARCA', 'JAÉN', 'COLASAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('060805', 'CAJAMARCA', 'JAÉN', 'HUABAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('060806', 'CAJAMARCA', 'JAÉN', 'LAS PIRIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060807', 'CAJAMARCA', 'JAÉN', 'POMAHUACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060808', 'CAJAMARCA', 'JAÉN', 'PUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060809', 'CAJAMARCA', 'JAÉN', 'SALLIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060810', 'CAJAMARCA', 'JAÉN', 'SAN FELIPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060811', 'CAJAMARCA', 'JAÉN', 'SAN JOSÉ DEL ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060812', 'CAJAMARCA', 'JAÉN', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060901', 'CAJAMARCA', 'SAN IGNACIO', 'SAN IGNACIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060902', 'CAJAMARCA', 'SAN IGNACIO', 'CHIRINOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060903', 'CAJAMARCA', 'SAN IGNACIO', 'HUARANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060904', 'CAJAMARCA', 'SAN IGNACIO', 'LA COIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060905', 'CAJAMARCA', 'SAN IGNACIO', 'NAMBALLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060906', 'CAJAMARCA', 'SAN IGNACIO', 'SAN JOSÉ DE LOURDES');
INSERT INTO `tb_conf_ubigeo` VALUES ('060907', 'CAJAMARCA', 'SAN IGNACIO', 'TABACONAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061001', 'CAJAMARCA', 'SAN MARCOS', 'PEDRO GÁLVEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('061002', 'CAJAMARCA', 'SAN MARCOS', 'CHANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('061003', 'CAJAMARCA', 'SAN MARCOS', 'EDUARDO VILLANUEVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061004', 'CAJAMARCA', 'SAN MARCOS', 'GREGORIO PITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061005', 'CAJAMARCA', 'SAN MARCOS', 'ICHOCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061006', 'CAJAMARCA', 'SAN MARCOS', 'JOSÉ MANUEL QUIROZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('061007', 'CAJAMARCA', 'SAN MARCOS', 'JOSÉ SABOGAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('061101', 'CAJAMARCA', 'SAN MIGUEL', 'SAN MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('061102', 'CAJAMARCA', 'SAN MIGUEL', 'BOLÍVAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('061103', 'CAJAMARCA', 'SAN MIGUEL', 'CALQUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061104', 'CAJAMARCA', 'SAN MIGUEL', 'CATILLUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('061105', 'CAJAMARCA', 'SAN MIGUEL', 'EL PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061106', 'CAJAMARCA', 'SAN MIGUEL', 'LA FLORIDA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061107', 'CAJAMARCA', 'SAN MIGUEL', 'LLAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061108', 'CAJAMARCA', 'SAN MIGUEL', 'NANCHOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('061109', 'CAJAMARCA', 'SAN MIGUEL', 'NIEPOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061110', 'CAJAMARCA', 'SAN MIGUEL', 'SAN GREGORIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061111', 'CAJAMARCA', 'SAN MIGUEL', 'SAN SILVESTRE DE COCHAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061112', 'CAJAMARCA', 'SAN MIGUEL', 'TONGOD');
INSERT INTO `tb_conf_ubigeo` VALUES ('061113', 'CAJAMARCA', 'SAN MIGUEL', 'UNIÓN AGUA BLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061201', 'CAJAMARCA', 'SAN PABLO', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061202', 'CAJAMARCA', 'SAN PABLO', 'SAN BERNARDINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061203', 'CAJAMARCA', 'SAN PABLO', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061204', 'CAJAMARCA', 'SAN PABLO', 'TUMBADEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061301', 'CAJAMARCA', 'SANTA CRUZ', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('061302', 'CAJAMARCA', 'SANTA CRUZ', 'ANDABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061303', 'CAJAMARCA', 'SANTA CRUZ', 'CATACHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('061304', 'CAJAMARCA', 'SANTA CRUZ', 'CHANCAYBAÑOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061305', 'CAJAMARCA', 'SANTA CRUZ', 'LA ESPERANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061306', 'CAJAMARCA', 'SANTA CRUZ', 'NINABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061307', 'CAJAMARCA', 'SANTA CRUZ', 'PULAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061308', 'CAJAMARCA', 'SANTA CRUZ', 'SAUCEPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061309', 'CAJAMARCA', 'SANTA CRUZ', 'SEXI');
INSERT INTO `tb_conf_ubigeo` VALUES ('061310', 'CAJAMARCA', 'SANTA CRUZ', 'UTICYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('061311', 'CAJAMARCA', 'SANTA CRUZ', 'YAUYUCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('070101', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'CALLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('070102', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070103', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'CARMEN DE LA LEGUA REYNOSO');
INSERT INTO `tb_conf_ubigeo` VALUES ('070104', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'LA PERLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070105', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'LA PUNTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070106', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'VENTANILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070107', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'MI PERÚ');
INSERT INTO `tb_conf_ubigeo` VALUES ('080101', 'CUSCO', 'CUSCO', 'CUSCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080102', 'CUSCO', 'CUSCO', 'CCORCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080103', 'CUSCO', 'CUSCO', 'POROY');
INSERT INTO `tb_conf_ubigeo` VALUES ('080104', 'CUSCO', 'CUSCO', 'SAN JERÓNIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080105', 'CUSCO', 'CUSCO', 'SAN SEBASTIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('080106', 'CUSCO', 'CUSCO', 'SANTIAGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080107', 'CUSCO', 'CUSCO', 'SAYLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080108', 'CUSCO', 'CUSCO', 'WANCHAQ');
INSERT INTO `tb_conf_ubigeo` VALUES ('080201', 'CUSCO', 'ACOMAYO', 'ACOMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080202', 'CUSCO', 'ACOMAYO', 'ACOPIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080203', 'CUSCO', 'ACOMAYO', 'ACOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('080204', 'CUSCO', 'ACOMAYO', 'MOSOC LLACTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080205', 'CUSCO', 'ACOMAYO', 'POMACANCHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080206', 'CUSCO', 'ACOMAYO', 'RONDOCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('080207', 'CUSCO', 'ACOMAYO', 'SANGARARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080301', 'CUSCO', 'ANTA', 'ANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080302', 'CUSCO', 'ANTA', 'ANCAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080303', 'CUSCO', 'ANTA', 'CACHIMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080304', 'CUSCO', 'ANTA', 'CHINCHAYPUJIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080305', 'CUSCO', 'ANTA', 'HUAROCONDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080306', 'CUSCO', 'ANTA', 'LIMATAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080307', 'CUSCO', 'ANTA', 'MOLLEPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080308', 'CUSCO', 'ANTA', 'PUCYURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080309', 'CUSCO', 'ANTA', 'ZURITE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080401', 'CUSCO', 'CALCA', 'CALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080402', 'CUSCO', 'CALCA', 'COYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080403', 'CUSCO', 'CALCA', 'LAMAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('080404', 'CUSCO', 'CALCA', 'LARES');
INSERT INTO `tb_conf_ubigeo` VALUES ('080405', 'CUSCO', 'CALCA', 'PISAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('080406', 'CUSCO', 'CALCA', 'SAN SALVADOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('080407', 'CUSCO', 'CALCA', 'TARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('080408', 'CUSCO', 'CALCA', 'YANATILE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080501', 'CUSCO', 'CANAS', 'YANAOCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080502', 'CUSCO', 'CANAS', 'CHECCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080503', 'CUSCO', 'CANAS', 'KUNTURKANKI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080504', 'CUSCO', 'CANAS', 'LANGUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080505', 'CUSCO', 'CANAS', 'LAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080506', 'CUSCO', 'CANAS', 'PAMPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080507', 'CUSCO', 'CANAS', 'QUEHUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080508', 'CUSCO', 'CANAS', 'TUPAC AMARU');
INSERT INTO `tb_conf_ubigeo` VALUES ('080601', 'CUSCO', 'CANCHIS', 'SICUANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080602', 'CUSCO', 'CANCHIS', 'CHECACUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080603', 'CUSCO', 'CANCHIS', 'COMBAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080604', 'CUSCO', 'CANCHIS', 'MARANGANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080605', 'CUSCO', 'CANCHIS', 'PITUMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080606', 'CUSCO', 'CANCHIS', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080607', 'CUSCO', 'CANCHIS', 'SAN PEDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080608', 'CUSCO', 'CANCHIS', 'TINTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080701', 'CUSCO', 'CHUMBIVILCAS', 'SANTO TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('080702', 'CUSCO', 'CHUMBIVILCAS', 'CAPACMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080703', 'CUSCO', 'CHUMBIVILCAS', 'CHAMACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080704', 'CUSCO', 'CHUMBIVILCAS', 'COLQUEMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080705', 'CUSCO', 'CHUMBIVILCAS', 'LIVITACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080706', 'CUSCO', 'CHUMBIVILCAS', 'LLUSCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080707', 'CUSCO', 'CHUMBIVILCAS', 'QUIÑOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080708', 'CUSCO', 'CHUMBIVILCAS', 'VELILLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080801', 'CUSCO', 'ESPINAR', 'ESPINAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('080802', 'CUSCO', 'ESPINAR', 'CONDOROMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080803', 'CUSCO', 'ESPINAR', 'COPORAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080804', 'CUSCO', 'ESPINAR', 'OCORURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080805', 'CUSCO', 'ESPINAR', 'PALLPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080806', 'CUSCO', 'ESPINAR', 'PICHIGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080807', 'CUSCO', 'ESPINAR', 'SUYCKUTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080808', 'CUSCO', 'ESPINAR', 'ALTO PICHIGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080901', 'CUSCO', 'LA CONVENCIÓN', 'SANTA ANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080902', 'CUSCO', 'LA CONVENCIÓN', 'ECHARATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080903', 'CUSCO', 'LA CONVENCIÓN', 'HUAYOPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080904', 'CUSCO', 'LA CONVENCIÓN', 'MARANURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080905', 'CUSCO', 'LA CONVENCIÓN', 'OCOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080906', 'CUSCO', 'LA CONVENCIÓN', 'QUELLOUNO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080907', 'CUSCO', 'LA CONVENCIÓN', 'KIMBIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080908', 'CUSCO', 'LA CONVENCIÓN', 'SANTA TERESA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080909', 'CUSCO', 'LA CONVENCIÓN', 'VILCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080910', 'CUSCO', 'LA CONVENCIÓN', 'PICHARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080911', 'CUSCO', 'LA CONVENCIÓN', 'INKAWASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080912', 'CUSCO', 'LA CONVENCIÓN', 'VILLA VIRGEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('080913', 'CUSCO', 'LA CONVENCIÓN', 'VILLA KINTIARINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081001', 'CUSCO', 'PARURO', 'PARURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081002', 'CUSCO', 'PARURO', 'ACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081003', 'CUSCO', 'PARURO', 'CCAPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('081004', 'CUSCO', 'PARURO', 'COLCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081005', 'CUSCO', 'PARURO', 'HUANOQUITE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081006', 'CUSCO', 'PARURO', 'OMACHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081007', 'CUSCO', 'PARURO', 'PACCARITAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081008', 'CUSCO', 'PARURO', 'PILLPINTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081009', 'CUSCO', 'PARURO', 'YAURISQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081101', 'CUSCO', 'PAUCARTAMBO', 'PAUCARTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081102', 'CUSCO', 'PAUCARTAMBO', 'CAICAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('081103', 'CUSCO', 'PAUCARTAMBO', 'CHALLABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081104', 'CUSCO', 'PAUCARTAMBO', 'COLQUEPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081105', 'CUSCO', 'PAUCARTAMBO', 'HUANCARANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('081106', 'CUSCO', 'PAUCARTAMBO', 'KOSÑIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081201', 'CUSCO', 'QUISPICANCHI', 'URCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('081202', 'CUSCO', 'QUISPICANCHI', 'ANDAHUAYLILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('081203', 'CUSCO', 'QUISPICANCHI', 'CAMANTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('081204', 'CUSCO', 'QUISPICANCHI', 'CCARHUAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081205', 'CUSCO', 'QUISPICANCHI', 'CCATCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081206', 'CUSCO', 'QUISPICANCHI', 'CUSIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081207', 'CUSCO', 'QUISPICANCHI', 'HUARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081208', 'CUSCO', 'QUISPICANCHI', 'LUCRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081209', 'CUSCO', 'QUISPICANCHI', 'MARCAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081210', 'CUSCO', 'QUISPICANCHI', 'OCONGATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081211', 'CUSCO', 'QUISPICANCHI', 'OROPESA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081212', 'CUSCO', 'QUISPICANCHI', 'QUIQUIJANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081301', 'CUSCO', 'URUBAMBA', 'URUBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081302', 'CUSCO', 'URUBAMBA', 'CHINCHERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081303', 'CUSCO', 'URUBAMBA', 'HUAYLLABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081304', 'CUSCO', 'URUBAMBA', 'MACHUPICCHU');
INSERT INTO `tb_conf_ubigeo` VALUES ('081305', 'CUSCO', 'URUBAMBA', 'MARAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('081306', 'CUSCO', 'URUBAMBA', 'OLLANTAYTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081307', 'CUSCO', 'URUBAMBA', 'YUCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('090101', 'HUANCAVELICA', 'HUANCAVELICA', 'HUANCAVELICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090102', 'HUANCAVELICA', 'HUANCAVELICA', 'ACOBAMBILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090103', 'HUANCAVELICA', 'HUANCAVELICA', 'ACORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090104', 'HUANCAVELICA', 'HUANCAVELICA', 'CONAYCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090105', 'HUANCAVELICA', 'HUANCAVELICA', 'CUENCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090106', 'HUANCAVELICA', 'HUANCAVELICA', 'HUACHOCOLPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090107', 'HUANCAVELICA', 'HUANCAVELICA', 'HUAYLLAHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090108', 'HUANCAVELICA', 'HUANCAVELICA', 'IZCUCHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090109', 'HUANCAVELICA', 'HUANCAVELICA', 'LARIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090110', 'HUANCAVELICA', 'HUANCAVELICA', 'MANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090111', 'HUANCAVELICA', 'HUANCAVELICA', 'MARISCAL CÁCERES');
INSERT INTO `tb_conf_ubigeo` VALUES ('090112', 'HUANCAVELICA', 'HUANCAVELICA', 'MOYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090113', 'HUANCAVELICA', 'HUANCAVELICA', 'NUEVO OCCORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090114', 'HUANCAVELICA', 'HUANCAVELICA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090115', 'HUANCAVELICA', 'HUANCAVELICA', 'PILCHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090116', 'HUANCAVELICA', 'HUANCAVELICA', 'VILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090117', 'HUANCAVELICA', 'HUANCAVELICA', 'YAULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090118', 'HUANCAVELICA', 'HUANCAVELICA', 'ASCENSIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('090119', 'HUANCAVELICA', 'HUANCAVELICA', 'HUANDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090201', 'HUANCAVELICA', 'ACOBAMBA', 'ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090202', 'HUANCAVELICA', 'ACOBAMBA', 'ANDABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090203', 'HUANCAVELICA', 'ACOBAMBA', 'ANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090204', 'HUANCAVELICA', 'ACOBAMBA', 'CAJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090205', 'HUANCAVELICA', 'ACOBAMBA', 'MARCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090206', 'HUANCAVELICA', 'ACOBAMBA', 'PAUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090207', 'HUANCAVELICA', 'ACOBAMBA', 'POMACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090208', 'HUANCAVELICA', 'ACOBAMBA', 'ROSARIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090301', 'HUANCAVELICA', 'ANGARAES', 'LIRCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('090302', 'HUANCAVELICA', 'ANGARAES', 'ANCHONGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090303', 'HUANCAVELICA', 'ANGARAES', 'CALLANMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090304', 'HUANCAVELICA', 'ANGARAES', 'CCOCHACCASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090305', 'HUANCAVELICA', 'ANGARAES', 'CHINCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090306', 'HUANCAVELICA', 'ANGARAES', 'CONGALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090307', 'HUANCAVELICA', 'ANGARAES', 'HUANCA-HUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090308', 'HUANCAVELICA', 'ANGARAES', 'HUAYLLAY GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('090309', 'HUANCAVELICA', 'ANGARAES', 'JULCAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090310', 'HUANCAVELICA', 'ANGARAES', 'SAN ANTONIO DE ANTAPARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090311', 'HUANCAVELICA', 'ANGARAES', 'SANTO TOMAS DE PATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090312', 'HUANCAVELICA', 'ANGARAES', 'SECCLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090401', 'HUANCAVELICA', 'CASTROVIRREYNA', 'CASTROVIRREYNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090402', 'HUANCAVELICA', 'CASTROVIRREYNA', 'ARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090403', 'HUANCAVELICA', 'CASTROVIRREYNA', 'AURAHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090404', 'HUANCAVELICA', 'CASTROVIRREYNA', 'CAPILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090405', 'HUANCAVELICA', 'CASTROVIRREYNA', 'CHUPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090406', 'HUANCAVELICA', 'CASTROVIRREYNA', 'COCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090407', 'HUANCAVELICA', 'CASTROVIRREYNA', 'HUACHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090408', 'HUANCAVELICA', 'CASTROVIRREYNA', 'HUAMATAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090409', 'HUANCAVELICA', 'CASTROVIRREYNA', 'MOLLEPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090410', 'HUANCAVELICA', 'CASTROVIRREYNA', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('090411', 'HUANCAVELICA', 'CASTROVIRREYNA', 'SANTA ANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090412', 'HUANCAVELICA', 'CASTROVIRREYNA', 'TANTARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090413', 'HUANCAVELICA', 'CASTROVIRREYNA', 'TICRAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090501', 'HUANCAVELICA', 'CHURCAMPA', 'CHURCAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090502', 'HUANCAVELICA', 'CHURCAMPA', 'ANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090503', 'HUANCAVELICA', 'CHURCAMPA', 'CHINCHIHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090504', 'HUANCAVELICA', 'CHURCAMPA', 'EL CARMEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('090505', 'HUANCAVELICA', 'CHURCAMPA', 'LA MERCED');
INSERT INTO `tb_conf_ubigeo` VALUES ('090506', 'HUANCAVELICA', 'CHURCAMPA', 'LOCROJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090507', 'HUANCAVELICA', 'CHURCAMPA', 'PAUCARBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090508', 'HUANCAVELICA', 'CHURCAMPA', 'SAN MIGUEL DE MAYOCC');
INSERT INTO `tb_conf_ubigeo` VALUES ('090509', 'HUANCAVELICA', 'CHURCAMPA', 'SAN PEDRO DE CORIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090510', 'HUANCAVELICA', 'CHURCAMPA', 'PACHAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090511', 'HUANCAVELICA', 'CHURCAMPA', 'COSME');
INSERT INTO `tb_conf_ubigeo` VALUES ('090601', 'HUANCAVELICA', 'HUAYTARÁ', 'HUAYTARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090602', 'HUANCAVELICA', 'HUAYTARÁ', 'AYAVI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090603', 'HUANCAVELICA', 'HUAYTARÁ', 'CÓRDOVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090604', 'HUANCAVELICA', 'HUAYTARÁ', 'HUAYACUNDO ARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090605', 'HUANCAVELICA', 'HUAYTARÁ', 'LARAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090606', 'HUANCAVELICA', 'HUAYTARÁ', 'OCOYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090607', 'HUANCAVELICA', 'HUAYTARÁ', 'PILPICHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090608', 'HUANCAVELICA', 'HUAYTARÁ', 'QUERCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090609', 'HUANCAVELICA', 'HUAYTARÁ', 'QUITO-ARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090610', 'HUANCAVELICA', 'HUAYTARÁ', 'SAN ANTONIO DE CUSICANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090611', 'HUANCAVELICA', 'HUAYTARÁ', 'SAN FRANCISCO DE SANGAYAICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090612', 'HUANCAVELICA', 'HUAYTARÁ', 'SAN ISIDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090613', 'HUANCAVELICA', 'HUAYTARÁ', 'SANTIAGO DE CHOCORVOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090614', 'HUANCAVELICA', 'HUAYTARÁ', 'SANTIAGO DE QUIRAHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090615', 'HUANCAVELICA', 'HUAYTARÁ', 'SANTO DOMINGO DE CAPILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090616', 'HUANCAVELICA', 'HUAYTARÁ', 'TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090701', 'HUANCAVELICA', 'TAYACAJA', 'PAMPAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090702', 'HUANCAVELICA', 'TAYACAJA', 'ACOSTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090703', 'HUANCAVELICA', 'TAYACAJA', 'ACRAQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090704', 'HUANCAVELICA', 'TAYACAJA', 'AHUAYCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090705', 'HUANCAVELICA', 'TAYACAJA', 'COLCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090706', 'HUANCAVELICA', 'TAYACAJA', 'DANIEL HERNÁNDEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('090707', 'HUANCAVELICA', 'TAYACAJA', 'HUACHOCOLPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090709', 'HUANCAVELICA', 'TAYACAJA', 'HUARIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090710', 'HUANCAVELICA', 'TAYACAJA', 'ÑAHUIMPUQUIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090711', 'HUANCAVELICA', 'TAYACAJA', 'PAZOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090713', 'HUANCAVELICA', 'TAYACAJA', 'QUISHUAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('090714', 'HUANCAVELICA', 'TAYACAJA', 'SALCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090715', 'HUANCAVELICA', 'TAYACAJA', 'SALCAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090716', 'HUANCAVELICA', 'TAYACAJA', 'SAN MARCOS DE ROCCHAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('090717', 'HUANCAVELICA', 'TAYACAJA', 'SURCUBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090718', 'HUANCAVELICA', 'TAYACAJA', 'TINTAY PUNCU');
INSERT INTO `tb_conf_ubigeo` VALUES ('090719', 'HUANCAVELICA', 'TAYACAJA', 'QUICHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090720', 'HUANCAVELICA', 'TAYACAJA', 'ANDAYMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090721', 'HUANCAVELICA', 'TAYACAJA', 'ROBLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('090722', 'HUANCAVELICA', 'TAYACAJA', 'PICHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100101', 'HUÁNUCO', 'HUÁNUCO', 'HUANUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100102', 'HUÁNUCO', 'HUÁNUCO', 'AMARILIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100103', 'HUÁNUCO', 'HUÁNUCO', 'CHINCHAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100104', 'HUÁNUCO', 'HUÁNUCO', 'CHURUBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100105', 'HUÁNUCO', 'HUÁNUCO', 'MARGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100106', 'HUÁNUCO', 'HUÁNUCO', 'QUISQUI (KICHKI)');
INSERT INTO `tb_conf_ubigeo` VALUES ('100107', 'HUÁNUCO', 'HUÁNUCO', 'SAN FRANCISCO DE CAYRAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100108', 'HUÁNUCO', 'HUÁNUCO', 'SAN PEDRO DE CHAULAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100109', 'HUÁNUCO', 'HUÁNUCO', 'SANTA MARÍA DEL VALLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('100110', 'HUÁNUCO', 'HUÁNUCO', 'YARUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100111', 'HUÁNUCO', 'HUÁNUCO', 'PILLCO MARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100112', 'HUÁNUCO', 'HUÁNUCO', 'YACUS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100113', 'HUÁNUCO', 'HUÁNUCO', 'SAN PABLO DE PILLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100201', 'HUÁNUCO', 'AMBO', 'AMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100202', 'HUÁNUCO', 'AMBO', 'CAYNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100203', 'HUÁNUCO', 'AMBO', 'COLPAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100204', 'HUÁNUCO', 'AMBO', 'CONCHAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100205', 'HUÁNUCO', 'AMBO', 'HUACAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('100206', 'HUÁNUCO', 'AMBO', 'SAN FRANCISCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100207', 'HUÁNUCO', 'AMBO', 'SAN RAFAEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('100208', 'HUÁNUCO', 'AMBO', 'TOMAY KICHWA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100301', 'HUÁNUCO', 'DOS DE MAYO', 'LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100307', 'HUÁNUCO', 'DOS DE MAYO', 'CHUQUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100311', 'HUÁNUCO', 'DOS DE MAYO', 'MARÍAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100313', 'HUÁNUCO', 'DOS DE MAYO', 'PACHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100316', 'HUÁNUCO', 'DOS DE MAYO', 'QUIVILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100317', 'HUÁNUCO', 'DOS DE MAYO', 'RIPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100321', 'HUÁNUCO', 'DOS DE MAYO', 'SHUNQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('100322', 'HUÁNUCO', 'DOS DE MAYO', 'SILLAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100323', 'HUÁNUCO', 'DOS DE MAYO', 'YANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100401', 'HUÁNUCO', 'HUACAYBAMBA', 'HUACAYBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100402', 'HUÁNUCO', 'HUACAYBAMBA', 'CANCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100403', 'HUÁNUCO', 'HUACAYBAMBA', 'COCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100404', 'HUÁNUCO', 'HUACAYBAMBA', 'PINRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100501', 'HUÁNUCO', 'HUAMALÍES', 'LLATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100502', 'HUÁNUCO', 'HUAMALÍES', 'ARANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('100503', 'HUÁNUCO', 'HUAMALÍES', 'CHAVÍN DE PARIARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100504', 'HUÁNUCO', 'HUAMALÍES', 'JACAS GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('100505', 'HUÁNUCO', 'HUAMALÍES', 'JIRCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100506', 'HUÁNUCO', 'HUAMALÍES', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('100507', 'HUÁNUCO', 'HUAMALÍES', 'MONZÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100508', 'HUÁNUCO', 'HUAMALÍES', 'PUNCHAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100509', 'HUÁNUCO', 'HUAMALÍES', 'PUÑOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100510', 'HUÁNUCO', 'HUAMALÍES', 'SINGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100511', 'HUÁNUCO', 'HUAMALÍES', 'TANTAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100601', 'HUÁNUCO', 'LEONCIO PRADO', 'RUPA-RUPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100602', 'HUÁNUCO', 'LEONCIO PRADO', 'DANIEL ALOMÍA ROBLES');
INSERT INTO `tb_conf_ubigeo` VALUES ('100603', 'HUÁNUCO', 'LEONCIO PRADO', 'HERMÍLIO VALDIZAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100604', 'HUÁNUCO', 'LEONCIO PRADO', 'JOSÉ CRESPO Y CASTILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100605', 'HUÁNUCO', 'LEONCIO PRADO', 'LUYANDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100606', 'HUÁNUCO', 'LEONCIO PRADO', 'MARIANO DAMASO BERAUN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100607', 'HUÁNUCO', 'LEONCIO PRADO', 'PUCAYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('100608', 'HUÁNUCO', 'LEONCIO PRADO', 'CASTILLO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('100701', 'HUÁNUCO', 'MARAÑÓN', 'HUACRACHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100702', 'HUÁNUCO', 'MARAÑÓN', 'CHOLON');
INSERT INTO `tb_conf_ubigeo` VALUES ('100703', 'HUÁNUCO', 'MARAÑÓN', 'SAN BUENAVENTURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100704', 'HUÁNUCO', 'MARAÑÓN', 'LA MORADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100705', 'HUÁNUCO', 'MARAÑÓN', 'SANTA ROSA DE ALTO YANAJANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100801', 'HUÁNUCO', 'PACHITEA', 'PANAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100802', 'HUÁNUCO', 'PACHITEA', 'CHAGLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100803', 'HUÁNUCO', 'PACHITEA', 'MOLINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100804', 'HUÁNUCO', 'PACHITEA', 'UMARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('100901', 'HUÁNUCO', 'PUERTO INCA', 'PUERTO INCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100902', 'HUÁNUCO', 'PUERTO INCA', 'CODO DEL POZUZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100903', 'HUÁNUCO', 'PUERTO INCA', 'HONORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100904', 'HUÁNUCO', 'PUERTO INCA', 'TOURNAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100905', 'HUÁNUCO', 'PUERTO INCA', 'YUYAPICHIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101001', 'HUÁNUCO', 'LAURICOCHA', 'JESÚS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101002', 'HUÁNUCO', 'LAURICOCHA', 'BAÑOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101003', 'HUÁNUCO', 'LAURICOCHA', 'JIVIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101004', 'HUÁNUCO', 'LAURICOCHA', 'QUEROPALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101005', 'HUÁNUCO', 'LAURICOCHA', 'RONDOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101006', 'HUÁNUCO', 'LAURICOCHA', 'SAN FRANCISCO DE ASÍS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101007', 'HUÁNUCO', 'LAURICOCHA', 'SAN MIGUEL DE CAURI');
INSERT INTO `tb_conf_ubigeo` VALUES ('101101', 'HUÁNUCO', 'YAROWILCA', 'CHAVINILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('101102', 'HUÁNUCO', 'YAROWILCA', 'CAHUAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('101103', 'HUÁNUCO', 'YAROWILCA', 'CHACABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101104', 'HUÁNUCO', 'YAROWILCA', 'APARICIO POMARES');
INSERT INTO `tb_conf_ubigeo` VALUES ('101105', 'HUÁNUCO', 'YAROWILCA', 'JACAS CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('101106', 'HUÁNUCO', 'YAROWILCA', 'OBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101107', 'HUÁNUCO', 'YAROWILCA', 'PAMPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101108', 'HUÁNUCO', 'YAROWILCA', 'CHORAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110101', 'ICA', 'ICA', 'ICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110102', 'ICA', 'ICA', 'LA TINGUIÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110103', 'ICA', 'ICA', 'LOS AQUIJES');
INSERT INTO `tb_conf_ubigeo` VALUES ('110104', 'ICA', 'ICA', 'OCUCAJE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110105', 'ICA', 'ICA', 'PACHACUTEC');
INSERT INTO `tb_conf_ubigeo` VALUES ('110106', 'ICA', 'ICA', 'PARCONA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110107', 'ICA', 'ICA', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110108', 'ICA', 'ICA', 'SALAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110109', 'ICA', 'ICA', 'SAN JOSÉ DE LOS MOLINOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110110', 'ICA', 'ICA', 'SAN JUAN BAUTISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110111', 'ICA', 'ICA', 'SANTIAGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110112', 'ICA', 'ICA', 'SUBTANJALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110113', 'ICA', 'ICA', 'TATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110114', 'ICA', 'ICA', 'YAUCA DEL ROSARIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110201', 'ICA', 'CHINCHA', 'CHINCHA ALTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110202', 'ICA', 'CHINCHA', 'ALTO LARAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('110203', 'ICA', 'CHINCHA', 'CHAVIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('110204', 'ICA', 'CHINCHA', 'CHINCHA BAJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110205', 'ICA', 'CHINCHA', 'EL CARMEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('110206', 'ICA', 'CHINCHA', 'GROCIO PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110207', 'ICA', 'CHINCHA', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110208', 'ICA', 'CHINCHA', 'SAN JUAN DE YANAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('110209', 'ICA', 'CHINCHA', 'SAN PEDRO DE HUACARPANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110210', 'ICA', 'CHINCHA', 'SUNAMPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110211', 'ICA', 'CHINCHA', 'TAMBO DE MORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110301', 'ICA', 'NASCA', 'NASCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110302', 'ICA', 'NASCA', 'CHANGUILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110303', 'ICA', 'NASCA', 'EL INGENIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110304', 'ICA', 'NASCA', 'MARCONA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110305', 'ICA', 'NASCA', 'VISTA ALEGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110401', 'ICA', 'PALPA', 'PALPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110402', 'ICA', 'PALPA', 'LLIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110403', 'ICA', 'PALPA', 'RÍO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110404', 'ICA', 'PALPA', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('110405', 'ICA', 'PALPA', 'TIBILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110501', 'ICA', 'PISCO', 'PISCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110502', 'ICA', 'PISCO', 'HUANCANO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110503', 'ICA', 'PISCO', 'HUMAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('110504', 'ICA', 'PISCO', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110505', 'ICA', 'PISCO', 'PARACAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110506', 'ICA', 'PISCO', 'SAN ANDRÉS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110507', 'ICA', 'PISCO', 'SAN CLEMENTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110508', 'ICA', 'PISCO', 'TUPAC AMARU INCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120101', 'JUNÍN', 'HUANCAYO', 'HUANCAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120104', 'JUNÍN', 'HUANCAYO', 'CARHUACALLANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120105', 'JUNÍN', 'HUANCAYO', 'CHACAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120106', 'JUNÍN', 'HUANCAYO', 'CHICCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120107', 'JUNÍN', 'HUANCAYO', 'CHILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120108', 'JUNÍN', 'HUANCAYO', 'CHONGOS ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120111', 'JUNÍN', 'HUANCAYO', 'CHUPURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120112', 'JUNÍN', 'HUANCAYO', 'COLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120113', 'JUNÍN', 'HUANCAYO', 'CULLHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120114', 'JUNÍN', 'HUANCAYO', 'EL TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120116', 'JUNÍN', 'HUANCAYO', 'HUACRAPUQUIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120117', 'JUNÍN', 'HUANCAYO', 'HUALHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120119', 'JUNÍN', 'HUANCAYO', 'HUANCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120120', 'JUNÍN', 'HUANCAYO', 'HUASICANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120121', 'JUNÍN', 'HUANCAYO', 'HUAYUCACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120122', 'JUNÍN', 'HUANCAYO', 'INGENIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120124', 'JUNÍN', 'HUANCAYO', 'PARIAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120125', 'JUNÍN', 'HUANCAYO', 'PILCOMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120126', 'JUNÍN', 'HUANCAYO', 'PUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120127', 'JUNÍN', 'HUANCAYO', 'QUICHUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('120128', 'JUNÍN', 'HUANCAYO', 'QUILCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120129', 'JUNÍN', 'HUANCAYO', 'SAN AGUSTÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120130', 'JUNÍN', 'HUANCAYO', 'SAN JERÓNIMO DE TUNAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120132', 'JUNÍN', 'HUANCAYO', 'SAÑO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120133', 'JUNÍN', 'HUANCAYO', 'SAPALLANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120134', 'JUNÍN', 'HUANCAYO', 'SICAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120135', 'JUNÍN', 'HUANCAYO', 'SANTO DOMINGO DE ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120136', 'JUNÍN', 'HUANCAYO', 'VIQUES');
INSERT INTO `tb_conf_ubigeo` VALUES ('120201', 'JUNÍN', 'CONCEPCIÓN', 'CONCEPCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120202', 'JUNÍN', 'CONCEPCIÓN', 'ACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120203', 'JUNÍN', 'CONCEPCIÓN', 'ANDAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120204', 'JUNÍN', 'CONCEPCIÓN', 'CHAMBARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120205', 'JUNÍN', 'CONCEPCIÓN', 'COCHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120206', 'JUNÍN', 'CONCEPCIÓN', 'COMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120207', 'JUNÍN', 'CONCEPCIÓN', 'HEROÍNAS TOLEDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120208', 'JUNÍN', 'CONCEPCIÓN', 'MANZANARES');
INSERT INTO `tb_conf_ubigeo` VALUES ('120209', 'JUNÍN', 'CONCEPCIÓN', 'MARISCAL CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120210', 'JUNÍN', 'CONCEPCIÓN', 'MATAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120211', 'JUNÍN', 'CONCEPCIÓN', 'MITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120212', 'JUNÍN', 'CONCEPCIÓN', 'NUEVE DE JULIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120213', 'JUNÍN', 'CONCEPCIÓN', 'ORCOTUNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120214', 'JUNÍN', 'CONCEPCIÓN', 'SAN JOSÉ DE QUERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120215', 'JUNÍN', 'CONCEPCIÓN', 'SANTA ROSA DE OCOPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120301', 'JUNÍN', 'CHANCHAMAYO', 'CHANCHAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120302', 'JUNÍN', 'CHANCHAMAYO', 'PERENE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120303', 'JUNÍN', 'CHANCHAMAYO', 'PICHANAQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120304', 'JUNÍN', 'CHANCHAMAYO', 'SAN LUIS DE SHUARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120305', 'JUNÍN', 'CHANCHAMAYO', 'SAN RAMÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120306', 'JUNÍN', 'CHANCHAMAYO', 'VITOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('120401', 'JUNÍN', 'JAUJA', 'JAUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120402', 'JUNÍN', 'JAUJA', 'ACOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120403', 'JUNÍN', 'JAUJA', 'APATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120404', 'JUNÍN', 'JAUJA', 'ATAURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120405', 'JUNÍN', 'JAUJA', 'CANCHAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120406', 'JUNÍN', 'JAUJA', 'CURICACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120407', 'JUNÍN', 'JAUJA', 'EL MANTARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120408', 'JUNÍN', 'JAUJA', 'HUAMALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120409', 'JUNÍN', 'JAUJA', 'HUARIPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120410', 'JUNÍN', 'JAUJA', 'HUERTAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120411', 'JUNÍN', 'JAUJA', 'JANJAILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120412', 'JUNÍN', 'JAUJA', 'JULCÁN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120413', 'JUNÍN', 'JAUJA', 'LEONOR ORDÓÑEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('120414', 'JUNÍN', 'JAUJA', 'LLOCLLAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120415', 'JUNÍN', 'JAUJA', 'MARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120416', 'JUNÍN', 'JAUJA', 'MASMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120417', 'JUNÍN', 'JAUJA', 'MASMA CHICCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120418', 'JUNÍN', 'JAUJA', 'MOLINOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120419', 'JUNÍN', 'JAUJA', 'MONOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120420', 'JUNÍN', 'JAUJA', 'MUQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120421', 'JUNÍN', 'JAUJA', 'MUQUIYAUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120422', 'JUNÍN', 'JAUJA', 'PACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120423', 'JUNÍN', 'JAUJA', 'PACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120424', 'JUNÍN', 'JAUJA', 'PANCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120425', 'JUNÍN', 'JAUJA', 'PARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120426', 'JUNÍN', 'JAUJA', 'POMACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120427', 'JUNÍN', 'JAUJA', 'RICRAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120428', 'JUNÍN', 'JAUJA', 'SAN LORENZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120429', 'JUNÍN', 'JAUJA', 'SAN PEDRO DE CHUNAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120430', 'JUNÍN', 'JAUJA', 'SAUSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120431', 'JUNÍN', 'JAUJA', 'SINCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120432', 'JUNÍN', 'JAUJA', 'TUNAN MARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120433', 'JUNÍN', 'JAUJA', 'YAULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120434', 'JUNÍN', 'JAUJA', 'YAUYOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120501', 'JUNÍN', 'JUNÍN', 'JUNIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120502', 'JUNÍN', 'JUNÍN', 'CARHUAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120503', 'JUNÍN', 'JUNÍN', 'ONDORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('120504', 'JUNÍN', 'JUNÍN', 'ULCUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120601', 'JUNÍN', 'SATIPO', 'SATIPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120602', 'JUNÍN', 'SATIPO', 'COVIRIALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120603', 'JUNÍN', 'SATIPO', 'LLAYLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120604', 'JUNÍN', 'SATIPO', 'MAZAMARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120605', 'JUNÍN', 'SATIPO', 'PAMPA HERMOSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120606', 'JUNÍN', 'SATIPO', 'PANGOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120607', 'JUNÍN', 'SATIPO', 'RÍO NEGRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120608', 'JUNÍN', 'SATIPO', 'RÍO TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120609', 'JUNÍN', 'SATIPO', 'VIZCATAN DEL ENE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120701', 'JUNÍN', 'TARMA', 'TARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120702', 'JUNÍN', 'TARMA', 'ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120703', 'JUNÍN', 'TARMA', 'HUARICOLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120704', 'JUNÍN', 'TARMA', 'HUASAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120705', 'JUNÍN', 'TARMA', 'LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120706', 'JUNÍN', 'TARMA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120707', 'JUNÍN', 'TARMA', 'PALCAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120708', 'JUNÍN', 'TARMA', 'SAN PEDRO DE CAJAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120709', 'JUNÍN', 'TARMA', 'TAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120801', 'JUNÍN', 'YAULI', 'LA OROYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120802', 'JUNÍN', 'YAULI', 'CHACAPALPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120803', 'JUNÍN', 'YAULI', 'HUAY-HUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('120804', 'JUNÍN', 'YAULI', 'MARCAPOMACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120805', 'JUNÍN', 'YAULI', 'MOROCOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120806', 'JUNÍN', 'YAULI', 'PACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120807', 'JUNÍN', 'YAULI', 'SANTA BÁRBARA DE CARHUACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120808', 'JUNÍN', 'YAULI', 'SANTA ROSA DE SACCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120809', 'JUNÍN', 'YAULI', 'SUITUCANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120810', 'JUNÍN', 'YAULI', 'YAULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120901', 'JUNÍN', 'CHUPACA', 'CHUPACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120902', 'JUNÍN', 'CHUPACA', 'AHUAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('120903', 'JUNÍN', 'CHUPACA', 'CHONGOS BAJO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120904', 'JUNÍN', 'CHUPACA', 'HUACHAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('120905', 'JUNÍN', 'CHUPACA', 'HUAMANCACA CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120906', 'JUNÍN', 'CHUPACA', 'SAN JUAN DE ISCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120907', 'JUNÍN', 'CHUPACA', 'SAN JUAN DE JARPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120908', 'JUNÍN', 'CHUPACA', 'TRES DE DICIEMBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120909', 'JUNÍN', 'CHUPACA', 'YANACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130101', 'LA LIBERTAD', 'TRUJILLO', 'TRUJILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130102', 'LA LIBERTAD', 'TRUJILLO', 'EL PORVENIR');
INSERT INTO `tb_conf_ubigeo` VALUES ('130103', 'LA LIBERTAD', 'TRUJILLO', 'FLORENCIA DE MORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130104', 'LA LIBERTAD', 'TRUJILLO', 'HUANCHACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130105', 'LA LIBERTAD', 'TRUJILLO', 'LA ESPERANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130106', 'LA LIBERTAD', 'TRUJILLO', 'LAREDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130107', 'LA LIBERTAD', 'TRUJILLO', 'MOCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130108', 'LA LIBERTAD', 'TRUJILLO', 'POROTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130109', 'LA LIBERTAD', 'TRUJILLO', 'SALAVERRY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130110', 'LA LIBERTAD', 'TRUJILLO', 'SIMBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130111', 'LA LIBERTAD', 'TRUJILLO', 'VICTOR LARCO HERRERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130201', 'LA LIBERTAD', 'ASCOPE', 'ASCOPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130202', 'LA LIBERTAD', 'ASCOPE', 'CHICAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130203', 'LA LIBERTAD', 'ASCOPE', 'CHOCOPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130204', 'LA LIBERTAD', 'ASCOPE', 'MAGDALENA DE CAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130205', 'LA LIBERTAD', 'ASCOPE', 'PAIJAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130206', 'LA LIBERTAD', 'ASCOPE', 'RÁZURI');
INSERT INTO `tb_conf_ubigeo` VALUES ('130207', 'LA LIBERTAD', 'ASCOPE', 'SANTIAGO DE CAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130208', 'LA LIBERTAD', 'ASCOPE', 'CASA GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130301', 'LA LIBERTAD', 'BOLÍVAR', 'BOLÍVAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('130302', 'LA LIBERTAD', 'BOLÍVAR', 'BAMBAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130303', 'LA LIBERTAD', 'BOLÍVAR', 'CONDORMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130304', 'LA LIBERTAD', 'BOLÍVAR', 'LONGOTEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130305', 'LA LIBERTAD', 'BOLÍVAR', 'UCHUMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130306', 'LA LIBERTAD', 'BOLÍVAR', 'UCUNCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130401', 'LA LIBERTAD', 'CHEPÉN', 'CHEPEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130402', 'LA LIBERTAD', 'CHEPÉN', 'PACANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130403', 'LA LIBERTAD', 'CHEPÉN', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130501', 'LA LIBERTAD', 'JULCÁN', 'JULCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130502', 'LA LIBERTAD', 'JULCÁN', 'CALAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130503', 'LA LIBERTAD', 'JULCÁN', 'CARABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130504', 'LA LIBERTAD', 'JULCÁN', 'HUASO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130601', 'LA LIBERTAD', 'OTUZCO', 'OTUZCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130602', 'LA LIBERTAD', 'OTUZCO', 'AGALLPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130604', 'LA LIBERTAD', 'OTUZCO', 'CHARAT');
INSERT INTO `tb_conf_ubigeo` VALUES ('130605', 'LA LIBERTAD', 'OTUZCO', 'HUARANCHAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130606', 'LA LIBERTAD', 'OTUZCO', 'LA CUESTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130608', 'LA LIBERTAD', 'OTUZCO', 'MACHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130610', 'LA LIBERTAD', 'OTUZCO', 'PARANDAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130611', 'LA LIBERTAD', 'OTUZCO', 'SALPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130613', 'LA LIBERTAD', 'OTUZCO', 'SINSICAP');
INSERT INTO `tb_conf_ubigeo` VALUES ('130614', 'LA LIBERTAD', 'OTUZCO', 'USQUIL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130701', 'LA LIBERTAD', 'PACASMAYO', 'SAN PEDRO DE LLOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('130702', 'LA LIBERTAD', 'PACASMAYO', 'GUADALUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130703', 'LA LIBERTAD', 'PACASMAYO', 'JEQUETEPEQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130704', 'LA LIBERTAD', 'PACASMAYO', 'PACASMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130705', 'LA LIBERTAD', 'PACASMAYO', 'SAN JOSÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('130801', 'LA LIBERTAD', 'PATAZ', 'TAYABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130802', 'LA LIBERTAD', 'PATAZ', 'BULDIBUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130803', 'LA LIBERTAD', 'PATAZ', 'CHILLIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130804', 'LA LIBERTAD', 'PATAZ', 'HUANCASPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130805', 'LA LIBERTAD', 'PATAZ', 'HUAYLILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130806', 'LA LIBERTAD', 'PATAZ', 'HUAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130807', 'LA LIBERTAD', 'PATAZ', 'ONGON');
INSERT INTO `tb_conf_ubigeo` VALUES ('130808', 'LA LIBERTAD', 'PATAZ', 'PARCOY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130809', 'LA LIBERTAD', 'PATAZ', 'PATAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('130810', 'LA LIBERTAD', 'PATAZ', 'PIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130811', 'LA LIBERTAD', 'PATAZ', 'SANTIAGO DE CHALLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130812', 'LA LIBERTAD', 'PATAZ', 'TAURIJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130813', 'LA LIBERTAD', 'PATAZ', 'URPAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130901', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'HUAMACHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130902', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'CHUGAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130903', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'COCHORCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130904', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'CURGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130905', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'MARCABAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130906', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'SANAGORAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130907', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'SARIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130908', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'SARTIMBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131001', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'SANTIAGO DE CHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('131002', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'ANGASMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131003', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'CACHICADAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('131004', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'MOLLEBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131005', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'MOLLEPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131006', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'QUIRUVILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131007', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'SANTA CRUZ DE CHUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131008', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'SITABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131101', 'LA LIBERTAD', 'GRAN CHIMÚ', 'CASCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('131102', 'LA LIBERTAD', 'GRAN CHIMÚ', 'LUCMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131103', 'LA LIBERTAD', 'GRAN CHIMÚ', 'MARMOT');
INSERT INTO `tb_conf_ubigeo` VALUES ('131104', 'LA LIBERTAD', 'GRAN CHIMÚ', 'SAYAPULLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('131201', 'LA LIBERTAD', 'VIRÚ', 'VIRU');
INSERT INTO `tb_conf_ubigeo` VALUES ('131202', 'LA LIBERTAD', 'VIRÚ', 'CHAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('131203', 'LA LIBERTAD', 'VIRÚ', 'GUADALUPITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140101', 'LAMBAYEQUE', 'CHICLAYO', 'CHICLAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140102', 'LAMBAYEQUE', 'CHICLAYO', 'CHONGOYAPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140103', 'LAMBAYEQUE', 'CHICLAYO', 'ETEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('140104', 'LAMBAYEQUE', 'CHICLAYO', 'ETEN PUERTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140105', 'LAMBAYEQUE', 'CHICLAYO', 'JOSÉ LEONARDO ORTIZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('140106', 'LAMBAYEQUE', 'CHICLAYO', 'LA VICTORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140107', 'LAMBAYEQUE', 'CHICLAYO', 'LAGUNAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140108', 'LAMBAYEQUE', 'CHICLAYO', 'MONSEFU');
INSERT INTO `tb_conf_ubigeo` VALUES ('140109', 'LAMBAYEQUE', 'CHICLAYO', 'NUEVA ARICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140110', 'LAMBAYEQUE', 'CHICLAYO', 'OYOTUN');
INSERT INTO `tb_conf_ubigeo` VALUES ('140111', 'LAMBAYEQUE', 'CHICLAYO', 'PICSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140112', 'LAMBAYEQUE', 'CHICLAYO', 'PIMENTEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('140113', 'LAMBAYEQUE', 'CHICLAYO', 'REQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140114', 'LAMBAYEQUE', 'CHICLAYO', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140115', 'LAMBAYEQUE', 'CHICLAYO', 'SAÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140116', 'LAMBAYEQUE', 'CHICLAYO', 'CAYALTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140117', 'LAMBAYEQUE', 'CHICLAYO', 'PATAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140118', 'LAMBAYEQUE', 'CHICLAYO', 'POMALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140119', 'LAMBAYEQUE', 'CHICLAYO', 'PUCALA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140120', 'LAMBAYEQUE', 'CHICLAYO', 'TUMAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('140201', 'LAMBAYEQUE', 'FERREÑAFE', 'FERREÑAFE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140202', 'LAMBAYEQUE', 'FERREÑAFE', 'CAÑARIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140203', 'LAMBAYEQUE', 'FERREÑAFE', 'INCAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140204', 'LAMBAYEQUE', 'FERREÑAFE', 'MANUEL ANTONIO MESONES MURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140205', 'LAMBAYEQUE', 'FERREÑAFE', 'PITIPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140206', 'LAMBAYEQUE', 'FERREÑAFE', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140301', 'LAMBAYEQUE', 'LAMBAYEQUE', 'LAMBAYEQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140302', 'LAMBAYEQUE', 'LAMBAYEQUE', 'CHOCHOPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140303', 'LAMBAYEQUE', 'LAMBAYEQUE', 'ILLIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140304', 'LAMBAYEQUE', 'LAMBAYEQUE', 'JAYANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140305', 'LAMBAYEQUE', 'LAMBAYEQUE', 'MOCHUMI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140306', 'LAMBAYEQUE', 'LAMBAYEQUE', 'MORROPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140307', 'LAMBAYEQUE', 'LAMBAYEQUE', 'MOTUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140308', 'LAMBAYEQUE', 'LAMBAYEQUE', 'OLMOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140309', 'LAMBAYEQUE', 'LAMBAYEQUE', 'PACORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140310', 'LAMBAYEQUE', 'LAMBAYEQUE', 'SALAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140311', 'LAMBAYEQUE', 'LAMBAYEQUE', 'SAN JOSÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('140312', 'LAMBAYEQUE', 'LAMBAYEQUE', 'TUCUME');
INSERT INTO `tb_conf_ubigeo` VALUES ('150101', 'LIMA', 'LIMA', 'LIMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150102', 'LIMA', 'LIMA', 'ANCÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150103', 'LIMA', 'LIMA', 'ATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150104', 'LIMA', 'LIMA', 'BARRANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150105', 'LIMA', 'LIMA', 'BREÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150106', 'LIMA', 'LIMA', 'CARABAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150107', 'LIMA', 'LIMA', 'CHACLACAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150108', 'LIMA', 'LIMA', 'CHORRILLOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150109', 'LIMA', 'LIMA', 'CIENEGUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150110', 'LIMA', 'LIMA', 'COMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150111', 'LIMA', 'LIMA', 'EL AGUSTINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150112', 'LIMA', 'LIMA', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150113', 'LIMA', 'LIMA', 'JESÚS MARÍA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150114', 'LIMA', 'LIMA', 'LA MOLINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150115', 'LIMA', 'LIMA', 'LA VICTORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150116', 'LIMA', 'LIMA', 'LINCE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150117', 'LIMA', 'LIMA', 'LOS OLIVOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150118', 'LIMA', 'LIMA', 'LURIGANCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150119', 'LIMA', 'LIMA', 'LURIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150120', 'LIMA', 'LIMA', 'MAGDALENA DEL MAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150121', 'LIMA', 'LIMA', 'PUEBLO LIBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150122', 'LIMA', 'LIMA', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150123', 'LIMA', 'LIMA', 'PACHACAMAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('150124', 'LIMA', 'LIMA', 'PUCUSANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150125', 'LIMA', 'LIMA', 'PUENTE PIEDRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150126', 'LIMA', 'LIMA', 'PUNTA HERMOSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150127', 'LIMA', 'LIMA', 'PUNTA NEGRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150128', 'LIMA', 'LIMA', 'RÍMAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('150129', 'LIMA', 'LIMA', 'SAN BARTOLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150130', 'LIMA', 'LIMA', 'SAN BORJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150131', 'LIMA', 'LIMA', 'SAN ISIDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150132', 'LIMA', 'LIMA', 'SAN JUAN DE LURIGANCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150133', 'LIMA', 'LIMA', 'SAN JUAN DE MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150134', 'LIMA', 'LIMA', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150135', 'LIMA', 'LIMA', 'SAN MARTÍN DE PORRES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150136', 'LIMA', 'LIMA', 'SAN MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150137', 'LIMA', 'LIMA', 'SANTA ANITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150138', 'LIMA', 'LIMA', 'SANTA MARÍA DEL MAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150139', 'LIMA', 'LIMA', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150140', 'LIMA', 'LIMA', 'SANTIAGO DE SURCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150141', 'LIMA', 'LIMA', 'SURQUILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150142', 'LIMA', 'LIMA', 'VILLA EL SALVADOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150143', 'LIMA', 'LIMA', 'VILLA MARÍA DEL TRIUNFO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150201', 'LIMA', 'BARRANCA', 'BARRANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150202', 'LIMA', 'BARRANCA', 'PARAMONGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150203', 'LIMA', 'BARRANCA', 'PATIVILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150204', 'LIMA', 'BARRANCA', 'SUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150205', 'LIMA', 'BARRANCA', 'SUPE PUERTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150301', 'LIMA', 'CAJATAMBO', 'CAJATAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150302', 'LIMA', 'CAJATAMBO', 'COPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150303', 'LIMA', 'CAJATAMBO', 'GORGOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150304', 'LIMA', 'CAJATAMBO', 'HUANCAPON');
INSERT INTO `tb_conf_ubigeo` VALUES ('150305', 'LIMA', 'CAJATAMBO', 'MANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150401', 'LIMA', 'CANTA', 'CANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150402', 'LIMA', 'CANTA', 'ARAHUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('150403', 'LIMA', 'CANTA', 'HUAMANTANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150404', 'LIMA', 'CANTA', 'HUAROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150405', 'LIMA', 'CANTA', 'LACHAQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150406', 'LIMA', 'CANTA', 'SAN BUENAVENTURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150407', 'LIMA', 'CANTA', 'SANTA ROSA DE QUIVES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150501', 'LIMA', 'CAÑETE', 'SAN VICENTE DE CAÑETE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150502', 'LIMA', 'CAÑETE', 'ASIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150503', 'LIMA', 'CAÑETE', 'CALANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150504', 'LIMA', 'CAÑETE', 'CERRO AZUL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150505', 'LIMA', 'CAÑETE', 'CHILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150506', 'LIMA', 'CAÑETE', 'COAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150507', 'LIMA', 'CAÑETE', 'IMPERIAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150508', 'LIMA', 'CAÑETE', 'LUNAHUANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150509', 'LIMA', 'CAÑETE', 'MALA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150510', 'LIMA', 'CAÑETE', 'NUEVO IMPERIAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150511', 'LIMA', 'CAÑETE', 'PACARAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150512', 'LIMA', 'CAÑETE', 'QUILMANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150513', 'LIMA', 'CAÑETE', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150514', 'LIMA', 'CAÑETE', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150515', 'LIMA', 'CAÑETE', 'SANTA CRUZ DE FLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150516', 'LIMA', 'CAÑETE', 'ZÚÑIGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150601', 'LIMA', 'HUARAL', 'HUARAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150602', 'LIMA', 'HUARAL', 'ATAVILLOS ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150603', 'LIMA', 'HUARAL', 'ATAVILLOS BAJO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150604', 'LIMA', 'HUARAL', 'AUCALLAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150605', 'LIMA', 'HUARAL', 'CHANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('150606', 'LIMA', 'HUARAL', 'IHUARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150607', 'LIMA', 'HUARAL', 'LAMPIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150608', 'LIMA', 'HUARAL', 'PACARAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150609', 'LIMA', 'HUARAL', 'SAN MIGUEL DE ACOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150610', 'LIMA', 'HUARAL', 'SANTA CRUZ DE ANDAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150611', 'LIMA', 'HUARAL', 'SUMBILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150612', 'LIMA', 'HUARAL', 'VEINTISIETE DE NOVIEMBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150701', 'LIMA', 'HUAROCHIRÍ', 'MATUCANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150702', 'LIMA', 'HUAROCHIRÍ', 'ANTIOQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150703', 'LIMA', 'HUAROCHIRÍ', 'CALLAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150704', 'LIMA', 'HUAROCHIRÍ', 'CARAMPOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150705', 'LIMA', 'HUAROCHIRÍ', 'CHICLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150706', 'LIMA', 'HUAROCHIRÍ', 'CUENCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150707', 'LIMA', 'HUAROCHIRÍ', 'HUACHUPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150708', 'LIMA', 'HUAROCHIRÍ', 'HUANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150709', 'LIMA', 'HUAROCHIRÍ', 'HUAROCHIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150710', 'LIMA', 'HUAROCHIRÍ', 'LAHUAYTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150711', 'LIMA', 'HUAROCHIRÍ', 'LANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150712', 'LIMA', 'HUAROCHIRÍ', 'LARAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150713', 'LIMA', 'HUAROCHIRÍ', 'MARIATANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150714', 'LIMA', 'HUAROCHIRÍ', 'RICARDO PALMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150715', 'LIMA', 'HUAROCHIRÍ', 'SAN ANDRÉS DE TUPICOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150716', 'LIMA', 'HUAROCHIRÍ', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150717', 'LIMA', 'HUAROCHIRÍ', 'SAN BARTOLOMÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('150718', 'LIMA', 'HUAROCHIRÍ', 'SAN DAMIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150719', 'LIMA', 'HUAROCHIRÍ', 'SAN JUAN DE IRIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150720', 'LIMA', 'HUAROCHIRÍ', 'SAN JUAN DE TANTARANCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150721', 'LIMA', 'HUAROCHIRÍ', 'SAN LORENZO DE QUINTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150722', 'LIMA', 'HUAROCHIRÍ', 'SAN MATEO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150723', 'LIMA', 'HUAROCHIRÍ', 'SAN MATEO DE OTAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150724', 'LIMA', 'HUAROCHIRÍ', 'SAN PEDRO DE CASTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150725', 'LIMA', 'HUAROCHIRÍ', 'SAN PEDRO DE HUANCAYRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150726', 'LIMA', 'HUAROCHIRÍ', 'SANGALLAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150727', 'LIMA', 'HUAROCHIRÍ', 'SANTA CRUZ DE COCACHACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150728', 'LIMA', 'HUAROCHIRÍ', 'SANTA EULALIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150729', 'LIMA', 'HUAROCHIRÍ', 'SANTIAGO DE ANCHUCAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150730', 'LIMA', 'HUAROCHIRÍ', 'SANTIAGO DE TUNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150731', 'LIMA', 'HUAROCHIRÍ', 'SANTO DOMINGO DE LOS OLLEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150732', 'LIMA', 'HUAROCHIRÍ', 'SURCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150801', 'LIMA', 'HUAURA', 'HUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150802', 'LIMA', 'HUAURA', 'AMBAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150803', 'LIMA', 'HUAURA', 'CALETA DE CARQUIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150804', 'LIMA', 'HUAURA', 'CHECRAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150805', 'LIMA', 'HUAURA', 'HUALMAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('150806', 'LIMA', 'HUAURA', 'HUAURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150807', 'LIMA', 'HUAURA', 'LEONCIO PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150808', 'LIMA', 'HUAURA', 'PACCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150809', 'LIMA', 'HUAURA', 'SANTA LEONOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150810', 'LIMA', 'HUAURA', 'SANTA MARÍA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150811', 'LIMA', 'HUAURA', 'SAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150812', 'LIMA', 'HUAURA', 'VEGUETA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150901', 'LIMA', 'OYÓN', 'OYON');
INSERT INTO `tb_conf_ubigeo` VALUES ('150902', 'LIMA', 'OYÓN', 'ANDAJES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150903', 'LIMA', 'OYÓN', 'CAUJUL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150904', 'LIMA', 'OYÓN', 'COCHAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150905', 'LIMA', 'OYÓN', 'NAVAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150906', 'LIMA', 'OYÓN', 'PACHANGARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151001', 'LIMA', 'YAUYOS', 'YAUYOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151002', 'LIMA', 'YAUYOS', 'ALIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151003', 'LIMA', 'YAUYOS', 'ALLAUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151004', 'LIMA', 'YAUYOS', 'AYAVIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('151005', 'LIMA', 'YAUYOS', 'AZÁNGARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('151006', 'LIMA', 'YAUYOS', 'CACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151007', 'LIMA', 'YAUYOS', 'CARANIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151008', 'LIMA', 'YAUYOS', 'CATAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('151009', 'LIMA', 'YAUYOS', 'CHOCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151010', 'LIMA', 'YAUYOS', 'COCHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151011', 'LIMA', 'YAUYOS', 'COLONIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151012', 'LIMA', 'YAUYOS', 'HONGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151013', 'LIMA', 'YAUYOS', 'HUAMPARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151014', 'LIMA', 'YAUYOS', 'HUANCAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151015', 'LIMA', 'YAUYOS', 'HUANGASCAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('151016', 'LIMA', 'YAUYOS', 'HUANTAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('151017', 'LIMA', 'YAUYOS', 'HUAÑEC');
INSERT INTO `tb_conf_ubigeo` VALUES ('151018', 'LIMA', 'YAUYOS', 'LARAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151019', 'LIMA', 'YAUYOS', 'LINCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151020', 'LIMA', 'YAUYOS', 'MADEAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('151021', 'LIMA', 'YAUYOS', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('151022', 'LIMA', 'YAUYOS', 'OMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151023', 'LIMA', 'YAUYOS', 'PUTINZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151024', 'LIMA', 'YAUYOS', 'QUINCHES');
INSERT INTO `tb_conf_ubigeo` VALUES ('151025', 'LIMA', 'YAUYOS', 'QUINOCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('151026', 'LIMA', 'YAUYOS', 'SAN JOAQUÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('151027', 'LIMA', 'YAUYOS', 'SAN PEDRO DE PILAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151028', 'LIMA', 'YAUYOS', 'TANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151029', 'LIMA', 'YAUYOS', 'TAURIPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151030', 'LIMA', 'YAUYOS', 'TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151031', 'LIMA', 'YAUYOS', 'TUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('151032', 'LIMA', 'YAUYOS', 'VIÑAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('151033', 'LIMA', 'YAUYOS', 'VITIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160101', 'LORETO', 'MAYNAS', 'IQUITOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160102', 'LORETO', 'MAYNAS', 'ALTO NANAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('160103', 'LORETO', 'MAYNAS', 'FERNANDO LORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('160104', 'LORETO', 'MAYNAS', 'INDIANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160105', 'LORETO', 'MAYNAS', 'LAS AMAZONAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160106', 'LORETO', 'MAYNAS', 'MAZAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160107', 'LORETO', 'MAYNAS', 'NAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160108', 'LORETO', 'MAYNAS', 'PUNCHANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160110', 'LORETO', 'MAYNAS', 'TORRES CAUSANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160112', 'LORETO', 'MAYNAS', 'BELÉN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160113', 'LORETO', 'MAYNAS', 'SAN JUAN BAUTISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160201', 'LORETO', 'ALTO AMAZONAS', 'YURIMAGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160202', 'LORETO', 'ALTO AMAZONAS', 'BALSAPUERTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160205', 'LORETO', 'ALTO AMAZONAS', 'JEBEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160206', 'LORETO', 'ALTO AMAZONAS', 'LAGUNAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160210', 'LORETO', 'ALTO AMAZONAS', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('160211', 'LORETO', 'ALTO AMAZONAS', 'TENIENTE CESAR LÓPEZ ROJAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160301', 'LORETO', 'LORETO', 'NAUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160302', 'LORETO', 'LORETO', 'PARINARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('160303', 'LORETO', 'LORETO', 'TIGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160304', 'LORETO', 'LORETO', 'TROMPETEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160305', 'LORETO', 'LORETO', 'URARINAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160401', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'RAMÓN CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160402', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'PEBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160403', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'YAVARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('160404', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160501', 'LORETO', 'REQUENA', 'REQUENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160502', 'LORETO', 'REQUENA', 'ALTO TAPICHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160503', 'LORETO', 'REQUENA', 'CAPELO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160504', 'LORETO', 'REQUENA', 'EMILIO SAN MARTÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160505', 'LORETO', 'REQUENA', 'MAQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160506', 'LORETO', 'REQUENA', 'PUINAHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160507', 'LORETO', 'REQUENA', 'SAQUENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160508', 'LORETO', 'REQUENA', 'SOPLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160509', 'LORETO', 'REQUENA', 'TAPICHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160510', 'LORETO', 'REQUENA', 'JENARO HERRERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160511', 'LORETO', 'REQUENA', 'YAQUERANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160601', 'LORETO', 'UCAYALI', 'CONTAMANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160602', 'LORETO', 'UCAYALI', 'INAHUAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160603', 'LORETO', 'UCAYALI', 'PADRE MÁRQUEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('160604', 'LORETO', 'UCAYALI', 'PAMPA HERMOSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160605', 'LORETO', 'UCAYALI', 'SARAYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('160606', 'LORETO', 'UCAYALI', 'VARGAS GUERRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160701', 'LORETO', 'DATEM DEL MARAÑÓN', 'BARRANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160702', 'LORETO', 'DATEM DEL MARAÑÓN', 'CAHUAPANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160703', 'LORETO', 'DATEM DEL MARAÑÓN', 'MANSERICHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160704', 'LORETO', 'DATEM DEL MARAÑÓN', 'MORONA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160705', 'LORETO', 'DATEM DEL MARAÑÓN', 'PASTAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160706', 'LORETO', 'DATEM DEL MARAÑÓN', 'ANDOAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160801', 'LORETO', 'PUTUMAYO', 'PUTUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160802', 'LORETO', 'PUTUMAYO', 'ROSA PANDURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160803', 'LORETO', 'PUTUMAYO', 'TENIENTE MANUEL CLAVERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160804', 'LORETO', 'PUTUMAYO', 'YAGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('170101', 'MADRE DE DIOS', 'TAMBOPATA', 'TAMBOPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('170102', 'MADRE DE DIOS', 'TAMBOPATA', 'INAMBARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('170103', 'MADRE DE DIOS', 'TAMBOPATA', 'LAS PIEDRAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('170104', 'MADRE DE DIOS', 'TAMBOPATA', 'LABERINTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('170201', 'MADRE DE DIOS', 'MANU', 'MANU');
INSERT INTO `tb_conf_ubigeo` VALUES ('170202', 'MADRE DE DIOS', 'MANU', 'FITZCARRALD');
INSERT INTO `tb_conf_ubigeo` VALUES ('170203', 'MADRE DE DIOS', 'MANU', 'MADRE DE DIOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('170204', 'MADRE DE DIOS', 'MANU', 'HUEPETUHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('170301', 'MADRE DE DIOS', 'TAHUAMANU', 'IÑAPARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('170302', 'MADRE DE DIOS', 'TAHUAMANU', 'IBERIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('170303', 'MADRE DE DIOS', 'TAHUAMANU', 'TAHUAMANU');
INSERT INTO `tb_conf_ubigeo` VALUES ('180101', 'MOQUEGUA', 'MARISCAL NIETO', 'MOQUEGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180102', 'MOQUEGUA', 'MARISCAL NIETO', 'CARUMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('180103', 'MOQUEGUA', 'MARISCAL NIETO', 'CUCHUMBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180104', 'MOQUEGUA', 'MARISCAL NIETO', 'SAMEGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180105', 'MOQUEGUA', 'MARISCAL NIETO', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('180106', 'MOQUEGUA', 'MARISCAL NIETO', 'TORATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180201', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'OMATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180202', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'CHOJATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180203', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'COALAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180204', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'ICHUÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180205', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'LA CAPILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180206', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'LLOQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180207', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'MATALAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180208', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'PUQUINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180209', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'QUINISTAQUILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('180210', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'UBINAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('180211', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'YUNGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180301', 'MOQUEGUA', 'ILO', 'ILO');
INSERT INTO `tb_conf_ubigeo` VALUES ('180302', 'MOQUEGUA', 'ILO', 'EL ALGARROBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('180303', 'MOQUEGUA', 'ILO', 'PACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190101', 'PASCO', 'PASCO', 'CHAUPIMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190102', 'PASCO', 'PASCO', 'HUACHON');
INSERT INTO `tb_conf_ubigeo` VALUES ('190103', 'PASCO', 'PASCO', 'HUARIACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190104', 'PASCO', 'PASCO', 'HUAYLLAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('190105', 'PASCO', 'PASCO', 'NINACACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190106', 'PASCO', 'PASCO', 'PALLANCHACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190107', 'PASCO', 'PASCO', 'PAUCARTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190108', 'PASCO', 'PASCO', 'SAN FRANCISCO DE ASÍS DE YARUSYACAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('190109', 'PASCO', 'PASCO', 'SIMON BOLÍVAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('190110', 'PASCO', 'PASCO', 'TICLACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('190111', 'PASCO', 'PASCO', 'TINYAHUARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190112', 'PASCO', 'PASCO', 'VICCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190113', 'PASCO', 'PASCO', 'YANACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190201', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'YANAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190202', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'CHACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('190203', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'GOYLLARISQUIZGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190204', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'PAUCAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('190205', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'SAN PEDRO DE PILLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190206', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'SANTA ANA DE TUSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('190207', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'TAPUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('190208', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'VILCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190301', 'PASCO', 'OXAPAMPA', 'OXAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190302', 'PASCO', 'OXAPAMPA', 'CHONTABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190303', 'PASCO', 'OXAPAMPA', 'HUANCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190304', 'PASCO', 'OXAPAMPA', 'PALCAZU');
INSERT INTO `tb_conf_ubigeo` VALUES ('190305', 'PASCO', 'OXAPAMPA', 'POZUZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190306', 'PASCO', 'OXAPAMPA', 'PUERTO BERMÚDEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('190307', 'PASCO', 'OXAPAMPA', 'VILLA RICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190308', 'PASCO', 'OXAPAMPA', 'CONSTITUCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200101', 'PIURA', 'PIURA', 'PIURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200104', 'PIURA', 'PIURA', 'CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200105', 'PIURA', 'PIURA', 'CATACAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200107', 'PIURA', 'PIURA', 'CURA MORI');
INSERT INTO `tb_conf_ubigeo` VALUES ('200108', 'PIURA', 'PIURA', 'EL TALLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200109', 'PIURA', 'PIURA', 'LA ARENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200110', 'PIURA', 'PIURA', 'LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200111', 'PIURA', 'PIURA', 'LAS LOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200114', 'PIURA', 'PIURA', 'TAMBO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200115', 'PIURA', 'PIURA', 'VEINTISEIS DE OCTUBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200201', 'PIURA', 'AYABACA', 'AYABACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200202', 'PIURA', 'AYABACA', 'FRIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200203', 'PIURA', 'AYABACA', 'JILILI');
INSERT INTO `tb_conf_ubigeo` VALUES ('200204', 'PIURA', 'AYABACA', 'LAGUNAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200205', 'PIURA', 'AYABACA', 'MONTERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200206', 'PIURA', 'AYABACA', 'PACAIPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200207', 'PIURA', 'AYABACA', 'PAIMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200208', 'PIURA', 'AYABACA', 'SAPILLICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200209', 'PIURA', 'AYABACA', 'SICCHEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('200210', 'PIURA', 'AYABACA', 'SUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200301', 'PIURA', 'HUANCABAMBA', 'HUANCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200302', 'PIURA', 'HUANCABAMBA', 'CANCHAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200303', 'PIURA', 'HUANCABAMBA', 'EL CARMEN DE LA FRONTERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200304', 'PIURA', 'HUANCABAMBA', 'HUARMACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200305', 'PIURA', 'HUANCABAMBA', 'LALAQUIZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('200306', 'PIURA', 'HUANCABAMBA', 'SAN MIGUEL DE EL FAIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200307', 'PIURA', 'HUANCABAMBA', 'SONDOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('200308', 'PIURA', 'HUANCABAMBA', 'SONDORILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200401', 'PIURA', 'MORROPÓN', 'CHULUCANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200402', 'PIURA', 'MORROPÓN', 'BUENOS AIRES');
INSERT INTO `tb_conf_ubigeo` VALUES ('200403', 'PIURA', 'MORROPÓN', 'CHALACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200404', 'PIURA', 'MORROPÓN', 'LA MATANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200405', 'PIURA', 'MORROPÓN', 'MORROPON');
INSERT INTO `tb_conf_ubigeo` VALUES ('200406', 'PIURA', 'MORROPÓN', 'SALITRAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200407', 'PIURA', 'MORROPÓN', 'SAN JUAN DE BIGOTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200408', 'PIURA', 'MORROPÓN', 'SANTA CATALINA DE MOSSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200409', 'PIURA', 'MORROPÓN', 'SANTO DOMINGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200410', 'PIURA', 'MORROPÓN', 'YAMANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200501', 'PIURA', 'PAITA', 'PAITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200502', 'PIURA', 'PAITA', 'AMOTAPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200503', 'PIURA', 'PAITA', 'ARENAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200504', 'PIURA', 'PAITA', 'COLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200505', 'PIURA', 'PAITA', 'LA HUACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200506', 'PIURA', 'PAITA', 'TAMARINDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200507', 'PIURA', 'PAITA', 'VICHAYAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200601', 'PIURA', 'SULLANA', 'SULLANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200602', 'PIURA', 'SULLANA', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200603', 'PIURA', 'SULLANA', 'IGNACIO ESCUDERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200604', 'PIURA', 'SULLANA', 'LANCONES');
INSERT INTO `tb_conf_ubigeo` VALUES ('200605', 'PIURA', 'SULLANA', 'MARCAVELICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200606', 'PIURA', 'SULLANA', 'MIGUEL CHECA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200607', 'PIURA', 'SULLANA', 'QUERECOTILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200608', 'PIURA', 'SULLANA', 'SALITRAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200701', 'PIURA', 'TALARA', 'PARIÑAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200702', 'PIURA', 'TALARA', 'EL ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200703', 'PIURA', 'TALARA', 'LA BREA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200704', 'PIURA', 'TALARA', 'LOBITOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200705', 'PIURA', 'TALARA', 'LOS ORGANOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200706', 'PIURA', 'TALARA', 'MANCORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200801', 'PIURA', 'SECHURA', 'SECHURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200802', 'PIURA', 'SECHURA', 'BELLAVISTA DE LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200803', 'PIURA', 'SECHURA', 'BERNAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200804', 'PIURA', 'SECHURA', 'CRISTO NOS VALGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200805', 'PIURA', 'SECHURA', 'VICE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200806', 'PIURA', 'SECHURA', 'RINCONADA LLICUAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('210101', 'PUNO', 'PUNO', 'PUNO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210102', 'PUNO', 'PUNO', 'ACORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210103', 'PUNO', 'PUNO', 'AMANTANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210104', 'PUNO', 'PUNO', 'ATUNCOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210105', 'PUNO', 'PUNO', 'CAPACHICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210106', 'PUNO', 'PUNO', 'CHUCUITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210107', 'PUNO', 'PUNO', 'COATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210108', 'PUNO', 'PUNO', 'HUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210109', 'PUNO', 'PUNO', 'MAÑAZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210110', 'PUNO', 'PUNO', 'PAUCARCOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210111', 'PUNO', 'PUNO', 'PICHACANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210112', 'PUNO', 'PUNO', 'PLATERIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210113', 'PUNO', 'PUNO', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210114', 'PUNO', 'PUNO', 'TIQUILLACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210115', 'PUNO', 'PUNO', 'VILQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('210201', 'PUNO', 'AZÁNGARO', 'AZÁNGARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210202', 'PUNO', 'AZÁNGARO', 'ACHAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210203', 'PUNO', 'AZÁNGARO', 'ARAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210204', 'PUNO', 'AZÁNGARO', 'ASILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210205', 'PUNO', 'AZÁNGARO', 'CAMINACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210206', 'PUNO', 'AZÁNGARO', 'CHUPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210207', 'PUNO', 'AZÁNGARO', 'JOSÉ DOMINGO CHOQUEHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210208', 'PUNO', 'AZÁNGARO', 'MUÑANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210209', 'PUNO', 'AZÁNGARO', 'POTONI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210210', 'PUNO', 'AZÁNGARO', 'SAMAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('210211', 'PUNO', 'AZÁNGARO', 'SAN ANTON');
INSERT INTO `tb_conf_ubigeo` VALUES ('210212', 'PUNO', 'AZÁNGARO', 'SAN JOSÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('210213', 'PUNO', 'AZÁNGARO', 'SAN JUAN DE SALINAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('210214', 'PUNO', 'AZÁNGARO', 'SANTIAGO DE PUPUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210215', 'PUNO', 'AZÁNGARO', 'TIRAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210301', 'PUNO', 'CARABAYA', 'MACUSANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210302', 'PUNO', 'CARABAYA', 'AJOYANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210303', 'PUNO', 'CARABAYA', 'AYAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210304', 'PUNO', 'CARABAYA', 'COASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210305', 'PUNO', 'CARABAYA', 'CORANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210306', 'PUNO', 'CARABAYA', 'CRUCERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210307', 'PUNO', 'CARABAYA', 'ITUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210308', 'PUNO', 'CARABAYA', 'OLLACHEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210309', 'PUNO', 'CARABAYA', 'SAN GABAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('210310', 'PUNO', 'CARABAYA', 'USICAYOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('210401', 'PUNO', 'CHUCUITO', 'JULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210402', 'PUNO', 'CHUCUITO', 'DESAGUADERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210403', 'PUNO', 'CHUCUITO', 'HUACULLANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210404', 'PUNO', 'CHUCUITO', 'KELLUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210405', 'PUNO', 'CHUCUITO', 'PISACOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210406', 'PUNO', 'CHUCUITO', 'POMATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210407', 'PUNO', 'CHUCUITO', 'ZEPITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210501', 'PUNO', 'EL COLLAO', 'ILAVE');
INSERT INTO `tb_conf_ubigeo` VALUES ('210502', 'PUNO', 'EL COLLAO', 'CAPAZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210503', 'PUNO', 'EL COLLAO', 'PILCUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210504', 'PUNO', 'EL COLLAO', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210505', 'PUNO', 'EL COLLAO', 'CONDURIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210601', 'PUNO', 'HUANCANÉ', 'HUANCANE');
INSERT INTO `tb_conf_ubigeo` VALUES ('210602', 'PUNO', 'HUANCANÉ', 'COJATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210603', 'PUNO', 'HUANCANÉ', 'HUATASANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210604', 'PUNO', 'HUANCANÉ', 'INCHUPALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210605', 'PUNO', 'HUANCANÉ', 'PUSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210606', 'PUNO', 'HUANCANÉ', 'ROSASPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210607', 'PUNO', 'HUANCANÉ', 'TARACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210608', 'PUNO', 'HUANCANÉ', 'VILQUE CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210701', 'PUNO', 'LAMPA', 'LAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210702', 'PUNO', 'LAMPA', 'CABANILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210703', 'PUNO', 'LAMPA', 'CALAPUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210704', 'PUNO', 'LAMPA', 'NICASIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210705', 'PUNO', 'LAMPA', 'OCUVIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210706', 'PUNO', 'LAMPA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210707', 'PUNO', 'LAMPA', 'PARATIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210708', 'PUNO', 'LAMPA', 'PUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210709', 'PUNO', 'LAMPA', 'SANTA LUCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210710', 'PUNO', 'LAMPA', 'VILAVILA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210801', 'PUNO', 'MELGAR', 'AYAVIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210802', 'PUNO', 'MELGAR', 'ANTAUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210803', 'PUNO', 'MELGAR', 'CUPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210804', 'PUNO', 'MELGAR', 'LLALLI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210805', 'PUNO', 'MELGAR', 'MACARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210806', 'PUNO', 'MELGAR', 'NUÑOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210807', 'PUNO', 'MELGAR', 'ORURILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210808', 'PUNO', 'MELGAR', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210809', 'PUNO', 'MELGAR', 'UMACHIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210901', 'PUNO', 'MOHO', 'MOHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210902', 'PUNO', 'MOHO', 'CONIMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210903', 'PUNO', 'MOHO', 'HUAYRAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210904', 'PUNO', 'MOHO', 'TILALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211001', 'PUNO', 'SAN ANTONIO DE PUTINA', 'PUTINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211002', 'PUNO', 'SAN ANTONIO DE PUTINA', 'ANANEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211003', 'PUNO', 'SAN ANTONIO DE PUTINA', 'PEDRO VILCA APAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211004', 'PUNO', 'SAN ANTONIO DE PUTINA', 'QUILCAPUNCU');
INSERT INTO `tb_conf_ubigeo` VALUES ('211005', 'PUNO', 'SAN ANTONIO DE PUTINA', 'SINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211101', 'PUNO', 'SAN ROMÁN', 'JULIACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211102', 'PUNO', 'SAN ROMÁN', 'CABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211103', 'PUNO', 'SAN ROMÁN', 'CABANILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('211104', 'PUNO', 'SAN ROMÁN', 'CARACOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211201', 'PUNO', 'SANDIA', 'SANDIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211202', 'PUNO', 'SANDIA', 'CUYOCUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211203', 'PUNO', 'SANDIA', 'LIMBANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211204', 'PUNO', 'SANDIA', 'PATAMBUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211205', 'PUNO', 'SANDIA', 'PHARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211206', 'PUNO', 'SANDIA', 'QUIACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211207', 'PUNO', 'SANDIA', 'SAN JUAN DEL ORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211208', 'PUNO', 'SANDIA', 'YANAHUAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211209', 'PUNO', 'SANDIA', 'ALTO INAMBARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211210', 'PUNO', 'SANDIA', 'SAN PEDRO DE PUTINA PUNCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211301', 'PUNO', 'YUNGUYO', 'YUNGUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211302', 'PUNO', 'YUNGUYO', 'ANAPIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211303', 'PUNO', 'YUNGUYO', 'COPANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211304', 'PUNO', 'YUNGUYO', 'CUTURAPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211305', 'PUNO', 'YUNGUYO', 'OLLARAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211306', 'PUNO', 'YUNGUYO', 'TINICACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211307', 'PUNO', 'YUNGUYO', 'UNICACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220101', 'SAN MARTÍN', 'MOYOBAMBA', 'MOYOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220102', 'SAN MARTÍN', 'MOYOBAMBA', 'CALZADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220103', 'SAN MARTÍN', 'MOYOBAMBA', 'HABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220104', 'SAN MARTÍN', 'MOYOBAMBA', 'JEPELACIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220105', 'SAN MARTÍN', 'MOYOBAMBA', 'SORITOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('220106', 'SAN MARTÍN', 'MOYOBAMBA', 'YANTALO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220201', 'SAN MARTÍN', 'BELLAVISTA', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220202', 'SAN MARTÍN', 'BELLAVISTA', 'ALTO BIAVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220203', 'SAN MARTÍN', 'BELLAVISTA', 'BAJO BIAVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220204', 'SAN MARTÍN', 'BELLAVISTA', 'HUALLAGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220205', 'SAN MARTÍN', 'BELLAVISTA', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220206', 'SAN MARTÍN', 'BELLAVISTA', 'SAN RAFAEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('220301', 'SAN MARTÍN', 'EL DORADO', 'SAN JOSÉ DE SISA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220302', 'SAN MARTÍN', 'EL DORADO', 'AGUA BLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220303', 'SAN MARTÍN', 'EL DORADO', 'SAN MARTÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220304', 'SAN MARTÍN', 'EL DORADO', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220305', 'SAN MARTÍN', 'EL DORADO', 'SHATOJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220401', 'SAN MARTÍN', 'HUALLAGA', 'SAPOSOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220402', 'SAN MARTÍN', 'HUALLAGA', 'ALTO SAPOSOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220403', 'SAN MARTÍN', 'HUALLAGA', 'EL ESLABÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220404', 'SAN MARTÍN', 'HUALLAGA', 'PISCOYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220405', 'SAN MARTÍN', 'HUALLAGA', 'SACANCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('220406', 'SAN MARTÍN', 'HUALLAGA', 'TINGO DE SAPOSOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220501', 'SAN MARTÍN', 'LAMAS', 'LAMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220502', 'SAN MARTÍN', 'LAMAS', 'ALONSO DE ALVARADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220503', 'SAN MARTÍN', 'LAMAS', 'BARRANQUITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220504', 'SAN MARTÍN', 'LAMAS', 'CAYNARACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220505', 'SAN MARTÍN', 'LAMAS', 'CUÑUMBUQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220506', 'SAN MARTÍN', 'LAMAS', 'PINTO RECODO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220507', 'SAN MARTÍN', 'LAMAS', 'RUMISAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220508', 'SAN MARTÍN', 'LAMAS', 'SAN ROQUE DE CUMBAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220509', 'SAN MARTÍN', 'LAMAS', 'SHANAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220510', 'SAN MARTÍN', 'LAMAS', 'TABALOSOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220511', 'SAN MARTÍN', 'LAMAS', 'ZAPATERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220601', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'JUANJUÍ');
INSERT INTO `tb_conf_ubigeo` VALUES ('220602', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'CAMPANILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220603', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'HUICUNGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220604', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'PACHIZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220605', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'PAJARILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220701', 'SAN MARTÍN', 'PICOTA', 'PICOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220702', 'SAN MARTÍN', 'PICOTA', 'BUENOS AIRES');
INSERT INTO `tb_conf_ubigeo` VALUES ('220703', 'SAN MARTÍN', 'PICOTA', 'CASPISAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220704', 'SAN MARTÍN', 'PICOTA', 'PILLUANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220705', 'SAN MARTÍN', 'PICOTA', 'PUCACACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220706', 'SAN MARTÍN', 'PICOTA', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('220707', 'SAN MARTÍN', 'PICOTA', 'SAN HILARIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220708', 'SAN MARTÍN', 'PICOTA', 'SHAMBOYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220709', 'SAN MARTÍN', 'PICOTA', 'TINGO DE PONASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220710', 'SAN MARTÍN', 'PICOTA', 'TRES UNIDOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220801', 'SAN MARTÍN', 'RIOJA', 'RIOJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220802', 'SAN MARTÍN', 'RIOJA', 'AWAJUN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220803', 'SAN MARTÍN', 'RIOJA', 'ELÍAS SOPLIN VARGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220804', 'SAN MARTÍN', 'RIOJA', 'NUEVA CAJAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220805', 'SAN MARTÍN', 'RIOJA', 'PARDO MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('220806', 'SAN MARTÍN', 'RIOJA', 'POSIC');
INSERT INTO `tb_conf_ubigeo` VALUES ('220807', 'SAN MARTÍN', 'RIOJA', 'SAN FERNANDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220808', 'SAN MARTÍN', 'RIOJA', 'YORONGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220809', 'SAN MARTÍN', 'RIOJA', 'YURACYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220901', 'SAN MARTÍN', 'SAN MARTÍN', 'TARAPOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220902', 'SAN MARTÍN', 'SAN MARTÍN', 'ALBERTO LEVEAU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220903', 'SAN MARTÍN', 'SAN MARTÍN', 'CACATACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220904', 'SAN MARTÍN', 'SAN MARTÍN', 'CHAZUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220905', 'SAN MARTÍN', 'SAN MARTÍN', 'CHIPURANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220906', 'SAN MARTÍN', 'SAN MARTÍN', 'EL PORVENIR');
INSERT INTO `tb_conf_ubigeo` VALUES ('220907', 'SAN MARTÍN', 'SAN MARTÍN', 'HUIMBAYOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('220908', 'SAN MARTÍN', 'SAN MARTÍN', 'JUAN GUERRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220909', 'SAN MARTÍN', 'SAN MARTÍN', 'LA BANDA DE SHILCAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220910', 'SAN MARTÍN', 'SAN MARTÍN', 'MORALES');
INSERT INTO `tb_conf_ubigeo` VALUES ('220911', 'SAN MARTÍN', 'SAN MARTÍN', 'PAPAPLAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220912', 'SAN MARTÍN', 'SAN MARTÍN', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220913', 'SAN MARTÍN', 'SAN MARTÍN', 'SAUCE');
INSERT INTO `tb_conf_ubigeo` VALUES ('220914', 'SAN MARTÍN', 'SAN MARTÍN', 'SHAPAJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('221001', 'SAN MARTÍN', 'TOCACHE', 'TOCACHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('221002', 'SAN MARTÍN', 'TOCACHE', 'NUEVO PROGRESO');
INSERT INTO `tb_conf_ubigeo` VALUES ('221003', 'SAN MARTÍN', 'TOCACHE', 'POLVORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('221004', 'SAN MARTÍN', 'TOCACHE', 'SHUNTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('221005', 'SAN MARTÍN', 'TOCACHE', 'UCHIZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230101', 'TACNA', 'TACNA', 'TACNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230102', 'TACNA', 'TACNA', 'ALTO DE LA ALIANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230103', 'TACNA', 'TACNA', 'CALANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230104', 'TACNA', 'TACNA', 'CIUDAD NUEVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230105', 'TACNA', 'TACNA', 'INCLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('230106', 'TACNA', 'TACNA', 'PACHIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230107', 'TACNA', 'TACNA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230108', 'TACNA', 'TACNA', 'POCOLLAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('230109', 'TACNA', 'TACNA', 'SAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230110', 'TACNA', 'TACNA', 'CORONEL GREGORIO ALBARRACÍN LANCHIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230111', 'TACNA', 'TACNA', 'LA YARADA LOS PALOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('230201', 'TACNA', 'CANDARAVE', 'CANDARAVE');
INSERT INTO `tb_conf_ubigeo` VALUES ('230202', 'TACNA', 'CANDARAVE', 'CAIRANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('230203', 'TACNA', 'CANDARAVE', 'CAMILACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230204', 'TACNA', 'CANDARAVE', 'CURIBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230205', 'TACNA', 'CANDARAVE', 'HUANUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230206', 'TACNA', 'CANDARAVE', 'QUILAHUANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('230301', 'TACNA', 'JORGE BASADRE', 'LOCUMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230302', 'TACNA', 'JORGE BASADRE', 'ILABAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230303', 'TACNA', 'JORGE BASADRE', 'ITE');
INSERT INTO `tb_conf_ubigeo` VALUES ('230401', 'TACNA', 'TARATA', 'TARATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230402', 'TACNA', 'TARATA', 'HÉROES ALBARRACÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('230403', 'TACNA', 'TARATA', 'ESTIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('230404', 'TACNA', 'TARATA', 'ESTIQUE-PAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230405', 'TACNA', 'TARATA', 'SITAJARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230406', 'TACNA', 'TARATA', 'SUSAPAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230407', 'TACNA', 'TARATA', 'TARUCACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('230408', 'TACNA', 'TARATA', 'TICACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('240101', 'TUMBES', 'TUMBES', 'TUMBES');
INSERT INTO `tb_conf_ubigeo` VALUES ('240102', 'TUMBES', 'TUMBES', 'CORRALES');
INSERT INTO `tb_conf_ubigeo` VALUES ('240103', 'TUMBES', 'TUMBES', 'LA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('240104', 'TUMBES', 'TUMBES', 'PAMPAS DE HOSPITAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('240105', 'TUMBES', 'TUMBES', 'SAN JACINTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('240106', 'TUMBES', 'TUMBES', 'SAN JUAN DE LA VIRGEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('240201', 'TUMBES', 'CONTRALMIRANTE VILLAR', 'ZORRITOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('240202', 'TUMBES', 'CONTRALMIRANTE VILLAR', 'CASITAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('240203', 'TUMBES', 'CONTRALMIRANTE VILLAR', 'CANOAS DE PUNTA SAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('240301', 'TUMBES', 'ZARUMILLA', 'ZARUMILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('240302', 'TUMBES', 'ZARUMILLA', 'AGUAS VERDES');
INSERT INTO `tb_conf_ubigeo` VALUES ('240303', 'TUMBES', 'ZARUMILLA', 'MATAPALO');
INSERT INTO `tb_conf_ubigeo` VALUES ('240304', 'TUMBES', 'ZARUMILLA', 'PAPAYAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('250101', 'UCAYALI', 'CORONEL PORTILLO', 'CALLERIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250102', 'UCAYALI', 'CORONEL PORTILLO', 'CAMPOVERDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('250103', 'UCAYALI', 'CORONEL PORTILLO', 'IPARIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250104', 'UCAYALI', 'CORONEL PORTILLO', 'MASISEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250105', 'UCAYALI', 'CORONEL PORTILLO', 'YARINACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250106', 'UCAYALI', 'CORONEL PORTILLO', 'NUEVA REQUENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250107', 'UCAYALI', 'CORONEL PORTILLO', 'MANANTAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('250201', 'UCAYALI', 'ATALAYA', 'RAYMONDI');
INSERT INTO `tb_conf_ubigeo` VALUES ('250202', 'UCAYALI', 'ATALAYA', 'SEPAHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250203', 'UCAYALI', 'ATALAYA', 'TAHUANIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250204', 'UCAYALI', 'ATALAYA', 'YURUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250301', 'UCAYALI', 'PADRE ABAD', 'PADRE ABAD');
INSERT INTO `tb_conf_ubigeo` VALUES ('250302', 'UCAYALI', 'PADRE ABAD', 'IRAZOLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250303', 'UCAYALI', 'PADRE ABAD', 'CURIMANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250304', 'UCAYALI', 'PADRE ABAD', 'NESHUYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250305', 'UCAYALI', 'PADRE ABAD', 'ALEXANDER VON HUMBOLDT');
INSERT INTO `tb_conf_ubigeo` VALUES ('250401', 'UCAYALI', 'PURÚS', 'PURUS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010101', 'AMAZONAS', 'CHACHAPOYAS', 'CHACHAPOYAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010102', 'AMAZONAS', 'CHACHAPOYAS', 'ASUNCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010103', 'AMAZONAS', 'CHACHAPOYAS', 'BALSAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010104', 'AMAZONAS', 'CHACHAPOYAS', 'CHETO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010105', 'AMAZONAS', 'CHACHAPOYAS', 'CHILIQUIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010106', 'AMAZONAS', 'CHACHAPOYAS', 'CHUQUIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010107', 'AMAZONAS', 'CHACHAPOYAS', 'GRANADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010108', 'AMAZONAS', 'CHACHAPOYAS', 'HUANCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010109', 'AMAZONAS', 'CHACHAPOYAS', 'LA JALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010110', 'AMAZONAS', 'CHACHAPOYAS', 'LEIMEBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010111', 'AMAZONAS', 'CHACHAPOYAS', 'LEVANTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010112', 'AMAZONAS', 'CHACHAPOYAS', 'MAGDALENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010113', 'AMAZONAS', 'CHACHAPOYAS', 'MARISCAL CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010114', 'AMAZONAS', 'CHACHAPOYAS', 'MOLINOPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010115', 'AMAZONAS', 'CHACHAPOYAS', 'MONTEVIDEO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010116', 'AMAZONAS', 'CHACHAPOYAS', 'OLLEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010117', 'AMAZONAS', 'CHACHAPOYAS', 'QUINJALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010118', 'AMAZONAS', 'CHACHAPOYAS', 'SAN FRANCISCO DE DAGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010119', 'AMAZONAS', 'CHACHAPOYAS', 'SAN ISIDRO DE MAINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010120', 'AMAZONAS', 'CHACHAPOYAS', 'SOLOCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010121', 'AMAZONAS', 'CHACHAPOYAS', 'SONCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010201', 'AMAZONAS', 'BAGUA', 'BAGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010202', 'AMAZONAS', 'BAGUA', 'ARAMANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010203', 'AMAZONAS', 'BAGUA', 'COPALLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010204', 'AMAZONAS', 'BAGUA', 'EL PARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010205', 'AMAZONAS', 'BAGUA', 'IMAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010206', 'AMAZONAS', 'BAGUA', 'LA PECA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010301', 'AMAZONAS', 'BONGARÁ', 'JUMBILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010302', 'AMAZONAS', 'BONGARÁ', 'CHISQUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010303', 'AMAZONAS', 'BONGARÁ', 'CHURUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010304', 'AMAZONAS', 'BONGARÁ', 'COROSHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010305', 'AMAZONAS', 'BONGARÁ', 'CUISPES');
INSERT INTO `tb_conf_ubigeo` VALUES ('010306', 'AMAZONAS', 'BONGARÁ', 'FLORIDA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010307', 'AMAZONAS', 'BONGARÁ', 'JAZAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('010308', 'AMAZONAS', 'BONGARÁ', 'RECTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010309', 'AMAZONAS', 'BONGARÁ', 'SAN CARLOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010310', 'AMAZONAS', 'BONGARÁ', 'SHIPASBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010311', 'AMAZONAS', 'BONGARÁ', 'VALERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010312', 'AMAZONAS', 'BONGARÁ', 'YAMBRASBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010401', 'AMAZONAS', 'CONDORCANQUI', 'NIEVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010402', 'AMAZONAS', 'CONDORCANQUI', 'EL CENEPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010403', 'AMAZONAS', 'CONDORCANQUI', 'RÍO SANTIAGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010501', 'AMAZONAS', 'LUYA', 'LAMUD');
INSERT INTO `tb_conf_ubigeo` VALUES ('010502', 'AMAZONAS', 'LUYA', 'CAMPORREDONDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010503', 'AMAZONAS', 'LUYA', 'COCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010504', 'AMAZONAS', 'LUYA', 'COLCAMAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('010505', 'AMAZONAS', 'LUYA', 'CONILA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010506', 'AMAZONAS', 'LUYA', 'INGUILPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010507', 'AMAZONAS', 'LUYA', 'LONGUITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010508', 'AMAZONAS', 'LUYA', 'LONYA CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010509', 'AMAZONAS', 'LUYA', 'LUYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010510', 'AMAZONAS', 'LUYA', 'LUYA VIEJO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010511', 'AMAZONAS', 'LUYA', 'MARÍA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010512', 'AMAZONAS', 'LUYA', 'OCALLI');
INSERT INTO `tb_conf_ubigeo` VALUES ('010513', 'AMAZONAS', 'LUYA', 'OCUMAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('010514', 'AMAZONAS', 'LUYA', 'PISUQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010515', 'AMAZONAS', 'LUYA', 'PROVIDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010516', 'AMAZONAS', 'LUYA', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('010517', 'AMAZONAS', 'LUYA', 'SAN FRANCISCO DE YESO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010518', 'AMAZONAS', 'LUYA', 'SAN JERÓNIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010519', 'AMAZONAS', 'LUYA', 'SAN JUAN DE LOPECANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010520', 'AMAZONAS', 'LUYA', 'SANTA CATALINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010521', 'AMAZONAS', 'LUYA', 'SANTO TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010522', 'AMAZONAS', 'LUYA', 'TINGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010523', 'AMAZONAS', 'LUYA', 'TRITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010601', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'SAN NICOLÁS');
INSERT INTO `tb_conf_ubigeo` VALUES ('010602', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'CHIRIMOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010603', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'COCHAMAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('010604', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'HUAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010605', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'LIMABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010606', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'LONGAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('010607', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'MARISCAL BENAVIDES');
INSERT INTO `tb_conf_ubigeo` VALUES ('010608', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'MILPUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('010609', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'OMIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010610', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010611', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'TOTORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010612', 'AMAZONAS', 'RODRÍGUEZ DE MENDOZA', 'VISTA ALEGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010701', 'AMAZONAS', 'UTCUBAMBA', 'BAGUA GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010702', 'AMAZONAS', 'UTCUBAMBA', 'CAJARURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010703', 'AMAZONAS', 'UTCUBAMBA', 'CUMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010704', 'AMAZONAS', 'UTCUBAMBA', 'EL MILAGRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('010705', 'AMAZONAS', 'UTCUBAMBA', 'JAMALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('010706', 'AMAZONAS', 'UTCUBAMBA', 'LONYA GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('010707', 'AMAZONAS', 'UTCUBAMBA', 'YAMON');
INSERT INTO `tb_conf_ubigeo` VALUES ('020101', 'ÁNCASH', 'HUARAZ', 'HUARAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('020102', 'ÁNCASH', 'HUARAZ', 'COCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020103', 'ÁNCASH', 'HUARAZ', 'COLCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020104', 'ÁNCASH', 'HUARAZ', 'HUANCHAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('020105', 'ÁNCASH', 'HUARAZ', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020106', 'ÁNCASH', 'HUARAZ', 'JANGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020107', 'ÁNCASH', 'HUARAZ', 'LA LIBERTAD');
INSERT INTO `tb_conf_ubigeo` VALUES ('020108', 'ÁNCASH', 'HUARAZ', 'OLLEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020109', 'ÁNCASH', 'HUARAZ', 'PAMPAS GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('020110', 'ÁNCASH', 'HUARAZ', 'PARIACOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020111', 'ÁNCASH', 'HUARAZ', 'PIRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020112', 'ÁNCASH', 'HUARAZ', 'TARICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020201', 'ÁNCASH', 'AIJA', 'AIJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020202', 'ÁNCASH', 'AIJA', 'CORIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020203', 'ÁNCASH', 'AIJA', 'HUACLLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020204', 'ÁNCASH', 'AIJA', 'LA MERCED');
INSERT INTO `tb_conf_ubigeo` VALUES ('020205', 'ÁNCASH', 'AIJA', 'SUCCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020301', 'ÁNCASH', 'ANTONIO RAYMONDI', 'LLAMELLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020302', 'ÁNCASH', 'ANTONIO RAYMONDI', 'ACZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020303', 'ÁNCASH', 'ANTONIO RAYMONDI', 'CHACCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020304', 'ÁNCASH', 'ANTONIO RAYMONDI', 'CHINGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020305', 'ÁNCASH', 'ANTONIO RAYMONDI', 'MIRGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020306', 'ÁNCASH', 'ANTONIO RAYMONDI', 'SAN JUAN DE RONTOY');
INSERT INTO `tb_conf_ubigeo` VALUES ('020401', 'ÁNCASH', 'ASUNCIÓN', 'CHACAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020402', 'ÁNCASH', 'ASUNCIÓN', 'ACOCHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020501', 'ÁNCASH', 'BOLOGNESI', 'CHIQUIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020502', 'ÁNCASH', 'BOLOGNESI', 'ABELARDO PARDO LEZAMETA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020503', 'ÁNCASH', 'BOLOGNESI', 'ANTONIO RAYMONDI');
INSERT INTO `tb_conf_ubigeo` VALUES ('020504', 'ÁNCASH', 'BOLOGNESI', 'AQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020505', 'ÁNCASH', 'BOLOGNESI', 'CAJACAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('020506', 'ÁNCASH', 'BOLOGNESI', 'CANIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020507', 'ÁNCASH', 'BOLOGNESI', 'COLQUIOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('020508', 'ÁNCASH', 'BOLOGNESI', 'HUALLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020509', 'ÁNCASH', 'BOLOGNESI', 'HUASTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020510', 'ÁNCASH', 'BOLOGNESI', 'HUAYLLACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020511', 'ÁNCASH', 'BOLOGNESI', 'LA PRIMAVERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020512', 'ÁNCASH', 'BOLOGNESI', 'MANGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020513', 'ÁNCASH', 'BOLOGNESI', 'PACLLON');
INSERT INTO `tb_conf_ubigeo` VALUES ('020514', 'ÁNCASH', 'BOLOGNESI', 'SAN MIGUEL DE CORPANQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('020515', 'ÁNCASH', 'BOLOGNESI', 'TICLLOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020601', 'ÁNCASH', 'CARHUAZ', 'CARHUAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('020602', 'ÁNCASH', 'CARHUAZ', 'ACOPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020603', 'ÁNCASH', 'CARHUAZ', 'AMASHCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020604', 'ÁNCASH', 'CARHUAZ', 'ANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020605', 'ÁNCASH', 'CARHUAZ', 'ATAQUERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020606', 'ÁNCASH', 'CARHUAZ', 'MARCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020607', 'ÁNCASH', 'CARHUAZ', 'PARIAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020608', 'ÁNCASH', 'CARHUAZ', 'SAN MIGUEL DE ACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020609', 'ÁNCASH', 'CARHUAZ', 'SHILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020610', 'ÁNCASH', 'CARHUAZ', 'TINCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020611', 'ÁNCASH', 'CARHUAZ', 'YUNGAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('020701', 'ÁNCASH', 'CARLOS FERMÍN FITZCARRALD', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020702', 'ÁNCASH', 'CARLOS FERMÍN FITZCARRALD', 'SAN NICOLÁS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020703', 'ÁNCASH', 'CARLOS FERMÍN FITZCARRALD', 'YAUYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020801', 'ÁNCASH', 'CASMA', 'CASMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020802', 'ÁNCASH', 'CASMA', 'BUENA VISTA ALTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020803', 'ÁNCASH', 'CASMA', 'COMANDANTE NOEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('020804', 'ÁNCASH', 'CASMA', 'YAUTAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('020901', 'ÁNCASH', 'CORONGO', 'CORONGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020902', 'ÁNCASH', 'CORONGO', 'ACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('020903', 'ÁNCASH', 'CORONGO', 'BAMBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('020904', 'ÁNCASH', 'CORONGO', 'CUSCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020905', 'ÁNCASH', 'CORONGO', 'LA PAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('020906', 'ÁNCASH', 'CORONGO', 'YANAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('020907', 'ÁNCASH', 'CORONGO', 'YUPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021001', 'ÁNCASH', 'HUARI', 'HUARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021002', 'ÁNCASH', 'HUARI', 'ANRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021003', 'ÁNCASH', 'HUARI', 'CAJAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('021004', 'ÁNCASH', 'HUARI', 'CHAVIN DE HUANTAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('021005', 'ÁNCASH', 'HUARI', 'HUACACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021006', 'ÁNCASH', 'HUARI', 'HUACCHIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021007', 'ÁNCASH', 'HUARI', 'HUACHIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021008', 'ÁNCASH', 'HUARI', 'HUANTAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('021009', 'ÁNCASH', 'HUARI', 'MASIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021010', 'ÁNCASH', 'HUARI', 'PAUCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021011', 'ÁNCASH', 'HUARI', 'PONTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021012', 'ÁNCASH', 'HUARI', 'RAHUAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021013', 'ÁNCASH', 'HUARI', 'RAPAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021014', 'ÁNCASH', 'HUARI', 'SAN MARCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021015', 'ÁNCASH', 'HUARI', 'SAN PEDRO DE CHANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021016', 'ÁNCASH', 'HUARI', 'UCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021101', 'ÁNCASH', 'HUARMEY', 'HUARMEY');
INSERT INTO `tb_conf_ubigeo` VALUES ('021102', 'ÁNCASH', 'HUARMEY', 'COCHAPETI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021103', 'ÁNCASH', 'HUARMEY', 'CULEBRAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021104', 'ÁNCASH', 'HUARMEY', 'HUAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021105', 'ÁNCASH', 'HUARMEY', 'MALVAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021201', 'ÁNCASH', 'HUAYLAS', 'CARAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('021202', 'ÁNCASH', 'HUAYLAS', 'HUALLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021203', 'ÁNCASH', 'HUAYLAS', 'HUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021204', 'ÁNCASH', 'HUAYLAS', 'HUAYLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021205', 'ÁNCASH', 'HUAYLAS', 'MATO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021206', 'ÁNCASH', 'HUAYLAS', 'PAMPAROMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021207', 'ÁNCASH', 'HUAYLAS', 'PUEBLO LIBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021208', 'ÁNCASH', 'HUAYLAS', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('021209', 'ÁNCASH', 'HUAYLAS', 'SANTO TORIBIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021210', 'ÁNCASH', 'HUAYLAS', 'YURACMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021301', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'PISCOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021302', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'CASCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021303', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'ELEAZAR GUZMÁN BARRON');
INSERT INTO `tb_conf_ubigeo` VALUES ('021304', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'FIDEL OLIVAS ESCUDERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021305', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'LLAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021306', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'LLUMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021307', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'LUCMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021308', 'ÁNCASH', 'MARISCAL LUZURIAGA', 'MUSGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021401', 'ÁNCASH', 'OCROS', 'OCROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021402', 'ÁNCASH', 'OCROS', 'ACAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021403', 'ÁNCASH', 'OCROS', 'CAJAMARQUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021404', 'ÁNCASH', 'OCROS', 'CARHUAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021405', 'ÁNCASH', 'OCROS', 'COCHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021406', 'ÁNCASH', 'OCROS', 'CONGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021407', 'ÁNCASH', 'OCROS', 'LLIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021408', 'ÁNCASH', 'OCROS', 'SAN CRISTÓBAL DE RAJAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021409', 'ÁNCASH', 'OCROS', 'SAN PEDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021410', 'ÁNCASH', 'OCROS', 'SANTIAGO DE CHILCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021501', 'ÁNCASH', 'PALLASCA', 'CABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021502', 'ÁNCASH', 'PALLASCA', 'BOLOGNESI');
INSERT INTO `tb_conf_ubigeo` VALUES ('021503', 'ÁNCASH', 'PALLASCA', 'CONCHUCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021504', 'ÁNCASH', 'PALLASCA', 'HUACASCHUQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021505', 'ÁNCASH', 'PALLASCA', 'HUANDOVAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('021506', 'ÁNCASH', 'PALLASCA', 'LACABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021507', 'ÁNCASH', 'PALLASCA', 'LLAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021508', 'ÁNCASH', 'PALLASCA', 'PALLASCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021509', 'ÁNCASH', 'PALLASCA', 'PAMPAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021510', 'ÁNCASH', 'PALLASCA', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021511', 'ÁNCASH', 'PALLASCA', 'TAUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021601', 'ÁNCASH', 'POMABAMBA', 'POMABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021602', 'ÁNCASH', 'POMABAMBA', 'HUAYLLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021603', 'ÁNCASH', 'POMABAMBA', 'PAROBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021604', 'ÁNCASH', 'POMABAMBA', 'QUINUABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021701', 'ÁNCASH', 'RECUAY', 'RECUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('021702', 'ÁNCASH', 'RECUAY', 'CATAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('021703', 'ÁNCASH', 'RECUAY', 'COTAPARACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021704', 'ÁNCASH', 'RECUAY', 'HUAYLLAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021705', 'ÁNCASH', 'RECUAY', 'LLACLLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021706', 'ÁNCASH', 'RECUAY', 'MARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021707', 'ÁNCASH', 'RECUAY', 'PAMPAS CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021708', 'ÁNCASH', 'RECUAY', 'PARARIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021709', 'ÁNCASH', 'RECUAY', 'TAPACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021710', 'ÁNCASH', 'RECUAY', 'TICAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021801', 'ÁNCASH', 'SANTA', 'CHIMBOTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021802', 'ÁNCASH', 'SANTA', 'CÁCERES DEL PERÚ');
INSERT INTO `tb_conf_ubigeo` VALUES ('021803', 'ÁNCASH', 'SANTA', 'COISHCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021804', 'ÁNCASH', 'SANTA', 'MACATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021805', 'ÁNCASH', 'SANTA', 'MORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021806', 'ÁNCASH', 'SANTA', 'NEPEÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021807', 'ÁNCASH', 'SANTA', 'SAMANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021808', 'ÁNCASH', 'SANTA', 'SANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021809', 'ÁNCASH', 'SANTA', 'NUEVO CHIMBOTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021901', 'ÁNCASH', 'SIHUAS', 'SIHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('021902', 'ÁNCASH', 'SIHUAS', 'ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021903', 'ÁNCASH', 'SIHUAS', 'ALFONSO UGARTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('021904', 'ÁNCASH', 'SIHUAS', 'CASHAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021905', 'ÁNCASH', 'SIHUAS', 'CHINGALPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('021906', 'ÁNCASH', 'SIHUAS', 'HUAYLLABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('021907', 'ÁNCASH', 'SIHUAS', 'QUICHES');
INSERT INTO `tb_conf_ubigeo` VALUES ('021908', 'ÁNCASH', 'SIHUAS', 'RAGASH');
INSERT INTO `tb_conf_ubigeo` VALUES ('021909', 'ÁNCASH', 'SIHUAS', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('021910', 'ÁNCASH', 'SIHUAS', 'SICSIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('022001', 'ÁNCASH', 'YUNGAY', 'YUNGAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('022002', 'ÁNCASH', 'YUNGAY', 'CASCAPARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('022003', 'ÁNCASH', 'YUNGAY', 'MANCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('022004', 'ÁNCASH', 'YUNGAY', 'MATACOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('022005', 'ÁNCASH', 'YUNGAY', 'QUILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('022006', 'ÁNCASH', 'YUNGAY', 'RANRAHIRCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('022007', 'ÁNCASH', 'YUNGAY', 'SHUPLUY');
INSERT INTO `tb_conf_ubigeo` VALUES ('022008', 'ÁNCASH', 'YUNGAY', 'YANAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030101', 'APURÍMAC', 'ABANCAY', 'ABANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030102', 'APURÍMAC', 'ABANCAY', 'CHACOCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('030103', 'APURÍMAC', 'ABANCAY', 'CIRCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030104', 'APURÍMAC', 'ABANCAY', 'CURAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030105', 'APURÍMAC', 'ABANCAY', 'HUANIPACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030106', 'APURÍMAC', 'ABANCAY', 'LAMBRAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030107', 'APURÍMAC', 'ABANCAY', 'PICHIRHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030108', 'APURÍMAC', 'ABANCAY', 'SAN PEDRO DE CACHORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030109', 'APURÍMAC', 'ABANCAY', 'TAMBURCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030201', 'APURÍMAC', 'ANDAHUAYLAS', 'ANDAHUAYLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030202', 'APURÍMAC', 'ANDAHUAYLAS', 'ANDARAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030203', 'APURÍMAC', 'ANDAHUAYLAS', 'CHIARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030204', 'APURÍMAC', 'ANDAHUAYLAS', 'HUANCARAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030205', 'APURÍMAC', 'ANDAHUAYLAS', 'HUANCARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030206', 'APURÍMAC', 'ANDAHUAYLAS', 'HUAYANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030207', 'APURÍMAC', 'ANDAHUAYLAS', 'KISHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030208', 'APURÍMAC', 'ANDAHUAYLAS', 'PACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030209', 'APURÍMAC', 'ANDAHUAYLAS', 'PACUCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030210', 'APURÍMAC', 'ANDAHUAYLAS', 'PAMPACHIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030211', 'APURÍMAC', 'ANDAHUAYLAS', 'POMACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030212', 'APURÍMAC', 'ANDAHUAYLAS', 'SAN ANTONIO DE CACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030213', 'APURÍMAC', 'ANDAHUAYLAS', 'SAN JERÓNIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030214', 'APURÍMAC', 'ANDAHUAYLAS', 'SAN MIGUEL DE CHACCRAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030215', 'APURÍMAC', 'ANDAHUAYLAS', 'SANTA MARÍA DE CHICMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030216', 'APURÍMAC', 'ANDAHUAYLAS', 'TALAVERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030217', 'APURÍMAC', 'ANDAHUAYLAS', 'TUMAY HUARACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030218', 'APURÍMAC', 'ANDAHUAYLAS', 'TURPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030219', 'APURÍMAC', 'ANDAHUAYLAS', 'KAQUIABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030220', 'APURÍMAC', 'ANDAHUAYLAS', 'JOSÉ MARÍA ARGUEDAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030301', 'APURÍMAC', 'ANTABAMBA', 'ANTABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030302', 'APURÍMAC', 'ANTABAMBA', 'EL ORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030303', 'APURÍMAC', 'ANTABAMBA', 'HUAQUIRCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030304', 'APURÍMAC', 'ANTABAMBA', 'JUAN ESPINOZA MEDRANO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030305', 'APURÍMAC', 'ANTABAMBA', 'OROPESA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030306', 'APURÍMAC', 'ANTABAMBA', 'PACHACONAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030307', 'APURÍMAC', 'ANTABAMBA', 'SABAINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030401', 'APURÍMAC', 'AYMARAES', 'CHALHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030402', 'APURÍMAC', 'AYMARAES', 'CAPAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030403', 'APURÍMAC', 'AYMARAES', 'CARAYBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030404', 'APURÍMAC', 'AYMARAES', 'CHAPIMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030405', 'APURÍMAC', 'AYMARAES', 'COLCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030406', 'APURÍMAC', 'AYMARAES', 'COTARUSE');
INSERT INTO `tb_conf_ubigeo` VALUES ('030407', 'APURÍMAC', 'AYMARAES', 'IHUAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030408', 'APURÍMAC', 'AYMARAES', 'JUSTO APU SAHUARAURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030409', 'APURÍMAC', 'AYMARAES', 'LUCRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('030410', 'APURÍMAC', 'AYMARAES', 'POCOHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030411', 'APURÍMAC', 'AYMARAES', 'SAN JUAN DE CHACÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030412', 'APURÍMAC', 'AYMARAES', 'SAÑAYCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030413', 'APURÍMAC', 'AYMARAES', 'SORAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030414', 'APURÍMAC', 'AYMARAES', 'TAPAIRIHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030415', 'APURÍMAC', 'AYMARAES', 'TINTAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030416', 'APURÍMAC', 'AYMARAES', 'TORAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030417', 'APURÍMAC', 'AYMARAES', 'YANACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030501', 'APURÍMAC', 'COTABAMBAS', 'TAMBOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030502', 'APURÍMAC', 'COTABAMBAS', 'COTABAMBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030503', 'APURÍMAC', 'COTABAMBAS', 'COYLLURQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030504', 'APURÍMAC', 'COTABAMBAS', 'HAQUIRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030505', 'APURÍMAC', 'COTABAMBAS', 'MARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030506', 'APURÍMAC', 'COTABAMBAS', 'CHALLHUAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030601', 'APURÍMAC', 'CHINCHEROS', 'CHINCHEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030602', 'APURÍMAC', 'CHINCHEROS', 'ANCO_HUALLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030603', 'APURÍMAC', 'CHINCHEROS', 'COCHARCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030604', 'APURÍMAC', 'CHINCHEROS', 'HUACCANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030605', 'APURÍMAC', 'CHINCHEROS', 'OCOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030606', 'APURÍMAC', 'CHINCHEROS', 'ONGOY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030607', 'APURÍMAC', 'CHINCHEROS', 'URANMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030608', 'APURÍMAC', 'CHINCHEROS', 'RANRACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030609', 'APURÍMAC', 'CHINCHEROS', 'ROCCHACC');
INSERT INTO `tb_conf_ubigeo` VALUES ('030610', 'APURÍMAC', 'CHINCHEROS', 'EL PORVENIR');
INSERT INTO `tb_conf_ubigeo` VALUES ('030701', 'APURÍMAC', 'GRAU', 'CHUQUIBAMBILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030702', 'APURÍMAC', 'GRAU', 'CURPAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030703', 'APURÍMAC', 'GRAU', 'GAMARRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030704', 'APURÍMAC', 'GRAU', 'HUAYLLATI');
INSERT INTO `tb_conf_ubigeo` VALUES ('030705', 'APURÍMAC', 'GRAU', 'MAMARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030706', 'APURÍMAC', 'GRAU', 'MICAELA BASTIDAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('030707', 'APURÍMAC', 'GRAU', 'PATAYPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030708', 'APURÍMAC', 'GRAU', 'PROGRESO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030709', 'APURÍMAC', 'GRAU', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030710', 'APURÍMAC', 'GRAU', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030711', 'APURÍMAC', 'GRAU', 'TURPAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('030712', 'APURÍMAC', 'GRAU', 'VILCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('030713', 'APURÍMAC', 'GRAU', 'VIRUNDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('030714', 'APURÍMAC', 'GRAU', 'CURASCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040101', 'AREQUIPA', 'AREQUIPA', 'AREQUIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040102', 'AREQUIPA', 'AREQUIPA', 'ALTO SELVA ALEGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040103', 'AREQUIPA', 'AREQUIPA', 'CAYMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040104', 'AREQUIPA', 'AREQUIPA', 'CERRO COLORADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040105', 'AREQUIPA', 'AREQUIPA', 'CHARACATO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040106', 'AREQUIPA', 'AREQUIPA', 'CHIGUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040107', 'AREQUIPA', 'AREQUIPA', 'JACOBO HUNTER');
INSERT INTO `tb_conf_ubigeo` VALUES ('040108', 'AREQUIPA', 'AREQUIPA', 'LA JOYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040109', 'AREQUIPA', 'AREQUIPA', 'MARIANO MELGAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('040110', 'AREQUIPA', 'AREQUIPA', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('040111', 'AREQUIPA', 'AREQUIPA', 'MOLLEBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040112', 'AREQUIPA', 'AREQUIPA', 'PAUCARPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040113', 'AREQUIPA', 'AREQUIPA', 'POCSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040114', 'AREQUIPA', 'AREQUIPA', 'POLOBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040115', 'AREQUIPA', 'AREQUIPA', 'QUEQUEÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040116', 'AREQUIPA', 'AREQUIPA', 'SABANDIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040117', 'AREQUIPA', 'AREQUIPA', 'SACHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040118', 'AREQUIPA', 'AREQUIPA', 'SAN JUAN DE SIGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040119', 'AREQUIPA', 'AREQUIPA', 'SAN JUAN DE TARUCANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040120', 'AREQUIPA', 'AREQUIPA', 'SANTA ISABEL DE SIGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040121', 'AREQUIPA', 'AREQUIPA', 'SANTA RITA DE SIGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040122', 'AREQUIPA', 'AREQUIPA', 'SOCABAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040123', 'AREQUIPA', 'AREQUIPA', 'TIABAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040124', 'AREQUIPA', 'AREQUIPA', 'UCHUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040125', 'AREQUIPA', 'AREQUIPA', 'VITOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('040126', 'AREQUIPA', 'AREQUIPA', 'YANAHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040127', 'AREQUIPA', 'AREQUIPA', 'YARABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040128', 'AREQUIPA', 'AREQUIPA', 'YURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040129', 'AREQUIPA', 'AREQUIPA', 'JOSÉ LUIS BUSTAMANTE Y RIVERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040201', 'AREQUIPA', 'CAMANÁ', 'CAMANÁ');
INSERT INTO `tb_conf_ubigeo` VALUES ('040202', 'AREQUIPA', 'CAMANÁ', 'JOSÉ MARÍA QUIMPER');
INSERT INTO `tb_conf_ubigeo` VALUES ('040203', 'AREQUIPA', 'CAMANÁ', 'MARIANO NICOLÁS VALCÁRCEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('040204', 'AREQUIPA', 'CAMANÁ', 'MARISCAL CÁCERES');
INSERT INTO `tb_conf_ubigeo` VALUES ('040205', 'AREQUIPA', 'CAMANÁ', 'NICOLÁS DE PIEROLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040206', 'AREQUIPA', 'CAMANÁ', 'OCOÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040207', 'AREQUIPA', 'CAMANÁ', 'QUILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040208', 'AREQUIPA', 'CAMANÁ', 'SAMUEL PASTOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('040301', 'AREQUIPA', 'CARAVELÍ', 'CARAVELÍ');
INSERT INTO `tb_conf_ubigeo` VALUES ('040302', 'AREQUIPA', 'CARAVELÍ', 'ACARÍ');
INSERT INTO `tb_conf_ubigeo` VALUES ('040303', 'AREQUIPA', 'CARAVELÍ', 'ATICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040304', 'AREQUIPA', 'CARAVELÍ', 'ATIQUIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040305', 'AREQUIPA', 'CARAVELÍ', 'BELLA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('040306', 'AREQUIPA', 'CARAVELÍ', 'CAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040307', 'AREQUIPA', 'CARAVELÍ', 'CHALA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040308', 'AREQUIPA', 'CARAVELÍ', 'CHAPARRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040309', 'AREQUIPA', 'CARAVELÍ', 'HUANUHUANU');
INSERT INTO `tb_conf_ubigeo` VALUES ('040310', 'AREQUIPA', 'CARAVELÍ', 'JAQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040311', 'AREQUIPA', 'CARAVELÍ', 'LOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040312', 'AREQUIPA', 'CARAVELÍ', 'QUICACHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040313', 'AREQUIPA', 'CARAVELÍ', 'YAUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040401', 'AREQUIPA', 'CASTILLA', 'APLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040402', 'AREQUIPA', 'CASTILLA', 'ANDAGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040403', 'AREQUIPA', 'CASTILLA', 'AYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040404', 'AREQUIPA', 'CASTILLA', 'CHACHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040405', 'AREQUIPA', 'CASTILLA', 'CHILCAYMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040406', 'AREQUIPA', 'CASTILLA', 'CHOCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040407', 'AREQUIPA', 'CASTILLA', 'HUANCARQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040408', 'AREQUIPA', 'CASTILLA', 'MACHAGUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040409', 'AREQUIPA', 'CASTILLA', 'ORCOPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040410', 'AREQUIPA', 'CASTILLA', 'PAMPACOLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040411', 'AREQUIPA', 'CASTILLA', 'TIPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('040412', 'AREQUIPA', 'CASTILLA', 'UÑON');
INSERT INTO `tb_conf_ubigeo` VALUES ('040413', 'AREQUIPA', 'CASTILLA', 'URACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040414', 'AREQUIPA', 'CASTILLA', 'VIRACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040501', 'AREQUIPA', 'CAYLLOMA', 'CHIVAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040502', 'AREQUIPA', 'CAYLLOMA', 'ACHOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040503', 'AREQUIPA', 'CAYLLOMA', 'CABANACONDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040504', 'AREQUIPA', 'CAYLLOMA', 'CALLALLI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040505', 'AREQUIPA', 'CAYLLOMA', 'CAYLLOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040506', 'AREQUIPA', 'CAYLLOMA', 'COPORAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040507', 'AREQUIPA', 'CAYLLOMA', 'HUAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040508', 'AREQUIPA', 'CAYLLOMA', 'HUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040509', 'AREQUIPA', 'CAYLLOMA', 'ICHUPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040510', 'AREQUIPA', 'CAYLLOMA', 'LARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040511', 'AREQUIPA', 'CAYLLOMA', 'LLUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040512', 'AREQUIPA', 'CAYLLOMA', 'MACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040513', 'AREQUIPA', 'CAYLLOMA', 'MADRIGAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('040514', 'AREQUIPA', 'CAYLLOMA', 'SAN ANTONIO DE CHUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040515', 'AREQUIPA', 'CAYLLOMA', 'SIBAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040516', 'AREQUIPA', 'CAYLLOMA', 'TAPAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040517', 'AREQUIPA', 'CAYLLOMA', 'TISCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040518', 'AREQUIPA', 'CAYLLOMA', 'TUTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040519', 'AREQUIPA', 'CAYLLOMA', 'YANQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040520', 'AREQUIPA', 'CAYLLOMA', 'MAJES');
INSERT INTO `tb_conf_ubigeo` VALUES ('040601', 'AREQUIPA', 'CONDESUYOS', 'CHUQUIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040602', 'AREQUIPA', 'CONDESUYOS', 'ANDARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040603', 'AREQUIPA', 'CONDESUYOS', 'CAYARANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040604', 'AREQUIPA', 'CONDESUYOS', 'CHICHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040605', 'AREQUIPA', 'CONDESUYOS', 'IRAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040606', 'AREQUIPA', 'CONDESUYOS', 'RÍO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('040607', 'AREQUIPA', 'CONDESUYOS', 'SALAMANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040608', 'AREQUIPA', 'CONDESUYOS', 'YANAQUIHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040701', 'AREQUIPA', 'ISLAY', 'MOLLENDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('040702', 'AREQUIPA', 'ISLAY', 'COCACHACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040703', 'AREQUIPA', 'ISLAY', 'DEAN VALDIVIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040704', 'AREQUIPA', 'ISLAY', 'ISLAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('040705', 'AREQUIPA', 'ISLAY', 'MEJIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040706', 'AREQUIPA', 'ISLAY', 'PUNTA DE BOMBÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('040801', 'AREQUIPA', 'LA UNIÒN', 'COTAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('040802', 'AREQUIPA', 'LA UNIÒN', 'ALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040803', 'AREQUIPA', 'LA UNIÒN', 'CHARCANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040804', 'AREQUIPA', 'LA UNIÒN', 'HUAYNACOTAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('040805', 'AREQUIPA', 'LA UNIÒN', 'PAMPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040806', 'AREQUIPA', 'LA UNIÒN', 'PUYCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040807', 'AREQUIPA', 'LA UNIÒN', 'QUECHUALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040808', 'AREQUIPA', 'LA UNIÒN', 'SAYLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040809', 'AREQUIPA', 'LA UNIÒN', 'TAURIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040810', 'AREQUIPA', 'LA UNIÒN', 'TOMEPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('040811', 'AREQUIPA', 'LA UNIÒN', 'TORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050101', 'AYACUCHO', 'HUAMANGA', 'AYACUCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050102', 'AYACUCHO', 'HUAMANGA', 'ACOCRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050103', 'AYACUCHO', 'HUAMANGA', 'ACOS VINCHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050104', 'AYACUCHO', 'HUAMANGA', 'CARMEN ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050105', 'AYACUCHO', 'HUAMANGA', 'CHIARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050106', 'AYACUCHO', 'HUAMANGA', 'OCROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050107', 'AYACUCHO', 'HUAMANGA', 'PACAYCASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050108', 'AYACUCHO', 'HUAMANGA', 'QUINUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050109', 'AYACUCHO', 'HUAMANGA', 'SAN JOSÉ DE TICLLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050110', 'AYACUCHO', 'HUAMANGA', 'SAN JUAN BAUTISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050111', 'AYACUCHO', 'HUAMANGA', 'SANTIAGO DE PISCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050112', 'AYACUCHO', 'HUAMANGA', 'SOCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050113', 'AYACUCHO', 'HUAMANGA', 'TAMBILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050114', 'AYACUCHO', 'HUAMANGA', 'VINCHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050115', 'AYACUCHO', 'HUAMANGA', 'JESÚS NAZARENO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050116', 'AYACUCHO', 'HUAMANGA', 'ANDRÉS AVELINO CÁCERES DORREGARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050201', 'AYACUCHO', 'CANGALLO', 'CANGALLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050202', 'AYACUCHO', 'CANGALLO', 'CHUSCHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050203', 'AYACUCHO', 'CANGALLO', 'LOS MOROCHUCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050204', 'AYACUCHO', 'CANGALLO', 'MARÍA PARADO DE BELLIDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050205', 'AYACUCHO', 'CANGALLO', 'PARAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050206', 'AYACUCHO', 'CANGALLO', 'TOTOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050301', 'AYACUCHO', 'HUANCA SANCOS', 'SANCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050302', 'AYACUCHO', 'HUANCA SANCOS', 'CARAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050303', 'AYACUCHO', 'HUANCA SANCOS', 'SACSAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050304', 'AYACUCHO', 'HUANCA SANCOS', 'SANTIAGO DE LUCANAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050401', 'AYACUCHO', 'HUANTA', 'HUANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050402', 'AYACUCHO', 'HUANTA', 'AYAHUANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050403', 'AYACUCHO', 'HUANTA', 'HUAMANGUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050404', 'AYACUCHO', 'HUANTA', 'IGUAIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('050405', 'AYACUCHO', 'HUANTA', 'LURICOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050406', 'AYACUCHO', 'HUANTA', 'SANTILLANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050407', 'AYACUCHO', 'HUANTA', 'SIVIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050408', 'AYACUCHO', 'HUANTA', 'LLOCHEGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050409', 'AYACUCHO', 'HUANTA', 'CANAYRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('050410', 'AYACUCHO', 'HUANTA', 'UCHURACCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050411', 'AYACUCHO', 'HUANTA', 'PUCACOLPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050412', 'AYACUCHO', 'HUANTA', 'CHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050501', 'AYACUCHO', 'LA MAR', 'SAN MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('050502', 'AYACUCHO', 'LA MAR', 'ANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050503', 'AYACUCHO', 'LA MAR', 'AYNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050504', 'AYACUCHO', 'LA MAR', 'CHILCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050505', 'AYACUCHO', 'LA MAR', 'CHUNGUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050506', 'AYACUCHO', 'LA MAR', 'LUIS CARRANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050507', 'AYACUCHO', 'LA MAR', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050508', 'AYACUCHO', 'LA MAR', 'TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050509', 'AYACUCHO', 'LA MAR', 'SAMUGARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050510', 'AYACUCHO', 'LA MAR', 'ANCHIHUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050601', 'AYACUCHO', 'LUCANAS', 'PUQUIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050602', 'AYACUCHO', 'LUCANAS', 'AUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050603', 'AYACUCHO', 'LUCANAS', 'CABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050604', 'AYACUCHO', 'LUCANAS', 'CARMEN SALCEDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050605', 'AYACUCHO', 'LUCANAS', 'CHAVIÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050606', 'AYACUCHO', 'LUCANAS', 'CHIPAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050607', 'AYACUCHO', 'LUCANAS', 'HUAC-HUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050608', 'AYACUCHO', 'LUCANAS', 'LARAMATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('050609', 'AYACUCHO', 'LUCANAS', 'LEONCIO PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050610', 'AYACUCHO', 'LUCANAS', 'LLAUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050611', 'AYACUCHO', 'LUCANAS', 'LUCANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050612', 'AYACUCHO', 'LUCANAS', 'OCAÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050613', 'AYACUCHO', 'LUCANAS', 'OTOCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050614', 'AYACUCHO', 'LUCANAS', 'SAISA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050615', 'AYACUCHO', 'LUCANAS', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('050616', 'AYACUCHO', 'LUCANAS', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('050617', 'AYACUCHO', 'LUCANAS', 'SAN PEDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050618', 'AYACUCHO', 'LUCANAS', 'SAN PEDRO DE PALCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050619', 'AYACUCHO', 'LUCANAS', 'SANCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050620', 'AYACUCHO', 'LUCANAS', 'SANTA ANA DE HUAYCAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050621', 'AYACUCHO', 'LUCANAS', 'SANTA LUCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050701', 'AYACUCHO', 'PARINACOCHAS', 'CORACORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050702', 'AYACUCHO', 'PARINACOCHAS', 'CHUMPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('050703', 'AYACUCHO', 'PARINACOCHAS', 'CORONEL CASTAÑEDA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050704', 'AYACUCHO', 'PARINACOCHAS', 'PACAPAUSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050705', 'AYACUCHO', 'PARINACOCHAS', 'PULLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050706', 'AYACUCHO', 'PARINACOCHAS', 'PUYUSCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050707', 'AYACUCHO', 'PARINACOCHAS', 'SAN FRANCISCO DE RAVACAYCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050708', 'AYACUCHO', 'PARINACOCHAS', 'UPAHUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050801', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'PAUSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050802', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'COLTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050803', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'CORCULLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050804', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'LAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050805', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'MARCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050806', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'OYOLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050807', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'PARARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050808', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'SAN JAVIER DE ALPABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050809', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'SAN JOSÉ DE USHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050810', 'AYACUCHO', 'PÀUCAR DEL SARA SARA', 'SARA SARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050901', 'AYACUCHO', 'SUCRE', 'QUEROBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050902', 'AYACUCHO', 'SUCRE', 'BELÉN');
INSERT INTO `tb_conf_ubigeo` VALUES ('050903', 'AYACUCHO', 'SUCRE', 'CHALCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('050904', 'AYACUCHO', 'SUCRE', 'CHILCAYOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('050905', 'AYACUCHO', 'SUCRE', 'HUACAÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050906', 'AYACUCHO', 'SUCRE', 'MORCOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('050907', 'AYACUCHO', 'SUCRE', 'PAICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('050908', 'AYACUCHO', 'SUCRE', 'SAN PEDRO DE LARCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050909', 'AYACUCHO', 'SUCRE', 'SAN SALVADOR DE QUIJE');
INSERT INTO `tb_conf_ubigeo` VALUES ('050910', 'AYACUCHO', 'SUCRE', 'SANTIAGO DE PAUCARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('050911', 'AYACUCHO', 'SUCRE', 'SORAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('051001', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUANCAPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('051002', 'AYACUCHO', 'VÍCTOR FAJARDO', 'ALCAMENCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051003', 'AYACUCHO', 'VÍCTOR FAJARDO', 'APONGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('051004', 'AYACUCHO', 'VÍCTOR FAJARDO', 'ASQUIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051005', 'AYACUCHO', 'VÍCTOR FAJARDO', 'CANARIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051006', 'AYACUCHO', 'VÍCTOR FAJARDO', 'CAYARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051007', 'AYACUCHO', 'VÍCTOR FAJARDO', 'COLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051008', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUAMANQUIQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051009', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUANCARAYLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051010', 'AYACUCHO', 'VÍCTOR FAJARDO', 'HUAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051011', 'AYACUCHO', 'VÍCTOR FAJARDO', 'SARHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051012', 'AYACUCHO', 'VÍCTOR FAJARDO', 'VILCANCHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('051101', 'AYACUCHO', 'VILCAS HUAMÁN', 'VILCAS HUAMAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('051102', 'AYACUCHO', 'VILCAS HUAMÁN', 'ACCOMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051103', 'AYACUCHO', 'VILCAS HUAMÁN', 'CARHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051104', 'AYACUCHO', 'VILCAS HUAMÁN', 'CONCEPCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('051105', 'AYACUCHO', 'VILCAS HUAMÁN', 'HUAMBALPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051106', 'AYACUCHO', 'VILCAS HUAMÁN', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051107', 'AYACUCHO', 'VILCAS HUAMÁN', 'SAURAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('051108', 'AYACUCHO', 'VILCAS HUAMÁN', 'VISCHONGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060101', 'CAJAMARCA', 'CAJAMARCA', 'CAJAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060102', 'CAJAMARCA', 'CAJAMARCA', 'ASUNCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060103', 'CAJAMARCA', 'CAJAMARCA', 'CHETILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060104', 'CAJAMARCA', 'CAJAMARCA', 'COSPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060105', 'CAJAMARCA', 'CAJAMARCA', 'ENCAÑADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060106', 'CAJAMARCA', 'CAJAMARCA', 'JESÚS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060107', 'CAJAMARCA', 'CAJAMARCA', 'LLACANORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060108', 'CAJAMARCA', 'CAJAMARCA', 'LOS BAÑOS DEL INCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060109', 'CAJAMARCA', 'CAJAMARCA', 'MAGDALENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060110', 'CAJAMARCA', 'CAJAMARCA', 'MATARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060111', 'CAJAMARCA', 'CAJAMARCA', 'NAMORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060112', 'CAJAMARCA', 'CAJAMARCA', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060201', 'CAJAMARCA', 'CAJABAMBA', 'CAJABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060202', 'CAJAMARCA', 'CAJABAMBA', 'CACHACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('060203', 'CAJAMARCA', 'CAJABAMBA', 'CONDEBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060204', 'CAJAMARCA', 'CAJABAMBA', 'SITACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060301', 'CAJAMARCA', 'CELENDÍN', 'CELENDÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060302', 'CAJAMARCA', 'CELENDÍN', 'CHUMUCH');
INSERT INTO `tb_conf_ubigeo` VALUES ('060303', 'CAJAMARCA', 'CELENDÍN', 'CORTEGANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060304', 'CAJAMARCA', 'CELENDÍN', 'HUASMIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060305', 'CAJAMARCA', 'CELENDÍN', 'JORGE CHÁVEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('060306', 'CAJAMARCA', 'CELENDÍN', 'JOSÉ GÁLVEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('060307', 'CAJAMARCA', 'CELENDÍN', 'MIGUEL IGLESIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060308', 'CAJAMARCA', 'CELENDÍN', 'OXAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060309', 'CAJAMARCA', 'CELENDÍN', 'SOROCHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060310', 'CAJAMARCA', 'CELENDÍN', 'SUCRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060311', 'CAJAMARCA', 'CELENDÍN', 'UTCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060312', 'CAJAMARCA', 'CELENDÍN', 'LA LIBERTAD DE PALLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060401', 'CAJAMARCA', 'CHOTA', 'CHOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060402', 'CAJAMARCA', 'CHOTA', 'ANGUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060403', 'CAJAMARCA', 'CHOTA', 'CHADIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060404', 'CAJAMARCA', 'CHOTA', 'CHIGUIRIP');
INSERT INTO `tb_conf_ubigeo` VALUES ('060405', 'CAJAMARCA', 'CHOTA', 'CHIMBAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060406', 'CAJAMARCA', 'CHOTA', 'CHOROPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060407', 'CAJAMARCA', 'CHOTA', 'COCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060408', 'CAJAMARCA', 'CHOTA', 'CONCHAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060409', 'CAJAMARCA', 'CHOTA', 'HUAMBOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060410', 'CAJAMARCA', 'CHOTA', 'LAJAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060411', 'CAJAMARCA', 'CHOTA', 'LLAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060412', 'CAJAMARCA', 'CHOTA', 'MIRACOSTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060413', 'CAJAMARCA', 'CHOTA', 'PACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060414', 'CAJAMARCA', 'CHOTA', 'PION');
INSERT INTO `tb_conf_ubigeo` VALUES ('060415', 'CAJAMARCA', 'CHOTA', 'QUEROCOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060416', 'CAJAMARCA', 'CHOTA', 'SAN JUAN DE LICUPIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060417', 'CAJAMARCA', 'CHOTA', 'TACABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060418', 'CAJAMARCA', 'CHOTA', 'TOCMOCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060419', 'CAJAMARCA', 'CHOTA', 'CHALAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060501', 'CAJAMARCA', 'CONTUMAZÁ', 'CONTUMAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060502', 'CAJAMARCA', 'CONTUMAZÁ', 'CHILETE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060503', 'CAJAMARCA', 'CONTUMAZÁ', 'CUPISNIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060504', 'CAJAMARCA', 'CONTUMAZÁ', 'GUZMANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060505', 'CAJAMARCA', 'CONTUMAZÁ', 'SAN BENITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060506', 'CAJAMARCA', 'CONTUMAZÁ', 'SANTA CRUZ DE TOLEDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060507', 'CAJAMARCA', 'CONTUMAZÁ', 'TANTARICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060508', 'CAJAMARCA', 'CONTUMAZÁ', 'YONAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060601', 'CAJAMARCA', 'CUTERVO', 'CUTERVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060602', 'CAJAMARCA', 'CUTERVO', 'CALLAYUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('060603', 'CAJAMARCA', 'CUTERVO', 'CHOROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060604', 'CAJAMARCA', 'CUTERVO', 'CUJILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060605', 'CAJAMARCA', 'CUTERVO', 'LA RAMADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060606', 'CAJAMARCA', 'CUTERVO', 'PIMPINGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060607', 'CAJAMARCA', 'CUTERVO', 'QUEROCOTILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060608', 'CAJAMARCA', 'CUTERVO', 'SAN ANDRÉS DE CUTERVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060609', 'CAJAMARCA', 'CUTERVO', 'SAN JUAN DE CUTERVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060610', 'CAJAMARCA', 'CUTERVO', 'SAN LUIS DE LUCMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060611', 'CAJAMARCA', 'CUTERVO', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('060612', 'CAJAMARCA', 'CUTERVO', 'SANTO DOMINGO DE LA CAPILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060613', 'CAJAMARCA', 'CUTERVO', 'SANTO TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060614', 'CAJAMARCA', 'CUTERVO', 'SOCOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060615', 'CAJAMARCA', 'CUTERVO', 'TORIBIO CASANOVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060701', 'CAJAMARCA', 'HUALGAYOC', 'BAMBAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060702', 'CAJAMARCA', 'HUALGAYOC', 'CHUGUR');
INSERT INTO `tb_conf_ubigeo` VALUES ('060703', 'CAJAMARCA', 'HUALGAYOC', 'HUALGAYOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('060801', 'CAJAMARCA', 'JAÉN', 'JAÉN');
INSERT INTO `tb_conf_ubigeo` VALUES ('060802', 'CAJAMARCA', 'JAÉN', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060803', 'CAJAMARCA', 'JAÉN', 'CHONTALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('060804', 'CAJAMARCA', 'JAÉN', 'COLASAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('060805', 'CAJAMARCA', 'JAÉN', 'HUABAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('060806', 'CAJAMARCA', 'JAÉN', 'LAS PIRIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060807', 'CAJAMARCA', 'JAÉN', 'POMAHUACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060808', 'CAJAMARCA', 'JAÉN', 'PUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060809', 'CAJAMARCA', 'JAÉN', 'SALLIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060810', 'CAJAMARCA', 'JAÉN', 'SAN FELIPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060811', 'CAJAMARCA', 'JAÉN', 'SAN JOSÉ DEL ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060812', 'CAJAMARCA', 'JAÉN', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060901', 'CAJAMARCA', 'SAN IGNACIO', 'SAN IGNACIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060902', 'CAJAMARCA', 'SAN IGNACIO', 'CHIRINOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('060903', 'CAJAMARCA', 'SAN IGNACIO', 'HUARANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('060904', 'CAJAMARCA', 'SAN IGNACIO', 'LA COIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('060905', 'CAJAMARCA', 'SAN IGNACIO', 'NAMBALLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('060906', 'CAJAMARCA', 'SAN IGNACIO', 'SAN JOSÉ DE LOURDES');
INSERT INTO `tb_conf_ubigeo` VALUES ('060907', 'CAJAMARCA', 'SAN IGNACIO', 'TABACONAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061001', 'CAJAMARCA', 'SAN MARCOS', 'PEDRO GÁLVEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('061002', 'CAJAMARCA', 'SAN MARCOS', 'CHANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('061003', 'CAJAMARCA', 'SAN MARCOS', 'EDUARDO VILLANUEVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061004', 'CAJAMARCA', 'SAN MARCOS', 'GREGORIO PITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061005', 'CAJAMARCA', 'SAN MARCOS', 'ICHOCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061006', 'CAJAMARCA', 'SAN MARCOS', 'JOSÉ MANUEL QUIROZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('061007', 'CAJAMARCA', 'SAN MARCOS', 'JOSÉ SABOGAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('061101', 'CAJAMARCA', 'SAN MIGUEL', 'SAN MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('061102', 'CAJAMARCA', 'SAN MIGUEL', 'BOLÍVAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('061103', 'CAJAMARCA', 'SAN MIGUEL', 'CALQUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061104', 'CAJAMARCA', 'SAN MIGUEL', 'CATILLUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('061105', 'CAJAMARCA', 'SAN MIGUEL', 'EL PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061106', 'CAJAMARCA', 'SAN MIGUEL', 'LA FLORIDA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061107', 'CAJAMARCA', 'SAN MIGUEL', 'LLAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061108', 'CAJAMARCA', 'SAN MIGUEL', 'NANCHOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('061109', 'CAJAMARCA', 'SAN MIGUEL', 'NIEPOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061110', 'CAJAMARCA', 'SAN MIGUEL', 'SAN GREGORIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061111', 'CAJAMARCA', 'SAN MIGUEL', 'SAN SILVESTRE DE COCHAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061112', 'CAJAMARCA', 'SAN MIGUEL', 'TONGOD');
INSERT INTO `tb_conf_ubigeo` VALUES ('061113', 'CAJAMARCA', 'SAN MIGUEL', 'UNIÓN AGUA BLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061201', 'CAJAMARCA', 'SAN PABLO', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061202', 'CAJAMARCA', 'SAN PABLO', 'SAN BERNARDINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('061203', 'CAJAMARCA', 'SAN PABLO', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061204', 'CAJAMARCA', 'SAN PABLO', 'TUMBADEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061301', 'CAJAMARCA', 'SANTA CRUZ', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('061302', 'CAJAMARCA', 'SANTA CRUZ', 'ANDABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061303', 'CAJAMARCA', 'SANTA CRUZ', 'CATACHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('061304', 'CAJAMARCA', 'SANTA CRUZ', 'CHANCAYBAÑOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('061305', 'CAJAMARCA', 'SANTA CRUZ', 'LA ESPERANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061306', 'CAJAMARCA', 'SANTA CRUZ', 'NINABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061307', 'CAJAMARCA', 'SANTA CRUZ', 'PULAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('061308', 'CAJAMARCA', 'SANTA CRUZ', 'SAUCEPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('061309', 'CAJAMARCA', 'SANTA CRUZ', 'SEXI');
INSERT INTO `tb_conf_ubigeo` VALUES ('061310', 'CAJAMARCA', 'SANTA CRUZ', 'UTICYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('061311', 'CAJAMARCA', 'SANTA CRUZ', 'YAUYUCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('070101', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'CALLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('070102', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070103', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'CARMEN DE LA LEGUA REYNOSO');
INSERT INTO `tb_conf_ubigeo` VALUES ('070104', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'LA PERLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070105', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'LA PUNTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070106', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'VENTANILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('070107', 'CALLAO', 'PROV. CONST. DEL CALLAO', 'MI PERÚ');
INSERT INTO `tb_conf_ubigeo` VALUES ('080101', 'CUSCO', 'CUSCO', 'CUSCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080102', 'CUSCO', 'CUSCO', 'CCORCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080103', 'CUSCO', 'CUSCO', 'POROY');
INSERT INTO `tb_conf_ubigeo` VALUES ('080104', 'CUSCO', 'CUSCO', 'SAN JERÓNIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080105', 'CUSCO', 'CUSCO', 'SAN SEBASTIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('080106', 'CUSCO', 'CUSCO', 'SANTIAGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080107', 'CUSCO', 'CUSCO', 'SAYLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080108', 'CUSCO', 'CUSCO', 'WANCHAQ');
INSERT INTO `tb_conf_ubigeo` VALUES ('080201', 'CUSCO', 'ACOMAYO', 'ACOMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080202', 'CUSCO', 'ACOMAYO', 'ACOPIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080203', 'CUSCO', 'ACOMAYO', 'ACOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('080204', 'CUSCO', 'ACOMAYO', 'MOSOC LLACTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080205', 'CUSCO', 'ACOMAYO', 'POMACANCHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080206', 'CUSCO', 'ACOMAYO', 'RONDOCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('080207', 'CUSCO', 'ACOMAYO', 'SANGARARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080301', 'CUSCO', 'ANTA', 'ANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080302', 'CUSCO', 'ANTA', 'ANCAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080303', 'CUSCO', 'ANTA', 'CACHIMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080304', 'CUSCO', 'ANTA', 'CHINCHAYPUJIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080305', 'CUSCO', 'ANTA', 'HUAROCONDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080306', 'CUSCO', 'ANTA', 'LIMATAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080307', 'CUSCO', 'ANTA', 'MOLLEPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080308', 'CUSCO', 'ANTA', 'PUCYURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080309', 'CUSCO', 'ANTA', 'ZURITE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080401', 'CUSCO', 'CALCA', 'CALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080402', 'CUSCO', 'CALCA', 'COYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080403', 'CUSCO', 'CALCA', 'LAMAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('080404', 'CUSCO', 'CALCA', 'LARES');
INSERT INTO `tb_conf_ubigeo` VALUES ('080405', 'CUSCO', 'CALCA', 'PISAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('080406', 'CUSCO', 'CALCA', 'SAN SALVADOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('080407', 'CUSCO', 'CALCA', 'TARAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('080408', 'CUSCO', 'CALCA', 'YANATILE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080501', 'CUSCO', 'CANAS', 'YANAOCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080502', 'CUSCO', 'CANAS', 'CHECCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080503', 'CUSCO', 'CANAS', 'KUNTURKANKI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080504', 'CUSCO', 'CANAS', 'LANGUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080505', 'CUSCO', 'CANAS', 'LAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080506', 'CUSCO', 'CANAS', 'PAMPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080507', 'CUSCO', 'CANAS', 'QUEHUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080508', 'CUSCO', 'CANAS', 'TUPAC AMARU');
INSERT INTO `tb_conf_ubigeo` VALUES ('080601', 'CUSCO', 'CANCHIS', 'SICUANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080602', 'CUSCO', 'CANCHIS', 'CHECACUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080603', 'CUSCO', 'CANCHIS', 'COMBAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080604', 'CUSCO', 'CANCHIS', 'MARANGANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080605', 'CUSCO', 'CANCHIS', 'PITUMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080606', 'CUSCO', 'CANCHIS', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080607', 'CUSCO', 'CANCHIS', 'SAN PEDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080608', 'CUSCO', 'CANCHIS', 'TINTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080701', 'CUSCO', 'CHUMBIVILCAS', 'SANTO TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('080702', 'CUSCO', 'CHUMBIVILCAS', 'CAPACMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080703', 'CUSCO', 'CHUMBIVILCAS', 'CHAMACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080704', 'CUSCO', 'CHUMBIVILCAS', 'COLQUEMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080705', 'CUSCO', 'CHUMBIVILCAS', 'LIVITACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080706', 'CUSCO', 'CHUMBIVILCAS', 'LLUSCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080707', 'CUSCO', 'CHUMBIVILCAS', 'QUIÑOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080708', 'CUSCO', 'CHUMBIVILCAS', 'VELILLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080801', 'CUSCO', 'ESPINAR', 'ESPINAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('080802', 'CUSCO', 'ESPINAR', 'CONDOROMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080803', 'CUSCO', 'ESPINAR', 'COPORAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080804', 'CUSCO', 'ESPINAR', 'OCORURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080805', 'CUSCO', 'ESPINAR', 'PALLPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080806', 'CUSCO', 'ESPINAR', 'PICHIGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080807', 'CUSCO', 'ESPINAR', 'SUYCKUTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080808', 'CUSCO', 'ESPINAR', 'ALTO PICHIGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080901', 'CUSCO', 'LA CONVENCIÓN', 'SANTA ANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080902', 'CUSCO', 'LA CONVENCIÓN', 'ECHARATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('080903', 'CUSCO', 'LA CONVENCIÓN', 'HUAYOPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080904', 'CUSCO', 'LA CONVENCIÓN', 'MARANURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080905', 'CUSCO', 'LA CONVENCIÓN', 'OCOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080906', 'CUSCO', 'LA CONVENCIÓN', 'QUELLOUNO');
INSERT INTO `tb_conf_ubigeo` VALUES ('080907', 'CUSCO', 'LA CONVENCIÓN', 'KIMBIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080908', 'CUSCO', 'LA CONVENCIÓN', 'SANTA TERESA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080909', 'CUSCO', 'LA CONVENCIÓN', 'VILCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('080910', 'CUSCO', 'LA CONVENCIÓN', 'PICHARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080911', 'CUSCO', 'LA CONVENCIÓN', 'INKAWASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('080912', 'CUSCO', 'LA CONVENCIÓN', 'VILLA VIRGEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('080913', 'CUSCO', 'LA CONVENCIÓN', 'VILLA KINTIARINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081001', 'CUSCO', 'PARURO', 'PARURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081002', 'CUSCO', 'PARURO', 'ACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081003', 'CUSCO', 'PARURO', 'CCAPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('081004', 'CUSCO', 'PARURO', 'COLCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081005', 'CUSCO', 'PARURO', 'HUANOQUITE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081006', 'CUSCO', 'PARURO', 'OMACHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081007', 'CUSCO', 'PARURO', 'PACCARITAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081008', 'CUSCO', 'PARURO', 'PILLPINTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081009', 'CUSCO', 'PARURO', 'YAURISQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081101', 'CUSCO', 'PAUCARTAMBO', 'PAUCARTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081102', 'CUSCO', 'PAUCARTAMBO', 'CAICAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('081103', 'CUSCO', 'PAUCARTAMBO', 'CHALLABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081104', 'CUSCO', 'PAUCARTAMBO', 'COLQUEPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081105', 'CUSCO', 'PAUCARTAMBO', 'HUANCARANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('081106', 'CUSCO', 'PAUCARTAMBO', 'KOSÑIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081201', 'CUSCO', 'QUISPICANCHI', 'URCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('081202', 'CUSCO', 'QUISPICANCHI', 'ANDAHUAYLILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('081203', 'CUSCO', 'QUISPICANCHI', 'CAMANTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('081204', 'CUSCO', 'QUISPICANCHI', 'CCARHUAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081205', 'CUSCO', 'QUISPICANCHI', 'CCATCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081206', 'CUSCO', 'QUISPICANCHI', 'CUSIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081207', 'CUSCO', 'QUISPICANCHI', 'HUARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081208', 'CUSCO', 'QUISPICANCHI', 'LUCRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081209', 'CUSCO', 'QUISPICANCHI', 'MARCAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081210', 'CUSCO', 'QUISPICANCHI', 'OCONGATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('081211', 'CUSCO', 'QUISPICANCHI', 'OROPESA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081212', 'CUSCO', 'QUISPICANCHI', 'QUIQUIJANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081301', 'CUSCO', 'URUBAMBA', 'URUBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081302', 'CUSCO', 'URUBAMBA', 'CHINCHERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081303', 'CUSCO', 'URUBAMBA', 'HUAYLLABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('081304', 'CUSCO', 'URUBAMBA', 'MACHUPICCHU');
INSERT INTO `tb_conf_ubigeo` VALUES ('081305', 'CUSCO', 'URUBAMBA', 'MARAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('081306', 'CUSCO', 'URUBAMBA', 'OLLANTAYTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('081307', 'CUSCO', 'URUBAMBA', 'YUCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('090101', 'HUANCAVELICA', 'HUANCAVELICA', 'HUANCAVELICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090102', 'HUANCAVELICA', 'HUANCAVELICA', 'ACOBAMBILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090103', 'HUANCAVELICA', 'HUANCAVELICA', 'ACORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090104', 'HUANCAVELICA', 'HUANCAVELICA', 'CONAYCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090105', 'HUANCAVELICA', 'HUANCAVELICA', 'CUENCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090106', 'HUANCAVELICA', 'HUANCAVELICA', 'HUACHOCOLPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090107', 'HUANCAVELICA', 'HUANCAVELICA', 'HUAYLLAHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090108', 'HUANCAVELICA', 'HUANCAVELICA', 'IZCUCHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090109', 'HUANCAVELICA', 'HUANCAVELICA', 'LARIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090110', 'HUANCAVELICA', 'HUANCAVELICA', 'MANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090111', 'HUANCAVELICA', 'HUANCAVELICA', 'MARISCAL CÁCERES');
INSERT INTO `tb_conf_ubigeo` VALUES ('090112', 'HUANCAVELICA', 'HUANCAVELICA', 'MOYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090113', 'HUANCAVELICA', 'HUANCAVELICA', 'NUEVO OCCORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090114', 'HUANCAVELICA', 'HUANCAVELICA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090115', 'HUANCAVELICA', 'HUANCAVELICA', 'PILCHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090116', 'HUANCAVELICA', 'HUANCAVELICA', 'VILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090117', 'HUANCAVELICA', 'HUANCAVELICA', 'YAULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090118', 'HUANCAVELICA', 'HUANCAVELICA', 'ASCENSIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('090119', 'HUANCAVELICA', 'HUANCAVELICA', 'HUANDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090201', 'HUANCAVELICA', 'ACOBAMBA', 'ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090202', 'HUANCAVELICA', 'ACOBAMBA', 'ANDABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090203', 'HUANCAVELICA', 'ACOBAMBA', 'ANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090204', 'HUANCAVELICA', 'ACOBAMBA', 'CAJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090205', 'HUANCAVELICA', 'ACOBAMBA', 'MARCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090206', 'HUANCAVELICA', 'ACOBAMBA', 'PAUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090207', 'HUANCAVELICA', 'ACOBAMBA', 'POMACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090208', 'HUANCAVELICA', 'ACOBAMBA', 'ROSARIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090301', 'HUANCAVELICA', 'ANGARAES', 'LIRCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('090302', 'HUANCAVELICA', 'ANGARAES', 'ANCHONGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090303', 'HUANCAVELICA', 'ANGARAES', 'CALLANMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090304', 'HUANCAVELICA', 'ANGARAES', 'CCOCHACCASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090305', 'HUANCAVELICA', 'ANGARAES', 'CHINCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090306', 'HUANCAVELICA', 'ANGARAES', 'CONGALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090307', 'HUANCAVELICA', 'ANGARAES', 'HUANCA-HUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090308', 'HUANCAVELICA', 'ANGARAES', 'HUAYLLAY GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('090309', 'HUANCAVELICA', 'ANGARAES', 'JULCAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090310', 'HUANCAVELICA', 'ANGARAES', 'SAN ANTONIO DE ANTAPARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090311', 'HUANCAVELICA', 'ANGARAES', 'SANTO TOMAS DE PATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090312', 'HUANCAVELICA', 'ANGARAES', 'SECCLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090401', 'HUANCAVELICA', 'CASTROVIRREYNA', 'CASTROVIRREYNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090402', 'HUANCAVELICA', 'CASTROVIRREYNA', 'ARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090403', 'HUANCAVELICA', 'CASTROVIRREYNA', 'AURAHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090404', 'HUANCAVELICA', 'CASTROVIRREYNA', 'CAPILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090405', 'HUANCAVELICA', 'CASTROVIRREYNA', 'CHUPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090406', 'HUANCAVELICA', 'CASTROVIRREYNA', 'COCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090407', 'HUANCAVELICA', 'CASTROVIRREYNA', 'HUACHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090408', 'HUANCAVELICA', 'CASTROVIRREYNA', 'HUAMATAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090409', 'HUANCAVELICA', 'CASTROVIRREYNA', 'MOLLEPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090410', 'HUANCAVELICA', 'CASTROVIRREYNA', 'SAN JUAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('090411', 'HUANCAVELICA', 'CASTROVIRREYNA', 'SANTA ANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090412', 'HUANCAVELICA', 'CASTROVIRREYNA', 'TANTARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090413', 'HUANCAVELICA', 'CASTROVIRREYNA', 'TICRAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090501', 'HUANCAVELICA', 'CHURCAMPA', 'CHURCAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090502', 'HUANCAVELICA', 'CHURCAMPA', 'ANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090503', 'HUANCAVELICA', 'CHURCAMPA', 'CHINCHIHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090504', 'HUANCAVELICA', 'CHURCAMPA', 'EL CARMEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('090505', 'HUANCAVELICA', 'CHURCAMPA', 'LA MERCED');
INSERT INTO `tb_conf_ubigeo` VALUES ('090506', 'HUANCAVELICA', 'CHURCAMPA', 'LOCROJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090507', 'HUANCAVELICA', 'CHURCAMPA', 'PAUCARBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090508', 'HUANCAVELICA', 'CHURCAMPA', 'SAN MIGUEL DE MAYOCC');
INSERT INTO `tb_conf_ubigeo` VALUES ('090509', 'HUANCAVELICA', 'CHURCAMPA', 'SAN PEDRO DE CORIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090510', 'HUANCAVELICA', 'CHURCAMPA', 'PACHAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090511', 'HUANCAVELICA', 'CHURCAMPA', 'COSME');
INSERT INTO `tb_conf_ubigeo` VALUES ('090601', 'HUANCAVELICA', 'HUAYTARÁ', 'HUAYTARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090602', 'HUANCAVELICA', 'HUAYTARÁ', 'AYAVI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090603', 'HUANCAVELICA', 'HUAYTARÁ', 'CÓRDOVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090604', 'HUANCAVELICA', 'HUAYTARÁ', 'HUAYACUNDO ARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090605', 'HUANCAVELICA', 'HUAYTARÁ', 'LARAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090606', 'HUANCAVELICA', 'HUAYTARÁ', 'OCOYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090607', 'HUANCAVELICA', 'HUAYTARÁ', 'PILPICHACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090608', 'HUANCAVELICA', 'HUAYTARÁ', 'QUERCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090609', 'HUANCAVELICA', 'HUAYTARÁ', 'QUITO-ARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090610', 'HUANCAVELICA', 'HUAYTARÁ', 'SAN ANTONIO DE CUSICANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090611', 'HUANCAVELICA', 'HUAYTARÁ', 'SAN FRANCISCO DE SANGAYAICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090612', 'HUANCAVELICA', 'HUAYTARÁ', 'SAN ISIDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090613', 'HUANCAVELICA', 'HUAYTARÁ', 'SANTIAGO DE CHOCORVOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090614', 'HUANCAVELICA', 'HUAYTARÁ', 'SANTIAGO DE QUIRAHUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090615', 'HUANCAVELICA', 'HUAYTARÁ', 'SANTO DOMINGO DE CAPILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090616', 'HUANCAVELICA', 'HUAYTARÁ', 'TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090701', 'HUANCAVELICA', 'TAYACAJA', 'PAMPAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090702', 'HUANCAVELICA', 'TAYACAJA', 'ACOSTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090703', 'HUANCAVELICA', 'TAYACAJA', 'ACRAQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090704', 'HUANCAVELICA', 'TAYACAJA', 'AHUAYCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090705', 'HUANCAVELICA', 'TAYACAJA', 'COLCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090706', 'HUANCAVELICA', 'TAYACAJA', 'DANIEL HERNÁNDEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('090707', 'HUANCAVELICA', 'TAYACAJA', 'HUACHOCOLPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090709', 'HUANCAVELICA', 'TAYACAJA', 'HUARIBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090710', 'HUANCAVELICA', 'TAYACAJA', 'ÑAHUIMPUQUIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('090711', 'HUANCAVELICA', 'TAYACAJA', 'PAZOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090713', 'HUANCAVELICA', 'TAYACAJA', 'QUISHUAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('090714', 'HUANCAVELICA', 'TAYACAJA', 'SALCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090715', 'HUANCAVELICA', 'TAYACAJA', 'SALCAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('090716', 'HUANCAVELICA', 'TAYACAJA', 'SAN MARCOS DE ROCCHAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('090717', 'HUANCAVELICA', 'TAYACAJA', 'SURCUBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090718', 'HUANCAVELICA', 'TAYACAJA', 'TINTAY PUNCU');
INSERT INTO `tb_conf_ubigeo` VALUES ('090719', 'HUANCAVELICA', 'TAYACAJA', 'QUICHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('090720', 'HUANCAVELICA', 'TAYACAJA', 'ANDAYMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('090721', 'HUANCAVELICA', 'TAYACAJA', 'ROBLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('090722', 'HUANCAVELICA', 'TAYACAJA', 'PICHOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100101', 'HUÁNUCO', 'HUÁNUCO', 'HUANUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100102', 'HUÁNUCO', 'HUÁNUCO', 'AMARILIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100103', 'HUÁNUCO', 'HUÁNUCO', 'CHINCHAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100104', 'HUÁNUCO', 'HUÁNUCO', 'CHURUBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100105', 'HUÁNUCO', 'HUÁNUCO', 'MARGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100106', 'HUÁNUCO', 'HUÁNUCO', 'QUISQUI (KICHKI)');
INSERT INTO `tb_conf_ubigeo` VALUES ('100107', 'HUÁNUCO', 'HUÁNUCO', 'SAN FRANCISCO DE CAYRAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100108', 'HUÁNUCO', 'HUÁNUCO', 'SAN PEDRO DE CHAULAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100109', 'HUÁNUCO', 'HUÁNUCO', 'SANTA MARÍA DEL VALLE');
INSERT INTO `tb_conf_ubigeo` VALUES ('100110', 'HUÁNUCO', 'HUÁNUCO', 'YARUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100111', 'HUÁNUCO', 'HUÁNUCO', 'PILLCO MARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100112', 'HUÁNUCO', 'HUÁNUCO', 'YACUS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100113', 'HUÁNUCO', 'HUÁNUCO', 'SAN PABLO DE PILLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100201', 'HUÁNUCO', 'AMBO', 'AMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100202', 'HUÁNUCO', 'AMBO', 'CAYNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100203', 'HUÁNUCO', 'AMBO', 'COLPAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100204', 'HUÁNUCO', 'AMBO', 'CONCHAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100205', 'HUÁNUCO', 'AMBO', 'HUACAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('100206', 'HUÁNUCO', 'AMBO', 'SAN FRANCISCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100207', 'HUÁNUCO', 'AMBO', 'SAN RAFAEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('100208', 'HUÁNUCO', 'AMBO', 'TOMAY KICHWA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100301', 'HUÁNUCO', 'DOS DE MAYO', 'LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100307', 'HUÁNUCO', 'DOS DE MAYO', 'CHUQUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100311', 'HUÁNUCO', 'DOS DE MAYO', 'MARÍAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100313', 'HUÁNUCO', 'DOS DE MAYO', 'PACHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100316', 'HUÁNUCO', 'DOS DE MAYO', 'QUIVILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100317', 'HUÁNUCO', 'DOS DE MAYO', 'RIPAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100321', 'HUÁNUCO', 'DOS DE MAYO', 'SHUNQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('100322', 'HUÁNUCO', 'DOS DE MAYO', 'SILLAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100323', 'HUÁNUCO', 'DOS DE MAYO', 'YANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100401', 'HUÁNUCO', 'HUACAYBAMBA', 'HUACAYBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100402', 'HUÁNUCO', 'HUACAYBAMBA', 'CANCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100403', 'HUÁNUCO', 'HUACAYBAMBA', 'COCHABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100404', 'HUÁNUCO', 'HUACAYBAMBA', 'PINRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100501', 'HUÁNUCO', 'HUAMALÍES', 'LLATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100502', 'HUÁNUCO', 'HUAMALÍES', 'ARANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('100503', 'HUÁNUCO', 'HUAMALÍES', 'CHAVÍN DE PARIARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100504', 'HUÁNUCO', 'HUAMALÍES', 'JACAS GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('100505', 'HUÁNUCO', 'HUAMALÍES', 'JIRCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100506', 'HUÁNUCO', 'HUAMALÍES', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('100507', 'HUÁNUCO', 'HUAMALÍES', 'MONZÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100508', 'HUÁNUCO', 'HUAMALÍES', 'PUNCHAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100509', 'HUÁNUCO', 'HUAMALÍES', 'PUÑOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('100510', 'HUÁNUCO', 'HUAMALÍES', 'SINGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100511', 'HUÁNUCO', 'HUAMALÍES', 'TANTAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100601', 'HUÁNUCO', 'LEONCIO PRADO', 'RUPA-RUPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100602', 'HUÁNUCO', 'LEONCIO PRADO', 'DANIEL ALOMÍA ROBLES');
INSERT INTO `tb_conf_ubigeo` VALUES ('100603', 'HUÁNUCO', 'LEONCIO PRADO', 'HERMÍLIO VALDIZAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100604', 'HUÁNUCO', 'LEONCIO PRADO', 'JOSÉ CRESPO Y CASTILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100605', 'HUÁNUCO', 'LEONCIO PRADO', 'LUYANDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100606', 'HUÁNUCO', 'LEONCIO PRADO', 'MARIANO DAMASO BERAUN');
INSERT INTO `tb_conf_ubigeo` VALUES ('100607', 'HUÁNUCO', 'LEONCIO PRADO', 'PUCAYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('100608', 'HUÁNUCO', 'LEONCIO PRADO', 'CASTILLO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('100701', 'HUÁNUCO', 'MARAÑÓN', 'HUACRACHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100702', 'HUÁNUCO', 'MARAÑÓN', 'CHOLON');
INSERT INTO `tb_conf_ubigeo` VALUES ('100703', 'HUÁNUCO', 'MARAÑÓN', 'SAN BUENAVENTURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100704', 'HUÁNUCO', 'MARAÑÓN', 'LA MORADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100705', 'HUÁNUCO', 'MARAÑÓN', 'SANTA ROSA DE ALTO YANAJANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100801', 'HUÁNUCO', 'PACHITEA', 'PANAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100802', 'HUÁNUCO', 'PACHITEA', 'CHAGLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100803', 'HUÁNUCO', 'PACHITEA', 'MOLINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100804', 'HUÁNUCO', 'PACHITEA', 'UMARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('100901', 'HUÁNUCO', 'PUERTO INCA', 'PUERTO INCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100902', 'HUÁNUCO', 'PUERTO INCA', 'CODO DEL POZUZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('100903', 'HUÁNUCO', 'PUERTO INCA', 'HONORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100904', 'HUÁNUCO', 'PUERTO INCA', 'TOURNAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('100905', 'HUÁNUCO', 'PUERTO INCA', 'YUYAPICHIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101001', 'HUÁNUCO', 'LAURICOCHA', 'JESÚS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101002', 'HUÁNUCO', 'LAURICOCHA', 'BAÑOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101003', 'HUÁNUCO', 'LAURICOCHA', 'JIVIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101004', 'HUÁNUCO', 'LAURICOCHA', 'QUEROPALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101005', 'HUÁNUCO', 'LAURICOCHA', 'RONDOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101006', 'HUÁNUCO', 'LAURICOCHA', 'SAN FRANCISCO DE ASÍS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101007', 'HUÁNUCO', 'LAURICOCHA', 'SAN MIGUEL DE CAURI');
INSERT INTO `tb_conf_ubigeo` VALUES ('101101', 'HUÁNUCO', 'YAROWILCA', 'CHAVINILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('101102', 'HUÁNUCO', 'YAROWILCA', 'CAHUAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('101103', 'HUÁNUCO', 'YAROWILCA', 'CHACABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101104', 'HUÁNUCO', 'YAROWILCA', 'APARICIO POMARES');
INSERT INTO `tb_conf_ubigeo` VALUES ('101105', 'HUÁNUCO', 'YAROWILCA', 'JACAS CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('101106', 'HUÁNUCO', 'YAROWILCA', 'OBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('101107', 'HUÁNUCO', 'YAROWILCA', 'PAMPAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('101108', 'HUÁNUCO', 'YAROWILCA', 'CHORAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110101', 'ICA', 'ICA', 'ICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110102', 'ICA', 'ICA', 'LA TINGUIÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110103', 'ICA', 'ICA', 'LOS AQUIJES');
INSERT INTO `tb_conf_ubigeo` VALUES ('110104', 'ICA', 'ICA', 'OCUCAJE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110105', 'ICA', 'ICA', 'PACHACUTEC');
INSERT INTO `tb_conf_ubigeo` VALUES ('110106', 'ICA', 'ICA', 'PARCONA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110107', 'ICA', 'ICA', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110108', 'ICA', 'ICA', 'SALAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110109', 'ICA', 'ICA', 'SAN JOSÉ DE LOS MOLINOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110110', 'ICA', 'ICA', 'SAN JUAN BAUTISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110111', 'ICA', 'ICA', 'SANTIAGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110112', 'ICA', 'ICA', 'SUBTANJALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110113', 'ICA', 'ICA', 'TATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110114', 'ICA', 'ICA', 'YAUCA DEL ROSARIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110201', 'ICA', 'CHINCHA', 'CHINCHA ALTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110202', 'ICA', 'CHINCHA', 'ALTO LARAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('110203', 'ICA', 'CHINCHA', 'CHAVIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('110204', 'ICA', 'CHINCHA', 'CHINCHA BAJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110205', 'ICA', 'CHINCHA', 'EL CARMEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('110206', 'ICA', 'CHINCHA', 'GROCIO PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110207', 'ICA', 'CHINCHA', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110208', 'ICA', 'CHINCHA', 'SAN JUAN DE YANAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('110209', 'ICA', 'CHINCHA', 'SAN PEDRO DE HUACARPANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110210', 'ICA', 'CHINCHA', 'SUNAMPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110211', 'ICA', 'CHINCHA', 'TAMBO DE MORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110301', 'ICA', 'NASCA', 'NASCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110302', 'ICA', 'NASCA', 'CHANGUILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110303', 'ICA', 'NASCA', 'EL INGENIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110304', 'ICA', 'NASCA', 'MARCONA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110305', 'ICA', 'NASCA', 'VISTA ALEGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110401', 'ICA', 'PALPA', 'PALPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110402', 'ICA', 'PALPA', 'LLIPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110403', 'ICA', 'PALPA', 'RÍO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110404', 'ICA', 'PALPA', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('110405', 'ICA', 'PALPA', 'TIBILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110501', 'ICA', 'PISCO', 'PISCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110502', 'ICA', 'PISCO', 'HUANCANO');
INSERT INTO `tb_conf_ubigeo` VALUES ('110503', 'ICA', 'PISCO', 'HUMAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('110504', 'ICA', 'PISCO', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('110505', 'ICA', 'PISCO', 'PARACAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110506', 'ICA', 'PISCO', 'SAN ANDRÉS');
INSERT INTO `tb_conf_ubigeo` VALUES ('110507', 'ICA', 'PISCO', 'SAN CLEMENTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('110508', 'ICA', 'PISCO', 'TUPAC AMARU INCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120101', 'JUNÍN', 'HUANCAYO', 'HUANCAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120104', 'JUNÍN', 'HUANCAYO', 'CARHUACALLANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120105', 'JUNÍN', 'HUANCAYO', 'CHACAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120106', 'JUNÍN', 'HUANCAYO', 'CHICCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120107', 'JUNÍN', 'HUANCAYO', 'CHILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120108', 'JUNÍN', 'HUANCAYO', 'CHONGOS ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120111', 'JUNÍN', 'HUANCAYO', 'CHUPURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120112', 'JUNÍN', 'HUANCAYO', 'COLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120113', 'JUNÍN', 'HUANCAYO', 'CULLHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120114', 'JUNÍN', 'HUANCAYO', 'EL TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120116', 'JUNÍN', 'HUANCAYO', 'HUACRAPUQUIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120117', 'JUNÍN', 'HUANCAYO', 'HUALHUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120119', 'JUNÍN', 'HUANCAYO', 'HUANCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120120', 'JUNÍN', 'HUANCAYO', 'HUASICANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120121', 'JUNÍN', 'HUANCAYO', 'HUAYUCACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120122', 'JUNÍN', 'HUANCAYO', 'INGENIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120124', 'JUNÍN', 'HUANCAYO', 'PARIAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120125', 'JUNÍN', 'HUANCAYO', 'PILCOMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120126', 'JUNÍN', 'HUANCAYO', 'PUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120127', 'JUNÍN', 'HUANCAYO', 'QUICHUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('120128', 'JUNÍN', 'HUANCAYO', 'QUILCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120129', 'JUNÍN', 'HUANCAYO', 'SAN AGUSTÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120130', 'JUNÍN', 'HUANCAYO', 'SAN JERÓNIMO DE TUNAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120132', 'JUNÍN', 'HUANCAYO', 'SAÑO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120133', 'JUNÍN', 'HUANCAYO', 'SAPALLANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120134', 'JUNÍN', 'HUANCAYO', 'SICAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120135', 'JUNÍN', 'HUANCAYO', 'SANTO DOMINGO DE ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120136', 'JUNÍN', 'HUANCAYO', 'VIQUES');
INSERT INTO `tb_conf_ubigeo` VALUES ('120201', 'JUNÍN', 'CONCEPCIÓN', 'CONCEPCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120202', 'JUNÍN', 'CONCEPCIÓN', 'ACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120203', 'JUNÍN', 'CONCEPCIÓN', 'ANDAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120204', 'JUNÍN', 'CONCEPCIÓN', 'CHAMBARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120205', 'JUNÍN', 'CONCEPCIÓN', 'COCHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120206', 'JUNÍN', 'CONCEPCIÓN', 'COMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120207', 'JUNÍN', 'CONCEPCIÓN', 'HEROÍNAS TOLEDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120208', 'JUNÍN', 'CONCEPCIÓN', 'MANZANARES');
INSERT INTO `tb_conf_ubigeo` VALUES ('120209', 'JUNÍN', 'CONCEPCIÓN', 'MARISCAL CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120210', 'JUNÍN', 'CONCEPCIÓN', 'MATAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120211', 'JUNÍN', 'CONCEPCIÓN', 'MITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120212', 'JUNÍN', 'CONCEPCIÓN', 'NUEVE DE JULIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120213', 'JUNÍN', 'CONCEPCIÓN', 'ORCOTUNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120214', 'JUNÍN', 'CONCEPCIÓN', 'SAN JOSÉ DE QUERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120215', 'JUNÍN', 'CONCEPCIÓN', 'SANTA ROSA DE OCOPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120301', 'JUNÍN', 'CHANCHAMAYO', 'CHANCHAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120302', 'JUNÍN', 'CHANCHAMAYO', 'PERENE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120303', 'JUNÍN', 'CHANCHAMAYO', 'PICHANAQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120304', 'JUNÍN', 'CHANCHAMAYO', 'SAN LUIS DE SHUARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120305', 'JUNÍN', 'CHANCHAMAYO', 'SAN RAMÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120306', 'JUNÍN', 'CHANCHAMAYO', 'VITOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('120401', 'JUNÍN', 'JAUJA', 'JAUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120402', 'JUNÍN', 'JAUJA', 'ACOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120403', 'JUNÍN', 'JAUJA', 'APATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120404', 'JUNÍN', 'JAUJA', 'ATAURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120405', 'JUNÍN', 'JAUJA', 'CANCHAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120406', 'JUNÍN', 'JAUJA', 'CURICACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120407', 'JUNÍN', 'JAUJA', 'EL MANTARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120408', 'JUNÍN', 'JAUJA', 'HUAMALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120409', 'JUNÍN', 'JAUJA', 'HUARIPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120410', 'JUNÍN', 'JAUJA', 'HUERTAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120411', 'JUNÍN', 'JAUJA', 'JANJAILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120412', 'JUNÍN', 'JAUJA', 'JULCÁN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120413', 'JUNÍN', 'JAUJA', 'LEONOR ORDÓÑEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('120414', 'JUNÍN', 'JAUJA', 'LLOCLLAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120415', 'JUNÍN', 'JAUJA', 'MARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120416', 'JUNÍN', 'JAUJA', 'MASMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120417', 'JUNÍN', 'JAUJA', 'MASMA CHICCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120418', 'JUNÍN', 'JAUJA', 'MOLINOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120419', 'JUNÍN', 'JAUJA', 'MONOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120420', 'JUNÍN', 'JAUJA', 'MUQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120421', 'JUNÍN', 'JAUJA', 'MUQUIYAUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120422', 'JUNÍN', 'JAUJA', 'PACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120423', 'JUNÍN', 'JAUJA', 'PACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120424', 'JUNÍN', 'JAUJA', 'PANCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120425', 'JUNÍN', 'JAUJA', 'PARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120426', 'JUNÍN', 'JAUJA', 'POMACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120427', 'JUNÍN', 'JAUJA', 'RICRAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120428', 'JUNÍN', 'JAUJA', 'SAN LORENZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120429', 'JUNÍN', 'JAUJA', 'SAN PEDRO DE CHUNAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120430', 'JUNÍN', 'JAUJA', 'SAUSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120431', 'JUNÍN', 'JAUJA', 'SINCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120432', 'JUNÍN', 'JAUJA', 'TUNAN MARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120433', 'JUNÍN', 'JAUJA', 'YAULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120434', 'JUNÍN', 'JAUJA', 'YAUYOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120501', 'JUNÍN', 'JUNÍN', 'JUNIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120502', 'JUNÍN', 'JUNÍN', 'CARHUAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120503', 'JUNÍN', 'JUNÍN', 'ONDORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('120504', 'JUNÍN', 'JUNÍN', 'ULCUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120601', 'JUNÍN', 'SATIPO', 'SATIPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120602', 'JUNÍN', 'SATIPO', 'COVIRIALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120603', 'JUNÍN', 'SATIPO', 'LLAYLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120604', 'JUNÍN', 'SATIPO', 'MAZAMARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120605', 'JUNÍN', 'SATIPO', 'PAMPA HERMOSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120606', 'JUNÍN', 'SATIPO', 'PANGOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120607', 'JUNÍN', 'SATIPO', 'RÍO NEGRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120608', 'JUNÍN', 'SATIPO', 'RÍO TAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120609', 'JUNÍN', 'SATIPO', 'VIZCATAN DEL ENE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120701', 'JUNÍN', 'TARMA', 'TARMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120702', 'JUNÍN', 'TARMA', 'ACOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120703', 'JUNÍN', 'TARMA', 'HUARICOLCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120704', 'JUNÍN', 'TARMA', 'HUASAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120705', 'JUNÍN', 'TARMA', 'LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120706', 'JUNÍN', 'TARMA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120707', 'JUNÍN', 'TARMA', 'PALCAMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120708', 'JUNÍN', 'TARMA', 'SAN PEDRO DE CAJAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120709', 'JUNÍN', 'TARMA', 'TAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120801', 'JUNÍN', 'YAULI', 'LA OROYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120802', 'JUNÍN', 'YAULI', 'CHACAPALPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120803', 'JUNÍN', 'YAULI', 'HUAY-HUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('120804', 'JUNÍN', 'YAULI', 'MARCAPOMACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120805', 'JUNÍN', 'YAULI', 'MOROCOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120806', 'JUNÍN', 'YAULI', 'PACCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120807', 'JUNÍN', 'YAULI', 'SANTA BÁRBARA DE CARHUACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('120808', 'JUNÍN', 'YAULI', 'SANTA ROSA DE SACCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120809', 'JUNÍN', 'YAULI', 'SUITUCANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120810', 'JUNÍN', 'YAULI', 'YAULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('120901', 'JUNÍN', 'CHUPACA', 'CHUPACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120902', 'JUNÍN', 'CHUPACA', 'AHUAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('120903', 'JUNÍN', 'CHUPACA', 'CHONGOS BAJO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120904', 'JUNÍN', 'CHUPACA', 'HUACHAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('120905', 'JUNÍN', 'CHUPACA', 'HUAMANCACA CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('120906', 'JUNÍN', 'CHUPACA', 'SAN JUAN DE ISCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('120907', 'JUNÍN', 'CHUPACA', 'SAN JUAN DE JARPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('120908', 'JUNÍN', 'CHUPACA', 'TRES DE DICIEMBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('120909', 'JUNÍN', 'CHUPACA', 'YANACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130101', 'LA LIBERTAD', 'TRUJILLO', 'TRUJILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130102', 'LA LIBERTAD', 'TRUJILLO', 'EL PORVENIR');
INSERT INTO `tb_conf_ubigeo` VALUES ('130103', 'LA LIBERTAD', 'TRUJILLO', 'FLORENCIA DE MORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130104', 'LA LIBERTAD', 'TRUJILLO', 'HUANCHACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130105', 'LA LIBERTAD', 'TRUJILLO', 'LA ESPERANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130106', 'LA LIBERTAD', 'TRUJILLO', 'LAREDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130107', 'LA LIBERTAD', 'TRUJILLO', 'MOCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130108', 'LA LIBERTAD', 'TRUJILLO', 'POROTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130109', 'LA LIBERTAD', 'TRUJILLO', 'SALAVERRY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130110', 'LA LIBERTAD', 'TRUJILLO', 'SIMBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130111', 'LA LIBERTAD', 'TRUJILLO', 'VICTOR LARCO HERRERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130201', 'LA LIBERTAD', 'ASCOPE', 'ASCOPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130202', 'LA LIBERTAD', 'ASCOPE', 'CHICAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130203', 'LA LIBERTAD', 'ASCOPE', 'CHOCOPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130204', 'LA LIBERTAD', 'ASCOPE', 'MAGDALENA DE CAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130205', 'LA LIBERTAD', 'ASCOPE', 'PAIJAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130206', 'LA LIBERTAD', 'ASCOPE', 'RÁZURI');
INSERT INTO `tb_conf_ubigeo` VALUES ('130207', 'LA LIBERTAD', 'ASCOPE', 'SANTIAGO DE CAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130208', 'LA LIBERTAD', 'ASCOPE', 'CASA GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130301', 'LA LIBERTAD', 'BOLÍVAR', 'BOLÍVAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('130302', 'LA LIBERTAD', 'BOLÍVAR', 'BAMBAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130303', 'LA LIBERTAD', 'BOLÍVAR', 'CONDORMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130304', 'LA LIBERTAD', 'BOLÍVAR', 'LONGOTEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130305', 'LA LIBERTAD', 'BOLÍVAR', 'UCHUMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130306', 'LA LIBERTAD', 'BOLÍVAR', 'UCUNCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130401', 'LA LIBERTAD', 'CHEPÉN', 'CHEPEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130402', 'LA LIBERTAD', 'CHEPÉN', 'PACANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130403', 'LA LIBERTAD', 'CHEPÉN', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130501', 'LA LIBERTAD', 'JULCÁN', 'JULCAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130502', 'LA LIBERTAD', 'JULCÁN', 'CALAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130503', 'LA LIBERTAD', 'JULCÁN', 'CARABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130504', 'LA LIBERTAD', 'JULCÁN', 'HUASO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130601', 'LA LIBERTAD', 'OTUZCO', 'OTUZCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130602', 'LA LIBERTAD', 'OTUZCO', 'AGALLPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130604', 'LA LIBERTAD', 'OTUZCO', 'CHARAT');
INSERT INTO `tb_conf_ubigeo` VALUES ('130605', 'LA LIBERTAD', 'OTUZCO', 'HUARANCHAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130606', 'LA LIBERTAD', 'OTUZCO', 'LA CUESTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130608', 'LA LIBERTAD', 'OTUZCO', 'MACHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130610', 'LA LIBERTAD', 'OTUZCO', 'PARANDAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130611', 'LA LIBERTAD', 'OTUZCO', 'SALPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130613', 'LA LIBERTAD', 'OTUZCO', 'SINSICAP');
INSERT INTO `tb_conf_ubigeo` VALUES ('130614', 'LA LIBERTAD', 'OTUZCO', 'USQUIL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130701', 'LA LIBERTAD', 'PACASMAYO', 'SAN PEDRO DE LLOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('130702', 'LA LIBERTAD', 'PACASMAYO', 'GUADALUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130703', 'LA LIBERTAD', 'PACASMAYO', 'JEQUETEPEQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('130704', 'LA LIBERTAD', 'PACASMAYO', 'PACASMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130705', 'LA LIBERTAD', 'PACASMAYO', 'SAN JOSÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('130801', 'LA LIBERTAD', 'PATAZ', 'TAYABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130802', 'LA LIBERTAD', 'PATAZ', 'BULDIBUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130803', 'LA LIBERTAD', 'PATAZ', 'CHILLIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130804', 'LA LIBERTAD', 'PATAZ', 'HUANCASPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130805', 'LA LIBERTAD', 'PATAZ', 'HUAYLILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130806', 'LA LIBERTAD', 'PATAZ', 'HUAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130807', 'LA LIBERTAD', 'PATAZ', 'ONGON');
INSERT INTO `tb_conf_ubigeo` VALUES ('130808', 'LA LIBERTAD', 'PATAZ', 'PARCOY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130809', 'LA LIBERTAD', 'PATAZ', 'PATAZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('130810', 'LA LIBERTAD', 'PATAZ', 'PIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130811', 'LA LIBERTAD', 'PATAZ', 'SANTIAGO DE CHALLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130812', 'LA LIBERTAD', 'PATAZ', 'TAURIJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('130813', 'LA LIBERTAD', 'PATAZ', 'URPAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130901', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'HUAMACHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130902', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'CHUGAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('130903', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'COCHORCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('130904', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'CURGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('130905', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'MARCABAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('130906', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'SANAGORAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130907', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'SARIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('130908', 'LA LIBERTAD', 'SÁNCHEZ CARRIÓN', 'SARTIMBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131001', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'SANTIAGO DE CHUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('131002', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'ANGASMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131003', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'CACHICADAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('131004', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'MOLLEBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131005', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'MOLLEPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131006', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'QUIRUVILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131007', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'SANTA CRUZ DE CHUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131008', 'LA LIBERTAD', 'SANTIAGO DE CHUCO', 'SITABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131101', 'LA LIBERTAD', 'GRAN CHIMÚ', 'CASCAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('131102', 'LA LIBERTAD', 'GRAN CHIMÚ', 'LUCMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('131103', 'LA LIBERTAD', 'GRAN CHIMÚ', 'MARMOT');
INSERT INTO `tb_conf_ubigeo` VALUES ('131104', 'LA LIBERTAD', 'GRAN CHIMÚ', 'SAYAPULLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('131201', 'LA LIBERTAD', 'VIRÚ', 'VIRU');
INSERT INTO `tb_conf_ubigeo` VALUES ('131202', 'LA LIBERTAD', 'VIRÚ', 'CHAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('131203', 'LA LIBERTAD', 'VIRÚ', 'GUADALUPITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140101', 'LAMBAYEQUE', 'CHICLAYO', 'CHICLAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140102', 'LAMBAYEQUE', 'CHICLAYO', 'CHONGOYAPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140103', 'LAMBAYEQUE', 'CHICLAYO', 'ETEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('140104', 'LAMBAYEQUE', 'CHICLAYO', 'ETEN PUERTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140105', 'LAMBAYEQUE', 'CHICLAYO', 'JOSÉ LEONARDO ORTIZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('140106', 'LAMBAYEQUE', 'CHICLAYO', 'LA VICTORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140107', 'LAMBAYEQUE', 'CHICLAYO', 'LAGUNAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140108', 'LAMBAYEQUE', 'CHICLAYO', 'MONSEFU');
INSERT INTO `tb_conf_ubigeo` VALUES ('140109', 'LAMBAYEQUE', 'CHICLAYO', 'NUEVA ARICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140110', 'LAMBAYEQUE', 'CHICLAYO', 'OYOTUN');
INSERT INTO `tb_conf_ubigeo` VALUES ('140111', 'LAMBAYEQUE', 'CHICLAYO', 'PICSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140112', 'LAMBAYEQUE', 'CHICLAYO', 'PIMENTEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('140113', 'LAMBAYEQUE', 'CHICLAYO', 'REQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140114', 'LAMBAYEQUE', 'CHICLAYO', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140115', 'LAMBAYEQUE', 'CHICLAYO', 'SAÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140116', 'LAMBAYEQUE', 'CHICLAYO', 'CAYALTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140117', 'LAMBAYEQUE', 'CHICLAYO', 'PATAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140118', 'LAMBAYEQUE', 'CHICLAYO', 'POMALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140119', 'LAMBAYEQUE', 'CHICLAYO', 'PUCALA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140120', 'LAMBAYEQUE', 'CHICLAYO', 'TUMAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('140201', 'LAMBAYEQUE', 'FERREÑAFE', 'FERREÑAFE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140202', 'LAMBAYEQUE', 'FERREÑAFE', 'CAÑARIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140203', 'LAMBAYEQUE', 'FERREÑAFE', 'INCAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140204', 'LAMBAYEQUE', 'FERREÑAFE', 'MANUEL ANTONIO MESONES MURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140205', 'LAMBAYEQUE', 'FERREÑAFE', 'PITIPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140206', 'LAMBAYEQUE', 'FERREÑAFE', 'PUEBLO NUEVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140301', 'LAMBAYEQUE', 'LAMBAYEQUE', 'LAMBAYEQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140302', 'LAMBAYEQUE', 'LAMBAYEQUE', 'CHOCHOPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140303', 'LAMBAYEQUE', 'LAMBAYEQUE', 'ILLIMO');
INSERT INTO `tb_conf_ubigeo` VALUES ('140304', 'LAMBAYEQUE', 'LAMBAYEQUE', 'JAYANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140305', 'LAMBAYEQUE', 'LAMBAYEQUE', 'MOCHUMI');
INSERT INTO `tb_conf_ubigeo` VALUES ('140306', 'LAMBAYEQUE', 'LAMBAYEQUE', 'MORROPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140307', 'LAMBAYEQUE', 'LAMBAYEQUE', 'MOTUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('140308', 'LAMBAYEQUE', 'LAMBAYEQUE', 'OLMOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140309', 'LAMBAYEQUE', 'LAMBAYEQUE', 'PACORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('140310', 'LAMBAYEQUE', 'LAMBAYEQUE', 'SALAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('140311', 'LAMBAYEQUE', 'LAMBAYEQUE', 'SAN JOSÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('140312', 'LAMBAYEQUE', 'LAMBAYEQUE', 'TUCUME');
INSERT INTO `tb_conf_ubigeo` VALUES ('150101', 'LIMA', 'LIMA', 'LIMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150102', 'LIMA', 'LIMA', 'ANCÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150103', 'LIMA', 'LIMA', 'ATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150104', 'LIMA', 'LIMA', 'BARRANCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150105', 'LIMA', 'LIMA', 'BREÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150106', 'LIMA', 'LIMA', 'CARABAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150107', 'LIMA', 'LIMA', 'CHACLACAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150108', 'LIMA', 'LIMA', 'CHORRILLOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150109', 'LIMA', 'LIMA', 'CIENEGUILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150110', 'LIMA', 'LIMA', 'COMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150111', 'LIMA', 'LIMA', 'EL AGUSTINO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150112', 'LIMA', 'LIMA', 'INDEPENDENCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150113', 'LIMA', 'LIMA', 'JESÚS MARÍA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150114', 'LIMA', 'LIMA', 'LA MOLINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150115', 'LIMA', 'LIMA', 'LA VICTORIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150116', 'LIMA', 'LIMA', 'LINCE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150117', 'LIMA', 'LIMA', 'LOS OLIVOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150118', 'LIMA', 'LIMA', 'LURIGANCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150119', 'LIMA', 'LIMA', 'LURIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150120', 'LIMA', 'LIMA', 'MAGDALENA DEL MAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150121', 'LIMA', 'LIMA', 'PUEBLO LIBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150122', 'LIMA', 'LIMA', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150123', 'LIMA', 'LIMA', 'PACHACAMAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('150124', 'LIMA', 'LIMA', 'PUCUSANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150125', 'LIMA', 'LIMA', 'PUENTE PIEDRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150126', 'LIMA', 'LIMA', 'PUNTA HERMOSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150127', 'LIMA', 'LIMA', 'PUNTA NEGRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150128', 'LIMA', 'LIMA', 'RÍMAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('150129', 'LIMA', 'LIMA', 'SAN BARTOLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150130', 'LIMA', 'LIMA', 'SAN BORJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150131', 'LIMA', 'LIMA', 'SAN ISIDRO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150132', 'LIMA', 'LIMA', 'SAN JUAN DE LURIGANCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150133', 'LIMA', 'LIMA', 'SAN JUAN DE MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150134', 'LIMA', 'LIMA', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150135', 'LIMA', 'LIMA', 'SAN MARTÍN DE PORRES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150136', 'LIMA', 'LIMA', 'SAN MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150137', 'LIMA', 'LIMA', 'SANTA ANITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150138', 'LIMA', 'LIMA', 'SANTA MARÍA DEL MAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150139', 'LIMA', 'LIMA', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150140', 'LIMA', 'LIMA', 'SANTIAGO DE SURCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150141', 'LIMA', 'LIMA', 'SURQUILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150142', 'LIMA', 'LIMA', 'VILLA EL SALVADOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150143', 'LIMA', 'LIMA', 'VILLA MARÍA DEL TRIUNFO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150201', 'LIMA', 'BARRANCA', 'BARRANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150202', 'LIMA', 'BARRANCA', 'PARAMONGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150203', 'LIMA', 'BARRANCA', 'PATIVILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150204', 'LIMA', 'BARRANCA', 'SUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150205', 'LIMA', 'BARRANCA', 'SUPE PUERTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150301', 'LIMA', 'CAJATAMBO', 'CAJATAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150302', 'LIMA', 'CAJATAMBO', 'COPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150303', 'LIMA', 'CAJATAMBO', 'GORGOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150304', 'LIMA', 'CAJATAMBO', 'HUANCAPON');
INSERT INTO `tb_conf_ubigeo` VALUES ('150305', 'LIMA', 'CAJATAMBO', 'MANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150401', 'LIMA', 'CANTA', 'CANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150402', 'LIMA', 'CANTA', 'ARAHUAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('150403', 'LIMA', 'CANTA', 'HUAMANTANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150404', 'LIMA', 'CANTA', 'HUAROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150405', 'LIMA', 'CANTA', 'LACHAQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150406', 'LIMA', 'CANTA', 'SAN BUENAVENTURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150407', 'LIMA', 'CANTA', 'SANTA ROSA DE QUIVES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150501', 'LIMA', 'CAÑETE', 'SAN VICENTE DE CAÑETE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150502', 'LIMA', 'CAÑETE', 'ASIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150503', 'LIMA', 'CAÑETE', 'CALANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150504', 'LIMA', 'CAÑETE', 'CERRO AZUL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150505', 'LIMA', 'CAÑETE', 'CHILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150506', 'LIMA', 'CAÑETE', 'COAYLLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150507', 'LIMA', 'CAÑETE', 'IMPERIAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150508', 'LIMA', 'CAÑETE', 'LUNAHUANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150509', 'LIMA', 'CAÑETE', 'MALA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150510', 'LIMA', 'CAÑETE', 'NUEVO IMPERIAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150511', 'LIMA', 'CAÑETE', 'PACARAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150512', 'LIMA', 'CAÑETE', 'QUILMANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150513', 'LIMA', 'CAÑETE', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150514', 'LIMA', 'CAÑETE', 'SAN LUIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150515', 'LIMA', 'CAÑETE', 'SANTA CRUZ DE FLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150516', 'LIMA', 'CAÑETE', 'ZÚÑIGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150601', 'LIMA', 'HUARAL', 'HUARAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150602', 'LIMA', 'HUARAL', 'ATAVILLOS ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150603', 'LIMA', 'HUARAL', 'ATAVILLOS BAJO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150604', 'LIMA', 'HUARAL', 'AUCALLAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150605', 'LIMA', 'HUARAL', 'CHANCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('150606', 'LIMA', 'HUARAL', 'IHUARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150607', 'LIMA', 'HUARAL', 'LAMPIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150608', 'LIMA', 'HUARAL', 'PACARAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150609', 'LIMA', 'HUARAL', 'SAN MIGUEL DE ACOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150610', 'LIMA', 'HUARAL', 'SANTA CRUZ DE ANDAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150611', 'LIMA', 'HUARAL', 'SUMBILCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150612', 'LIMA', 'HUARAL', 'VEINTISIETE DE NOVIEMBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150701', 'LIMA', 'HUAROCHIRÍ', 'MATUCANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150702', 'LIMA', 'HUAROCHIRÍ', 'ANTIOQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150703', 'LIMA', 'HUAROCHIRÍ', 'CALLAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150704', 'LIMA', 'HUAROCHIRÍ', 'CARAMPOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150705', 'LIMA', 'HUAROCHIRÍ', 'CHICLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150706', 'LIMA', 'HUAROCHIRÍ', 'CUENCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150707', 'LIMA', 'HUAROCHIRÍ', 'HUACHUPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150708', 'LIMA', 'HUAROCHIRÍ', 'HUANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150709', 'LIMA', 'HUAROCHIRÍ', 'HUAROCHIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150710', 'LIMA', 'HUAROCHIRÍ', 'LAHUAYTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150711', 'LIMA', 'HUAROCHIRÍ', 'LANGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150712', 'LIMA', 'HUAROCHIRÍ', 'LARAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150713', 'LIMA', 'HUAROCHIRÍ', 'MARIATANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150714', 'LIMA', 'HUAROCHIRÍ', 'RICARDO PALMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150715', 'LIMA', 'HUAROCHIRÍ', 'SAN ANDRÉS DE TUPICOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150716', 'LIMA', 'HUAROCHIRÍ', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150717', 'LIMA', 'HUAROCHIRÍ', 'SAN BARTOLOMÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('150718', 'LIMA', 'HUAROCHIRÍ', 'SAN DAMIAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150719', 'LIMA', 'HUAROCHIRÍ', 'SAN JUAN DE IRIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150720', 'LIMA', 'HUAROCHIRÍ', 'SAN JUAN DE TANTARANCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150721', 'LIMA', 'HUAROCHIRÍ', 'SAN LORENZO DE QUINTI');
INSERT INTO `tb_conf_ubigeo` VALUES ('150722', 'LIMA', 'HUAROCHIRÍ', 'SAN MATEO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150723', 'LIMA', 'HUAROCHIRÍ', 'SAN MATEO DE OTAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150724', 'LIMA', 'HUAROCHIRÍ', 'SAN PEDRO DE CASTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150725', 'LIMA', 'HUAROCHIRÍ', 'SAN PEDRO DE HUANCAYRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('150726', 'LIMA', 'HUAROCHIRÍ', 'SANGALLAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150727', 'LIMA', 'HUAROCHIRÍ', 'SANTA CRUZ DE COCACHACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150728', 'LIMA', 'HUAROCHIRÍ', 'SANTA EULALIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150729', 'LIMA', 'HUAROCHIRÍ', 'SANTIAGO DE ANCHUCAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150730', 'LIMA', 'HUAROCHIRÍ', 'SANTIAGO DE TUNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150731', 'LIMA', 'HUAROCHIRÍ', 'SANTO DOMINGO DE LOS OLLEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150732', 'LIMA', 'HUAROCHIRÍ', 'SURCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150801', 'LIMA', 'HUAURA', 'HUACHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150802', 'LIMA', 'HUAURA', 'AMBAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150803', 'LIMA', 'HUAURA', 'CALETA DE CARQUIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150804', 'LIMA', 'HUAURA', 'CHECRAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('150805', 'LIMA', 'HUAURA', 'HUALMAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('150806', 'LIMA', 'HUAURA', 'HUAURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150807', 'LIMA', 'HUAURA', 'LEONCIO PRADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150808', 'LIMA', 'HUAURA', 'PACCHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('150809', 'LIMA', 'HUAURA', 'SANTA LEONOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('150810', 'LIMA', 'HUAURA', 'SANTA MARÍA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150811', 'LIMA', 'HUAURA', 'SAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150812', 'LIMA', 'HUAURA', 'VEGUETA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150901', 'LIMA', 'OYÓN', 'OYON');
INSERT INTO `tb_conf_ubigeo` VALUES ('150902', 'LIMA', 'OYÓN', 'ANDAJES');
INSERT INTO `tb_conf_ubigeo` VALUES ('150903', 'LIMA', 'OYÓN', 'CAUJUL');
INSERT INTO `tb_conf_ubigeo` VALUES ('150904', 'LIMA', 'OYÓN', 'COCHAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('150905', 'LIMA', 'OYÓN', 'NAVAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('150906', 'LIMA', 'OYÓN', 'PACHANGARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151001', 'LIMA', 'YAUYOS', 'YAUYOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151002', 'LIMA', 'YAUYOS', 'ALIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151003', 'LIMA', 'YAUYOS', 'ALLAUCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151004', 'LIMA', 'YAUYOS', 'AYAVIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('151005', 'LIMA', 'YAUYOS', 'AZÁNGARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('151006', 'LIMA', 'YAUYOS', 'CACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151007', 'LIMA', 'YAUYOS', 'CARANIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151008', 'LIMA', 'YAUYOS', 'CATAHUASI');
INSERT INTO `tb_conf_ubigeo` VALUES ('151009', 'LIMA', 'YAUYOS', 'CHOCOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151010', 'LIMA', 'YAUYOS', 'COCHAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151011', 'LIMA', 'YAUYOS', 'COLONIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151012', 'LIMA', 'YAUYOS', 'HONGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151013', 'LIMA', 'YAUYOS', 'HUAMPARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151014', 'LIMA', 'YAUYOS', 'HUANCAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151015', 'LIMA', 'YAUYOS', 'HUANGASCAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('151016', 'LIMA', 'YAUYOS', 'HUANTAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('151017', 'LIMA', 'YAUYOS', 'HUAÑEC');
INSERT INTO `tb_conf_ubigeo` VALUES ('151018', 'LIMA', 'YAUYOS', 'LARAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151019', 'LIMA', 'YAUYOS', 'LINCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151020', 'LIMA', 'YAUYOS', 'MADEAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('151021', 'LIMA', 'YAUYOS', 'MIRAFLORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('151022', 'LIMA', 'YAUYOS', 'OMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151023', 'LIMA', 'YAUYOS', 'PUTINZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151024', 'LIMA', 'YAUYOS', 'QUINCHES');
INSERT INTO `tb_conf_ubigeo` VALUES ('151025', 'LIMA', 'YAUYOS', 'QUINOCAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('151026', 'LIMA', 'YAUYOS', 'SAN JOAQUÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('151027', 'LIMA', 'YAUYOS', 'SAN PEDRO DE PILAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151028', 'LIMA', 'YAUYOS', 'TANTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151029', 'LIMA', 'YAUYOS', 'TAURIPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('151030', 'LIMA', 'YAUYOS', 'TOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('151031', 'LIMA', 'YAUYOS', 'TUPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('151032', 'LIMA', 'YAUYOS', 'VIÑAC');
INSERT INTO `tb_conf_ubigeo` VALUES ('151033', 'LIMA', 'YAUYOS', 'VITIS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160101', 'LORETO', 'MAYNAS', 'IQUITOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160102', 'LORETO', 'MAYNAS', 'ALTO NANAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('160103', 'LORETO', 'MAYNAS', 'FERNANDO LORES');
INSERT INTO `tb_conf_ubigeo` VALUES ('160104', 'LORETO', 'MAYNAS', 'INDIANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160105', 'LORETO', 'MAYNAS', 'LAS AMAZONAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160106', 'LORETO', 'MAYNAS', 'MAZAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160107', 'LORETO', 'MAYNAS', 'NAPO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160108', 'LORETO', 'MAYNAS', 'PUNCHANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160110', 'LORETO', 'MAYNAS', 'TORRES CAUSANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160112', 'LORETO', 'MAYNAS', 'BELÉN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160113', 'LORETO', 'MAYNAS', 'SAN JUAN BAUTISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160201', 'LORETO', 'ALTO AMAZONAS', 'YURIMAGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160202', 'LORETO', 'ALTO AMAZONAS', 'BALSAPUERTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160205', 'LORETO', 'ALTO AMAZONAS', 'JEBEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160206', 'LORETO', 'ALTO AMAZONAS', 'LAGUNAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160210', 'LORETO', 'ALTO AMAZONAS', 'SANTA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('160211', 'LORETO', 'ALTO AMAZONAS', 'TENIENTE CESAR LÓPEZ ROJAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160301', 'LORETO', 'LORETO', 'NAUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160302', 'LORETO', 'LORETO', 'PARINARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('160303', 'LORETO', 'LORETO', 'TIGRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160304', 'LORETO', 'LORETO', 'TROMPETEROS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160305', 'LORETO', 'LORETO', 'URARINAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160401', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'RAMÓN CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160402', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'PEBAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160403', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'YAVARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('160404', 'LORETO', 'MARISCAL RAMÓN CASTILLA', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160501', 'LORETO', 'REQUENA', 'REQUENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160502', 'LORETO', 'REQUENA', 'ALTO TAPICHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160503', 'LORETO', 'REQUENA', 'CAPELO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160504', 'LORETO', 'REQUENA', 'EMILIO SAN MARTÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160505', 'LORETO', 'REQUENA', 'MAQUIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160506', 'LORETO', 'REQUENA', 'PUINAHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160507', 'LORETO', 'REQUENA', 'SAQUENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160508', 'LORETO', 'REQUENA', 'SOPLIN');
INSERT INTO `tb_conf_ubigeo` VALUES ('160509', 'LORETO', 'REQUENA', 'TAPICHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160510', 'LORETO', 'REQUENA', 'JENARO HERRERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160511', 'LORETO', 'REQUENA', 'YAQUERANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160601', 'LORETO', 'UCAYALI', 'CONTAMANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160602', 'LORETO', 'UCAYALI', 'INAHUAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160603', 'LORETO', 'UCAYALI', 'PADRE MÁRQUEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('160604', 'LORETO', 'UCAYALI', 'PAMPA HERMOSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160605', 'LORETO', 'UCAYALI', 'SARAYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('160606', 'LORETO', 'UCAYALI', 'VARGAS GUERRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160701', 'LORETO', 'DATEM DEL MARAÑÓN', 'BARRANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160702', 'LORETO', 'DATEM DEL MARAÑÓN', 'CAHUAPANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160703', 'LORETO', 'DATEM DEL MARAÑÓN', 'MANSERICHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('160704', 'LORETO', 'DATEM DEL MARAÑÓN', 'MORONA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160705', 'LORETO', 'DATEM DEL MARAÑÓN', 'PASTAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('160706', 'LORETO', 'DATEM DEL MARAÑÓN', 'ANDOAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('160801', 'LORETO', 'PUTUMAYO', 'PUTUMAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160802', 'LORETO', 'PUTUMAYO', 'ROSA PANDURO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160803', 'LORETO', 'PUTUMAYO', 'TENIENTE MANUEL CLAVERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('160804', 'LORETO', 'PUTUMAYO', 'YAGUAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('170101', 'MADRE DE DIOS', 'TAMBOPATA', 'TAMBOPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('170102', 'MADRE DE DIOS', 'TAMBOPATA', 'INAMBARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('170103', 'MADRE DE DIOS', 'TAMBOPATA', 'LAS PIEDRAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('170104', 'MADRE DE DIOS', 'TAMBOPATA', 'LABERINTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('170201', 'MADRE DE DIOS', 'MANU', 'MANU');
INSERT INTO `tb_conf_ubigeo` VALUES ('170202', 'MADRE DE DIOS', 'MANU', 'FITZCARRALD');
INSERT INTO `tb_conf_ubigeo` VALUES ('170203', 'MADRE DE DIOS', 'MANU', 'MADRE DE DIOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('170204', 'MADRE DE DIOS', 'MANU', 'HUEPETUHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('170301', 'MADRE DE DIOS', 'TAHUAMANU', 'IÑAPARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('170302', 'MADRE DE DIOS', 'TAHUAMANU', 'IBERIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('170303', 'MADRE DE DIOS', 'TAHUAMANU', 'TAHUAMANU');
INSERT INTO `tb_conf_ubigeo` VALUES ('180101', 'MOQUEGUA', 'MARISCAL NIETO', 'MOQUEGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180102', 'MOQUEGUA', 'MARISCAL NIETO', 'CARUMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('180103', 'MOQUEGUA', 'MARISCAL NIETO', 'CUCHUMBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180104', 'MOQUEGUA', 'MARISCAL NIETO', 'SAMEGUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180105', 'MOQUEGUA', 'MARISCAL NIETO', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('180106', 'MOQUEGUA', 'MARISCAL NIETO', 'TORATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180201', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'OMATE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180202', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'CHOJATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180203', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'COALAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180204', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'ICHUÑA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180205', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'LA CAPILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180206', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'LLOQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180207', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'MATALAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('180208', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'PUQUINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180209', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'QUINISTAQUILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('180210', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'UBINAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('180211', 'MOQUEGUA', 'GENERAL SÁNCHEZ CERRO', 'YUNGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('180301', 'MOQUEGUA', 'ILO', 'ILO');
INSERT INTO `tb_conf_ubigeo` VALUES ('180302', 'MOQUEGUA', 'ILO', 'EL ALGARROBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('180303', 'MOQUEGUA', 'ILO', 'PACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190101', 'PASCO', 'PASCO', 'CHAUPIMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190102', 'PASCO', 'PASCO', 'HUACHON');
INSERT INTO `tb_conf_ubigeo` VALUES ('190103', 'PASCO', 'PASCO', 'HUARIACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190104', 'PASCO', 'PASCO', 'HUAYLLAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('190105', 'PASCO', 'PASCO', 'NINACACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190106', 'PASCO', 'PASCO', 'PALLANCHACRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190107', 'PASCO', 'PASCO', 'PAUCARTAMBO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190108', 'PASCO', 'PASCO', 'SAN FRANCISCO DE ASÍS DE YARUSYACAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('190109', 'PASCO', 'PASCO', 'SIMON BOLÍVAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('190110', 'PASCO', 'PASCO', 'TICLACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('190111', 'PASCO', 'PASCO', 'TINYAHUARCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190112', 'PASCO', 'PASCO', 'VICCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190113', 'PASCO', 'PASCO', 'YANACANCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190201', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'YANAHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190202', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'CHACAYAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('190203', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'GOYLLARISQUIZGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190204', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'PAUCAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('190205', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'SAN PEDRO DE PILLAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190206', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'SANTA ANA DE TUSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('190207', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'TAPUC');
INSERT INTO `tb_conf_ubigeo` VALUES ('190208', 'PASCO', 'DANIEL ALCIDES CARRIÓN', 'VILCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190301', 'PASCO', 'OXAPAMPA', 'OXAPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190302', 'PASCO', 'OXAPAMPA', 'CHONTABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190303', 'PASCO', 'OXAPAMPA', 'HUANCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190304', 'PASCO', 'OXAPAMPA', 'PALCAZU');
INSERT INTO `tb_conf_ubigeo` VALUES ('190305', 'PASCO', 'OXAPAMPA', 'POZUZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('190306', 'PASCO', 'OXAPAMPA', 'PUERTO BERMÚDEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('190307', 'PASCO', 'OXAPAMPA', 'VILLA RICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('190308', 'PASCO', 'OXAPAMPA', 'CONSTITUCIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200101', 'PIURA', 'PIURA', 'PIURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200104', 'PIURA', 'PIURA', 'CASTILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200105', 'PIURA', 'PIURA', 'CATACAOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200107', 'PIURA', 'PIURA', 'CURA MORI');
INSERT INTO `tb_conf_ubigeo` VALUES ('200108', 'PIURA', 'PIURA', 'EL TALLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200109', 'PIURA', 'PIURA', 'LA ARENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200110', 'PIURA', 'PIURA', 'LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200111', 'PIURA', 'PIURA', 'LAS LOMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200114', 'PIURA', 'PIURA', 'TAMBO GRANDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200115', 'PIURA', 'PIURA', 'VEINTISEIS DE OCTUBRE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200201', 'PIURA', 'AYABACA', 'AYABACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200202', 'PIURA', 'AYABACA', 'FRIAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200203', 'PIURA', 'AYABACA', 'JILILI');
INSERT INTO `tb_conf_ubigeo` VALUES ('200204', 'PIURA', 'AYABACA', 'LAGUNAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200205', 'PIURA', 'AYABACA', 'MONTERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200206', 'PIURA', 'AYABACA', 'PACAIPAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200207', 'PIURA', 'AYABACA', 'PAIMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200208', 'PIURA', 'AYABACA', 'SAPILLICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200209', 'PIURA', 'AYABACA', 'SICCHEZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('200210', 'PIURA', 'AYABACA', 'SUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200301', 'PIURA', 'HUANCABAMBA', 'HUANCABAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200302', 'PIURA', 'HUANCABAMBA', 'CANCHAQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200303', 'PIURA', 'HUANCABAMBA', 'EL CARMEN DE LA FRONTERA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200304', 'PIURA', 'HUANCABAMBA', 'HUARMACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200305', 'PIURA', 'HUANCABAMBA', 'LALAQUIZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('200306', 'PIURA', 'HUANCABAMBA', 'SAN MIGUEL DE EL FAIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200307', 'PIURA', 'HUANCABAMBA', 'SONDOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('200308', 'PIURA', 'HUANCABAMBA', 'SONDORILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200401', 'PIURA', 'MORROPÓN', 'CHULUCANAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200402', 'PIURA', 'MORROPÓN', 'BUENOS AIRES');
INSERT INTO `tb_conf_ubigeo` VALUES ('200403', 'PIURA', 'MORROPÓN', 'CHALACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200404', 'PIURA', 'MORROPÓN', 'LA MATANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200405', 'PIURA', 'MORROPÓN', 'MORROPON');
INSERT INTO `tb_conf_ubigeo` VALUES ('200406', 'PIURA', 'MORROPÓN', 'SALITRAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200407', 'PIURA', 'MORROPÓN', 'SAN JUAN DE BIGOTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200408', 'PIURA', 'MORROPÓN', 'SANTA CATALINA DE MOSSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200409', 'PIURA', 'MORROPÓN', 'SANTO DOMINGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200410', 'PIURA', 'MORROPÓN', 'YAMANGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200501', 'PIURA', 'PAITA', 'PAITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200502', 'PIURA', 'PAITA', 'AMOTAPE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200503', 'PIURA', 'PAITA', 'ARENAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200504', 'PIURA', 'PAITA', 'COLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200505', 'PIURA', 'PAITA', 'LA HUACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200506', 'PIURA', 'PAITA', 'TAMARINDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200507', 'PIURA', 'PAITA', 'VICHAYAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200601', 'PIURA', 'SULLANA', 'SULLANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200602', 'PIURA', 'SULLANA', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200603', 'PIURA', 'SULLANA', 'IGNACIO ESCUDERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200604', 'PIURA', 'SULLANA', 'LANCONES');
INSERT INTO `tb_conf_ubigeo` VALUES ('200605', 'PIURA', 'SULLANA', 'MARCAVELICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200606', 'PIURA', 'SULLANA', 'MIGUEL CHECA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200607', 'PIURA', 'SULLANA', 'QUERECOTILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200608', 'PIURA', 'SULLANA', 'SALITRAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200701', 'PIURA', 'TALARA', 'PARIÑAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200702', 'PIURA', 'TALARA', 'EL ALTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('200703', 'PIURA', 'TALARA', 'LA BREA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200704', 'PIURA', 'TALARA', 'LOBITOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200705', 'PIURA', 'TALARA', 'LOS ORGANOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('200706', 'PIURA', 'TALARA', 'MANCORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200801', 'PIURA', 'SECHURA', 'SECHURA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200802', 'PIURA', 'SECHURA', 'BELLAVISTA DE LA UNIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('200803', 'PIURA', 'SECHURA', 'BERNAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('200804', 'PIURA', 'SECHURA', 'CRISTO NOS VALGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('200805', 'PIURA', 'SECHURA', 'VICE');
INSERT INTO `tb_conf_ubigeo` VALUES ('200806', 'PIURA', 'SECHURA', 'RINCONADA LLICUAR');
INSERT INTO `tb_conf_ubigeo` VALUES ('210101', 'PUNO', 'PUNO', 'PUNO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210102', 'PUNO', 'PUNO', 'ACORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210103', 'PUNO', 'PUNO', 'AMANTANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210104', 'PUNO', 'PUNO', 'ATUNCOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210105', 'PUNO', 'PUNO', 'CAPACHICA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210106', 'PUNO', 'PUNO', 'CHUCUITO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210107', 'PUNO', 'PUNO', 'COATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210108', 'PUNO', 'PUNO', 'HUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210109', 'PUNO', 'PUNO', 'MAÑAZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210110', 'PUNO', 'PUNO', 'PAUCARCOLLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210111', 'PUNO', 'PUNO', 'PICHACANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210112', 'PUNO', 'PUNO', 'PLATERIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210113', 'PUNO', 'PUNO', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210114', 'PUNO', 'PUNO', 'TIQUILLACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210115', 'PUNO', 'PUNO', 'VILQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('210201', 'PUNO', 'AZÁNGARO', 'AZÁNGARO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210202', 'PUNO', 'AZÁNGARO', 'ACHAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210203', 'PUNO', 'AZÁNGARO', 'ARAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210204', 'PUNO', 'AZÁNGARO', 'ASILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210205', 'PUNO', 'AZÁNGARO', 'CAMINACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210206', 'PUNO', 'AZÁNGARO', 'CHUPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210207', 'PUNO', 'AZÁNGARO', 'JOSÉ DOMINGO CHOQUEHUANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210208', 'PUNO', 'AZÁNGARO', 'MUÑANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210209', 'PUNO', 'AZÁNGARO', 'POTONI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210210', 'PUNO', 'AZÁNGARO', 'SAMAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('210211', 'PUNO', 'AZÁNGARO', 'SAN ANTON');
INSERT INTO `tb_conf_ubigeo` VALUES ('210212', 'PUNO', 'AZÁNGARO', 'SAN JOSÉ');
INSERT INTO `tb_conf_ubigeo` VALUES ('210213', 'PUNO', 'AZÁNGARO', 'SAN JUAN DE SALINAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('210214', 'PUNO', 'AZÁNGARO', 'SANTIAGO DE PUPUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210215', 'PUNO', 'AZÁNGARO', 'TIRAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210301', 'PUNO', 'CARABAYA', 'MACUSANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210302', 'PUNO', 'CARABAYA', 'AJOYANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210303', 'PUNO', 'CARABAYA', 'AYAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210304', 'PUNO', 'CARABAYA', 'COASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210305', 'PUNO', 'CARABAYA', 'CORANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210306', 'PUNO', 'CARABAYA', 'CRUCERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210307', 'PUNO', 'CARABAYA', 'ITUATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210308', 'PUNO', 'CARABAYA', 'OLLACHEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210309', 'PUNO', 'CARABAYA', 'SAN GABAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('210310', 'PUNO', 'CARABAYA', 'USICAYOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('210401', 'PUNO', 'CHUCUITO', 'JULI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210402', 'PUNO', 'CHUCUITO', 'DESAGUADERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210403', 'PUNO', 'CHUCUITO', 'HUACULLANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210404', 'PUNO', 'CHUCUITO', 'KELLUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210405', 'PUNO', 'CHUCUITO', 'PISACOMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210406', 'PUNO', 'CHUCUITO', 'POMATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210407', 'PUNO', 'CHUCUITO', 'ZEPITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210501', 'PUNO', 'EL COLLAO', 'ILAVE');
INSERT INTO `tb_conf_ubigeo` VALUES ('210502', 'PUNO', 'EL COLLAO', 'CAPAZO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210503', 'PUNO', 'EL COLLAO', 'PILCUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210504', 'PUNO', 'EL COLLAO', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210505', 'PUNO', 'EL COLLAO', 'CONDURIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210601', 'PUNO', 'HUANCANÉ', 'HUANCANE');
INSERT INTO `tb_conf_ubigeo` VALUES ('210602', 'PUNO', 'HUANCANÉ', 'COJATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210603', 'PUNO', 'HUANCANÉ', 'HUATASANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210604', 'PUNO', 'HUANCANÉ', 'INCHUPALLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210605', 'PUNO', 'HUANCANÉ', 'PUSI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210606', 'PUNO', 'HUANCANÉ', 'ROSASPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210607', 'PUNO', 'HUANCANÉ', 'TARACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210608', 'PUNO', 'HUANCANÉ', 'VILQUE CHICO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210701', 'PUNO', 'LAMPA', 'LAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210702', 'PUNO', 'LAMPA', 'CABANILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210703', 'PUNO', 'LAMPA', 'CALAPUJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210704', 'PUNO', 'LAMPA', 'NICASIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210705', 'PUNO', 'LAMPA', 'OCUVIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210706', 'PUNO', 'LAMPA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210707', 'PUNO', 'LAMPA', 'PARATIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210708', 'PUNO', 'LAMPA', 'PUCARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210709', 'PUNO', 'LAMPA', 'SANTA LUCIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210710', 'PUNO', 'LAMPA', 'VILAVILA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210801', 'PUNO', 'MELGAR', 'AYAVIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210802', 'PUNO', 'MELGAR', 'ANTAUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210803', 'PUNO', 'MELGAR', 'CUPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210804', 'PUNO', 'MELGAR', 'LLALLI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210805', 'PUNO', 'MELGAR', 'MACARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210806', 'PUNO', 'MELGAR', 'NUÑOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210807', 'PUNO', 'MELGAR', 'ORURILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210808', 'PUNO', 'MELGAR', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210809', 'PUNO', 'MELGAR', 'UMACHIRI');
INSERT INTO `tb_conf_ubigeo` VALUES ('210901', 'PUNO', 'MOHO', 'MOHO');
INSERT INTO `tb_conf_ubigeo` VALUES ('210902', 'PUNO', 'MOHO', 'CONIMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210903', 'PUNO', 'MOHO', 'HUAYRAPATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('210904', 'PUNO', 'MOHO', 'TILALI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211001', 'PUNO', 'SAN ANTONIO DE PUTINA', 'PUTINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211002', 'PUNO', 'SAN ANTONIO DE PUTINA', 'ANANEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211003', 'PUNO', 'SAN ANTONIO DE PUTINA', 'PEDRO VILCA APAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211004', 'PUNO', 'SAN ANTONIO DE PUTINA', 'QUILCAPUNCU');
INSERT INTO `tb_conf_ubigeo` VALUES ('211005', 'PUNO', 'SAN ANTONIO DE PUTINA', 'SINA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211101', 'PUNO', 'SAN ROMÁN', 'JULIACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211102', 'PUNO', 'SAN ROMÁN', 'CABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211103', 'PUNO', 'SAN ROMÁN', 'CABANILLAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('211104', 'PUNO', 'SAN ROMÁN', 'CARACOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211201', 'PUNO', 'SANDIA', 'SANDIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211202', 'PUNO', 'SANDIA', 'CUYOCUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211203', 'PUNO', 'SANDIA', 'LIMBANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211204', 'PUNO', 'SANDIA', 'PATAMBUCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211205', 'PUNO', 'SANDIA', 'PHARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211206', 'PUNO', 'SANDIA', 'QUIACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211207', 'PUNO', 'SANDIA', 'SAN JUAN DEL ORO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211208', 'PUNO', 'SANDIA', 'YANAHUAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211209', 'PUNO', 'SANDIA', 'ALTO INAMBARI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211210', 'PUNO', 'SANDIA', 'SAN PEDRO DE PUTINA PUNCO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211301', 'PUNO', 'YUNGUYO', 'YUNGUYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('211302', 'PUNO', 'YUNGUYO', 'ANAPIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211303', 'PUNO', 'YUNGUYO', 'COPANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211304', 'PUNO', 'YUNGUYO', 'CUTURAPI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211305', 'PUNO', 'YUNGUYO', 'OLLARAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('211306', 'PUNO', 'YUNGUYO', 'TINICACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('211307', 'PUNO', 'YUNGUYO', 'UNICACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220101', 'SAN MARTÍN', 'MOYOBAMBA', 'MOYOBAMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220102', 'SAN MARTÍN', 'MOYOBAMBA', 'CALZADA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220103', 'SAN MARTÍN', 'MOYOBAMBA', 'HABANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220104', 'SAN MARTÍN', 'MOYOBAMBA', 'JEPELACIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220105', 'SAN MARTÍN', 'MOYOBAMBA', 'SORITOR');
INSERT INTO `tb_conf_ubigeo` VALUES ('220106', 'SAN MARTÍN', 'MOYOBAMBA', 'YANTALO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220201', 'SAN MARTÍN', 'BELLAVISTA', 'BELLAVISTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220202', 'SAN MARTÍN', 'BELLAVISTA', 'ALTO BIAVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220203', 'SAN MARTÍN', 'BELLAVISTA', 'BAJO BIAVO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220204', 'SAN MARTÍN', 'BELLAVISTA', 'HUALLAGA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220205', 'SAN MARTÍN', 'BELLAVISTA', 'SAN PABLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220206', 'SAN MARTÍN', 'BELLAVISTA', 'SAN RAFAEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('220301', 'SAN MARTÍN', 'EL DORADO', 'SAN JOSÉ DE SISA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220302', 'SAN MARTÍN', 'EL DORADO', 'AGUA BLANCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220303', 'SAN MARTÍN', 'EL DORADO', 'SAN MARTÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220304', 'SAN MARTÍN', 'EL DORADO', 'SANTA ROSA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220305', 'SAN MARTÍN', 'EL DORADO', 'SHATOJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220401', 'SAN MARTÍN', 'HUALLAGA', 'SAPOSOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220402', 'SAN MARTÍN', 'HUALLAGA', 'ALTO SAPOSOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220403', 'SAN MARTÍN', 'HUALLAGA', 'EL ESLABÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220404', 'SAN MARTÍN', 'HUALLAGA', 'PISCOYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220405', 'SAN MARTÍN', 'HUALLAGA', 'SACANCHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('220406', 'SAN MARTÍN', 'HUALLAGA', 'TINGO DE SAPOSOA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220501', 'SAN MARTÍN', 'LAMAS', 'LAMAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220502', 'SAN MARTÍN', 'LAMAS', 'ALONSO DE ALVARADO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220503', 'SAN MARTÍN', 'LAMAS', 'BARRANQUITA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220504', 'SAN MARTÍN', 'LAMAS', 'CAYNARACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220505', 'SAN MARTÍN', 'LAMAS', 'CUÑUMBUQUI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220506', 'SAN MARTÍN', 'LAMAS', 'PINTO RECODO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220507', 'SAN MARTÍN', 'LAMAS', 'RUMISAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220508', 'SAN MARTÍN', 'LAMAS', 'SAN ROQUE DE CUMBAZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220509', 'SAN MARTÍN', 'LAMAS', 'SHANAO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220510', 'SAN MARTÍN', 'LAMAS', 'TABALOSOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220511', 'SAN MARTÍN', 'LAMAS', 'ZAPATERO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220601', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'JUANJUÍ');
INSERT INTO `tb_conf_ubigeo` VALUES ('220602', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'CAMPANILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220603', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'HUICUNGO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220604', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'PACHIZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220605', 'SAN MARTÍN', 'MARISCAL CÁCERES', 'PAJARILLO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220701', 'SAN MARTÍN', 'PICOTA', 'PICOTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220702', 'SAN MARTÍN', 'PICOTA', 'BUENOS AIRES');
INSERT INTO `tb_conf_ubigeo` VALUES ('220703', 'SAN MARTÍN', 'PICOTA', 'CASPISAPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220704', 'SAN MARTÍN', 'PICOTA', 'PILLUANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220705', 'SAN MARTÍN', 'PICOTA', 'PUCACACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220706', 'SAN MARTÍN', 'PICOTA', 'SAN CRISTÓBAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('220707', 'SAN MARTÍN', 'PICOTA', 'SAN HILARIÓN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220708', 'SAN MARTÍN', 'PICOTA', 'SHAMBOYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220709', 'SAN MARTÍN', 'PICOTA', 'TINGO DE PONASA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220710', 'SAN MARTÍN', 'PICOTA', 'TRES UNIDOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220801', 'SAN MARTÍN', 'RIOJA', 'RIOJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220802', 'SAN MARTÍN', 'RIOJA', 'AWAJUN');
INSERT INTO `tb_conf_ubigeo` VALUES ('220803', 'SAN MARTÍN', 'RIOJA', 'ELÍAS SOPLIN VARGAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220804', 'SAN MARTÍN', 'RIOJA', 'NUEVA CAJAMARCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220805', 'SAN MARTÍN', 'RIOJA', 'PARDO MIGUEL');
INSERT INTO `tb_conf_ubigeo` VALUES ('220806', 'SAN MARTÍN', 'RIOJA', 'POSIC');
INSERT INTO `tb_conf_ubigeo` VALUES ('220807', 'SAN MARTÍN', 'RIOJA', 'SAN FERNANDO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220808', 'SAN MARTÍN', 'RIOJA', 'YORONGOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('220809', 'SAN MARTÍN', 'RIOJA', 'YURACYACU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220901', 'SAN MARTÍN', 'SAN MARTÍN', 'TARAPOTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220902', 'SAN MARTÍN', 'SAN MARTÍN', 'ALBERTO LEVEAU');
INSERT INTO `tb_conf_ubigeo` VALUES ('220903', 'SAN MARTÍN', 'SAN MARTÍN', 'CACATACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('220904', 'SAN MARTÍN', 'SAN MARTÍN', 'CHAZUTA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220905', 'SAN MARTÍN', 'SAN MARTÍN', 'CHIPURANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220906', 'SAN MARTÍN', 'SAN MARTÍN', 'EL PORVENIR');
INSERT INTO `tb_conf_ubigeo` VALUES ('220907', 'SAN MARTÍN', 'SAN MARTÍN', 'HUIMBAYOC');
INSERT INTO `tb_conf_ubigeo` VALUES ('220908', 'SAN MARTÍN', 'SAN MARTÍN', 'JUAN GUERRA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220909', 'SAN MARTÍN', 'SAN MARTÍN', 'LA BANDA DE SHILCAYO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220910', 'SAN MARTÍN', 'SAN MARTÍN', 'MORALES');
INSERT INTO `tb_conf_ubigeo` VALUES ('220911', 'SAN MARTÍN', 'SAN MARTÍN', 'PAPAPLAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('220912', 'SAN MARTÍN', 'SAN MARTÍN', 'SAN ANTONIO');
INSERT INTO `tb_conf_ubigeo` VALUES ('220913', 'SAN MARTÍN', 'SAN MARTÍN', 'SAUCE');
INSERT INTO `tb_conf_ubigeo` VALUES ('220914', 'SAN MARTÍN', 'SAN MARTÍN', 'SHAPAJA');
INSERT INTO `tb_conf_ubigeo` VALUES ('221001', 'SAN MARTÍN', 'TOCACHE', 'TOCACHE');
INSERT INTO `tb_conf_ubigeo` VALUES ('221002', 'SAN MARTÍN', 'TOCACHE', 'NUEVO PROGRESO');
INSERT INTO `tb_conf_ubigeo` VALUES ('221003', 'SAN MARTÍN', 'TOCACHE', 'POLVORA');
INSERT INTO `tb_conf_ubigeo` VALUES ('221004', 'SAN MARTÍN', 'TOCACHE', 'SHUNTE');
INSERT INTO `tb_conf_ubigeo` VALUES ('221005', 'SAN MARTÍN', 'TOCACHE', 'UCHIZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230101', 'TACNA', 'TACNA', 'TACNA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230102', 'TACNA', 'TACNA', 'ALTO DE LA ALIANZA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230103', 'TACNA', 'TACNA', 'CALANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230104', 'TACNA', 'TACNA', 'CIUDAD NUEVA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230105', 'TACNA', 'TACNA', 'INCLAN');
INSERT INTO `tb_conf_ubigeo` VALUES ('230106', 'TACNA', 'TACNA', 'PACHIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230107', 'TACNA', 'TACNA', 'PALCA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230108', 'TACNA', 'TACNA', 'POCOLLAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('230109', 'TACNA', 'TACNA', 'SAMA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230110', 'TACNA', 'TACNA', 'CORONEL GREGORIO ALBARRACÍN LANCHIPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230111', 'TACNA', 'TACNA', 'LA YARADA LOS PALOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('230201', 'TACNA', 'CANDARAVE', 'CANDARAVE');
INSERT INTO `tb_conf_ubigeo` VALUES ('230202', 'TACNA', 'CANDARAVE', 'CAIRANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('230203', 'TACNA', 'CANDARAVE', 'CAMILACA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230204', 'TACNA', 'CANDARAVE', 'CURIBAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230205', 'TACNA', 'CANDARAVE', 'HUANUARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230206', 'TACNA', 'CANDARAVE', 'QUILAHUANI');
INSERT INTO `tb_conf_ubigeo` VALUES ('230301', 'TACNA', 'JORGE BASADRE', 'LOCUMBA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230302', 'TACNA', 'JORGE BASADRE', 'ILABAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230303', 'TACNA', 'JORGE BASADRE', 'ITE');
INSERT INTO `tb_conf_ubigeo` VALUES ('230401', 'TACNA', 'TARATA', 'TARATA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230402', 'TACNA', 'TARATA', 'HÉROES ALBARRACÍN');
INSERT INTO `tb_conf_ubigeo` VALUES ('230403', 'TACNA', 'TARATA', 'ESTIQUE');
INSERT INTO `tb_conf_ubigeo` VALUES ('230404', 'TACNA', 'TARATA', 'ESTIQUE-PAMPA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230405', 'TACNA', 'TARATA', 'SITAJARA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230406', 'TACNA', 'TARATA', 'SUSAPAYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('230407', 'TACNA', 'TARATA', 'TARUCACHI');
INSERT INTO `tb_conf_ubigeo` VALUES ('230408', 'TACNA', 'TARATA', 'TICACO');
INSERT INTO `tb_conf_ubigeo` VALUES ('240101', 'TUMBES', 'TUMBES', 'TUMBES');
INSERT INTO `tb_conf_ubigeo` VALUES ('240102', 'TUMBES', 'TUMBES', 'CORRALES');
INSERT INTO `tb_conf_ubigeo` VALUES ('240103', 'TUMBES', 'TUMBES', 'LA CRUZ');
INSERT INTO `tb_conf_ubigeo` VALUES ('240104', 'TUMBES', 'TUMBES', 'PAMPAS DE HOSPITAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('240105', 'TUMBES', 'TUMBES', 'SAN JACINTO');
INSERT INTO `tb_conf_ubigeo` VALUES ('240106', 'TUMBES', 'TUMBES', 'SAN JUAN DE LA VIRGEN');
INSERT INTO `tb_conf_ubigeo` VALUES ('240201', 'TUMBES', 'CONTRALMIRANTE VILLAR', 'ZORRITOS');
INSERT INTO `tb_conf_ubigeo` VALUES ('240202', 'TUMBES', 'CONTRALMIRANTE VILLAR', 'CASITAS');
INSERT INTO `tb_conf_ubigeo` VALUES ('240203', 'TUMBES', 'CONTRALMIRANTE VILLAR', 'CANOAS DE PUNTA SAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('240301', 'TUMBES', 'ZARUMILLA', 'ZARUMILLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('240302', 'TUMBES', 'ZARUMILLA', 'AGUAS VERDES');
INSERT INTO `tb_conf_ubigeo` VALUES ('240303', 'TUMBES', 'ZARUMILLA', 'MATAPALO');
INSERT INTO `tb_conf_ubigeo` VALUES ('240304', 'TUMBES', 'ZARUMILLA', 'PAPAYAL');
INSERT INTO `tb_conf_ubigeo` VALUES ('250101', 'UCAYALI', 'CORONEL PORTILLO', 'CALLERIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250102', 'UCAYALI', 'CORONEL PORTILLO', 'CAMPOVERDE');
INSERT INTO `tb_conf_ubigeo` VALUES ('250103', 'UCAYALI', 'CORONEL PORTILLO', 'IPARIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250104', 'UCAYALI', 'CORONEL PORTILLO', 'MASISEA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250105', 'UCAYALI', 'CORONEL PORTILLO', 'YARINACOCHA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250106', 'UCAYALI', 'CORONEL PORTILLO', 'NUEVA REQUENA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250107', 'UCAYALI', 'CORONEL PORTILLO', 'MANANTAY');
INSERT INTO `tb_conf_ubigeo` VALUES ('250201', 'UCAYALI', 'ATALAYA', 'RAYMONDI');
INSERT INTO `tb_conf_ubigeo` VALUES ('250202', 'UCAYALI', 'ATALAYA', 'SEPAHUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250203', 'UCAYALI', 'ATALAYA', 'TAHUANIA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250204', 'UCAYALI', 'ATALAYA', 'YURUA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250301', 'UCAYALI', 'PADRE ABAD', 'PADRE ABAD');
INSERT INTO `tb_conf_ubigeo` VALUES ('250302', 'UCAYALI', 'PADRE ABAD', 'IRAZOLA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250303', 'UCAYALI', 'PADRE ABAD', 'CURIMANA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250304', 'UCAYALI', 'PADRE ABAD', 'NESHUYA');
INSERT INTO `tb_conf_ubigeo` VALUES ('250305', 'UCAYALI', 'PADRE ABAD', 'ALEXANDER VON HUMBOLDT');
INSERT INTO `tb_conf_ubigeo` VALUES ('250401', 'UCAYALI', 'PURÚS', 'PURUS');

-- ----------------------------
-- Table structure for tb_conf_users
-- ----------------------------
DROP TABLE IF EXISTS `tb_conf_users`;
CREATE TABLE `tb_conf_users`  (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `two_factor_secret` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `two_factor_recovery_codes` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `two_factor_confirmed_at` timestamp NULL DEFAULT NULL,
  `remember_token` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `current_team_id` bigint(20) UNSIGNED NULL DEFAULT NULL,
  `profile_photo_path` varchar(2048) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `active` tinyint(1) NULL DEFAULT NULL,
  `apaterno` varchar(250) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `amaterno` varchar(250) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `dni` varchar(12) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `rol_id` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `users_ibfk_1`(`rol_id`) USING BTREE,
  CONSTRAINT `tb_conf_users_ibfk_1` FOREIGN KEY (`rol_id`) REFERENCES `tb_conf_roles` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_conf_users
-- ----------------------------
INSERT INTO `tb_conf_users` VALUES (2, 'Agapito De la cruz Carlos', 'username@gmail.com', 'adelacruz', '1cf9ab3ec43e15f2f06cf21e48de64248f44044260f2d089e0144775401a4cff', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, 1);
INSERT INTO `tb_conf_users` VALUES (7, 'Username two', 'usernametwo@gmail.com', 'usernametwo', '47b767547a83b9904a4d0a821772db606f8deb5e6ba44bf69b3a7181127a5b5f', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, 3);
INSERT INTO `tb_conf_users` VALUES (8, 'Juanqui', 'jc@gmail.com', 'jotace', '1cf9ab3ec43e15f2f06cf21e48de64248f44044260f2d089e0144775401a4cff', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, 2);

-- ----------------------------
-- Table structure for tb_form_contactanos
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_contactanos`;
CREATE TABLE `tb_form_contactanos`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoServicio` int(11) NULL DEFAULT NULL,
  `nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `asunto` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `mensaje` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `correoElectronico` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_FormContactanos_IndServicioDet`(`tipoServicio`) USING BTREE,
  CONSTRAINT `FK_FormContactanos_IndServicioDet` FOREIGN KEY (`tipoServicio`) REFERENCES `tb_ind_serviciodet` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_contactanos
-- ----------------------------

-- ----------------------------
-- Table structure for tb_form_cotizanos
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_cotizanos`;
CREATE TABLE `tb_form_cotizanos`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoServicio` int(11) NULL DEFAULT NULL,
  `distrito` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ruc` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `razonSocial` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `contacto` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `celular` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `telefono` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `fechaEvento` datetime NULL DEFAULT NULL,
  `correoElectronico` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `comentario` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `tipoAbonado` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `estacionamiento` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cantidad` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_FormCotizanos_ServicioCabecera`(`tipoServicio`) USING BTREE,
  CONSTRAINT `FK_FormCotizanos_ServicioCabecera` FOREIGN KEY (`tipoServicio`) REFERENCES `tb_serv_cabecera` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_cotizanos
-- ----------------------------
INSERT INTO `tb_form_cotizanos` VALUES (1, 2, 'SAN ISIDRO', NULL, NULL, NULL, 'AGAPEDE LA CRUZ CARLOS', '951545454', '5345345', NULL, 'adelacruzcarlos@gmail.com', NULL, 'Personas', 'BBVA Oficinas Corporativas', 2);
INSERT INTO `tb_form_cotizanos` VALUES (2, 2, 'LIMA', NULL, NULL, NULL, NULL, '959158444', NULL, NULL, 'adelacruzcarlos@gmail.com', NULL, 'Empresas', 'Hotel Sheraton', 1);
INSERT INTO `tb_form_cotizanos` VALUES (3, 2, 'MAGDALENA DEL MAR', NULL, '22121155152', 'razonsocial completo', NULL, '999999999', NULL, NULL, 'age@gmail.com', NULL, 'Empresas', 'Prime Towers', 4);

-- ----------------------------
-- Table structure for tb_form_hojareclamaciones
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_hojareclamaciones`;
CREATE TABLE `tb_form_hojareclamaciones`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NULL DEFAULT NULL,
  `fechaindicente` datetime NULL DEFAULT NULL,
  `nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `apellido` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `correo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `telefono` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `tipodocumento` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `numerodocumento` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `menordeedad` tinyint(4) NULL DEFAULT NULL,
  `departamento` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `provincia` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `distrito` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `reclamo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `tiposervicio` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `estacionamiento` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `detalle` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_hojareclamaciones
-- ----------------------------

-- ----------------------------
-- Table structure for tb_form_parkingcard
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_parkingcard`;
CREATE TABLE `tb_form_parkingcard`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dni` char(8) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'dni del usuario',
  `correo` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'correo del usuario',
  `codSeguridad` char(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'codigo de seguridad aleatorio que genera el sistema de 20 caracteres',
  `fecRegistro` datetime NULL DEFAULT NULL COMMENT 'fecha actual de registro',
  `notificado` int(11) NULL DEFAULT NULL COMMENT 'valida si esta notificacion fue verificado',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_parkingcard
-- ----------------------------

-- ----------------------------
-- Table structure for tb_form_proveedores
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_proveedores`;
CREATE TABLE `tb_form_proveedores`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NULL DEFAULT NULL,
  `solicitadoPor` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_ruc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_dni` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_direccion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_distrito` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_telefono` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_rubro` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_tipoPersona` int(11) NULL DEFAULT NULL,
  `f_codigoPostal` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `f_fax` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `rl_nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `rl_cargo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `rl_celular` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `rl_telefono` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `rl_email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cc_nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cc_cargo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cc_celular` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cc_telefono` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cc_email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `afectoRetencionDeIGV` tinyint(1) NULL DEFAULT NULL,
  `afectoDetraccionDeIGV` tinyint(1) NULL DEFAULT NULL,
  `porcentajeDetraccion` double NULL DEFAULT NULL,
  `AfectoRentade4taCategoría` tinyint(1) NULL DEFAULT NULL,
  `Exoneradorenta4ta` tinyint(1) NULL DEFAULT NULL,
  `comprobanteExoneracion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `tipoDocumentoFactura` tinyint(1) NULL DEFAULT NULL,
  `tipoDocumentoReciboHonorarios` tinyint(1) NULL DEFAULT NULL,
  `tipoDocumentoOtros` tinyint(1) NULL DEFAULT NULL,
  `datosCompraSoles` tinyint(1) NULL DEFAULT NULL,
  `datosCompraDolares` tinyint(1) NULL DEFAULT NULL,
  `datosCompraAmbas` tinyint(1) NULL DEFAULT NULL,
  `informacionPagoProveedor30dias` tinyint(1) NULL DEFAULT NULL,
  `informacionPagoProveedor60dias` tinyint(1) NULL DEFAULT NULL,
  `informacionPagoProveedorEfectivo` tinyint(1) NULL DEFAULT NULL,
  `informacionPagoProveedorTranferenciaBancaria` tinyint(1) NULL DEFAULT NULL,
  `informacionPagoProveedorOtros` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ccobranza_nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ccobranza_cargo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ccobranza_celular` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ccobranza_telefono` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ccobranza_email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `codCuentaBancaria` int(11) NULL DEFAULT NULL,
  `cuentaBancaria` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cuentaBancariaTitular` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `cuentaBancariaCCI` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_tipoBanco`(`codCuentaBancaria`) USING BTREE,
  CONSTRAINT `FK_tipoBanco` FOREIGN KEY (`codCuentaBancaria`) REFERENCES `tb_conf_banco` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_proveedores
-- ----------------------------

-- ----------------------------
-- Table structure for tb_form_servicios
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_servicios`;
CREATE TABLE `tb_form_servicios`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoServicio` int(11) NULL DEFAULT NULL,
  `distrito` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `direccionEstacionamiento` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ruc` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `razonSocial` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `datosContacto` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `celular` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `telefono` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `correoElectronico` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `FK_FormServicios_IndServicioDet`(`tipoServicio`) USING BTREE,
  CONSTRAINT `FK_FormServicios_IndServicioDet` FOREIGN KEY (`tipoServicio`) REFERENCES `tb_ind_serviciodet` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_servicios
-- ----------------------------

-- ----------------------------
-- Table structure for tb_form_tbcnosotros
-- ----------------------------
DROP TABLE IF EXISTS `tb_form_tbcnosotros`;
CREATE TABLE `tb_form_tbcnosotros`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoDocumento` int(11) NULL DEFAULT NULL,
  `nombre` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `apellido` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `fechaNacimiento` datetime NULL DEFAULT NULL,
  `correoElectronico` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `departamento` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `provincia` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `distrito` int(11) NULL DEFAULT NULL,
  `puesto` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `informacionAdicional` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `numeroDocumento` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `celular` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `medio` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 30 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_form_tbcnosotros
-- ----------------------------
INSERT INTO `tb_form_tbcnosotros` VALUES (1, 1, 'EjmploPost', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `tb_form_tbcnosotros` VALUES (2, 1, 'Mauro Emiliano', 'Ayarde', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, '3888655340', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (3, 1, 'prueba', 'prueba', '2002-01-01 00:00:00', 'prueba@gmail.com', 'LIMA', 'LIMA', 1, 'prueba', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (4, 1, 'test', 'test', NULL, 'test@gmail.com', 'LIMA', 'LIMA', 1, 'asdasd', NULL, NULL, '34214', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (5, 1, 'Emiliano', 'Ayarde', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, '123123', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (6, 1, 'asdasd', 'asdasd', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (7, 1, 'asdasd', 'asdasd', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, '123123', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (8, 1, 'maur', 'emi', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (9, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (10, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (11, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (12, 1, 'maur', 'emi', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (13, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (14, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (15, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (16, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (17, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (18, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (19, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (20, 1, 'AHORASI', 'AHORASI', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, NULL, NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (21, 1, 'Mauro Emiliano', 'Ayarde', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', 'luis dispo.png', NULL, '3888655340', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (22, 1, 'Mauro Emiliano', 'Ayarde', '2023-06-05 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', NULL, '39198157', '3888655340', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (23, 1, 'Mauro Emiliano', 'Ayarde', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Programador', 'testhoycode.png', '39198157', '3888655340', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `tb_form_tbcnosotros` VALUES (25, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `tb_form_tbcnosotros` VALUES (26, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `tb_form_tbcnosotros` VALUES (27, 1, NULL, NULL, NULL, NULL, 'LIMA', 'LIMA', 1, 'Agente Servicio', NULL, NULL, NULL, 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (28, 1, 'Mauro Emiliano', 'Ayarde', NULL, 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Agente Servicio', '09-12_dia-del-programador.jpg', '39198157', '3888655340', 'PAGINA');
INSERT INTO `tb_form_tbcnosotros` VALUES (29, 1, 'Mauro Emiliano', 'Ayarde', '1995-07-25 00:00:00', 'mauroprogramador157@gmail.com', 'LIMA', 'LIMA', 1, 'Agente Servicio', NULL, '39198157', '3888655340', 'PAGINA');

-- ----------------------------
-- Table structure for tb_ind_caracteristica
-- ----------------------------
DROP TABLE IF EXISTS `tb_ind_caracteristica`;
CREATE TABLE `tb_ind_caracteristica`  (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `icono` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Detalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_ind_caracteristica
-- ----------------------------
INSERT INTO `tb_ind_caracteristica` VALUES (1, 'Mision Vision', 'fa fa-puzzle-piece', 'Administrar estacionamientos a través de personas comprometidas con integridad...sdsdsdsd');
INSERT INTO `tb_ind_caracteristica` VALUES (2, 'Valor', 'fa fa-magic', 'Integridad, Respeto, Iniciativa y Comunicación y mas..');
INSERT INTO `tb_ind_caracteristica` VALUES (3, 'Reconocimientos', 'fa fa-trophy', 'Empresa líder en la administración de estacionamientos. tres');

-- ----------------------------
-- Table structure for tb_ind_redsocial
-- ----------------------------
DROP TABLE IF EXISTS `tb_ind_redsocial`;
CREATE TABLE `tb_ind_redsocial`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `clasehead` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ruta` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `clasefoot` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `icono` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `color` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `estado` int(11) NULL DEFAULT 1,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_ind_redsocial
-- ----------------------------
INSERT INTO `tb_ind_redsocial` VALUES (1, 'Facebook', 'fab fa-facebook-f', 'ruta fb', 'fa fb', 'fa-fb', 'text-primary', 1);

-- ----------------------------
-- Table structure for tb_ind_serviciocab
-- ----------------------------
DROP TABLE IF EXISTS `tb_ind_serviciocab`;
CREATE TABLE `tb_ind_serviciocab`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tituloGrande` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `tituloPeque` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `descripcion` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `imagenGrande` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `imagenPeque` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ruta` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_ind_serviciocab
-- ----------------------------
INSERT INTO `tb_ind_serviciocab` VALUES (1, 'Para nuestros usuaries', 'SERVICIOS', NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for tb_ind_serviciodet
-- ----------------------------
DROP TABLE IF EXISTS `tb_ind_serviciodet`;
CREATE TABLE `tb_ind_serviciodet`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idCab` int(11) NULL DEFAULT NULL,
  `icono` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `detalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ruta` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `imagen` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `indexserviciodet_ibfk_1`(`idCab`) USING BTREE,
  CONSTRAINT `tb_ind_serviciodet_ibfk_1` FOREIGN KEY (`idCab`) REFERENCES `tb_ind_serviciocab` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_ind_serviciodet
-- ----------------------------
INSERT INTO `tb_ind_serviciodet` VALUES (1, 1, 'fas fa-car', 'ADMINISTRACION DE ESTACIONAMIENTO', 'La Administracion de estacionamiento se puede ver ingresando en el botesn', '/Home/Otrosservicios', '/images/cliente1.jpg');
INSERT INTO `tb_ind_serviciodet` VALUES (2, 1, 'fas fa-user-tag', 'GESTIÓN DE ABONADOS', 'Tempor erat elitr rebum at clita dolor diam ipsum sit diam amet diam et ', '/Home/Abonados', '/images/cliente2.jpg');
INSERT INTO `tb_ind_serviciodet` VALUES (3, 1, 'fas fa-people-carry', 'OTROS SERVICIOS', 'Tempor erat elitr rebum at clita dolor diam ipsum sit diam amet diam et eos', '/Home/Otrosservicios', '/images/cliente3.jpg');

-- ----------------------------
-- Table structure for tb_ind_slidecab
-- ----------------------------
DROP TABLE IF EXISTS `tb_ind_slidecab`;
CREATE TABLE `tb_ind_slidecab`  (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `imagen` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `idBtn1` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `idBtn1`(`idBtn1`) USING BTREE,
  CONSTRAINT `tb_ind_slidecab_ibfk_1` FOREIGN KEY (`idBtn1`) REFERENCES `tb_conf_botones` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_ind_slidecab
-- ----------------------------
INSERT INTO `tb_ind_slidecab` VALUES (1, 'Comprometidos con nuestros client@s', '/images/banner_playas3.jpg', 1);
INSERT INTO `tb_ind_slidecab` VALUES (2, 'Estaciónate aquí con nosotros', '/images/banner_playas2.jpg', 2);
INSERT INTO `tb_ind_slidecab` VALUES (3, 'Tenemos un servicio específico para vos', '/images/banner_playas22_9.jpg', 3);

-- ----------------------------
-- Table structure for tb_nos_cabecera
-- ----------------------------
DROP TABLE IF EXISTS `tb_nos_cabecera`;
CREATE TABLE `tb_nos_cabecera`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_nos_cabecera
-- ----------------------------
INSERT INTO `tb_nos_cabecera` VALUES (1, 'QUIENES SOMOS');

-- ----------------------------
-- Table structure for tb_nos_detalle
-- ----------------------------
DROP TABLE IF EXISTS `tb_nos_detalle`;
CREATE TABLE `tb_nos_detalle`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `detalle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `espacio` int(11) NULL DEFAULT NULL,
  `imagen` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `icono` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_nos_detalle
-- ----------------------------
INSERT INTO `tb_nos_detalle` VALUES (1, 'RESEÑA HISTÓRICA', 'Central Parking System se fundó en el año 1968 en Nashville, Tenesse, EE.U, llegó al Perú en 1992, somos una empresa líder en la administración de estacionamientos y operamos los Centros Comerciales, Edificios Corporativos y Hoteles más importantes del país además de brindar Servicio de Valet Parking en empresas y eventos.', 12, NULL, 'fa fa-clock');
INSERT INTO `tb_nos_detalle` VALUES (2, 'MISIÓN', 'Administrar estacionamientos a través de personas comprometidas con integridad y excelencia.', 6, 'img/playa_estacionamiento2.jpg', 'fas fa-map-marker-alt');
INSERT INTO `tb_nos_detalle` VALUES (3, 'VISIÓN', 'Ser reconocidos como un socio confiable e innovador, que agrega valor a la experiencia de nuestros colaboradores, clientes y usuarios.', 6, NULL, 'fas fa-eye');
INSERT INTO `tb_nos_detalle` VALUES (4, 'VALORES', 'Integridad, Respeto, Iniciativa y Comunicación', 6, 'img/playa_estacionamiento.jpg', 'fas fa-magic');
INSERT INTO `tb_nos_detalle` VALUES (5, 'RECONOCIMIENTO', 'Empresa líder en la administración de estacionamientos.', 6, NULL, 'fas fa-trophy');

-- ----------------------------
-- Table structure for tb_prov_registro
-- ----------------------------
DROP TABLE IF EXISTS `tb_prov_registro`;
CREATE TABLE `tb_prov_registro`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `codPersonaSolicita` int(11) NULL DEFAULT NULL,
  `codPersonaInforFiscal` int(11) NULL DEFAULT NULL,
  `codPersonaRepLegal` int(11) NULL DEFAULT NULL,
  `codPersonaContactoComercial` int(11) NULL DEFAULT NULL,
  `AfectoRetencionIGV` int(11) NULL DEFAULT NULL,
  `AfectoDetraccionIGV` int(11) NULL DEFAULT NULL,
  `PorcentajeDetraccion` int(11) NULL DEFAULT NULL,
  `AfectoRenta4taCat` int(11) NULL DEFAULT NULL,
  `ExoneradoRenta4taCat` int(11) NULL DEFAULT NULL,
  `ComprobanteExonera` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `tipoDocElectronicoRemite` int(11) NULL DEFAULT NULL,
  `tipoMonedaCompra` int(11) NULL DEFAULT NULL,
  `tiempoPago` int(11) NULL DEFAULT NULL,
  `otroTiempoPago` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `tipoPagoDinero` int(11) NULL DEFAULT NULL,
  `codPersonaCobranza` int(11) NULL DEFAULT NULL,
  `codBanco` int(11) NULL DEFAULT NULL,
  `Titular` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `NroCuenta` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CCI` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `codPersonaSolicita`(`codPersonaSolicita`) USING BTREE,
  INDEX `codPersonaInforFiscal`(`codPersonaInforFiscal`) USING BTREE,
  INDEX `codPersonaRepLegal`(`codPersonaRepLegal`) USING BTREE,
  INDEX `codPersonaContactoComercial`(`codPersonaContactoComercial`) USING BTREE,
  INDEX `codPersonaCobranza`(`codPersonaCobranza`) USING BTREE,
  INDEX `tipoMonedaCompra`(`tipoMonedaCompra`) USING BTREE,
  INDEX `tiempoPago`(`tiempoPago`) USING BTREE,
  INDEX `tipoDocElectronicoRemite`(`tipoDocElectronicoRemite`) USING BTREE,
  INDEX `tipoPagoDinero`(`tipoPagoDinero`) USING BTREE,
  INDEX `codBanco`(`codBanco`) USING BTREE,
  CONSTRAINT `tb_prov_registro_ibfk_1` FOREIGN KEY (`codPersonaSolicita`) REFERENCES `tb_conf_personas` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_10` FOREIGN KEY (`codBanco`) REFERENCES `tb_conf_banco` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_2` FOREIGN KEY (`codPersonaInforFiscal`) REFERENCES `tb_conf_personas` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_3` FOREIGN KEY (`codPersonaRepLegal`) REFERENCES `tb_conf_personas` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_4` FOREIGN KEY (`codPersonaContactoComercial`) REFERENCES `tb_conf_personas` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_5` FOREIGN KEY (`codPersonaCobranza`) REFERENCES `tb_conf_personas` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_6` FOREIGN KEY (`tipoMonedaCompra`) REFERENCES `tb_conf_moneda` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_7` FOREIGN KEY (`tiempoPago`) REFERENCES `tb_conf_timepago` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_8` FOREIGN KEY (`tipoDocElectronicoRemite`) REFERENCES `tb_conf_docelectronico` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_prov_registro_ibfk_9` FOREIGN KEY (`tipoPagoDinero`) REFERENCES `tb_conf_tipopago` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_prov_registro
-- ----------------------------

-- ----------------------------
-- Table structure for tb_serv_cabecera
-- ----------------------------
DROP TABLE IF EXISTS `tb_serv_cabecera`;
CREATE TABLE `tb_serv_cabecera`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `desc_corto` varchar(350) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `idBtnSolicitar` int(11) NULL DEFAULT NULL,
  `idBtnConoce` int(11) NULL DEFAULT NULL,
  `Imagen` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsMenu` int(11) NOT NULL COMMENT 'true:Esta en el menu, false: No esta en el menu',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `idBtnSolicitar`(`idBtnSolicitar`) USING BTREE,
  INDEX `idBtnConoce`(`idBtnConoce`) USING BTREE,
  CONSTRAINT `tb_serv_cabecera_ibfk_1` FOREIGN KEY (`idBtnSolicitar`) REFERENCES `tb_conf_botones` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_serv_cabecera_ibfk_2` FOREIGN KEY (`idBtnConoce`) REFERENCES `tb_conf_botones` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_serv_cabecera
-- ----------------------------
INSERT INTO `tb_serv_cabecera` VALUES (1, 'Administracion de estacionamiento', NULL, NULL, NULL, NULL, 1);
INSERT INTO `tb_serv_cabecera` VALUES (2, 'Abonados', NULL, NULL, NULL, NULL, 1);
INSERT INTO `tb_serv_cabecera` VALUES (3, 'VALET PARKING', 'Te ayudamos a que tus colaboradores tengan la tranquilidad de estacionar sin problemas', 6, 7, 'images/Valet-Parking.jpg', 0);
INSERT INTO `tb_serv_cabecera` VALUES (4, 'EVENTOS', 'Tus clientes e invitados solo se preocuparán por pasarla bien. Nosotros nos encargamos de lo demás.', 8, 9, 'images/Mozo2.jpg', 0);
INSERT INTO `tb_serv_cabecera` VALUES (5, 'PREVENCIÓN', 'Te ayudamos a que tus colaboradores tengan la tranquilidad de estacionar sin problemas', 10, 11, 'images/prevencion.jpg', 0);
INSERT INTO `tb_serv_cabecera` VALUES (6, 'RENTABILIZACIÓN DE TERRENOS', 'Tus clientes e invitados solo se preocuparán por pasarla bien. Nosotros nos encargamos de lo demás.', 12, 13, 'images/rentablizaccion.jpg', 0);

-- ----------------------------
-- Table structure for tb_serv_detalle
-- ----------------------------
DROP TABLE IF EXISTS `tb_serv_detalle`;
CREATE TABLE `tb_serv_detalle`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idServicio` int(11) NOT NULL,
  `subtitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `descripcion` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `idBtnSolicitalo` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `idServicio`(`idServicio`) USING BTREE,
  INDEX `idBtnSolicitalo`(`idBtnSolicitalo`) USING BTREE,
  CONSTRAINT `tb_serv_detalle_ibfk_1` FOREIGN KEY (`idServicio`) REFERENCES `tb_serv_cabecera` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_serv_detalle_ibfk_2` FOREIGN KEY (`idBtnSolicitalo`) REFERENCES `tb_conf_botones` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_serv_detalle
-- ----------------------------
INSERT INTO `tb_serv_detalle` VALUES (1, 1, '¿Qué es?', 'Es un service integral donde se garantiza el diseño e implementación de esquemas operativos que controlen y administren eficientemente el flujo vehicular de la playa de estacionamiento, estableciendo políticas tarifarias para el cobro del servicio.', NULL);
INSERT INTO `tb_serv_detalle` VALUES (2, 1, '¿Dónde usarlo?', 'Puede ser usado en estadios, teatros, edificios, universidades, colegios, empresas, hoteles, playas de estacionamiento privadas, centros comerciales y/ o cualquier espacio que cuente con un estacionamiento para administrar.', NULL);
INSERT INTO `tb_serv_detalle` VALUES (3, 2, '¿Qué es?', 'Es una suscripciónessssss para poder tener un espacio donde estacionar en un espacio específico de una localidad específica, la cual puede ser contratada por un mes como mínimo aaaa.', 2);
INSERT INTO `tb_serv_detalle` VALUES (4, 2, '¿Dónde usarlo?', 'Puede ser usado en edificios, universidades, colegios, empresas, hoteles, playas de estacionamiento privadas, centros comerciales y/ o cualquier espacio que cuente con espacios para rentar.', NULL);
INSERT INTO `tb_serv_detalle` VALUES (5, 3, '¿Qué es?', 'Servicio Personalizado ubicado en el ingreso del inmueble; Consiste en estacionar los vehículos de los visitantes y/o clientes en el espacio designado. Cuando el visitante y/o cliente retorna, el personal del valet devuelve su auto a un lugar designado.', NULL);
INSERT INTO `tb_serv_detalle` VALUES (6, 3, '¿Dónde usarlo?', 'Puede ser usado en eventos, hoteles, restaurantes y/ o cualquier espacio que necesite un servicio personalizado para que estacione los vehículos en el espacio asignado.', NULL);
INSERT INTO `tb_serv_detalle` VALUES (7, 4, '¿Qué es?', 'Servicio integral que consiste en el cuidado del espacio para el evento y personal vigilando el ingreso y salida tanto de personas como de vehículos como también de capacitado de valet parking que brinda servicio personalizado para que estacione los vehículos en el espacio asignado', NULL);
INSERT INTO `tb_serv_detalle` VALUES (8, 4, '¿Dónde usarlo?', 'Puede ser usado en hoteles, restaurantes y/ o cualquier espacio privado que necesite un servicio personalizado para la gestión del ingreso y salida de los vehículos en el espacio asignado.', NULL);

-- ----------------------------
-- Table structure for tb_serv_formularios
-- ----------------------------
DROP TABLE IF EXISTS `tb_serv_formularios`;
CREATE TABLE `tb_serv_formularios`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idServicio` int(11) NULL DEFAULT NULL,
  `codUbigeo` char(6) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `idEstacionamiento` int(11) NULL DEFAULT NULL,
  `ruc` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `razonSocial` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `apellidosNombres` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `celular` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `telefono` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `correo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `idServicio`(`idServicio`) USING BTREE,
  INDEX `codUbigeo`(`codUbigeo`) USING BTREE,
  CONSTRAINT `tb_serv_formularios_ibfk_1` FOREIGN KEY (`idServicio`) REFERENCES `tb_serv_cabecera` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `tb_serv_formularios_ibfk_2` FOREIGN KEY (`codUbigeo`) REFERENCES `tb_conf_ubigeo` (`codUbi`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_serv_formularios
-- ----------------------------

-- ----------------------------
-- Table structure for tb_tra_puestos
-- ----------------------------
DROP TABLE IF EXISTS `tb_tra_puestos`;
CREATE TABLE `tb_tra_puestos`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `subtitulo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `requisitos` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ruta` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ocupado` int(11) NULL DEFAULT NULL COMMENT '0: Sin ocupar; 1: ocupado',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_tra_puestos
-- ----------------------------
INSERT INTO `tb_tra_puestos` VALUES (1, 'Agente de Prevención', '¿A QUIÉN BUSCAMOS?', '<li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Personas residentes de los distritos de: Lince, Jesus Maria, Pueblo libre, Cercado de Lima, Surquillo y San Juan de Lurigacho</li><li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Contar con estudios mínimos de secundaria completa.</li><li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Experiencia en atención al cliente.</li><li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Conocimientos de SST (deseable).</li>', NULL, 0);
INSERT INTO `tb_tra_puestos` VALUES (2, 'Valet Parking', '¿A QUIÉN BUSCAMOS?', '<li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Contar con Brevete Vigente desde(AI).</li><li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Récord de Conducir Limpio</li><li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Experiencia mayor a un año en atención al cliente (deseable)</li>', NULL, NULL);
INSERT INTO `tb_tra_puestos` VALUES (3, 'Agente de Servicio', '¿A QUIÉN BUSCAMOS?', '<li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Contar con estudios mínimos de secundaria completa.</li><li class=\"text-start\" style=\"color: rgb(117, 117, 117); font-family: &quot;Work Sans&quot;, sans-serif; background-color: rgb(243, 246, 248); text-align: left !important;\">- Experiencia en atención al cliente</li>', NULL, NULL);

-- ----------------------------
-- Triggers structure for table tb_conf_modalcab
-- ----------------------------
DROP TRIGGER IF EXISTS `tr_actualizar_piepagina`;
delimiter ;;
CREATE TRIGGER `tr_actualizar_piepagina` AFTER UPDATE ON `tb_conf_modalcab` FOR EACH ROW BEGIN
              UPDATE tb_conf_piepaginadet
              SET titulo = NEW.titulo,
                  ruta = NEW.btn_ruta
              WHERE id = NEW.idDetallePie;
            END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;

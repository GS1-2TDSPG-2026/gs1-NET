using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phycocarbon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PERFIL",
                columns: table => new
                {
                    ID_PERFIL = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_PERFIL = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL", x => x.ID_PERFIL);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_PERFIL = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    SENHA_HASH = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FAZENDA",
                columns: table => new
                {
                    ID_FAZENDA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO_RESPONSAVEL = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CIDADE = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    UF = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    LATITUDE = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "DECIMAL(11,7)", precision: 11, scale: 7, nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FAZENDA", x => x.ID_FAZENDA);
                    table.ForeignKey(
                        name: "FK_FAZENDA_USUARIO",
                        column: x => x.ID_USUARIO_RESPONSAVEL,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DADO_ORBITAL",
                columns: table => new
                {
                    ID_DADO_ORBITAL = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_FAZENDA = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FONTE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DT_COLETA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IRRADIANCIA_PAR = table.Column<decimal>(type: "DECIMAL(8,3)", precision: 8, scale: 3, nullable: true),
                    NEBULOSIDADE = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: true),
                    TEMPERATURA_AMBIENTE = table.Column<decimal>(type: "DECIMAL(6,2)", precision: 6, scale: 2, nullable: true),
                    LATITUDE = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "DECIMAL(11,7)", precision: 11, scale: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DADO_ORBITAL", x => x.ID_DADO_ORBITAL);
                    table.ForeignKey(
                        name: "FK_TB_DADO_ORBITAL_TB_FAZENDA_ID_FAZENDA",
                        column: x => x.ID_FAZENDA,
                        principalTable: "TB_FAZENDA",
                        principalColumn: "ID_FAZENDA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TANQUE",
                columns: table => new
                {
                    ID_TANQUE = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_FAZENDA = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CODIGO_TANQUE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TIPO_ALGA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CAPACIDADE_LITROS = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    PH_MIN = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: false),
                    PH_MAX = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: false),
                    TEMPERATURA_MIN = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: false),
                    TEMPERATURA_MAX = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    DT_INSTALACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TANQUE", x => x.ID_TANQUE);
                    table.ForeignKey(
                        name: "FK_TANQUE_FAZENDA",
                        column: x => x.ID_FAZENDA,
                        principalTable: "TB_FAZENDA",
                        principalColumn: "ID_FAZENDA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISPOSITIVO_IOT",
                columns: table => new
                {
                    ID_DISPOSITIVO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_TANQUE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CODIGO_SERIE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TOPICO_MQTT = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ATIVO = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    DT_INSTALACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPOSITIVO_IOT", x => x.ID_DISPOSITIVO);
                    table.ForeignKey(
                        name: "FK_TB_DISPOSITIVO_IOT_TB_TANQUE_ID_TANQUE",
                        column: x => x.ID_TANQUE,
                        principalTable: "TB_TANQUE",
                        principalColumn: "ID_TANQUE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PREVISOES_IA",
                columns: table => new
                {
                    ID_PREVISAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_TANQUE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ID_DADO_ORBITAL = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DT_PREVISAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    BIOMASSA_G_L = table.Column<decimal>(type: "DECIMAL(8,4)", precision: 8, scale: 4, nullable: false),
                    DT_PICO_PREVISTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CONFIANCA_PCT = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: false),
                    MODELO_UTILIZADO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PREVISOES_IA", x => x.ID_PREVISAO);
                    table.ForeignKey(
                        name: "FK_TB_PREVISOES_IA_TB_DADO_ORBITAL_ID_DADO_ORBITAL",
                        column: x => x.ID_DADO_ORBITAL,
                        principalTable: "TB_DADO_ORBITAL",
                        principalColumn: "ID_DADO_ORBITAL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PREVISOES_IA_TB_TANQUE_ID_TANQUE",
                        column: x => x.ID_TANQUE,
                        principalTable: "TB_TANQUE",
                        principalColumn: "ID_TANQUE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_METRICAS_TANQUE",
                columns: table => new
                {
                    ID_METRICA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_DISPOSITIVO = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ID_TANQUE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DT_LEITURA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PH = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: true),
                    TEMPERATURA = table.Column<decimal>(type: "DECIMAL(6,2)", precision: 6, scale: 2, nullable: true),
                    TURBIDEZ = table.Column<decimal>(type: "DECIMAL(8,3)", precision: 8, scale: 3, nullable: true),
                    LUMINOSIDADE = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    PAYLOAD_ORIGINAL = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_METRICAS_TANQUE", x => x.ID_METRICA);
                    table.ForeignKey(
                        name: "FK_TB_METRICAS_TANQUE_TB_DISPOSITIVO_IOT_ID_DISPOSITIVO",
                        column: x => x.ID_DISPOSITIVO,
                        principalTable: "TB_DISPOSITIVO_IOT",
                        principalColumn: "ID_DISPOSITIVO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_METRICAS_TANQUE_TB_TANQUE_ID_TANQUE",
                        column: x => x.ID_TANQUE,
                        principalTable: "TB_TANQUE",
                        principalColumn: "ID_TANQUE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALERTA_CRITICO",
                columns: table => new
                {
                    ID_ALERTA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_METRICA = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ID_TANQUE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TIPO_ALERTA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SEVERIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MENSAGEM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_ALERTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA_CRITICO", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_CRITICO_TB_METRICAS_TANQUE_ID_METRICA",
                        column: x => x.ID_METRICA,
                        principalTable: "TB_METRICAS_TANQUE",
                        principalColumn: "ID_METRICA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_CRITICO_TB_TANQUE_ID_TANQUE",
                        column: x => x.ID_TANQUE,
                        principalTable: "TB_TANQUE",
                        principalColumn: "ID_TANQUE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_CRITICO_ID_METRICA",
                table: "TB_ALERTA_CRITICO",
                column: "ID_METRICA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_CRITICO_ID_TANQUE",
                table: "TB_ALERTA_CRITICO",
                column: "ID_TANQUE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DADO_ORBITAL_ID_FAZENDA",
                table: "TB_DADO_ORBITAL",
                column: "ID_FAZENDA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DISPOSITIVO_IOT_ID_TANQUE",
                table: "TB_DISPOSITIVO_IOT",
                column: "ID_TANQUE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FAZENDA_ID_USUARIO_RESPONSAVEL",
                table: "TB_FAZENDA",
                column: "ID_USUARIO_RESPONSAVEL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_METRICAS_TANQUE_ID_DISPOSITIVO",
                table: "TB_METRICAS_TANQUE",
                column: "ID_DISPOSITIVO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_METRICAS_TANQUE_ID_TANQUE",
                table: "TB_METRICAS_TANQUE",
                column: "ID_TANQUE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_NOME_PERFIL",
                table: "TB_PERFIL",
                column: "NOME_PERFIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PREVISOES_IA_ID_DADO_ORBITAL",
                table: "TB_PREVISOES_IA",
                column: "ID_DADO_ORBITAL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PREVISOES_IA_ID_TANQUE",
                table: "TB_PREVISOES_IA",
                column: "ID_TANQUE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TANQUE_ID_FAZENDA",
                table: "TB_TANQUE",
                column: "ID_FAZENDA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_EMAIL",
                table: "TB_USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_ID_PERFIL",
                table: "TB_USUARIO",
                column: "ID_PERFIL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALERTA_CRITICO");

            migrationBuilder.DropTable(
                name: "TB_PREVISOES_IA");

            migrationBuilder.DropTable(
                name: "TB_METRICAS_TANQUE");

            migrationBuilder.DropTable(
                name: "TB_DADO_ORBITAL");

            migrationBuilder.DropTable(
                name: "TB_DISPOSITIVO_IOT");

            migrationBuilder.DropTable(
                name: "TB_TANQUE");

            migrationBuilder.DropTable(
                name: "TB_FAZENDA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_PERFIL");
        }
    }
}

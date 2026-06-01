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
                    id_perfil = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    nome_perfil = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL", x => x.id_perfil);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    id_usuario = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_perfil = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    senha_hash = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_TB_PERFIL_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "TB_PERFIL",
                        principalColumn: "id_perfil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FAZENDA",
                columns: table => new
                {
                    id_fazenda = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_usuario_responsavel = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    latitude = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    longitude = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    dt_cadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FAZENDA", x => x.id_fazenda);
                    table.ForeignKey(
                        name: "FK_TB_FAZENDA_TB_USUARIO_id_usuario_responsavel",
                        column: x => x.id_usuario_responsavel,
                        principalTable: "TB_USUARIO",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DADO_ORBITAL",
                columns: table => new
                {
                    id_dado_orbital = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_fazenda = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    fonte = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    dt_coleta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    irradiancia_par = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    nebulosidade = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: true),
                    temperatura_ambiente = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: true),
                    latitude = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    longitude = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DADO_ORBITAL", x => x.id_dado_orbital);
                    table.ForeignKey(
                        name: "FK_TB_DADO_ORBITAL_TB_FAZENDA_id_fazenda",
                        column: x => x.id_fazenda,
                        principalTable: "TB_FAZENDA",
                        principalColumn: "id_fazenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TANQUE",
                columns: table => new
                {
                    id_tanque = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_fazenda = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    codigo_tanque = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    tipo_alga = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    capacidade_litros = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    ph_min = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: false),
                    ph_max = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: false),
                    temperatura_min = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: false),
                    temperatura_max = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    dt_instalacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TANQUE", x => x.id_tanque);
                    table.ForeignKey(
                        name: "FK_TB_TANQUE_TB_FAZENDA_id_fazenda",
                        column: x => x.id_fazenda,
                        principalTable: "TB_FAZENDA",
                        principalColumn: "id_fazenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISPOSITIVO_IOT",
                columns: table => new
                {
                    id_dispositivo = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_tanque = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    codigo_serie = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    topico_mqtt = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    modelo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ativo = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    dt_instalacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPOSITIVO_IOT", x => x.id_dispositivo);
                    table.ForeignKey(
                        name: "FK_TB_DISPOSITIVO_IOT_TB_TANQUE_id_tanque",
                        column: x => x.id_tanque,
                        principalTable: "TB_TANQUE",
                        principalColumn: "id_tanque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PREVISOES_IA",
                columns: table => new
                {
                    id_previsao = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_tanque = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_dado_orbital = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    dt_previsao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    biomassa_gl = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    dt_pico_previsto = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    confianca_pct = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: false),
                    modelo_utilizado = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PREVISOES_IA", x => x.id_previsao);
                    table.ForeignKey(
                        name: "FK_TB_PREVISOES_IA_TB_DADO_ORBITAL_id_dado_orbital",
                        column: x => x.id_dado_orbital,
                        principalTable: "TB_DADO_ORBITAL",
                        principalColumn: "id_dado_orbital",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PREVISOES_IA_TB_TANQUE_id_tanque",
                        column: x => x.id_tanque,
                        principalTable: "TB_TANQUE",
                        principalColumn: "id_tanque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_METRICAS_TANQUE",
                columns: table => new
                {
                    id_metrica = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_dispositivo = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_tanque = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    dt_leitura = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ph = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: true),
                    temperatura = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: true),
                    turbidez = table.Column<decimal>(type: "DECIMAL(4,2)", precision: 4, scale: 2, nullable: true),
                    luminosidade = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    payload_original = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_METRICAS_TANQUE", x => x.id_metrica);
                    table.ForeignKey(
                        name: "FK_TB_METRICAS_TANQUE_TB_DISPOSITIVO_IOT_id_dispositivo",
                        column: x => x.id_dispositivo,
                        principalTable: "TB_DISPOSITIVO_IOT",
                        principalColumn: "id_dispositivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_METRICAS_TANQUE_TB_TANQUE_id_tanque",
                        column: x => x.id_tanque,
                        principalTable: "TB_TANQUE",
                        principalColumn: "id_tanque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALERTA_CRITICO",
                columns: table => new
                {
                    id_alerta = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_metrica = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    id_tanque = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    tipo_alerta = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    severidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    mensagem = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    dt_alerta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA_CRITICO", x => x.id_alerta);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_CRITICO_TB_METRICAS_TANQUE_id_metrica",
                        column: x => x.id_metrica,
                        principalTable: "TB_METRICAS_TANQUE",
                        principalColumn: "id_metrica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ALERTA_CRITICO_TB_TANQUE_id_tanque",
                        column: x => x.id_tanque,
                        principalTable: "TB_TANQUE",
                        principalColumn: "id_tanque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_CRITICO_id_metrica",
                table: "TB_ALERTA_CRITICO",
                column: "id_metrica");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTA_CRITICO_id_tanque",
                table: "TB_ALERTA_CRITICO",
                column: "id_tanque");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DADO_ORBITAL_id_fazenda",
                table: "TB_DADO_ORBITAL",
                column: "id_fazenda");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DISPOSITIVO_IOT_id_tanque",
                table: "TB_DISPOSITIVO_IOT",
                column: "id_tanque");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FAZENDA_id_usuario_responsavel",
                table: "TB_FAZENDA",
                column: "id_usuario_responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_TB_METRICAS_TANQUE_id_dispositivo",
                table: "TB_METRICAS_TANQUE",
                column: "id_dispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_TB_METRICAS_TANQUE_id_tanque",
                table: "TB_METRICAS_TANQUE",
                column: "id_tanque");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_nome_perfil",
                table: "TB_PERFIL",
                column: "nome_perfil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PREVISOES_IA_id_dado_orbital",
                table: "TB_PREVISOES_IA",
                column: "id_dado_orbital");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PREVISOES_IA_id_tanque",
                table: "TB_PREVISOES_IA",
                column: "id_tanque");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TANQUE_id_fazenda",
                table: "TB_TANQUE",
                column: "id_fazenda");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_email",
                table: "TB_USUARIO",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_id_perfil",
                table: "TB_USUARIO",
                column: "id_perfil");
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

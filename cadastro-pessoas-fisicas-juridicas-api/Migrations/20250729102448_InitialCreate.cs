using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cadastro_pessoas_fisicas_juridicas_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa_fisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Rg = table.Column<string>(type: "text", nullable: false),
                    OrgaoEmissor = table.Column<string>(type: "text", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NomePai = table.Column<string>(type: "text", nullable: false),
                    NomeMae = table.Column<string>(type: "text", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "boolean", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa_fisica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa_juridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazaoSocial = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    EhMatriz = table.Column<bool>(type: "boolean", nullable: false),
                    RamoAtividade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa_juridica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Uf = table.Column<string>(type: "text", nullable: false),
                    PessoaFisicaId = table.Column<int>(type: "integer", nullable: true),
                    PessoaJuridicaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endereco_pessoa_fisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "pessoa_fisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_endereco_pessoa_juridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "pessoa_juridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "presenca_online",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    FacebookUrl = table.Column<string>(type: "text", nullable: true),
                    InstagramUrl = table.Column<string>(type: "text", nullable: true),
                    TwitterUrl = table.Column<string>(type: "text", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "text", nullable: true),
                    PessoaFisicaId = table.Column<int>(type: "integer", nullable: true),
                    PessoaJuridicaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presenca_online", x => x.Id);
                    table.ForeignKey(
                        name: "FK_presenca_online_pessoa_fisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "pessoa_fisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_presenca_online_pessoa_juridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "pessoa_juridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ddd = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Assunto = table.Column<string>(type: "text", nullable: true),
                    FalarCom = table.Column<string>(type: "text", nullable: true),
                    EhWhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    PessoaFisicaId = table.Column<int>(type: "integer", nullable: true),
                    PessoaJuridicaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_telefone_pessoa_fisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "pessoa_fisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_telefone_pessoa_juridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "pessoa_juridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_endereco_PessoaFisicaId",
                table: "endereco",
                column: "PessoaFisicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_endereco_PessoaJuridicaId",
                table: "endereco",
                column: "PessoaJuridicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_presenca_online_PessoaFisicaId",
                table: "presenca_online",
                column: "PessoaFisicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_presenca_online_PessoaJuridicaId",
                table: "presenca_online",
                column: "PessoaJuridicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_telefone_PessoaFisicaId",
                table: "telefone",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_telefone_PessoaJuridicaId",
                table: "telefone",
                column: "PessoaJuridicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "presenca_online");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "pessoa_fisica");

            migrationBuilder.DropTable(
                name: "pessoa_juridica");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.TI.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class filaemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdExterno",
                table: "Usuarios",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("82a53fee-2088-4b94-a7cc-934cde30eb45"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("7ca08c48-0ab4-440d-b529-54cc1c210a2c"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdExterno",
                table: "Empresas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("4f4291e4-e929-4312-86d8-064249d7d5e8"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("a8357583-9988-4943-be83-9bc7db4dcbe4"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "FilaEmails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataEnvio = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Destinatario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Assunto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mensagem = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUsuarioCriacao = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilaEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilaEmails_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FilaEmails_IdEmpresa",
                table: "FilaEmails",
                column: "IdEmpresa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilaEmails");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdExterno",
                table: "Usuarios",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("7ca08c48-0ab4-440d-b529-54cc1c210a2c"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("82a53fee-2088-4b94-a7cc-934cde30eb45"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdExterno",
                table: "Empresas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("a8357583-9988-4943-be83-9bc7db4dcbe4"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("4f4291e4-e929-4312-86d8-064249d7d5e8"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}

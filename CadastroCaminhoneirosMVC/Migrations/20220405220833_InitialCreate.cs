using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroCaminhoneirosMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaminhaoMotorista_Motorista_MotoristaId",
                table: "CaminhaoMotorista");

            migrationBuilder.AlterColumn<int>(
                name: "MotoristaId",
                table: "CaminhaoMotorista",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaminhaoMotorista_Motorista_MotoristaId",
                table: "CaminhaoMotorista",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaminhaoMotorista_Motorista_MotoristaId",
                table: "CaminhaoMotorista");

            migrationBuilder.AlterColumn<int>(
                name: "MotoristaId",
                table: "CaminhaoMotorista",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CaminhaoMotorista_Motorista_MotoristaId",
                table: "CaminhaoMotorista",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

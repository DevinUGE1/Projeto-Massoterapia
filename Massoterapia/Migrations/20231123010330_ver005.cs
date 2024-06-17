using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Massoterapia.Migrations
{
    /// <inheritdoc />
    public partial class ver005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Profissionais");

            migrationBuilder.AddColumn<bool>(
                name: "Amaromaterapia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Auriculoterapia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BambuTerapia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cromoterapia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoIn",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DrenagemLinfatica",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MassagemDesportiva",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MassagemModeladora",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MassagemRelaxante",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Maxoterapia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PedrasQuentes",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QuickMassagem",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reflexologia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shiatsu",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShiatsuDaCadeira",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TemAKinesioTape",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VentoSaterapia",
                table: "RegistroViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Amaromaterapia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Auriculoterapia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BambuTerapia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cromoterapia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoIn",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DrenagemLinfatica",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MassagemDesportiva",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MassagemModeladora",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MassagemRelaxante",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Maxoterapia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedrasQuentes",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuickMassagem",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reflexologia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Shiatsu",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiatsuDaCadeira",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemAKinesioTape",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VentoSaterapia",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amaromaterapia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Auriculoterapia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "BambuTerapia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Cromoterapia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "DoIn",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "DrenagemLinfatica",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "MassagemDesportiva",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "MassagemModeladora",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "MassagemRelaxante",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Maxoterapia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "PedrasQuentes",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "QuickMassagem",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Reflexologia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Shiatsu",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "ShiatsuDaCadeira",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "TemAKinesioTape",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "VentoSaterapia",
                table: "RegistroViewModel");

            migrationBuilder.DropColumn(
                name: "Amaromaterapia",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Auriculoterapia",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "BambuTerapia",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Cromoterapia",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "DoIn",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "DrenagemLinfatica",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "MassagemDesportiva",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "MassagemModeladora",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "MassagemRelaxante",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Maxoterapia",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "PedrasQuentes",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "QuickMassagem",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Reflexologia",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Shiatsu",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "ShiatsuDaCadeira",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "TemAKinesioTape",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "VentoSaterapia",
                table: "Profissionais");

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "RegistroViewModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Profissionais",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}

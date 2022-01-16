using Microsoft.EntityFrameworkCore.Migrations;

namespace Elections.Data.Migrations
{
    public partial class AddIDInVoterModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotersPhonesInElections_Voters_VoterID",
                table: "VotersPhonesInElections");

            migrationBuilder.AlterColumn<int>(
                name: "VoterID",
                table: "VotersPhonesInElections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VotersPhonesInElections_Voters_VoterID",
                table: "VotersPhonesInElections",
                column: "VoterID",
                principalTable: "Voters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotersPhonesInElections_Voters_VoterID",
                table: "VotersPhonesInElections");

            migrationBuilder.AlterColumn<int>(
                name: "VoterID",
                table: "VotersPhonesInElections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VotersPhonesInElections_Voters_VoterID",
                table: "VotersPhonesInElections",
                column: "VoterID",
                principalTable: "Voters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

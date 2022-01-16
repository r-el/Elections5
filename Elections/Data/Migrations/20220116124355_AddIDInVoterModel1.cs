using Microsoft.EntityFrameworkCore.Migrations;

namespace Elections.Data.Migrations
{
    public partial class AddIDInVoterModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "VotersPhonesInElections");

            migrationBuilder.AddColumn<int>(
                name: "VoterID",
                table: "VotersPhonesInElections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotersPhonesInElections_VoterID",
                table: "VotersPhonesInElections",
                column: "VoterID");

            migrationBuilder.AddForeignKey(
                name: "FK_VotersPhonesInElections_Voters_VoterID",
                table: "VotersPhonesInElections",
                column: "VoterID",
                principalTable: "Voters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotersPhonesInElections_Voters_VoterID",
                table: "VotersPhonesInElections");

            migrationBuilder.DropIndex(
                name: "IX_VotersPhonesInElections_VoterID",
                table: "VotersPhonesInElections");

            migrationBuilder.DropColumn(
                name: "VoterID",
                table: "VotersPhonesInElections");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "VotersPhonesInElections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

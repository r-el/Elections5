using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elections.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stam",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StamString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StamInt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stam", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    PhoneID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.PhoneID);
                });

            migrationBuilder.CreateTable(
                name: "VotingAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPossibleToChangeAVote = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Elections_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectionsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidates_Elections_ElectionsID",
                        column: x => x.ElectionsID,
                        principalTable: "Elections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VotersPhonesInElections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectionsID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VotingAreaID = table.Column<int>(type: "int", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotersPhonesInElections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VotersPhonesInElections_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VotersPhonesInElections_Elections_ElectionsID",
                        column: x => x.ElectionsID,
                        principalTable: "Elections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotersPhonesInElections_VotingAreas_VotingAreaID",
                        column: x => x.VotingAreaID,
                        principalTable: "VotingAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterPhoneInElectionsID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Problems_VotersPhonesInElections_VoterPhoneInElectionsID",
                        column: x => x.VoterPhoneInElectionsID,
                        principalTable: "VotersPhonesInElections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemNotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    VisitorPhoneID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProblemNotes_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ElectionsID",
                table: "Candidates",
                column: "ElectionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_ManagerID",
                table: "Elections",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemNotes_ProblemID",
                table: "ProblemNotes",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_VoterPhoneInElectionsID",
                table: "Problems",
                column: "VoterPhoneInElectionsID");

            migrationBuilder.CreateIndex(
                name: "IX_VotersPhonesInElections_CandidateID",
                table: "VotersPhonesInElections",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_VotersPhonesInElections_ElectionsID",
                table: "VotersPhonesInElections",
                column: "ElectionsID");

            migrationBuilder.CreateIndex(
                name: "IX_VotersPhonesInElections_VotingAreaID",
                table: "VotersPhonesInElections",
                column: "VotingAreaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemNotes");

            migrationBuilder.DropTable(
                name: "Stam");

            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "VotersPhonesInElections");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "VotingAreas");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}

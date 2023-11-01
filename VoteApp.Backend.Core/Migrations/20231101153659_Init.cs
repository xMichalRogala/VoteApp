using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoteApp.Backend.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "Candidates",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    VoterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Core",
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Voters_VoterId",
                        column: x => x.VoterId,
                        principalSchema: "Core",
                        principalTable: "Voters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Candidates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alpha" },
                    { 2, "Charlie" },
                    { 3, "Beta" },
                    { 4, "Delta" },
                    { 5, "Omega" }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Voters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alpha" },
                    { 2, "Charlie" },
                    { 3, "Beta" },
                    { 4, "Delta" },
                    { 5, "Omega" }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Votes",
                columns: new[] { "Id", "CandidateId", "VoterId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Name",
                schema: "Core",
                table: "Candidates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voters_Name",
                schema: "Core",
                table: "Voters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CandidateId",
                schema: "Core",
                table: "Votes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId",
                schema: "Core",
                table: "Votes",
                column: "VoterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId_CandidateId",
                schema: "Core",
                table: "Votes",
                columns: new[] { "VoterId", "CandidateId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Candidates",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Voters",
                schema: "Core");
        }
    }
}

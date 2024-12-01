using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Material_Code",
                table: "ProposalMaterials",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalMaterials_ProposalId",
                table: "ProposalMaterials",
                column: "ProposalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalMaterials_Proposals_ProposalId",
                table: "ProposalMaterials",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalMaterials_Proposals_ProposalId",
                table: "ProposalMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProposalMaterials_ProposalId",
                table: "ProposalMaterials");

            migrationBuilder.AlterColumn<string>(
                name: "Material_Code",
                table: "ProposalMaterials",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }
    }
}

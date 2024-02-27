using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fyp.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class changedlabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "KycDetails",
                newName: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userID",
                table: "KycDetails",
                newName: "ID");
        }
    }
}

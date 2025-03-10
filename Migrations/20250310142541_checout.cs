using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookish.Migrations
{
    /// <inheritdoc />
    public partial class checout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOut_BookCopy_CopyId",
                table: "CheckOut");

            migrationBuilder.DropIndex(
                name: "IX_CheckOut_CopyId",
                table: "CheckOut");

            migrationBuilder.AddColumn<int>(
                name: "BookCopyCopyId",
                table: "CheckOut",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Late",
                table: "CheckOut",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_BookCopyCopyId",
                table: "CheckOut",
                column: "BookCopyCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOut_BookCopy_BookCopyCopyId",
                table: "CheckOut",
                column: "BookCopyCopyId",
                principalTable: "BookCopy",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOut_BookCopy_BookCopyCopyId",
                table: "CheckOut");

            migrationBuilder.DropIndex(
                name: "IX_CheckOut_BookCopyCopyId",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "BookCopyCopyId",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "Late",
                table: "CheckOut");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_CopyId",
                table: "CheckOut",
                column: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOut_BookCopy_CopyId",
                table: "CheckOut",
                column: "CopyId",
                principalTable: "BookCopy",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

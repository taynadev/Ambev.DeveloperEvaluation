using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class FixCartProductFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Carts_CartId1",
                table: "CartProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_CartId1",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "CartProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CartId1",
                table: "CartProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId1",
                table: "CartProducts",
                column: "CartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Carts_CartId1",
                table: "CartProducts",
                column: "CartId1",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

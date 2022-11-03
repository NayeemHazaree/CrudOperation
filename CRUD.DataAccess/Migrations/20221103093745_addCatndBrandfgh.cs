using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.DataAccess.Migrations
{
    public partial class addCatndBrandfgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Category_CategoryId",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_CategoryId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Brand",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Brand_CategoryId",
                table: "Brand",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Category_CategoryId",
                table: "Brand",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

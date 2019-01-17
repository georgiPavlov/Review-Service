using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryData.Migrations
{
    public partial class InitialMigration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hold_LibraryAssets_LibraryAssetId",
                table: "Hold");

            migrationBuilder.DropForeignKey(
                name: "FK_Hold_LibraryCards_LibraryCardId",
                table: "Hold");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hold",
                table: "Hold");

            migrationBuilder.RenameTable(
                name: "Hold",
                newName: "Holds");

            migrationBuilder.RenameIndex(
                name: "IX_Hold_LibraryCardId",
                table: "Holds",
                newName: "IX_Holds_LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Hold_LibraryAssetId",
                table: "Holds",
                newName: "IX_Holds_LibraryAssetId");

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Checkouts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holds",
                table: "Holds",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Fees = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MoviesId",
                table: "Checkouts",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Movies_MoviesId",
                table: "Checkouts",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryAssets_LibraryAssetId",
                table: "Holds",
                column: "LibraryAssetId",
                principalTable: "LibraryAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardId",
                table: "Holds",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Movies_MoviesId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryAssets_LibraryAssetId",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardId",
                table: "Holds");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holds",
                table: "Holds");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_MoviesId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Checkouts");

            migrationBuilder.RenameTable(
                name: "Holds",
                newName: "Hold");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_LibraryCardId",
                table: "Hold",
                newName: "IX_Hold_LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_LibraryAssetId",
                table: "Hold",
                newName: "IX_Hold_LibraryAssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hold",
                table: "Hold",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hold_LibraryAssets_LibraryAssetId",
                table: "Hold",
                column: "LibraryAssetId",
                principalTable: "LibraryAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hold_LibraryCards_LibraryCardId",
                table: "Hold",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

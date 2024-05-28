﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class newFieldForAttestationViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Attestations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Attestations");
        }
    }
}

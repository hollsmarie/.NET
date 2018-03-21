using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class ModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");
        }
    }
}

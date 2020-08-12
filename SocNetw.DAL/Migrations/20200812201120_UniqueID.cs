using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocNetw.DAL.Migrations
{
    public partial class UniqueID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UniqueID",
                table: "Accounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueID",
                table: "Accounts");
        }
    }
}

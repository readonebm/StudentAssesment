using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAssesment.Migrations
{
    public partial class AddDataStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NIM = table.Column<long>(type: "bigint", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nilai = table.Column<long>(type: "bigint", nullable: false),
                    Catatan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

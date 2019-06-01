using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace curs_2_webapi.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Taskuri",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Title = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: false),
            //        Deadline = table.Column<DateTime>(nullable: false),
            //        ClosedAt = table.Column<DateTime>(nullable: true),
            //        Status = table.Column<int>(nullable: false),
            //        TaskImportance = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Taskuri", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Comments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Text = table.Column<string>(nullable: true),
            //        Important = table.Column<bool>(nullable: false),
            //        TaskulId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Comments_Taskuri_TaskulId",
            //            column: x => x.TaskulId,
            //            principalTable: "Taskuri",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comments_TaskulId",
            //    table: "Comments",
            //    column: "TaskulId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Taskuri");
        }
    }
}

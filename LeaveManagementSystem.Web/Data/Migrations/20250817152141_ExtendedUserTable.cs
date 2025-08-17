using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297d438f-7cf3-4f90-84a9-8598959e95bb",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18ce9cff-3d70-492e-825b-148c438f1792", new DateOnly(1990, 1, 1), "System", "Administrator", "AQAAAAIAAYagAAAAEHN2Vy6qSRXTKCU3fuwS/0L69zfQjCyVYwJu+bGnZj7SPGLmOllIxMYnbSls2g+N1w==", "de7ef546-4907-43a2-ab79-43ce89b886ec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297d438f-7cf3-4f90-84a9-8598959e95bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1dad8e7-b894-4f8a-8564-e65db91ab6f5", "AQAAAAIAAYagAAAAEPIYpejnCN1M9zoaJSsNzt4P3mPyyjnm6M0+J5upO/O22vY5KmZoAeDj/OMC9bHIVg==", "cc031fb8-70a1-4c20-a981-86539d7281fb" });
        }
    }
}

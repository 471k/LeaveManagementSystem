using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297d438f-7cf3-4f90-84a9-8598959e95bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f54040e-c240-44f0-bff7-a28eed1acfc4", "AQAAAAIAAYagAAAAEGnuT0U+2qofilrHDQ595Fw8CjkchCQJRW2eL6uVgZIujUM0EVM89Mbzj3FMVV18zA==", "1b4efb6a-0325-4485-b4b4-95e061489063" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297d438f-7cf3-4f90-84a9-8598959e95bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95f1b2b3-c5bd-4134-8de3-d853ef8f23cb", "AQAAAAIAAYagAAAAEOFPeDoV6dd9llJnkqU6Nwh4NH44ALL4GIWOOA0y09fsFvMXj/oCCnQtu8jwYY9hUA==", "91c745c3-c4aa-436b-ab7f-363f7921caea" });
        }
    }
}

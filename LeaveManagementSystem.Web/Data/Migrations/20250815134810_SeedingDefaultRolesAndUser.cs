using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cf65df1-597c-447e-9e47-208ae83f4aea", null, "Employee", "EMPLOYEE" },
                    { "7e336a5a-3f08-4d8c-986e-17e6d5233b90", null, "Supervisor", "SUPERVISOR" },
                    { "c2909634-c00e-4491-b6ac-1de88f7eeef1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "297d438f-7cf3-4f90-84a9-8598959e95bb", 0, "a1dad8e7-b894-4f8a-8564-e65db91ab6f5", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPIYpejnCN1M9zoaJSsNzt4P3mPyyjnm6M0+J5upO/O22vY5KmZoAeDj/OMC9bHIVg==", null, false, "cc031fb8-70a1-4c20-a981-86539d7281fb", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c2909634-c00e-4491-b6ac-1de88f7eeef1", "297d438f-7cf3-4f90-84a9-8598959e95bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cf65df1-597c-447e-9e47-208ae83f4aea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e336a5a-3f08-4d8c-986e-17e6d5233b90");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2909634-c00e-4491-b6ac-1de88f7eeef1", "297d438f-7cf3-4f90-84a9-8598959e95bb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2909634-c00e-4491-b6ac-1de88f7eeef1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297d438f-7cf3-4f90-84a9-8598959e95bb");
        }
    }
}

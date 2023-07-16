using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addtables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "RefreshTokens",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserOperationClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UserOperationClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserOperationClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OperationClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "OperationClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OperationClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Models",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Models",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Models",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status", "UpdatedDate" },
                values: new object[] { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.com", "Admin", "NArchitecture", new byte[] { 130, 85, 129, 88, 89, 251, 25, 70, 125, 201, 40, 102, 10, 146, 133, 217, 169, 145, 127, 143, 61, 19, 140, 182, 118, 5, 149, 223, 222, 35, 123, 151, 247, 245, 33, 221, 218, 217, 139, 223, 209, 205, 81, 156, 53, 116, 33, 34, 47, 191, 113, 3, 95, 164, 182, 54, 20, 159, 88, 183, 73, 250, 189, 201 }, new byte[] { 109, 118, 75, 231, 254, 82, 111, 13, 216, 254, 140, 47, 189, 163, 44, 65, 77, 107, 109, 255, 64, 221, 253, 163, 32, 195, 112, 80, 137, 209, 9, 104, 134, 166, 132, 136, 192, 143, 54, 208, 118, 115, 222, 236, 13, 67, 99, 178, 102, 217, 33, 93, 231, 219, 10, 39, 132, 86, 230, 226, 211, 162, 68, 242, 149, 85, 164, 42, 195, 8, 4, 1, 55, 17, 31, 97, 151, 101, 86, 64, 200, 193, 16, 82, 182, 192, 116, 115, 173, 228, 185, 163, 184, 35, 75, 222, 192, 196, 240, 165, 188, 146, 125, 121, 73, 78, 172, 158, 101, 252, 233, 236, 182, 83, 80, 182, 130, 251, 225, 78, 200, 209, 67, 40, 112, 61, 56, 49 }, true, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "RefreshTokens",
                newName: "Created");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "BMW" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Mercedes" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[] { 1, 1, 1500m, "", "Series 4" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[] { 2, 1, 1200m, "", "Series 3" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[] { 3, 2, 1000m, "", "A180" });
        }
    }
}

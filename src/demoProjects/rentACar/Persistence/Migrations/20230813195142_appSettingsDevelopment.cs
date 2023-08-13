﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class appSettingsDevelopment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 62, 23, 184, 238, 48, 142, 47, 246, 154, 118, 226, 121, 66, 185, 165, 219, 200, 159, 29, 57, 22, 163, 95, 210, 165, 116, 241, 47, 193, 166, 137, 186, 185, 73, 63, 240, 156, 64, 29, 13, 94, 240, 208, 254, 98, 21, 49, 2, 62, 69, 168, 227, 203, 144, 92, 174, 246, 252, 122, 179, 197, 20, 246, 106 }, new byte[] { 205, 146, 2, 251, 76, 102, 114, 15, 56, 67, 13, 133, 162, 46, 103, 197, 114, 128, 143, 10, 163, 0, 43, 47, 66, 171, 198, 69, 108, 235, 47, 171, 118, 194, 95, 212, 184, 212, 29, 240, 14, 10, 123, 117, 136, 157, 38, 52, 125, 5, 155, 110, 172, 150, 219, 232, 212, 161, 106, 62, 130, 91, 85, 23, 114, 214, 57, 152, 234, 80, 225, 140, 254, 128, 17, 19, 52, 114, 166, 133, 137, 94, 22, 122, 243, 164, 47, 94, 220, 74, 186, 252, 216, 189, 225, 254, 236, 3, 76, 178, 56, 104, 193, 118, 46, 213, 28, 203, 222, 163, 29, 232, 194, 202, 9, 62, 10, 211, 182, 197, 165, 117, 213, 116, 163, 137, 90, 13 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 50, 9, 255, 159, 4, 79, 28, 144, 200, 169, 238, 28, 54, 54, 12, 34, 244, 166, 9, 33, 152, 32, 194, 197, 217, 255, 210, 38, 219, 147, 253, 91, 8, 125, 157, 136, 154, 30, 30, 181, 29, 126, 128, 52, 99, 192, 69, 107, 237, 24, 117, 33, 154, 21, 6, 7, 119, 35, 125, 208, 206, 104, 242, 29 }, new byte[] { 32, 212, 179, 187, 29, 131, 197, 98, 57, 163, 191, 94, 193, 200, 208, 120, 20, 31, 6, 131, 217, 189, 34, 148, 12, 39, 216, 80, 14, 193, 118, 57, 122, 14, 83, 200, 235, 99, 204, 240, 110, 44, 186, 172, 6, 232, 218, 174, 99, 155, 9, 108, 138, 190, 136, 141, 153, 213, 182, 49, 72, 25, 246, 157, 56, 100, 205, 168, 174, 79, 1, 52, 252, 3, 14, 41, 79, 155, 87, 241, 45, 28, 73, 112, 177, 157, 194, 103, 74, 68, 153, 122, 194, 164, 38, 139, 140, 170, 136, 208, 225, 196, 137, 33, 198, 89, 83, 241, 121, 25, 97, 9, 245, 42, 173, 141, 96, 163, 205, 136, 11, 245, 235, 28, 58, 210, 233, 139 } });
        }
    }
}

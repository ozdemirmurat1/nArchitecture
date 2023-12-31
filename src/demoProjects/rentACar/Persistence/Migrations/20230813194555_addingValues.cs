﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addingValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 50, 9, 255, 159, 4, 79, 28, 144, 200, 169, 238, 28, 54, 54, 12, 34, 244, 166, 9, 33, 152, 32, 194, 197, 217, 255, 210, 38, 219, 147, 253, 91, 8, 125, 157, 136, 154, 30, 30, 181, 29, 126, 128, 52, 99, 192, 69, 107, 237, 24, 117, 33, 154, 21, 6, 7, 119, 35, 125, 208, 206, 104, 242, 29 }, new byte[] { 32, 212, 179, 187, 29, 131, 197, 98, 57, 163, 191, 94, 193, 200, 208, 120, 20, 31, 6, 131, 217, 189, 34, 148, 12, 39, 216, 80, 14, 193, 118, 57, 122, 14, 83, 200, 235, 99, 204, 240, 110, 44, 186, 172, 6, 232, 218, 174, 99, 155, 9, 108, 138, 190, 136, 141, 153, 213, 182, 49, 72, 25, 246, 157, 56, 100, 205, 168, 174, 79, 1, 52, 252, 3, 14, 41, 79, 155, 87, 241, 45, 28, 73, 112, 177, 157, 194, 103, 74, 68, 153, 122, 194, 164, 38, 139, 140, 170, 136, 208, 225, 196, 137, 33, 198, 89, 83, 241, 121, 25, 97, 9, 245, 42, 173, 141, 96, 163, 205, 136, 11, 245, 235, 28, 58, 210, 233, 139 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 85, 129, 88, 89, 251, 25, 70, 125, 201, 40, 102, 10, 146, 133, 217, 169, 145, 127, 143, 61, 19, 140, 182, 118, 5, 149, 223, 222, 35, 123, 151, 247, 245, 33, 221, 218, 217, 139, 223, 209, 205, 81, 156, 53, 116, 33, 34, 47, 191, 113, 3, 95, 164, 182, 54, 20, 159, 88, 183, 73, 250, 189, 201 }, new byte[] { 109, 118, 75, 231, 254, 82, 111, 13, 216, 254, 140, 47, 189, 163, 44, 65, 77, 107, 109, 255, 64, 221, 253, 163, 32, 195, 112, 80, 137, 209, 9, 104, 134, 166, 132, 136, 192, 143, 54, 208, 118, 115, 222, 236, 13, 67, 99, 178, 102, 217, 33, 93, 231, 219, 10, 39, 132, 86, 230, 226, 211, 162, 68, 242, 149, 85, 164, 42, 195, 8, 4, 1, 55, 17, 31, 97, 151, 101, 86, 64, 200, 193, 16, 82, 182, 192, 116, 115, 173, 228, 185, 163, 184, 35, 75, 222, 192, 196, 240, 165, 188, 146, 125, 121, 73, 78, 172, 158, 101, 252, 233, 236, 182, 83, 80, 182, 130, 251, 225, 78, 200, 209, 67, 40, 112, 61, 56, 49 } });
        }
    }
}

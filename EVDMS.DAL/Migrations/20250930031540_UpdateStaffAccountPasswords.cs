using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVDMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStaffAccountPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0002-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0003-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0004-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0005-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0006-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0007-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0008-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0009-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-000a-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0002-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0003-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0004-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0005-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0006-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0007-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0008-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0009-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("00000002-000a-0000-0000-000000000000"),
                column: "HashedPassword",
                value: "hash");
        }
    }
}

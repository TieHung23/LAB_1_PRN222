using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVDMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_ImgUrl_To_VehicleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Dealers_DealerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "VehicleModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0001-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0002-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0003-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0004-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0005-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Dealers_DealerId",
                table: "Accounts",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Dealers_DealerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "VehicleModels");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Dealers_DealerId",
                table: "Accounts",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

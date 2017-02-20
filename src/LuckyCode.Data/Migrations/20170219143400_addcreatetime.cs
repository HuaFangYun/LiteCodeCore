using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiteCode.Data.Migrations
{
    public partial class addcreatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysModuleses_Sys_Application_ApplicationId",
                table: "Sys_Modules");

            migrationBuilder.RenameTable(
                name: "SysModuleses",
                newName: "Sys_Modules");

            migrationBuilder.RenameIndex(
                name: "IX_SysModuleses_ApplicationId",
                table: "Sys_Modules",
                newName: "IX_Sys_Modules_ApplicationId");

            migrationBuilder.RenameColumn(
                name: "PrentId",
                table: "Sys_Modules",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "ControleName",
                table: "Sys_Modules",
                newName: "ControllerName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Sys_Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsLock",
                table: "Sys_Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Sys_Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowDelete",
                table: "Sys_Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Sys_Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoleDescription",
                table: "Sys_Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Sys_Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleType",
                table: "Sys_Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Sys_Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "Sys_RoleModules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "Sys_RoleModules",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurviewSum",
                table: "Sys_RoleModules",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PurviewNum",
                table: "Sys_Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PurviewSum",
                table: "Sys_Modules",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_Modules_Sys_Application_ApplicationId",
                table: "Sys_Modules",
                column: "ApplicationId",
                principalTable: "Sys_Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sys_Modules_Sys_Application_ApplicationId",
                table: "SysModuleses");

            migrationBuilder.RenameTable(
                name: "Sys_Modules",
                newName: "SysModuleses");

            migrationBuilder.RenameIndex(
                name: "IX_Sys_Modules_ApplicationId",
                table: "SysModuleses",
                newName: "IX_SysModuleses_ApplicationId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "SysModuleses",
                newName: "PrentId");

            migrationBuilder.RenameColumn(
                name: "ControllerName",
                table: "SysModuleses",
                newName: "ControleName");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Sys_Users");

            migrationBuilder.DropColumn(
                name: "IsLock",
                table: "Sys_Users");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "IsAllowDelete",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Sys_Roles");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Sys_RoleModules");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "Sys_RoleModules");

            migrationBuilder.DropColumn(
                name: "PurviewSum",
                table: "Sys_RoleModules");

            migrationBuilder.DropColumn(
                name: "PurviewNum",
                table: "SysModuleses");

            migrationBuilder.DropColumn(
                name: "PurviewSum",
                table: "SysModuleses");

            migrationBuilder.AddForeignKey(
                name: "FK_SysModuleses_Sys_Application_ApplicationId",
                table: "SysModuleses",
                column: "ApplicationId",
                principalTable: "Sys_Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

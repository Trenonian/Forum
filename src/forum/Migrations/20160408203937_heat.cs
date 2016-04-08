using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace forum.Migrations
{
    public partial class heat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Comment_Board_ParentBoardId", table: "Comment");
            migrationBuilder.DropForeignKey(name: "FK_Edit_Voteable_ParentId", table: "Edit");
            migrationBuilder.DropForeignKey(name: "FK_Post_Board_ParentBoardId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_UserBoard_Board_BoardId", table: "UserBoard");
            migrationBuilder.DropForeignKey(name: "FK_Vote_Voteable_TargetId", table: "Vote");
            migrationBuilder.DropForeignKey(name: "FK_Voteable_Board_ParentBoardId", table: "Voteable");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddColumn<float>(
                name: "Heat",
                table: "Post",
                nullable: false,
                defaultValue: 0f);
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Board_ParentBoardId",
                table: "Comment",
                column: "ParentBoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Edit_Voteable_ParentId",
                table: "Edit",
                column: "ParentId",
                principalTable: "Voteable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Post_Board_ParentBoardId",
                table: "Post",
                column: "ParentBoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserBoard_Board_BoardId",
                table: "UserBoard",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Voteable_TargetId",
                table: "Vote",
                column: "TargetId",
                principalTable: "Voteable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Voteable_Board_ParentBoardId",
                table: "Voteable",
                column: "ParentBoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Comment_Board_ParentBoardId", table: "Comment");
            migrationBuilder.DropForeignKey(name: "FK_Edit_Voteable_ParentId", table: "Edit");
            migrationBuilder.DropForeignKey(name: "FK_Post_Board_ParentBoardId", table: "Post");
            migrationBuilder.DropForeignKey(name: "FK_UserBoard_Board_BoardId", table: "UserBoard");
            migrationBuilder.DropForeignKey(name: "FK_Vote_Voteable_TargetId", table: "Vote");
            migrationBuilder.DropForeignKey(name: "FK_Voteable_Board_ParentBoardId", table: "Voteable");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "Heat", table: "Post");
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Board_ParentBoardId",
                table: "Comment",
                column: "ParentBoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Edit_Voteable_ParentId",
                table: "Edit",
                column: "ParentId",
                principalTable: "Voteable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Post_Board_ParentBoardId",
                table: "Post",
                column: "ParentBoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserBoard_Board_BoardId",
                table: "UserBoard",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Voteable_TargetId",
                table: "Vote",
                column: "TargetId",
                principalTable: "Voteable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Voteable_Board_ParentBoardId",
                table: "Voteable",
                column: "ParentBoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

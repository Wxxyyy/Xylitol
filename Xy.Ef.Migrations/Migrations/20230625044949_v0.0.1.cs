using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Ef.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Uid = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "用户Uid")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Account = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "账户用户")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: true, comment: "头像")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nick = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "昵称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", maxLength: 1, nullable: true, comment: "性别：[0-男生],[1-女生],[2-❀]"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "手机号码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "电子邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false, comment: "用户生日"),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "用户地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Signature = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "用户签名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "varchar(88)", maxLength: 88, nullable: true, comment: "用户备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", maxLength: 1, nullable: false, comment: "用户状态：[0-正常],[1-禁用],[2-封禁]"),
                    LastLoginDt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "最后登录时间"),
                    LastLoginIp = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "最后登录IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLoginDev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "最后登录设备")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatedUid = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false, comment: "创建用户Uid")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedDt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "更新时间"),
                    UpdatedUid = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "更新用户Uid")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Id, x.Uid })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_User");
        }
    }
}

1.将 程序包管理控制台 默认项目设置为 YouXXX.DataBase.Core
        -- 创建模型版本
        -- Add-Migration vxxx (Add-Migration v1.0.0)

2.更新到数据库
        -- Update-Database
        -- (如果 Update-Database 后面带字符串参数，则会自动还原数据库到指定版本，如：
        --  Update-Database v0.0.3 )

3.导出 Sql
        -- Script-Migration


注：VsCode IDE下，需要按照一下方式（以下方式暂时有点问题）↓
    Ⅰ.确保已在项目的根目录下打开终端。
    Ⅱ.在终端中运行以下命令，安装 Entity Framework Core CLI 工具：
        dotnet tool install --global dotnet-ef
    Ⅲ.确保已经在项目中添加了 Entity Framework Core NuGet 包。如果没有，请运行以下命令安装：
        dotnet add package Microsoft.EntityFrameworkCore.Design
    Ⅳ.开始迁移：
        -- 开始迁移
        -- dotnet ef migrations add vx.x.x -s "../Xylitol"
        -- 更新到库
        -- dotnet ef database update -s "../Xylitol"
        -- 生成SQL
        -- dotnet ef migrations scripts -s "../Xylitol"
        -- 迁移列表
        -- dotnet ef migrations list -s "../Xylitol"
        -- 删除迁移
        -- dotnet ef migrations remove -s "../Xylitol"
-----------------------Ef---------------------------
Entity Framework Core .NET Command-line Tools 7.0.8
Entity Framework Core .NET 命令行工具
Usage: dotnet ef [options] [command]
用法：dotnet ef [选项] [命令]
Options[选项]:
  --version        Show version information.[显示版本信息]
  -h|--help        Show help information.[显示帮助信息]
  -v|--verbose     Show verbose output.[显示详细输出]
  --no-color       Don't colorize output.[不使用颜色标记输出]
  --prefix-output  Prefix output with level.[在输出前加上级别]

Commands[命令]:
  database    Commands to manage the database.[用于管理数据库的命令]
  dbcontext   Commands to manage DbContext types. [用于管理DbContext类型的命令]
  migrations  Commands to manage migrations.[用于管理迁移的命令]

Use "dotnet ef [command] --help" for more information about a command.
使用 "dotnet ef [命令] --help"  了解更多关于命令的信息。
-----------------------------------------------------------
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneCompare.Migrations
{
    public partial class PhoneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apple",
                columns: table => new
                {
                    AppleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apple", x => x.AppleId);
                });

            migrationBuilder.CreateTable(
                name: "Huawei",
                columns: table => new
                {
                    HuaweiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huawei", x => x.HuaweiId);
                });

            migrationBuilder.CreateTable(
                name: "Lenovo",
                columns: table => new
                {
                    LenovoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenovo", x => x.LenovoId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    YearBorn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Samsung",
                columns: table => new
                {
                    SamsungId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samsung", x => x.SamsungId);
                });

            migrationBuilder.CreateTable(
                name: "Xiaomi",
                columns: table => new
                {
                    XiaomiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xiaomi", x => x.XiaomiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apple");

            migrationBuilder.DropTable(
                name: "Huawei");

            migrationBuilder.DropTable(
                name: "Lenovo");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Samsung");

            migrationBuilder.DropTable(
                name: "Xiaomi");
        }
    }
}

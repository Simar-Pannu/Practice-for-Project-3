using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HighStakes.Storing.Migrations
{
    public partial class Hoepfullyremovedduplicated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DUser_DAccount_AccountId",
                table: "DUser");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DUser",
                table: "DUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DCard",
                table: "DCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DAccount",
                table: "DAccount");

            migrationBuilder.RenameTable(
                name: "DUser",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "DCard",
                newName: "Card");

            migrationBuilder.RenameTable(
                name: "DAccount",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_DUser_AccountId",
                table: "User",
                newName: "IX_User_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account_AccountId",
                table: "User",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Account_AccountId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "DUser");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "DCard");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "DAccount");

            migrationBuilder.RenameIndex(
                name: "IX_User_AccountId",
                table: "DUser",
                newName: "IX_DUser_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DUser",
                table: "DUser",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DCard",
                table: "DCard",
                column: "CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DAccount",
                table: "DAccount",
                column: "AccountId");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Suit = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: true),
                    ChipTotal = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_DUser_DAccount_AccountId",
                table: "DUser",
                column: "AccountId",
                principalTable: "DAccount",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

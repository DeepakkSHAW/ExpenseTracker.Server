using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseTracker.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrencyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "expenseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpenseTitle = table.Column<string>(nullable: true),
                    ExpensesAmount = table.Column<double>(nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    Signature = table.Column<string>(nullable: true),
                    inDate = table.Column<DateTime>(nullable: false),
                    updateDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_expenseCategory_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "expenseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Detail = table.Column<string>(nullable: true),
                    ExpenseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetail_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 1, "INR" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 2, "USD" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 3, "EUR" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 4, "SFR" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 5, "AUD" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 6, "SGD" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[] { 7, "GBP" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 15, "Office exp" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 14, "Fun money" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 13, "Household items" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 12, "Kids schooling" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 11, "Personal" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 10, "Shelter" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 9, "Utilities" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 5, "Medical" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 7, "Clothing" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 6, "Insurance" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 16, "Donation" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 4, "Gifts" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 3, "Transportation" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 2, "Restaurants" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 1, "Grocery" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 8, "Education" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 17, "Miscellaneous" });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetail_ExpenseId",
                table: "ExpenseDetail",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyId",
                table: "Expenses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDetail");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "expenseCategory");
        }
    }
}

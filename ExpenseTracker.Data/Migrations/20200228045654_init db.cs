using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseTracker.Data.Migrations
{
    public partial class initdb : Migration
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
                name: "ExpenseRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActiveRule = table.Column<bool>(nullable: false),
                    Priority = table.Column<uint>(nullable: false),
                    RuleName = table.Column<string>(nullable: true),
                    SearchText = table.Column<string>(nullable: true),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    inDate = table.Column<DateTime>(nullable: false),
                    updateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseRules_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseRules_expenseCategory_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "expenseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpenseTitle = table.Column<string>(maxLength: 50, nullable: false),
                    ExpensesAmount = table.Column<double>(nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    Signature = table.Column<string>(maxLength: 3, nullable: true),
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
                    Detail = table.Column<string>(maxLength: 255, nullable: true),
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
                values: new object[] { 16, "Donation" });

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
                values: new object[] { 6, "Insurance" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 7, "Clothing" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 17, "Communication" });

            migrationBuilder.InsertData(
                table: "expenseCategory",
                columns: new[] { "Id", "Category" },
                values: new object[] { 5, "Medical" });

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
                values: new object[] { 18, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 1, 5, 1, true, 1, 0, 1u, "Grocery Rule", "coles,woolworths,kt mart, ALDI, MARKET, BAZAAR", new DateTime(2020, 2, 28, 15, 56, 54, 623, DateTimeKind.Local).AddTicks(6954), new DateTime(2020, 2, 28, 15, 56, 54, 625, DateTimeKind.Local).AddTicks(9251) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 2, 5, 2, true, 1, 0, 0u, "the restaurant-Rule", "DOMINOS, PIZZA, CAFE, BURGERS, KFC, CHILLI, SWEETS, RED ROOSTER,", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3311), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3334) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 3, 5, 3, true, 1, 0, 2u, "Transport-Rule", "TRANSPORT, TRAIN, AIRPORT, SHIP, BUS", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3410), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 4, 5, 4, true, 5, 0, 3u, "Gift-Rule", "ebay", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3417), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 5, 5, 5, true, 1, 0, 4u, "medical-Rule", "CHEMIST,DENTAL,doctor", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3422), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3425) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 6, 5, 6, true, 1, 0, 5u, "Insurance-Rule", "INSURANCE, BUPA,LIC", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3428), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3431) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 7, 5, 7, true, 1, 0, 9u, "Clothing-Rule", "Target, MALL", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3434), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3437) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 8, 5, 8, true, 1, 0, 6u, "Education-Rule", "School, OFFICEWORKS", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3440), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3443) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 9, 5, 9, true, 1, 0, 7u, "Utilities-Rule", "ENERGY, CITYWATER", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3446), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3449) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 10, 5, 17, true, 1, 0, 11u, "comm-Rule-AU", "AMAYSIM,Internet", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3452), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3455) });

            migrationBuilder.InsertData(
                table: "ExpenseRules",
                columns: new[] { "Id", "CurrencyId", "ExpenseCategoryId", "IsActiveRule", "PaymentMethod", "PaymentType", "Priority", "RuleName", "SearchText", "inDate", "updateDate" },
                values: new object[] { 11, 1, 17, true, 1, 0, 20u, "comm-Rule-IND", "jio,airtel", new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3458), new DateTime(2020, 2, 28, 15, 56, 54, 626, DateTimeKind.Local).AddTicks(3461) });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetail_ExpenseId",
                table: "ExpenseDetail",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRules_CurrencyId",
                table: "ExpenseRules",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRules_ExpenseCategoryId",
                table: "ExpenseRules",
                column: "ExpenseCategoryId");

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
                name: "ExpenseRules");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "expenseCategory");
        }
    }
}

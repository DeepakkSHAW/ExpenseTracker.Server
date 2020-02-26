using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace ExpenseTracker.Data
{
    public class ETDBContext : DbContext
    {
        public DbSet<ExpenseCategory> expenseCategory { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseRule> ExpenseRules { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(@"Data Source=DB\\ETracker.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            optionsBuilder
            //.UseLoggerFactory(GetLoggerFactory()) //* Encapsulated approach to enable logging, when consumer does have exposed database context *//
            //.UseSqlite("", options => options.MaxBatchSize(30));
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var dbConnection = configuration.GetConnectionString("DefaultConnection");
            System.Diagnostics.Debug.WriteLine(dbConnection);

            optionsBuilder.UseSqlite(dbConnection, options => options.MaxBatchSize(512));
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(entity =>
            {
                // Set key for entity
                entity.HasKey(p => p.Id);
            });
            modelBuilder.Entity<ExpenseCategory>().HasData(
                new ExpenseCategory() { Id = 1, Category = "Grocery" },
                new ExpenseCategory() { Id = 2, Category = "Restaurants" },
                new ExpenseCategory() { Id = 3, Category = "Transportation" },
                new ExpenseCategory() { Id = 4, Category = "Gifts" },
                new ExpenseCategory() { Id = 5, Category = "Medical" },
                new ExpenseCategory() { Id = 6, Category = "Insurance" },
                new ExpenseCategory() { Id = 7, Category = "Clothing" },
                new ExpenseCategory() { Id = 8, Category = "Education" },
                new ExpenseCategory() { Id = 9, Category = "Utilities" },
                new ExpenseCategory() { Id = 10, Category = "Shelter" },
                new ExpenseCategory() { Id = 11, Category = "Personal" },
                new ExpenseCategory() { Id = 12, Category = "Kids schooling" },
                new ExpenseCategory() { Id = 13, Category = "Household items" },
                new ExpenseCategory() { Id = 14, Category = "Fun money" },
                new ExpenseCategory() { Id = 15, Category = "Office exp" },
                new ExpenseCategory() { Id = 16, Category = "Donation" },
                new ExpenseCategory() { Id = 17, Category = "Communication" },
                new ExpenseCategory() { Id = 18, Category = "Miscellaneous" }
);

            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, CurrencyName = "INR" },
                new Currency() { Id = 2, CurrencyName = "USD" },
                new Currency() { Id = 3, CurrencyName = "EUR" },
                new Currency() { Id = 4, CurrencyName = "SFR" },
                new Currency() { Id = 5, CurrencyName = "AUD" },
                new Currency() { Id = 6, CurrencyName = "SGD" },
                new Currency() { Id = 7, CurrencyName = "GBP" }
                );

            modelBuilder.Entity<ExpenseRule>(entity =>
            {
                entity.HasKey(p => p.Id);
            });
            modelBuilder.Entity<ExpenseRule>().HasData(
                new ExpenseRule() { Id = 1, IsActiveRule = true, RuleName = "Grocery Rule", SearchText = "coles,woolworths,kt mart, ALDI, MARKET, BAZAAR", ExpenseCategoryId = 1, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 2, IsActiveRule = true, RuleName = "the restaurant-Rule", SearchText = "DOMINOS, PIZZA, CAFE, BURGERS, KFC, CHILLI, SWEETS, RED ROOSTER,", ExpenseCategoryId = 2, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 3, IsActiveRule = true, RuleName = "Transport-Rule", SearchText = "TRANSPORT, TRAIN, AIRPORT, SHIP, BUS", ExpenseCategoryId = 3, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 4, IsActiveRule = true, RuleName = "Gift-Rule", SearchText = "ebay", ExpenseCategoryId = 4, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Paypal },
                new ExpenseRule() { Id = 5, IsActiveRule = true, RuleName = "medical-Rule", SearchText = "CHEMIST,DENTAL,doctor", ExpenseCategoryId = 5, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 6, IsActiveRule = true, RuleName = "Insurance-Rule", SearchText = "INSURANCE, BUPA,LIC", ExpenseCategoryId = 6, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 7, IsActiveRule = true, RuleName = "Clothing-Rule", SearchText = "Target, MALL", ExpenseCategoryId = 7, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 8, IsActiveRule = true, RuleName = "Education-Rule", SearchText = "School, OFFICEWORKS", ExpenseCategoryId = 8, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id = 9, IsActiveRule = true, RuleName = "Utilities-Rule", SearchText = "ENERGY, CITYWATER", ExpenseCategoryId = 9, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id =10, IsActiveRule = true, RuleName = "comm-Rule-AU", SearchText = "AMAYSIM,Internet", ExpenseCategoryId = 17, CurrencyId = 5, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card },
                new ExpenseRule() { Id =11, IsActiveRule = true, RuleName = "comm-Rule-IND", SearchText = "jio,airtel", ExpenseCategoryId = 17, CurrencyId = 1, PaymentType = PaymentType.Paid, PaymentMethod = PaymentMethod.Card }
                );
        }
    }
}

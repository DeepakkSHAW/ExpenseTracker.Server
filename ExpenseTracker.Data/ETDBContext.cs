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
                new ExpenseCategory() { Id = 17, Category = "Miscellaneous" }
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
        }
    }
}

﻿// <auto-generated />
using System;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpenseTracker.Data.Migrations
{
    [DbContext(typeof(ETDBContext))]
    [Migration("20200225025848_db init")]
    partial class dbinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("ExpenseTracker.Data.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyName = "INR"
                        },
                        new
                        {
                            Id = 2,
                            CurrencyName = "USD"
                        },
                        new
                        {
                            Id = 3,
                            CurrencyName = "EUR"
                        },
                        new
                        {
                            Id = 4,
                            CurrencyName = "SFR"
                        },
                        new
                        {
                            Id = 5,
                            CurrencyName = "AUD"
                        },
                        new
                        {
                            Id = 6,
                            CurrencyName = "SGD"
                        },
                        new
                        {
                            Id = 7,
                            CurrencyName = "GBP"
                        });
                });

            modelBuilder.Entity("ExpenseTracker.Data.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpenseCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpenseTitle")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<double>("ExpensesAmount")
                        .HasColumnType("REAL");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Signature")
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<DateTime>("inDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ExpenseCategoryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ExpenseTracker.Data.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("expenseCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Grocery"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Restaurants"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Transportation"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Gifts"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Medical"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Insurance"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Clothing"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Education"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Utilities"
                        },
                        new
                        {
                            Id = 10,
                            Category = "Shelter"
                        },
                        new
                        {
                            Id = 11,
                            Category = "Personal"
                        },
                        new
                        {
                            Id = 12,
                            Category = "Kids schooling"
                        },
                        new
                        {
                            Id = 13,
                            Category = "Household items"
                        },
                        new
                        {
                            Id = 14,
                            Category = "Fun money"
                        },
                        new
                        {
                            Id = 15,
                            Category = "Office exp"
                        },
                        new
                        {
                            Id = 16,
                            Category = "Donation"
                        },
                        new
                        {
                            Id = 17,
                            Category = "Communication"
                        },
                        new
                        {
                            Id = 18,
                            Category = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("ExpenseTracker.Data.ExpenseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<int>("ExpenseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId")
                        .IsUnique();

                    b.ToTable("ExpenseDetail");
                });

            modelBuilder.Entity("ExpenseTracker.Data.ExpenseRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpenseCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActiveRule")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RuleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SearchText")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("inDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExpenseRules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyId = 5,
                            ExpenseCategoryId = 1,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "Grocery Rule",
                            SearchText = "coles,woolworths,kt mart, ALDI, MARKET, BAZAAR",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 479, DateTimeKind.Local).AddTicks(4917),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(5143)
                        },
                        new
                        {
                            Id = 2,
                            CurrencyId = 5,
                            ExpenseCategoryId = 2,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "the restaurant-Rule",
                            SearchText = "DOMINOS, PIZZA, CAFE, BURGERS, KFC, CHILLI, SWEETS, RED ROOSTER,",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8536),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8551)
                        },
                        new
                        {
                            Id = 3,
                            CurrencyId = 5,
                            ExpenseCategoryId = 3,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "Transport-Rule",
                            SearchText = "TRANSPORT, TRAIN, AIRPORT, SHIP, BUS",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8612),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8615)
                        },
                        new
                        {
                            Id = 4,
                            CurrencyId = 5,
                            ExpenseCategoryId = 4,
                            IsActiveRule = true,
                            PaymentMethod = 5,
                            PaymentType = 0,
                            RuleName = "Gift-Rule",
                            SearchText = "ebay",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8619),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8621)
                        },
                        new
                        {
                            Id = 5,
                            CurrencyId = 5,
                            ExpenseCategoryId = 5,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "medical-Rule",
                            SearchText = "CHEMIST,DENTAL,doctor",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8624),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8627)
                        },
                        new
                        {
                            Id = 6,
                            CurrencyId = 5,
                            ExpenseCategoryId = 6,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "Insurance-Rule",
                            SearchText = "INSURANCE, BUPA,LIC",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8629),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8632)
                        },
                        new
                        {
                            Id = 7,
                            CurrencyId = 5,
                            ExpenseCategoryId = 7,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "Clothing-Rule",
                            SearchText = "Target, MALL",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8635),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8637)
                        },
                        new
                        {
                            Id = 8,
                            CurrencyId = 5,
                            ExpenseCategoryId = 8,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "Education-Rule",
                            SearchText = "School, OFFICEWORKS",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8640),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8642)
                        },
                        new
                        {
                            Id = 9,
                            CurrencyId = 5,
                            ExpenseCategoryId = 9,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "Utilities-Rule",
                            SearchText = "ENERGY, CITYWATER",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8645),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8647)
                        },
                        new
                        {
                            Id = 10,
                            CurrencyId = 5,
                            ExpenseCategoryId = 17,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "comm-Rule-AU",
                            SearchText = "AMAYSIM,Internet",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8650),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8652)
                        },
                        new
                        {
                            Id = 11,
                            CurrencyId = 1,
                            ExpenseCategoryId = 17,
                            IsActiveRule = true,
                            PaymentMethod = 1,
                            PaymentType = 0,
                            RuleName = "comm-Rule-IND",
                            SearchText = "jio,airtel",
                            inDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8656),
                            updateDate = new DateTime(2020, 2, 25, 13, 58, 48, 481, DateTimeKind.Local).AddTicks(8658)
                        });
                });

            modelBuilder.Entity("ExpenseTracker.Data.Expense", b =>
                {
                    b.HasOne("ExpenseTracker.Data.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseTracker.Data.ExpenseCategory", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExpenseTracker.Data.ExpenseDetail", b =>
                {
                    b.HasOne("ExpenseTracker.Data.Expense", "Expense")
                        .WithOne("ExpenseDetail")
                        .HasForeignKey("ExpenseTracker.Data.ExpenseDetail", "ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

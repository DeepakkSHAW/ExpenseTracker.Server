using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpenseTracker.Data
{
    public enum PaymentMethod
    {
        [Description("Cash")] Cash = 0,
        [Description("Card")] Card = 1,
        [Description("Mobile Payments")] MobilePayments = 3,
        [Description("Direct Deposit")] DirectDeposit = 4,
        [Description("PayPal")] Paypal = 5,
        [Description("Bank Cheque")] BankCheque = 6,
        [Description("Prepaid Cards")] PrepaidCards = 7,
        [Description("E wallets")] Ewallets = 8,
        [Description("BankTransfers")] BankTransfers = 9,
        [Description("Others")] Others = 10
    }
    public enum PaymentType
    {
        [Description("Paid")] Paid = 0,
        [Description("Reimbursed")] Reimbursed = 1,
        [Description("Refunded")] Refunded = 2
    }
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
    public class Currency
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
    }
    public class ExpenseDetail
    {
        public int Id { get; set; }
        public String Detail { get; set; }
        public Expense Expense { get; set; }
        public int ExpenseId { get; set; }
    }
    public class Expense
    {
        public int Id { get; set; }
        public String ExpenseTitle { get; set; }
        //public String ExpensesDetails { get; set; }
        public double ExpensesAmount { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string Signature { get; set; }
        //only for audit purposes
        public DateTime inDate { get; private set; }
        //only for audit purposes
        public DateTime updateDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int CurrencyId { get; set; }
        //Navigation properties
        public ExpenseDetail ExpenseDetail { get; set; }
        public ExpenseCategory Category { get; set; }
        public Currency Currency { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseTracker.Data
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        public int QuantityPerPage { get; set; } = 10;
    }
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
        [StringLength(255, ErrorMessage = "Detail too long (255 char max).")]
        public String Detail { get; set; }
        public Expense Expense { get; set; }
        public int ExpenseId { get; set; }

        //public static implicit operator ExpenseDetail(string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class Expense
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Expense Title required")]
        [StringLength(50, ErrorMessage = "Title too long (50 char).")]
        public String ExpenseTitle { get; set; }
        //public String ExpensesDetails { get; set; }
        [Required]
        [Range(1, 10000000, ErrorMessage = "Amount invalid (1-10000000).")]
        public double ExpensesAmount { get; set; }

        [Required(ErrorMessage = "Expense Date needed")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        [StringLength(3, ErrorMessage = "Signature should not be more than 3 chars long")]
        public string Signature { get; set; }
        //only for audit purposes
        public DateTime inDate { get; private set; } = DateTime.Now;
        //only for audit purposes
        public DateTime updateDate { get; set; } = DateTime.Now;
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Must select a expense category.")]
        public int ExpenseCategoryId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Must select expense currency.")]
        public int CurrencyId { get; set; }
        //Navigation properties
        public ExpenseDetail? ExpenseDetail { get; set; }
        public ExpenseCategory Category { get; set; }
        public Currency Currency { get; set; }

    }
}

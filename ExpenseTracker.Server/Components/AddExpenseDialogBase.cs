using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Server.Components
{
    public class AddExpenseDialogBase : ComponentBase
    {

        private const ExpenseTracker.Data.PaymentType _defaultPaymentType = ExpenseTracker.Data.PaymentType.Paid;
        private const ExpenseTracker.Data.PaymentMethod _defaultPaymentMethod = ExpenseTracker.Data.PaymentMethod.Card;

        [Inject]
        private ExpenseTracker.Data.Services.IExpenseRepository SrvExp { get; set; }
        protected ExpenseTracker.Data.Expense expense;
        [Inject]
        private ExpenseTracker.Data.Services.ICategoryRepository SrvCategoties { get; set; }
        protected List<ExpenseTracker.Data.ExpenseCategory> Categories;
        [Inject]
        private ExpenseTracker.Data.Services.ICurrencyRepository SrvCurrencies { get; set; }
        protected List<ExpenseTracker.Data.Currency> Currencies;


        protected string SelectedCategoryId = string.Empty;
        protected string SelectedCurrencyId = string.Empty;
        protected string SelectedPaymentType = string.Empty;
        protected string? SelectedPaymentMethod = string.Empty;
        protected string SelectedDetails = string.Empty;
        protected string EnteredAmt = "0.0";
        protected DateTime todaysDate = System.DateTime.Now;

        [Parameter]
        public string ExpnsesID { get; set; }
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }
        public bool ShowDialog { get; set; }

        public void Show()
        {
            //ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            expense = new ExpenseTracker.Data.Expense { Id = 1, ExpenseTitle = "demmy-reset", ExpensesAmount = 105.5, Signature = "DK", ExpenseDate = DateTime.Now };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            // var id = EmployeeId;
            // ExpnsesID = 0;
            ExpnsesID = "5";
            Console.WriteLine(ExpnsesID);
            if (string.IsNullOrEmpty(ExpnsesID)) //consider as new expense, getting ready to fetch post method 
            {
                //add some defaults
                expense = new ExpenseTracker.Data.Expense
                {
                    Id = 1,
                    CurrencyId = 1,
                    ExpenseCategoryId = 1,
                    ExpenseTitle = "shoe",
                    ExpensesAmount = 105.5,
                    Signature = "DK",
                    PaymentType = _defaultPaymentType,
                    PaymentMethod = _defaultPaymentMethod,
                    updateDate = DateTime.Now,
                    ExpenseDate = DateTime.Now
                };
            }
            else  //consider as existing expense, getting ready to fetch put method
            {
                expense = await SrvExp.GetExpensesAsync(int.Parse(ExpnsesID));
            }

            Categories = (await SrvCategoties.GetCategoriesAsync(true)).ToList();
            Currencies = (await SrvCurrencies.GetCurrencyAsync(true)).ToList();

            SelectedCategoryId = expense.ExpenseCategoryId.ToString();
            SelectedCurrencyId = expense.CurrencyId.ToString();
            //SelectedDetails = expense.ExpenseDetail.Detail;
            SelectedPaymentMethod = ((int)expense.PaymentMethod).ToString();
            SelectedPaymentType = ((int)expense.PaymentType).ToString();
            EnteredAmt = expense.ExpensesAmount.ToString();


            //foreach (int value in Enum.GetValues(typeof(ExpenseTracker.Data.PaymentType)))
            //{
            //    Console.WriteLine(((ExpenseTracker.Data.PaymentType)value).ToString());
            //}

            //foreach (string value in Enum.GetNames(typeof(ExpenseTracker.Data.PaymentType)))
            //{
            //    Console.WriteLine(value);
            //}
        }

        protected async Task HandleValidSubmit()
        {
            //await EmployeeDataService.AddEmployee(Employee);
            expense.ExpenseCategoryId = int.Parse(SelectedCategoryId);
            expense.CurrencyId = int.Parse(SelectedCurrencyId);
            expense.ExpensesAmount = double.Parse(EnteredAmt);
            expense.PaymentMethod = (ExpenseTracker.Data.PaymentMethod)Enum.Parse(typeof(ExpenseTracker.Data.PaymentMethod), SelectedPaymentMethod);
            expense.PaymentType = (ExpenseTracker.Data.PaymentType)Enum.Parse(typeof(ExpenseTracker.Data.PaymentType), SelectedPaymentType);

            ExpnsesID = "";
            if (string.IsNullOrEmpty(ExpnsesID))
            {
                //expense.Id = -1;
                //await SrvExp.NewExpensesAsync(expense);
                ExpenseTracker.Data.Expense new_expense = new ExpenseTracker.Data.Expense();
                new_expense.ExpenseTitle = expense.ExpenseTitle;
                new_expense.ExpensesAmount = expense.ExpensesAmount;
                new_expense.ExpenseDate = expense.ExpenseDate;
                new_expense.Signature = expense.Signature;
                new_expense.PaymentType = expense.PaymentType;
                new_expense.PaymentMethod = expense.PaymentMethod;
                new_expense.ExpenseCategoryId = expense.ExpenseCategoryId;
                new_expense.CurrencyId = expense.CurrencyId;
                new_expense.ExpenseDate = todaysDate.Date;

                if (!string.IsNullOrEmpty(SelectedDetails))
                //dExpense.ExpenseDetail = new Domain.ExpenseDetail { Detail = newExpense.ExpenseDetail };
                {
                    ExpenseTracker.Data.ExpenseDetail expDetails = new ExpenseTracker.Data.ExpenseDetail { Detail = "Some details from code directly." };
                    new_expense.ExpenseDetail = expDetails;
                }

                await SrvExp.NewExpensesAsync(new_expense);
            }
            else
            {
                await SrvExp.EditExpensesAsync(expense, int.Parse(ExpnsesID));
            }

            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

    }
}

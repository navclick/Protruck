using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IExpenseRepository
    {
        Task<Response> GetALLExpenses();

        Task<Response> AddExpense(ExpenseVM expense);
        Task<Response> RemoveExpense(ExpenseVM expense);

        Response GetallExpenseTypes();

    }
}

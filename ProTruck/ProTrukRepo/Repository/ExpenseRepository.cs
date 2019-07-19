using AutoMapper;
using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;

namespace ProTrukRepo.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {

        private readonly ProTruckEntities _db;
        private Hashtable ExpenseTypes = new Hashtable();
        public ExpenseRepository()
        {
            _db = new ProTruckEntities();
            ExpenseTypes[1] = "Vehicle";
            ExpenseTypes[2] = "Office";
            ExpenseTypes[3] = "Misc";
            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Expense, ExpenseVM>();
                cfg.CreateMap<ExpenseVM, Expense>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });





        }

        public async Task<Response> GetALLExpenses()
        {
            try
            {
                List<ExpenseVM> response = new List<ExpenseVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Expenses.ToListAsync();
                foreach (var expense in DTO) {
                    ExpenseVM obj = new ExpenseVM();
                    obj.Description = expense.Description;
                    obj.EcomID = expense.EcomID;
                    obj.Expense1 = expense.Expense1;
                    obj.Id = expense.Id;
                    obj.Type = expense.Type;
                    obj.TypeName = GetExpenseTypeByID((int)obj.Type);
                    response.Add(obj);
                }
                
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
               // response = Mapper.Map<IEnumerable<Expense>, List<ExpenseVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<ExpenseVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<ExpenseVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<ExpenseVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddExpense(ExpenseVM expense)
        {

            var Dto = Mapper.Map<ExpenseVM, Expense>(expense);

            Expense Exist = await _db.Expenses.Where(x => x.Expense1.Trim() == expense.Expense1.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Expenses.Add(Dto);

            int result = await _db.SaveChangesAsync();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
            }
            else
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoLoginFailed, (int)Constant.httpStatus.NoContent, result);
            }


        }

        public async Task<Response> RemoveExpense(ExpenseVM expense)
        {
            try
            {
                var DTO = await _db.Expenses.Where(x => x.Id == expense.Id).FirstOrDefaultAsync();

                _db.Expenses.Remove(DTO);

                int result = await _db.SaveChangesAsync();

                if (result == 1)
                {
                    // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                    return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
                }
                else
                {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MSGFailed, (int)Constant.httpStatus.NoContent, result);
                }
            }
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }

        public Response GetallExpenseTypes()
        {

            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (DictionaryEntry entry in ExpenseTypes)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)entry.Key;
                obj.Text = entry.Value.ToString();
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }


        public String GetExpenseTypeByID(int id)
        {
            return (string)ExpenseTypes[id];


        }



    }
}

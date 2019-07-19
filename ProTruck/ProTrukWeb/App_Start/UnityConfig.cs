using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProTrukWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ProTrukRepo.Interface.IUserMasterRepository, ProTrukRepo.Repository.UserMasterRepository>();
            container.RegisterType<ProTrukRepo.Interface.IRoleRepository, ProTrukRepo.Repository.RoleRepository>();
            container.RegisterType<ProTrukRepo.Interface.IGoodsRepository, ProTrukRepo.Repository.GoodsRepository>();
            container.RegisterType<ProTrukRepo.Interface.IVehicleRepository, ProTrukRepo.Repository.VehicleRepository>();
            container.RegisterType<ProTrukRepo.Interface.IDriversRepository, ProTrukRepo.Repository.DriverRepository>();
            container.RegisterType<ProTrukRepo.Interface.IBankRepository, ProTrukRepo.Repository.BankRepository>();
            container.RegisterType<ProTrukRepo.Interface.IExpenseRepository, ProTrukRepo.Repository.ExpenseRepository>();
            container.RegisterType<ProTrukRepo.Interface.IPartyRepository, ProTrukRepo.Repository.PartyRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
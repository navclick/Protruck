using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.Util;
using ProTrukRepo.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Repository
{
   public class SharedRepository : ISharedRepository
    {

        private readonly ProTruckEntities _db;
        private Hashtable Units = new Hashtable();
        private Hashtable VehicleStatus = new Hashtable();
        private Hashtable VehicleTypes = new Hashtable();

        public SharedRepository()
        {
            _db = new ProTruckEntities();
            //------------------------------
            Units[1] = "ton(s)";
            Units[2] = "Kgs";
            //-------------------------

            //---------------------------

            VehicleStatus[1] = "Active";
            VehicleStatus[2] = "Deactive";
            VehicleStatus[3] = "OnMaintenance";
            VehicleStatus[4] = "Available";
            VehicleStatus[5] = "NotAvailable";
            //-------------------------------

            VehicleTypes[1] = "Truk";
            VehicleTypes[1] = "Dumper";
            
            /*
                        AutoMapper.Mapper.Reset();
                        Mapper.Initialize(cfg =>
                        {
                            cfg.CreateMap<GoodsType, GoodsTypeVM>();
                            cfg.CreateMap<GoodsTypeVM, GoodsType>();
                             cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                             cfg.CreateMap<Module, ModuleVM>();
                             cfg.CreateMap<Role, RolesVM>();
                             cfg.CreateMap<UserVM, User>();

                        });
                    */

        }

        public Response GetallUnits()
        {

            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (DictionaryEntry entry in Units)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)entry.Key;
                obj.Text = entry.Value.ToString();
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }

        public String GetUnitByID(int id)
        {
            return (string)Units[id];


        }
        public Response GetallVehicleStatus()
        {

            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (DictionaryEntry entry in VehicleStatus)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)entry.Key;
                obj.Text = entry.Value.ToString();
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }

        public String GetVehicleStatusByID(int id)
        {
            return (string)VehicleStatus[id];


        }

        public Response GetallVehicleTypes()
        {

            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (DictionaryEntry entry in VehicleTypes)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)entry.Key;
                obj.Text = entry.Value.ToString();
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }

        public String GetVehicleTypeID(int id)
        {
            return (string)VehicleTypes[id];


        }

    }
}

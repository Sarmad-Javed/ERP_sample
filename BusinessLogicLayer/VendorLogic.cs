using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAL_Logic.Admin;
using DataAccessLayer.DAL_Logic.SupplyChain.ManageVendor;
using ERPEntities.Models;

namespace BusinessLogicLayer
{
    public class VendorLogic
    {
        //Initializaton
        VendorDAL VendorDAL = new VendorDAL();
        List<VendorModel> VendorList = new List<VendorModel>();


        //add record
        public void addVendor(AddVendorModel vendor)
        {
            VendorDAL.addVendor(vendor);
        }

        //get Vendor List
        public List<VendorModel> getVendorList()
        {
            VendorList = VendorDAL.getVendorsList();
            return VendorList;
        }

        public List<VendorModel> viewVendorListByID(int id)
        {
            VendorList = VendorDAL.viewVendorListByID(id);
            return VendorList;
        }

        //getItembyID
        public VendorModel viewVendorByID(int id)
        {
            VendorModel vendor = new VendorModel();
            vendor = VendorDAL.viewVendorByID(id);
            return vendor;
        }

        //UpdateItem
        public void updateVendor(int id,VendorModel vendor)
        {
            VendorDAL.updateVendor(id,vendor);
        }

        //deleteItem
        public void deleteVendor(int id)
        {
            VendorDAL.deleteVendor(id);
        }

    }
}
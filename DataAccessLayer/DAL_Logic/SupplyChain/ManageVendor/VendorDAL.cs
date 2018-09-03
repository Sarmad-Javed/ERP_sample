using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;

namespace DataAccessLayer.DAL_Logic.SupplyChain.ManageVendor
{
    public class VendorDAL
    {
        List<VendorModel> VendorList= new List<VendorModel>();
        VendorModel vendor = new VendorModel();
        SqlConnection Sqlcon = new SqlConnection("Data Source=Ijlal07-PC;Initial Catalog=ERP;Integrated Security=True");
        public void addVendor(AddVendorModel vendor)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Add_Vendor", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                Sqlcmd.Parameters.AddWithValue("@VendorAddress", vendor.VendorAddress);
                Sqlcmd.Parameters.AddWithValue("@VendorContact", vendor.VendorContact);
                Sqlcmd.Parameters.AddWithValue("@ZIPCode", vendor.ZIPCode);
                
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public List<VendorModel> getVendorsList()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Vendor", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                VendorModel vendor= new VendorModel();
                vendor.VendorID = Convert.ToInt32(dr["VendorID"]);
                vendor.VendorName = Convert.ToString(dr["VendorName"]);
                vendor.VendorAddress = Convert.ToString(dr["VendorAddress"]);
                vendor.VendorContact = Convert.ToString(dr["VendorContact"]);
                vendor.ZIPCode = Convert.ToInt32(dr["ZIPCode"]);
                
                VendorList.Add(vendor);
            }
            Sqlcon.Close();
            return VendorList;
        }

        public List<VendorModel> viewVendorListByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_VendorbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@VendorID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {

                vendor.VendorID = Convert.ToInt32(dr["VendorID"]);
                vendor.VendorName = Convert.ToString(dr["VendorName"]);
                vendor.VendorAddress = Convert.ToString(dr["VendorAddress"]);
                vendor.VendorContact = Convert.ToString(dr["VendorContact"]);
                vendor.ZIPCode = Convert.ToInt32(dr["ZIPCode"]);
                VendorList.Add(vendor);

            }
            Sqlcon.Close();
            return VendorList;
        }

        public VendorModel viewVendorByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_VendorbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@VendorID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                vendor.VendorID = Convert.ToInt32(dr["VendorID"]);
                vendor.VendorName = Convert.ToString(dr["VendorName"]);
                vendor.VendorAddress = Convert.ToString(dr["VendorAddress"]);
                vendor.VendorContact = Convert.ToString(dr["VendorContact"]);
                vendor.ZIPCode = Convert.ToInt32(dr["ZIPCode"]);
                
            }
            Sqlcon.Close();
            return vendor;
        }

        public void updateVendor(int id,VendorModel vendor)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Update_Vendor", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@VendorID", id);
                Sqlcmd.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                Sqlcmd.Parameters.AddWithValue("@VendorAddress", vendor.VendorAddress);
                Sqlcmd.Parameters.AddWithValue("@VendorContact", vendor.VendorContact);
                Sqlcmd.Parameters.AddWithValue("@ZIPCode", vendor.ZIPCode);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public void deleteVendor(int id)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                SqlCommand Sqlcmd = new SqlCommand("SP_Delete_Vendor", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@VendorID",id);
                Sqlcon.Open();
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

       
    }
}

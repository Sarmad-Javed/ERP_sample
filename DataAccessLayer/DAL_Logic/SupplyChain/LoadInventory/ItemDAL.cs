using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.Configuration;
using ERPEntities;
using ERPEntities.Models;
using System.Data.SqlClient;



namespace DataAccessLayer.SupplyChain.LoadInventory
{
    public class ItemDAL
    {
        List<ItemsModel> itemList = new List<ItemsModel>();
        SqlConnection Sqlcon = new SqlConnection("Data Source=pc-sarmad;Initial Catalog=ERP;Integrated Security=True");
        public void addItems(ItemsModel item)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Add_Items", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@VendorID", item.VendorID);
                Sqlcmd.Parameters.AddWithValue("@CategoryID", item.CategoryID);
                Sqlcmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                Sqlcmd.Parameters.AddWithValue("@MfgDate", item.MfgDate.Date);
                Sqlcmd.Parameters.AddWithValue("@ExpDate", item.ExpDate.Date);
                Sqlcmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                Sqlcmd.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                Sqlcmd.Parameters.AddWithValue("@LeadTime", item.LeadTime);
                Sqlcmd.Parameters.AddWithValue("@Unit_of_Measure", item.Unit_of_Measure);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public DataSet showItems()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Items", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(Sqlcmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //getItemList
        public List<ItemsModel> getItemsList()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Items", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while(dr.Read())
            {
                ItemsModel item = new ItemsModel();
                item.ItemID = Convert.ToInt32(dr["ItemID"]);
                item.VendorID = Convert.ToInt32(dr["VendorID"]);
                item.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                item.ItemName = Convert.ToString(dr["ItemName"]);
                item.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                item.PurchasePrice = Convert.ToDouble(dr["PurchasePrice"]);
                item.MfgDate = Convert.ToDateTime(dr["MfgDate"]).Date;
                item.ExpDate = Convert.ToDateTime(dr["ExpDate"]).Date;
                item.LeadTime = Convert.ToInt32(dr["LeadTime"]);
                item.Unit_of_Measure = Convert.ToString(dr["Unit_of_Measure"]);
                itemList.Add(item);
            }
            Sqlcon.Close();
           return itemList;
        }

        //getItembyID
        public List<ItemsModel> viewItemByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_ItemsbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@ItemID",id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                ItemsModel item = new ItemsModel();
                item.ItemID = Convert.ToInt32(dr["ItemID"]);
                item.VendorID = Convert.ToInt32(dr["VendorID"]);
                item.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                item.ItemName = Convert.ToString(dr["ItemName"]);
                item.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                item.PurchasePrice = Convert.ToDouble(dr["PurchasePrice"]);
                item.MfgDate = Convert.ToDateTime(dr["MfgDate"]).Date;
                item.ExpDate = Convert.ToDateTime(dr["ExpDate"]).Date;
                item.LeadTime = Convert.ToInt32(dr["LeadTime"]);
                item.Unit_of_Measure = Convert.ToString(dr["Unit_of_Measure"]);
                itemList.Add(item);
            }
            Sqlcon.Close();
            return itemList;
        }

        //UpdateItem
        public void UpdateItem(ItemsModel item)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Update_Items", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                Sqlcmd.Parameters.AddWithValue("@VendorID", item.VendorID);
                Sqlcmd.Parameters.AddWithValue("@CategoryID", item.CategoryID);
                Sqlcmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                Sqlcmd.Parameters.AddWithValue("@MfgDate", item.MfgDate.Date);
                Sqlcmd.Parameters.AddWithValue("@ExpDate", item.ExpDate.Date);
                Sqlcmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                Sqlcmd.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                Sqlcmd.Parameters.AddWithValue("@LeadTime", item.LeadTime);
                Sqlcmd.Parameters.AddWithValue("@Unit_of_Measure", item.Unit_of_Measure);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();
            }

        }

        //DeleteItem
        public void DeleteItem(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Delete_Items", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(Sqlcmd);
            Sqlcmd.Parameters.AddWithValue("@ItemID",id);
            Sqlcon.Open();
            Sqlcmd.ExecuteNonQuery();
            Sqlcon.Close();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;
using DataAccessLayer.SupplyChain.LoadInventory;
using System.Data;
using System.Collections;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class ItemsLogic
    {   
        //Initializaton
        ItemDAL ItemDAL = new ItemDAL();
        List<ItemsModel> itemList = new List<ItemsModel>();
        
        
        //add record
        public void addItems(ItemsModel item)
        {
            ItemDAL.addItems(item);
        }

        //view record
        public DataSet showItems()
        {
            DataSet ds = ItemDAL.showItems();
            return ds;
        }

        //getItemList
        public List<ItemsModel> getItemsList()
        {
            itemList = ItemDAL.getItemsList();
            return itemList;
        }

        //getItembyID
        public List<ItemsModel> view_ItemsByID(int id)
        {
            itemList = ItemDAL.viewItemByID(id);
            return itemList;
        }

        //UpdateItem
        public void UpdateItem(ItemsModel item)
        {
            ItemDAL.UpdateItem(item);
        }

        //deleteItem
        public void DeleteItem(int id)
        {
            ItemDAL.DeleteItem(id);
        }

        //public ItemsModel getItemModel()
        //{
        //    DataSet ds = ItemDAL.showItems();
        //    DataTable dt = ds.Tables[0];
        //    //itemList = CommonMethod.ConvertToList<ItemsModel>(dt);
        //    itemList = dt.DataTableToList<ItemsModel>();

        //    foreach (ItemsModel i in itemList)
        //    {
        //        i.ItemID = itemList.Select(x => x.ItemID).FirstOrDefault();
        //        i.VendorID = itemList.Select(x => x.VendorID).FirstOrDefault();
        //        i.CategoryID = itemList.Select(x => x.CategoryID).FirstOrDefault();
        //        i.ItemName = itemList.Select(x => x.ItemName).FirstOrDefault();
        //        i.LeadTime = itemList.Select(x => x.LeadTime).FirstOrDefault();
        //        i.MfgDate = itemList.Select(x => x.MfgDate.Date).FirstOrDefault();
        //        i.ExpDate = itemList.Select(x => x.ExpDate.Date).FirstOrDefault();
        //        i.UnitPrice = itemList.Select(x => x.UnitPrice).FirstOrDefault();
        //        i.PurchasePrice = itemList.Select(x => x.PurchasePrice).FirstOrDefault();
        //        i.Unit_of_Measure = itemList.Select(x => x.Unit_of_Measure).FirstOrDefault();
        //        item = i;

        //    }

        //    return item;
        //}
    
    }
    public static class Helper
{
    private static readonly IDictionary<Type, ICollection<PropertyInfo>> _Properties =
        new Dictionary<Type, ICollection<PropertyInfo>>();

    /// <summary>
    /// Converts a DataTable to a list with generic objects
    /// </summary>
    /// <typeparam name="T">Generic object</typeparam>
    /// <param name="table">DataTable</param>
    /// <returns>List with generic objects</returns>
    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            var objType = typeof(T);
            ICollection<PropertyInfo> properties;

            lock (_Properties)
            {
                if (!_Properties.TryGetValue(objType, out properties))
                {
                    properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                    _Properties.Add(objType, properties);
                }
            }

            var list = new List<T>(table.Rows.Count);

            foreach (var row in table.AsEnumerable())
            {
                var obj = new T();

                foreach (var prop in properties)
                {
                    try
                    {
                        var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        var safeValue = row[prop.Name] == null ? null : Convert.ChangeType(row[prop.Name], propType);

                        prop.SetValue(obj, safeValue, null);
                    }
                    catch
                    {
                        // ignored
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        catch
        {
            return null ;
        }
    }
}
}

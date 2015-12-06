using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;  
using AhcTest.Helper.External.Models;

namespace AhcTest.Helper
{
    public class XMLReader
    {
        public List<Orders> RetrunListOfOrders()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var products = new List<Orders>();
            products = (from rows in ds.Tables[0].AsEnumerable()
                        select new Orders
                        {
                            OrderID = Convert.ToInt32(rows[0].ToString()), //Convert row to int  
                            Ordered = Convert.ToInt32(rows[1].ToString()),
                            PeriodDate = rows[2].ToString(),
                            PeriodLabel = rows[3].ToString(),
                            Shipped = Convert.ToInt32(rows[4].ToString()),
                            TotalAmountOrdered = Convert.ToInt32(rows[5].ToString()),
                            TotalAmountShipped = Convert.ToInt32(rows[6].ToString())
                        }).ToList();
            return products;
        }   
    }
}

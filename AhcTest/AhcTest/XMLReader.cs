using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;

namespace AhcTest
{
    public class XMLReader
    {
        public List<AhcTest.Models.OrdersModel.Orders> ReturnListOfOrders()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var orders = new List<AhcTest.Models.OrdersModel.Orders>();
            orders = (from rows in ds.Tables[0].AsEnumerable()
                        select new AhcTest.Models.OrdersModel.Orders
                        {
                            OrderID = Convert.ToInt32(rows[0].ToString()), //Convert row to int  
                            Ordered = Convert.ToInt32(rows[1].ToString()),
                            PeriodDate = rows[2].ToString(),
                            PeriodLabel = rows[3].ToString(),
                            Shipped = Convert.ToInt32(rows[4].ToString()),
                            TotalAmountOrdered = Convert.ToInt32(rows[5].ToString()),
                            TotalAmountShipped = Convert.ToInt32(rows[6].ToString()),
                            AverageOrdered = String.Format("{0:#,###0}",ReturnAverageOrderedAmount()),
                            TotalOrdered = String.Format("{0:#,###0}",ReturnTotalOrdered()),
                            AverageShipped = String.Format("{0:#,###0}",ReturnAverageShipped()),
                            TotalShipped = String.Format("{0:#,###0}", ReturnTotalShipped()),
                            ChartData = ReturnChartData()
                        }).ToList();
            return orders;
        }

        public int ReturnAverageOrderedAmount()
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");
            XDocument xmlDoc = XDocument.Load(strFileName);
            var xmlValue = (from prod in xmlDoc.Descendants("OrderSummary")
                            select
                            (
                                        int.Parse(prod.Element("TotalOrderedAmount").Value)
                            )).Average();

            return Convert.ToInt32(xmlValue);
        }

        private int ReturnTotalOrdered()
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");
            XDocument xmlDoc = XDocument.Load(strFileName);
            var xmlValue = (from prod in xmlDoc.Descendants("OrderSummary")
                            select
                            (
                                        int.Parse(prod.Element("TotalOrderedAmount").Value)
                            )).Sum();

            return xmlValue;
        }

        private int ReturnAverageShipped()
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");
            XDocument xmlDoc = XDocument.Load(strFileName);
            var xmlValue = (from prod in xmlDoc.Descendants("OrderSummary")
                            select
                            (
                                        int.Parse(prod.Element("TotalShippedAmount").Value)
                            )).Average();

            return Convert.ToInt32(xmlValue);
        }

        private int ReturnTotalShipped()
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");
            XDocument xmlDoc = XDocument.Load(strFileName);
            var xmlValue = (from prod in xmlDoc.Descendants("OrderSummary")
                            select
                            (
                                        int.Parse(prod.Element("TotalShippedAmount").Value)
                            )).Sum();

            return xmlValue;
        }

        public List<AhcTest.Models.ChartModel.Chart> ReturnChartData()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/WeekByWeek.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var chartData = new List<AhcTest.Models.ChartModel.Chart>();
            chartData = (from rows in ds.Tables[0].AsEnumerable()
                         select new AhcTest.Models.ChartModel.Chart
                         {
                             PeriodLabel = rows[3].ToString(),
                             TotalAmountOrdered = Convert.ToInt32(rows[5].ToString()),
                             TotalAmountShipped = Convert.ToInt32(rows[6].ToString())
                         }).ToList();


            return chartData;
        }
    }
}
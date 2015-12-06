using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AhcTest.Models
{
    public class OrdersModel
    {
        [Serializable]
        [XmlRoot("Orders"), XmlType("Orders")]
        public class Orders
        {
            public int OrderID { get; set; }
            public int Ordered { get; set; }
            public string PeriodDate { get; set; }
            public string PeriodLabel { get; set; }
            public int Shipped { get; set; }
            public int TotalAmountOrdered { get; set; }
            public int TotalAmountShipped { get; set; }
            public string AverageOrdered { get; set; }
            public string TotalOrdered { get; set; }
            public string AverageShipped { get; set; }
            public string TotalShipped { get; set; }
            public List<ChartModel.Chart> ChartData {get; set;}
        }
    }
}
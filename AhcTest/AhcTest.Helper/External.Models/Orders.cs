using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AhcTest.Helper.External.Models
{
    [Serializable]
    [XmlRoot("Products"), XmlType("Products")]
    public class Orders
    {
        public int OrderID { get; set; }
        public int Ordered { get; set; }
        public string PeriodDate {get; set;}
        public string PeriodLabel {get; set;}
        public int Shipped {get;set;}
        public int TotalAmountOrdered { get; set; }
        public int TotalAmountShipped { get; set; }
        
    }   
}

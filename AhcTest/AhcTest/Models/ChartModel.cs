using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AhcTest.Models
{
    public class ChartModel
    {
        [Serializable]
        [XmlRoot("Chart"), XmlType("Chart")]
        public class Chart
        {
            public string PeriodLabel { get; set; }
            public int TotalAmountOrdered { get; set; }
            public int TotalAmountShipped { get; set; }
        }
    }
}
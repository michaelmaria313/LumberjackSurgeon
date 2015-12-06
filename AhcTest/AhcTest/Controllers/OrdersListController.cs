using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AhcTest.Models;

namespace AhcTest.Controllers
{
    public class OrdersListController : Controller
    {
        //
        // GET: /List of Orders/

        public ActionResult Index()
        {
            XMLReader readXML = new XMLReader();
            var dataSet = readXML.ReturnListOfOrders();
            return View(dataSet.ToList());
        }

    }
}

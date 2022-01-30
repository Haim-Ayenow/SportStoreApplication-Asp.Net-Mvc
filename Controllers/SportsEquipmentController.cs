using SportStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStoreApplication.Controllers
{
    public class SportsEquipmentController : Controller
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: SportsEquipment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Equipment(string Type)
        {
            switch (Type)
            {
                case "Football":
                    return View(sportstoredb.SportsEquipments.Where(item => item.Category =="Football").ToList());

                case "BasketBall":
                    return View(sportstoredb.SportsEquipments.Where(item => item.Category == "BasketBall").ToList());

                case "SortedByLowToHigher":
                    return View(sportstoredb.SportsEquipments.OrderBy(item => item.Price).ToList());

                case "SortedByHigherToLow":
                    return View(sportstoredb.SportsEquipments.OrderByDescending(price => price.Price).ToList());
            }
            return View(sportstoredb.SportsEquipments.ToList());
               
        }
        public ActionResult EquipmentManagerShow()
        {
            return View(sportstoredb.SportsEquipments);
        }
    }
}
using SportStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStoreApplication.Controllers
{
    public class ShoesController : Controller
    {
             static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
              SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: Shoes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowShoes()
        {
            return View(sportstoredb.Shoes);
        }
        public ActionResult ManagerShow()
        {
            return View(sportstoredb.Shoes);
        }
        public ActionResult SalesShow()
        {
            return View(sportstoredb.Shoes);
        }

    }
}
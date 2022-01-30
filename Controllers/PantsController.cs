using SportStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStoreApplication.Controllers
{
    public class PantsController : Controller
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: Pants
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowPants(string Type)
        {
            switch (Type)
            {
                case "ShortPants":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants" && item.IsShort == true).ToList());

                case "LongPants":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants" && item.IsShort == false).ToList());

                case "DryFit":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants" && item.IsDryFit == true).ToList());


                case "SortedByLowerToHigher ":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants").OrderBy(item => item.Price).ToList());

                case "SortedByHigherToLower":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants").OrderByDescending(price => price.Price).ToList());
            }
            return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants").ToList());

        }
        public ActionResult ManagerShow()
        {
            return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants").ToList());
        }
    }
}
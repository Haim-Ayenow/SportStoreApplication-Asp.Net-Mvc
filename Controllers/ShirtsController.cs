using SportStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStoreApplication.Controllers
{
    public class ShirtsController : Controller
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: Shirts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowShirts(string selectedType)
        {


            switch (selectedType)
            {
                case "ShortSleeves":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt" && item.IsShort == true).ToList());

                case "LongSleeves":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt" && item.IsShort == false).ToList());

                case "Dryfit":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt" && item.IsDryFit == true).ToList());


                case "SortedByLowToHigher":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt").OrderBy(item => item.Price).ToList());

                case "SortedByHigherToLow":
                    return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt").OrderByDescending(price => price.Price).ToList());
            }
            return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt").ToList());
        }
        public ActionResult ManagerShow()
        {
            return View(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirt").ToList());
        }

    }
}
using SportStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportStoreApplication.Controllers.API
{
    public class PantsController : ApiController
    {
        // GET: api/Pants
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: api/Shirts
        public IHttpActionResult Get()
        {
            return Ok(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Pants").ToList());
        }

        // GET: api/Shirts/5
        public IHttpActionResult Get(int id)
        {

            try
            {
                Clothe Pants = sportstoredb.Clothes.First(item => item.TypeOfCloth == "Pants" && item.Id == id);
                if (Pants != null)
                {
                    return Ok(new { Pants });
                }
                return NotFound();
            }
            catch (SqlException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/Shirts
        public IHttpActionResult Post([FromBody] Clothe pants)
        {
            try
            {
                if (pants != null)
                {
                    sportstoredb.Clothes.InsertOnSubmit(pants);
                    sportstoredb.SubmitChanges();
                    return Ok("item was added");
                }
                return BadRequest();
            }
            catch (SqlException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Shirts/5
        public IHttpActionResult Put(int id, [FromBody] Clothe clothe)
        {
            try
            {
                Clothe EditClothes = sportstoredb.Clothes.First(Item => Item.TypeOfCloth == "Pants" && Item.Id == id);
                if (clothe != null)
                {
                    EditClothes.TypeOfCloth = clothe.TypeOfCloth;
                    EditClothes.Gender = clothe.Gender;
                    EditClothes.Company = clothe.Company;
                    EditClothes.Brand = clothe.Brand;
                    EditClothes.Price = clothe.Price;
                    EditClothes.Amount = clothe.Amount;
                    EditClothes.IsShort = clothe.IsShort;
                    EditClothes.IsDryFit = clothe.IsDryFit;
                    EditClothes.Picture = clothe.Picture;

                    sportstoredb.SubmitChanges();
                    return Ok("item was edited");

                }
                return NotFound();
            }
            catch (SqlException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Shirts/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Clothe pants = sportstoredb.Clothes.First(Item => Item.TypeOfCloth == "Pants" && Item.Id == id);
                if (pants != null)
                {
                    sportstoredb.Clothes.DeleteOnSubmit(pants);
                    sportstoredb.SubmitChanges();
                    return Ok("item was deleted");
                }
                return NotFound();
            }
            catch (SqlException err)
            {
                return BadRequest(err.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

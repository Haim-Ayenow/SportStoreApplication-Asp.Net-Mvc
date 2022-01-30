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

    public class ShirtsController : ApiController
    { 
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: api/Shirts
        public IHttpActionResult Get()
        {
            return Ok(sportstoredb.Clothes.Where(item => item.TypeOfCloth == "Shirts").ToList());
        }

        // GET: api/Shirts/5
        public IHttpActionResult Get(int id)
        {
          
                try
                {
                    Clothe shirts = sportstoredb.Clothes.First(item => item.TypeOfCloth == "Shirt" && item.Id == id);
                    if (shirts != null)
                    {
                        return Ok(new { shirts });
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
        public IHttpActionResult Post([FromBody]Clothe shirt)
        {
            try
            {
                if (shirt != null)
                {
                    sportstoredb.Clothes.InsertOnSubmit(shirt);
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
        public IHttpActionResult Put(int id, [FromBody]Clothe clothe)
        {
            try
            {
                Clothe EditClothes = sportstoredb.Clothes.First(Item => Item.TypeOfCloth == "Shirts" && Item.Id==id);
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
                Clothe shirts = sportstoredb.Clothes.First(Item => Item.TypeOfCloth == "Shirts" && Item.Id == id);
                if (shirts != null)
                {
                    sportstoredb.Clothes.DeleteOnSubmit(shirts);
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

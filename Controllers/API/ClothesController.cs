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
    public class ClothesController : ApiController
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: api/Clothes
        public IHttpActionResult Get()
        {
            return Ok(sportstoredb.Clothes.ToList());
        }

        // GET: api/Clothes/5
        public IHttpActionResult Get(int id)
        {
            try { 
            Clothe ItemId = sportstoredb.Clothes.First(item => item.Id == id);
                if (ItemId != null)
                {
                 return Ok(new { ItemId });
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

        // POST: api/Clothes
        public IHttpActionResult Post([FromBody]Clothe clothe)
        {
            try
            {
                if (clothe != null)
                {
                    sportstoredb.Clothes.InsertOnSubmit(clothe);
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

        // PUT: api/Clothes/5
        public IHttpActionResult Put(int id, [FromBody]Clothe clothe)
        {
            try
            {
                Clothe EditClothes = sportstoredb.Clothes.First(Item => Item.Id == id);
                if(clothe != null)
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
            catch(SqlException err)
            {
                return BadRequest(err.Message);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Clothes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Clothe clothe = sportstoredb.Clothes.First(item => item.Id == id);
                if (clothe != null)
                {
                    sportstoredb.Clothes.DeleteOnSubmit(clothe);
                    sportstoredb.SubmitChanges();
                    return Ok("otem was deleted");
                }
                return NotFound();
            }
            catch(SqlException err)
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

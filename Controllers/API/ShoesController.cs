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
    public class ShoesController : ApiController
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportstoredb = new SportStoreDataContext(ConnectionString);
        // GET: api/Shoes
        public IHttpActionResult Get()
        {
            return Ok(sportstoredb.Shoes.ToList());
        }

        // GET: api/Shoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Shoe shoe = sportstoredb.Shoes.First(item => item.Id == id);
                if (shoe != null)
                {
                    return Ok(new { shoe });
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

        // POST: api/Shoes
        public IHttpActionResult Post([FromBody]Shoe shoe)
        {
            try
            {
                if (shoe != null)
                {
                    sportstoredb.Shoes.InsertOnSubmit(shoe);
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

        // PUT: api/Shoes/5
        public IHttpActionResult Put(int id, [FromBody]Shoe shoe)
        {
            try
            {
                Shoe EditShoes = sportstoredb.Shoes.First(Item => Item.Id == id);
                if (shoe != null)
                {
                    EditShoes.ShoeType = shoe.ShoeType;
                    EditShoes.Company = shoe.Company;
                    EditShoes.Brand = shoe.Brand;
                    EditShoes.Price = shoe.Price;
                    EditShoes.Amount = shoe.Amount;
                    EditShoes.IsSale = shoe.IsSale;
                    EditShoes.Picture = shoe.Picture;


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

        // DELETE: api/Shoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Shoe shoe = sportstoredb.Shoes.First(Item => Item.Id == id);
                if (shoe != null)
                {
                    sportstoredb.Shoes.DeleteOnSubmit(shoe);
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

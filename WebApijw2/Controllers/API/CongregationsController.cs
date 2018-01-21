using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApijw2.Models;

namespace WebApijw2.Controllers.API
{
    public class CongregationsController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/Congregations
        public IQueryable<Congregation> GetCongregations()
        {
            return db.Congregations;
        }

        // GET: api/Congregations/5
        [ResponseType(typeof(Congregation))]
        public IHttpActionResult GetCongregation(int id)
        {
            Congregation congregation = db.Congregations.Find(id);
            if (congregation == null)
            {
                return NotFound();
            }

            return Ok(congregation);
        }

        // PUT: api/Congregations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCongregation(int id, Congregation congregation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != congregation.CongregationId)
            {
                return BadRequest();
            }

            db.Entry(congregation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongregationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Congregations
        [ResponseType(typeof(Congregation))]
        public IHttpActionResult PostCongregation(Congregation congregation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Congregations.Add(congregation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = congregation.CongregationId }, congregation);
        }

        // DELETE: api/Congregations/5
        [ResponseType(typeof(Congregation))]
        public IHttpActionResult DeleteCongregation(int id)
        {
            Congregation congregation = db.Congregations.Find(id);
            if (congregation == null)
            {
                return NotFound();
            }

            db.Congregations.Remove(congregation);
            db.SaveChanges();

            return Ok(congregation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CongregationExists(int id)
        {
            return db.Congregations.Count(e => e.CongregationId == id) > 0;
        }
    }
}
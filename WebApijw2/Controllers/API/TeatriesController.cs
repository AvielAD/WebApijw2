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
    public class TeatriesController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/Teatries
        public IQueryable<Teatry> GetTeatrys()
        {
            return db.Teatrys;
        }

        // GET: api/Teatries/5
        [ResponseType(typeof(Teatry))]
        public IHttpActionResult GetTeatry(int id)
        {
            Teatry teatry = db.Teatrys.Find(id);
            if (teatry == null)
            {
                return NotFound();
            }

            return Ok(teatry);
        }

        // PUT: api/Teatries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeatry(int id, Teatry teatry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teatry.TeatryId)
            {
                return BadRequest();
            }

            db.Entry(teatry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeatryExists(id))
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

        // POST: api/Teatries
        [ResponseType(typeof(Teatry))]
        public IHttpActionResult PostTeatry(Teatry teatry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teatrys.Add(teatry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teatry.TeatryId }, teatry);
        }

        // DELETE: api/Teatries/5
        [ResponseType(typeof(Teatry))]
        public IHttpActionResult DeleteTeatry(int id)
        {
            Teatry teatry = db.Teatrys.Find(id);
            if (teatry == null)
            {
                return NotFound();
            }

            db.Teatrys.Remove(teatry);
            db.SaveChanges();

            return Ok(teatry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeatryExists(int id)
        {
            return db.Teatrys.Count(e => e.TeatryId == id) > 0;
        }
    }
}
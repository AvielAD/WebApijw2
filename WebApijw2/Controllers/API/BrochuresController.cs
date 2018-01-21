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
    public class BrochuresController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/Brochures
        public IQueryable<Brochure> GetBrochures()
        {
            return db.Brochures;
        }

        // GET: api/Brochures/5
        [ResponseType(typeof(Brochure))]
        public IHttpActionResult GetBrochure(int id)
        {
            Brochure brochure = db.Brochures.Find(id);
            if (brochure == null)
            {
                return NotFound();
            }

            return Ok(brochure);
        }

        // PUT: api/Brochures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrochure(int id, Brochure brochure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brochure.BrochureId)
            {
                return BadRequest();
            }

            db.Entry(brochure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrochureExists(id))
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

        // POST: api/Brochures
        [ResponseType(typeof(Brochure))]
        public IHttpActionResult PostBrochure(Brochure brochure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brochures.Add(brochure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brochure.BrochureId }, brochure);
        }

        // DELETE: api/Brochures/5
        [ResponseType(typeof(Brochure))]
        public IHttpActionResult DeleteBrochure(int id)
        {
            Brochure brochure = db.Brochures.Find(id);
            if (brochure == null)
            {
                return NotFound();
            }

            db.Brochures.Remove(brochure);
            db.SaveChanges();

            return Ok(brochure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrochureExists(int id)
        {
            return db.Brochures.Count(e => e.BrochureId == id) > 0;
        }
    }
}
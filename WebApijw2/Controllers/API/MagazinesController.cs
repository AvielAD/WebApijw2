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
    public class MagazinesController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/Magazines
        public IQueryable<Magazine> GetMagazine()
        {
            return db.Magazine;
        }

        // GET: api/Magazines/5
        [ResponseType(typeof(Magazine))]
        public IHttpActionResult GetMagazine(int id)
        {
            Magazine magazine = db.Magazine.Find(id);
            if (magazine == null)
            {
                return NotFound();
            }

            return Ok(magazine);
        }

        // PUT: api/Magazines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMagazine(int id, Magazine magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != magazine.MagazineId)
            {
                return BadRequest();
            }

            db.Entry(magazine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineExists(id))
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

        // POST: api/Magazines
        [ResponseType(typeof(Magazine))]
        public IHttpActionResult PostMagazine(Magazine magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Magazine.Add(magazine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = magazine.MagazineId }, magazine);
        }

        // DELETE: api/Magazines/5
        [ResponseType(typeof(Magazine))]
        public IHttpActionResult DeleteMagazine(int id)
        {
            Magazine magazine = db.Magazine.Find(id);
            if (magazine == null)
            {
                return NotFound();
            }

            db.Magazine.Remove(magazine);
            db.SaveChanges();

            return Ok(magazine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MagazineExists(int id)
        {
            return db.Magazine.Count(e => e.MagazineId == id) > 0;
        }
    }
}
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
    public class EditorialsController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/Editorials
        public IQueryable<Editorial> GetEditorials()
        {
            return db.Editorials;
        }

        // GET: api/Editorials/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult GetEditorial(int id)
        {
            Editorial editorial = db.Editorials.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            return Ok(editorial);
        }

        // PUT: api/Editorials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEditorial(int id, Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editorial.MyProperty)
            {
                return BadRequest();
            }

            db.Entry(editorial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialExists(id))
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

        // POST: api/Editorials
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult PostEditorial(Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Editorials.Add(editorial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = editorial.MyProperty }, editorial);
        }

        // DELETE: api/Editorials/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult DeleteEditorial(int id)
        {
            Editorial editorial = db.Editorials.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            db.Editorials.Remove(editorial);
            db.SaveChanges();

            return Ok(editorial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditorialExists(int id)
        {
            return db.Editorials.Count(e => e.MyProperty == id) > 0;
        }
    }
}
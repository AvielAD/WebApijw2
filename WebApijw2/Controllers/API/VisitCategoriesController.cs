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
    public class VisitCategoriesController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/VisitCategories
        public IQueryable<VisitCategory> GetVisitCategories()
        {
            return db.VisitCategories;
        }

        // GET: api/VisitCategories/5
        [ResponseType(typeof(VisitCategory))]
        public IHttpActionResult GetVisitCategory(int id)
        {
            VisitCategory visitCategory = db.VisitCategories.Find(id);
            if (visitCategory == null)
            {
                return NotFound();
            }

            return Ok(visitCategory);
        }

        // PUT: api/VisitCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitCategory(int id, VisitCategory visitCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitCategory.VisitCategoryId)
            {
                return BadRequest();
            }

            db.Entry(visitCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitCategoryExists(id))
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

        // POST: api/VisitCategories
        [ResponseType(typeof(VisitCategory))]
        public IHttpActionResult PostVisitCategory(VisitCategory visitCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VisitCategories.Add(visitCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visitCategory.VisitCategoryId }, visitCategory);
        }

        // DELETE: api/VisitCategories/5
        [ResponseType(typeof(VisitCategory))]
        public IHttpActionResult DeleteVisitCategory(int id)
        {
            VisitCategory visitCategory = db.VisitCategories.Find(id);
            if (visitCategory == null)
            {
                return NotFound();
            }

            db.VisitCategories.Remove(visitCategory);
            db.SaveChanges();

            return Ok(visitCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitCategoryExists(int id)
        {
            return db.VisitCategories.Count(e => e.VisitCategoryId == id) > 0;
        }
    }
}
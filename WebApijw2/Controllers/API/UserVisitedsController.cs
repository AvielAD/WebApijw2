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
    public class UserVisitedsController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/UserVisiteds
        public IQueryable<UserVisited> GetUserVisited()
        {
            return db.UserVisited;
        }

        // GET: api/UserVisiteds/5
        [ResponseType(typeof(UserVisited))]
        public IHttpActionResult GetUserVisited(int id)
        {
            UserVisited userVisited = db.UserVisited.Find(id);
            if (userVisited == null)
            {
                return NotFound();
            }

            return Ok(userVisited);
        }

        // PUT: api/UserVisiteds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserVisited(int id, UserVisited userVisited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userVisited.UserVisitedId)
            {
                return BadRequest();
            }

            db.Entry(userVisited).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserVisitedExists(id))
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

        // POST: api/UserVisiteds
        [ResponseType(typeof(UserVisited))]
        public IHttpActionResult PostUserVisited(UserVisited userVisited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserVisited.Add(userVisited);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userVisited.UserVisitedId }, userVisited);
        }

        // DELETE: api/UserVisiteds/5
        [ResponseType(typeof(UserVisited))]
        public IHttpActionResult DeleteUserVisited(int id)
        {
            UserVisited userVisited = db.UserVisited.Find(id);
            if (userVisited == null)
            {
                return NotFound();
            }

            db.UserVisited.Remove(userVisited);
            db.SaveChanges();

            return Ok(userVisited);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserVisitedExists(int id)
        {
            return db.UserVisited.Count(e => e.UserVisitedId == id) > 0;
        }
    }
}
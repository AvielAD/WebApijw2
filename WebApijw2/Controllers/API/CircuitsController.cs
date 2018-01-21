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
    public class CircuitsController : ApiController
    {
        private JWContext db = new JWContext();

        // GET: api/Circuits
        public IQueryable<Circuit> GetCircuits()
        {
            return db.Circuits;
        }

        // GET: api/Circuits/5
        [ResponseType(typeof(Circuit))]
        public IHttpActionResult GetCircuit(int id)
        {
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return NotFound();
            }

            return Ok(circuit);
        }

        // PUT: api/Circuits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCircuit(int id, Circuit circuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != circuit.CircuitId)
            {
                return BadRequest();
            }

            db.Entry(circuit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitExists(id))
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

        // POST: api/Circuits
        [ResponseType(typeof(Circuit))]
        public IHttpActionResult PostCircuit(Circuit circuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Circuits.Add(circuit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = circuit.CircuitId }, circuit);
        }

        // DELETE: api/Circuits/5
        [ResponseType(typeof(Circuit))]
        public IHttpActionResult DeleteCircuit(int id)
        {
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return NotFound();
            }

            db.Circuits.Remove(circuit);
            db.SaveChanges();

            return Ok(circuit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CircuitExists(int id)
        {
            return db.Circuits.Count(e => e.CircuitId == id) > 0;
        }
    }
}
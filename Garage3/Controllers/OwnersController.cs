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
using Garage3.DataAccess;
using Garage3.Entities;

namespace Garage3.Controllers
{
    public class OwnersController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/Owners
        public ICollection<Owner> GetOwners()
        {
            return db.Owners.ToList();
        }

        // GET: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult GetOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOwner(int id, Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.PersonId)
            {
                return BadRequest();
            }

            db.Entry(owner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        [ResponseType(typeof(Owner))]
        public IHttpActionResult PostOwner(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Owners.Add(owner);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OwnerExists(owner.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = owner.PersonId }, owner);
        }

        // DELETE: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            db.Owners.Remove(owner);
            db.SaveChanges();

            return Ok(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerExists(int id)
        {
            return db.Owners.Count(e => e.PersonId == id) > 0;
        }
    }
}
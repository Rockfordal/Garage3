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
using Garage3.Repositories;

namespace Garage3.Controllers
{
    public class OwnersController : ApiController
    {
        private readonly SuperRepository _repo;

        public OwnersController ()
        {
            _repo = new SuperRepository();
        }

        // GET: api/Owners
        public ICollection<Owner> GetOwners()
        {
            return _repo.GetAllOwners().ToList();
        }

        // GET: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult GetOwner(int id)
        {
            var owner = _repo.FindOwnerById(id);

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOwner(int id, Owner owner)
        {
            _repo.UpdateOwner(owner);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Owners
        [ResponseType(typeof(Owner))]
        public IHttpActionResult PostOwner(Owner owner)
        {
            _repo.AddOwner(owner);

            return CreatedAtRoute("DefaultApi", new { id = owner.PersonId }, owner);
        }

        // DELETE: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {

            var owner = _repo.RemoveOwner(id);

            return Ok(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
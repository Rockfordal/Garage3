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
    public class VehiclesController : ApiController
    {
        private readonly SuperRepository _repo;

        // GET: api/Vehicles
        public ICollection<Vehicle> GetVehicles()
        {
            return _repo.GetAllVehicles().ToList();
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {
            var vehicle = _repo.FindVehicleById(id);

            return Ok(vehicle);
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            _repo.UpdateVehicle(vehicle);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.AddVehicle(vehicle);

            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }


        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var vehicle = _repo.RemoveVehicle(id);

            return Ok(vehicle);
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
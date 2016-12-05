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
    public class VehicleTypesController : ApiController
    {
        private readonly SuperRepository _repo;

        public VehicleTypesController()
        {
            _repo = new SuperRepository();
        }

        // GET: api/VehicleTypes
        public ICollection<VehicleType> Get_VehicleTypes()
        {
            return _repo.GetAllVehicleTypes().ToList();
        }

        // GET: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult GetVehicleType(int id)
        {
            var vehicleType = _repo.FindVehicleTypeById(id);
            return Ok(vehicleType);
        }

        // PUT: api/VehicleTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleType(int id, VehicleType vehicleType)
        {
            _repo.UpdateVehicleType(vehicleType);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleTypes
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult PostVehicleType(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.AddVehicleType(vehicleType);

            return CreatedAtRoute("DefaultApi", new { id = vehicleType.Id }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult DeleteVehicleType(int id)
        {
            _repo.RemoveVehicleType(id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool VehicleTypeExists(int id)
        //{
        //    return _repo.VehicleTypes.Count(e => e.Id == id) > 0;
        //}
    }
}
﻿using System;
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
    public class VehicleTypesController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/VehicleTypes
        public IQueryable<VehicleType> Get_VehicleTypes()
        {
            return db.VehicleTypes;
        }

        // GET: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult GetVehicleType(int id)
        {
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return Ok(vehicleType);
        }

        // PUT: api/VehicleTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleType(int id, VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleType.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(id))
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

        // POST: api/VehicleTypes
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult PostVehicleType(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleTypes.Add(vehicleType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleType.Id }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult DeleteVehicleType(int id)
        {
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            db.VehicleTypes.Remove(vehicleType);
            db.SaveChanges();

            return Ok(vehicleType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleTypeExists(int id)
        {
            return db.VehicleTypes.Count(e => e.Id == id) > 0;
        }
    }
}
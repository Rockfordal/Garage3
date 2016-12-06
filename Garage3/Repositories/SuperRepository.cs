using Garage3.DataAccess;
using Garage3.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage3.Repositories
{
    public class SuperRepository
    {
        private AppContext db = new AppContext();

        public int MyProperty { get; set; }

        public void Dispose()
        {
            db.Dispose();
        }

        #region Person

        public IEnumerable<Person> GetPeople()
        {
            return db.People;
        }

        public Person FindPersonById(int? id)
        {
            return db.People.Find(id);
        }

        public void AddPerson(Person p)
        {
            db.People.Add(p);
            db.SaveChanges();
        }

        public void UpdatePerson(Person p)
        {
            db.Entry(p).State = EntityState.Modified;

            //db.Entry(person).State = EntityState.Modified;
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}


            db.SaveChanges();
        }

        public Person RemovePerson(int id)
        {

            Person person = db.People.Find(id);
            if (person == null)
            {
                //return NotFound();
                return null;
            }

            db.People.Remove(person);
            db.SaveChanges();
            return person;
        }

        private bool PersonExists(int id)
        {
            return GetPeople().Count(p => p.Id == id) > 0;
        }

        #endregion

        #region VehicleType

        public IQueryable<VehicleType> GetAllVehicleTypes()
        {
            return db.VehicleTypes;
        }

        //public List<string> VehicleTypes()
        //{
        //    List<string> tmp = new List<string>();
        //    foreach (var vt in db.VehicleTypes)
        //    {
        //        tmp.Add(vt.Type);
        //    }
        //    return tmp;
        //}

        public VehicleType FindVehicleTypeById(int? id)
        {
            return db.VehicleTypes.Find(id);
        }

        public void AddVehicleType(VehicleType vt)
        {
            db.VehicleTypes.Add(vt);
            db.SaveChanges();
        }

        public void UpdateVehicleType(VehicleType vt)
        {
            db.Entry(vt).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonExists(id))
            //        return NotFound();
            //    else
            //        throw;
            //}

            db.SaveChanges();
        }

        public void VehicleTypeEntry(VehicleType vt)
        {
            db.Entry(vt).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveVehicleType(int id)
        {
            db.VehicleTypes.Remove(FindVehicleTypeById(id));
            db.SaveChanges();
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Count(e => e.Id == id) > 0;
        }

        #endregion

        #region Vehicle

        public string NumToType(string type)
        {
            string tmp = "";
            switch(type)
            {
                case "Car":
                    tmp = "1";
                    break;
                case "Truck":
                    tmp = "2";
                    break;
                case "Boat":
                    tmp = "3";
                    break;
                case "Bike":
                    tmp = "4";
                    break;
            }
            return tmp;
        }

        public IQueryable<Vehicle> GetAllVehicles()
        {
            return db.Vehicles;
        }

        public Vehicle FindVehicleById(int? id)
        {
            return db.Vehicles.Find(id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            var vtid = vehicle.VehicleType.Id;
            var vt = db.VehicleTypes.FirstOrDefault(t => t.Id == vtid);
            vehicle.VehicleType = vt;
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
        }

        public void AddVehicle(Vehicle v, VehicleType vehicleType)
        {
            v.VehicleType = vehicleType;
            db.Vehicles.Add(v);
            db.SaveChanges();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            db.Entry(vehicle).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!VehicleExists(id))
            //        return NotFound();
            //    else
            //        throw;
            //}

            db.SaveChanges();
        }

        public void VehicleEntry(Vehicle v)
        {
            db.Entry(v).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Vehicle RemoveVehicle(int id)
        {
            var vehicle = FindVehicleById(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return vehicle;
        }

        #endregion

        #region Owner

        public IQueryable<Owner> GetAllOwners()
        {
            return db.Owners;
        }

        public void MakeOwner(Vehicle v, Person p)
        {

        }

        public void BecomeOwner(int id)
        {
            //db.Owners.Add(new Owner { PersonId = id });
            db.SaveChanges();
        }

        public Owner FindOwnerById(int? id)
        {
            return db.Owners.Find(id);
        }

        public void AddOwner(Owner o)
        {
            db.Owners.Add(o);
            db.SaveChanges();
        }

        public void UpdateOwner(Owner o)
        {
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public Owner RemoveOwner(int id)
        {
            var owner = FindOwnerById(id);
            db.Owners.Remove(owner);
            db.SaveChanges();
            return owner;
        }

        private bool OwnerExists(int id)
        {
            return db.Owners.Count(e => e.PersonId == id) > 0;
        }

        #endregion

        #region Search

        public IQueryable<Vehicle> GetVehiclesFromSearch(string search, string type)
        {
            return GetAllVehicles()
                .Where(v => (
                        (v.Manufacturer == search || v.RegNr == search || v.Color == search || v.NumberOfWheels.ToString() == search || search == "")
                     && (v.VehicleType.Type == type || type == "")
                       ));
        }

        #endregion

    }
}
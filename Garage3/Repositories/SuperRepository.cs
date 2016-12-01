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
            db.SaveChanges();
        }

        public void RemovePerson(Person p)
        {
            db.People.Remove(p);
            db.SaveChanges();
        }

        public void AddVehicle(Vehicle v, Owner o)
        {

        }

        #endregion

        #region VehicleType

        public IEnumerable<VehicleType> GetAllVehicleTypes()
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

        public void VehicleTypeEntry(VehicleType vt)
        {
            db.Entry(vt).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void VehicleTypeRemove(int id)
        {
            db.VehicleTypes.Remove(FindVehicleTypeById(id));
            db.SaveChanges();
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

        public void AddVehicle(Vehicle v)
        {
            db.Vehicles.Add(v);
            db.SaveChanges();
        }

        public void AddVehicle(Vehicle v, VehicleType vehicleType)
        {
            v.VehicleType = vehicleType;
            db.Vehicles.Add(v);
            db.SaveChanges();
        }

        public void VehicleEntry(Vehicle v)
        {
            db.Entry(v).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveVehicle(int id)
        {
            db.Vehicles.Remove(FindVehicleById(id));
            db.SaveChanges();
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
        
        public void RemoveOwner(int id)
        {
            db.Owners.Remove(FindOwnerById(id));
            db.SaveChanges();
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
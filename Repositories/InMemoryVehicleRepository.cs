using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Best_Practices.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles;

        public InMemoryVehicleRepository()
        {
            _vehicles = new List<Vehicle>();
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _vehicles.AsReadOnly();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));
            
            _vehicles.Add(vehicle);
        }

        public Vehicle Find(string id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.ID.ToString() == id);
            if (vehicle == null)
                throw new KeyNotFoundException($"Vehicle with ID {id} not found");
            
            return vehicle;
        }
    }
}

using Best_Practices.ModelBuilders;
using System;

namespace Best_Practices.Models
{
    public abstract class Vehicle : IVehicle
    {
        #region Private properties
        private bool _isEngineOn { get; set; }
        #endregion

        #region Properties
        public readonly Guid ID;
        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; set; }
        public double FuelLimit { get; set; }
        public int Year { get; set; }
        
        // Propiedades adicionales (preparadas para 20+ propiedades)
        public string VIN { get; set; }
        public int Mileage { get; set; }
        public string TransmissionType { get; set; }
        public string EngineType { get; set; }
        public int Horsepower { get; set; }
        #endregion

        #region Constructors
        protected Vehicle(VehicleBuilder builder)
        {
            ID = Guid.NewGuid();
            Color = builder.Color;
            Brand = builder.Brand;
            Model = builder.Model;
            FuelLimit = builder.FuelLimit;
            Year = builder.Year;
            VIN = builder.VIN;
            Mileage = builder.Mileage;
            TransmissionType = builder.TransmissionType;
            EngineType = builder.EngineType;
            Horsepower = builder.Horsepower;
            Gas = 0;
            _isEngineOn = false;
        }
        #endregion

        #region Methods
        public void AddGas()
        {
            if(Gas >= FuelLimit)
            {
                throw new Exception("Gas Full");
            }
            Gas += 0.1;
        }
        
        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }
            if (NeedsGas())
            {
                throw new Exception("Not enough gas. You need to go to Gas Station");
            }
            _isEngineOn = true;
        }

        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Engine already stopped");
            }
            _isEngineOn = false;
        }
        #endregion
    }
}

using Best_Practices.Models;
using System;

namespace Best_Practices.ModelBuilders
{
    public class VehicleBuilder
    {
        public string Brand { get; private set; } = "Ford";
        public string Model { get; private set; } = "Generic";
        public string Color { get; private set; } = "White";
        public int Year { get; private set; } = DateTime.Now.Year;
        public double FuelLimit { get; private set; } = 10.0;
        
        // Propiedades adicionales con valores por defecto
        public string VIN { get; private set; } = string.Empty;
        public int Mileage { get; private set; } = 0;
        public string TransmissionType { get; private set; } = "Automatic";
        public string EngineType { get; private set; } = "Gasoline";
        public int Horsepower { get; private set; } = 150;

        public VehicleBuilder SetBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        public VehicleBuilder SetModel(string model)
        {
            Model = model;
            return this;
        }

        public VehicleBuilder SetColor(string color)
        {
            Color = color;
            return this;
        }

        public VehicleBuilder SetYear(int year)
        {
            if (year < 1900 || year > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid year");
            Year = year;
            return this;
        }

        public VehicleBuilder SetFuelLimit(double fuelLimit)
        {
            if (fuelLimit <= 0)
                throw new ArgumentException("Fuel limit must be positive");
            FuelLimit = fuelLimit;
            return this;
        }

        public VehicleBuilder SetVIN(string vin)
        {
            VIN = vin;
            return this;
        }

        public VehicleBuilder SetMileage(int mileage)
        {
            Mileage = mileage;
            return this;
        }

        public VehicleBuilder SetTransmissionType(string transmissionType)
        {
            TransmissionType = transmissionType;
            return this;
        }

        public VehicleBuilder SetEngineType(string engineType)
        {
            EngineType = engineType;
            return this;
        }

        public VehicleBuilder SetHorsepower(int horsepower)
        {
            Horsepower = horsepower;
            return this;
        }

        public Car BuildCar()
        {
            return new Car(this);
        }

        public Motorcycle BuildMotorcycle()
        {
            return new Motorcycle(this);
        }
    }
}

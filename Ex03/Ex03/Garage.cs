using System;
using System.Collections.Generic;

namespace Ex03
{
    public class GarageCar
    {
        #region Members and Props
        #region Members
        Vehicle m_vehicle;
        private string m_Owner;
        private string m_PhoneNumber;
        private CarStatus m_CarStatus;
        #endregion Members

        #region Props
        public string Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }
        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }
        public CarStatus CarStatus
        {
            get { return m_CarStatus; }
            set { m_CarStatus = value; }
        }
        public Vehicle Vehicle
        {
            get { return m_vehicle; }
        }
        #endregion Props
        #endregion Members and Props

        public GarageCar(Vehicle vehicle, string owner, string phoneNumber)
        {
            m_vehicle = vehicle;
            Owner = owner;
            PhoneNumber = phoneNumber;
            CarStatus = CarStatus.BeingFixed;
        }
    }

    public class Garage
    {
        private Dictionary<string, GarageCar> m_garage_cars;


        public Garage()
        {
            m_garage_cars = new Dictionary<string, GarageCar>();
        }

        public void AddCarToGarage(Vehicle vehicle, string owner, string phoneNumber)
        {
            GarageCar entry;
            if (m_garage_cars.TryGetValue(vehicle.PlateNumber, out entry))
            {
                entry.CarStatus = CarStatus.BeingFixed;
                return;
            }

            entry = new GarageCar(vehicle, owner, phoneNumber);
            m_garage_cars.Add(vehicle.PlateNumber, entry);
        }

        public void ShowPlateNumbers()
        {
            //Console.WriteLine("Showing all plate numbers");
            foreach (var item in m_garage_cars)
            {
                Console.WriteLine(item.Key);
            }
        }

        public void ShowPlateNumbers(CarStatus carStatus)
        {
            //Console.WriteLine("Showing all plate numbers by status" + carStatus);
            foreach (var item in m_garage_cars)
            {
                if (item.Value.CarStatus == carStatus)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        public void ChangeCarStatus(string plateNumber, CarStatus newCarStatus)
        {
            GarageCar entry;
            if (!m_garage_cars.TryGetValue(plateNumber, out entry))
            {
                throw new ArgumentException("Car with this plate number isn't found");
            }

            entry.CarStatus = newCarStatus;
        }

        public void FillAirInWheels(string plateNumber)
        {
            GarageCar entry;
            if (!m_garage_cars.TryGetValue(plateNumber, out entry))
            {
                throw new ArgumentException("Car with this plate number isn't found");
            }

            foreach (Wheels wheel in entry.Vehicle.Wheels)
            {
                wheel.FillAir(wheel.MaxAirPressure - wheel.AirPressure);
            }

            // Console.WriteLine("Wheels air pressure filled");
        }

        public void FuelGasCar(string plateNumber, GasType gasType, int gasToAdd)
        {
            GarageCar entry;
            if (!m_garage_cars.TryGetValue(plateNumber, out entry))
            {
                throw new ArgumentException("Car with this plate number isn't found");
            }

            if (entry.Vehicle is not IGasolineObject)
            {
                throw new ArgumentException("Vehicle is not gasoline powered");
            }

            IGasolineObject gasVehicle = (IGasolineObject)entry.Vehicle;
            gasVehicle.FillGas(gasType, gasVehicle.MaxGasLiterAmount - gasVehicle.GasLiterAmount);

            // Console.WriteLine("Wheels air pressure filled");
        }

        public void ChargeElectricCar(string plateNumber, int minutesToCharge)
        {
            GarageCar entry;
            if (!m_garage_cars.TryGetValue(plateNumber, out entry))
            {
                throw new ArgumentException("Car with this plate number isn't found");
            }

            if (entry.Vehicle is not IElectricObject)
            {
                throw new ArgumentException("Vehicle is not electric");
            }

            IElectricObject electricVehicle = (IElectricObject)entry.Vehicle;
            electricVehicle.ChargeBattery(electricVehicle.MaxBatteryHours - electricVehicle.BatteryHours);

            // Console.WriteLine("Wheels air pressure filled");
        }
    }

    public enum CarStatus
    {
        BeingFixed,
        Fixed,
        Payed,
    }
}

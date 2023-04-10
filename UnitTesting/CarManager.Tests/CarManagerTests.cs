namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            make = "BMW";
            model = "520";
            fuelConsumption = 5.0;
            fuelCapacity = 70;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }
        [Test]
        public void CheckCarEmptyConstructor()
        {
            Car Expectbmw = new Car("BMW", "520", 5.0, 70);
            Assert.AreEqual(Expectbmw.Make, car.Make);
            Assert.AreEqual(Expectbmw.Model, car.Model);
            Assert.AreEqual(Expectbmw.FuelCapacity, car.FuelCapacity);
            Assert.AreEqual(Expectbmw.FuelConsumption, car.FuelConsumption);
        }
        [Test]
        public void CheckCarPropWhenMakeIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car carMake = new Car("", model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");

        }
        [Test]
        public void CheckCarPropWhenModelIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car carMake = new Car(make, "", fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");

        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-51)]
        public void CheckCarfuelConsumptionIsZeroOrNegative(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car carMake = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void CheckCarfuelAmountIsZeroOrNegative()
        {
            Car carMake = new Car(make, model, fuelConsumption, fuelCapacity);
     
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);

            }, "Fuel consumption cannot be zero or negative!");
            
        }
        [Test]
        public void CheckCarfuelAmount()
        {
            Car carMake = new Car(make, model, fuelConsumption, fuelCapacity);
                car.Refuel(25);
            double expectResult = 25;
            Assert.AreEqual(expectResult, car.FuelAmount);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-51)]
        public void CheckCarfuelCapacityIsZeroOrNegative(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car carMake = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-51)]
        public void CheckCarRefuelWhenFuelQntIsZeroOrNEgative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelCapacity);
            }, "Fuel amount cannot be zero or negative!");
        }
        [TestCase(50)]
        [TestCase(150)]
        [TestCase(1000)]
        public void CheckCarRefuelWhenFuelQntCapacitCheck(double fuelCapacity)
        {
            car.Refuel(25);
            double expectedResult= 25;
            Assert.AreEqual(expectedResult, car.FuelAmount);
            car.Refuel(fuelCapacity);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);

        }
        [TestCase(250)]
        [TestCase(450)]
        [TestCase(1000)]
        public void CheckCarDrive(double distance)
        {
            car.Refuel(6);
            double expectedResult =1;
            car.Drive(100);
            Assert.AreEqual(expectedResult, car.FuelAmount);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }



    }
}
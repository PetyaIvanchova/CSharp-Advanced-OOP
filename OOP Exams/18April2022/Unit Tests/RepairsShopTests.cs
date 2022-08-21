using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
           [Test]
           public void TestNameGarageNull()
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentNullException(nameof(value), "Invalid garage name.");
                //}
               
                Assert.Throws<ArgumentNullException>(()
                    =>new Garage(null,3), "Invalid garage name.");
            }
            [Test]
            public void TestGrageNameEmpty()
            {
                Assert.Throws<ArgumentNullException>(()
                    => new Garage("", 3), "Invalid garage name.");
            }
            [Test]
            public void TestMechanicksAveilabebelowzero()
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException("At least one mechanic must work in the garage.");
                //}
                Assert.Throws<ArgumentException>(()
                   => new Garage("dfgh", -1), "At least one mechanic must work in the garage.");
            }
            [Test]
            public void TestMechanickAveilablezer0()
            {
                Assert.Throws<ArgumentException>(()
                  => new Garage("dfgh", 0), "At least one mechanic must work in the garage.");
            }
            [Test]
            public void TestCarsInGarage()
            {
                //public int CarsInGarage => this.cars.Count;
                Garage garage = new Garage("ivan", 2);
                Car car1 = new Car("Ferrari", 5);
                Car car2 = new Car("BMW", 6);
                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.AreEqual(garage.CarsInGarage, 2);
            }
            [Test]
            public void TestFixCar()
            {
                //Car carToFix = this.cars.FirstOrDefault(x => x.CarModel == carModel);

                //if (carToFix == null)
                //{
                //    throw new InvalidOperationException($"The car {carModel} doesn't exist.");
                //}

                //carToFix.NumberOfIssues = 0;

                //return carToFix;
                Garage garage = new Garage("sfs", 4);
                Car c = new Car(null, 4);
                Assert.Throws<InvalidOperationException>(()
                    => garage.FixCar(null), $"The car {c.CarModel} doesn't exist.");
            }
        }
    }
}
using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]
       public void TestCapacity()
        {
            //    if (value < 0)
            //    {
            //        throw new ArgumentException("Invalid capacity.");
            //    }
            Assert.Throws<ArgumentException>(()
                => new Shop(-1), "Invalid capacity.");
        }
        [Test]
        public void TestCount()
        {
            Shop shop = new Shop(4);
            Smartphone one = new Smartphone("ds", 100);
            Smartphone two = new Smartphone("fs", 100);
            shop.Add(one);
            shop.Add(two);
            Assert.AreEqual(shop.Count, 2);
        }
        [Test]
        public void TestAddone()
        {
            //if (this.phones.Any(x => x.ModelName == smartPhone.ModelName))
            //{
            //    throw new InvalidOperationException($"The phone model {smartPhone.ModelName} already exist.");
            //}
            Shop shop = new Shop(5);
            Smartphone one = new Smartphone("fsds", 100);
            Smartphone two = new Smartphone("fsds", 3);
            shop.Add(one);
            Assert.Throws<InvalidOperationException>(()
                => shop.Add(two), $"The phone model {one.ModelName} already exist.");
        }
        [Test]
        public void TestAqddTwo()
        {
            //else if (this.phones.Count == this.capacity)
            //{
            //    throw new InvalidOperationException("The shop is full.");
            //}
            Shop shop = new Shop(2);
            Smartphone one = new Smartphone("ds", 345);
            Smartphone two = new Smartphone("asd", 26);
            shop.Add(one);
            shop.Add(two);
            Smartphone t = new Smartphone("sd", 23456);

            Assert.Throws<InvalidOperationException>(()
                => shop.Add(t), "The shop is full.");
        }
        [Test]
        public void TestRemove()
        {
            //if (currentPhone == null)
            //{
            //    throw new InvalidOperationException($"The phone model {modelName} doesn't exist.");
            //}
            Shop shop = new Shop(4);
            Smartphone one = new Smartphone("sd", 4);

            Assert.Throws<InvalidOperationException>(()
                => shop.Remove("sd"), $"The phone model {one.ModelName} doesn't exist.");
        }
        [Test]
        public void TestRemoveS()
        {
            Shop shop = new Shop(3);
            Smartphone one = new Smartphone("sv", 434);
            shop.Add(one);
            shop.Remove("sv");
            Assert.AreEqual(shop.Count, 0);
        }
        [Test]
        public void TestB()
        {
            Shop shop = new Shop(3);
            Smartphone one = new Smartphone("sv", 100);
            shop.Add(one);
            //shop.TestPhone("sv", 200);
            Assert.Throws<InvalidOperationException>(()
                => shop.TestPhone("sv", 200), $"The phone model {one.ModelName} is low on batery.");
        }
        [Test]
        public void TestBS()
        {
            Shop shop = new Shop(3);
            Smartphone one = new Smartphone("sv", 100);
            shop.Add(one);
            shop.TestPhone("sv", 40);
            Assert.IsTrue(one.CurrentBateryCharge == 60);
        }
        [Test]
        public void TestCharge()
        {
            //currentPhone.CurrentBateryCharge = currentPhone.MaximumBatteryCharge;
            Shop shop = new Shop(3);
            Smartphone one = new Smartphone("sv", 100);
            shop.Add(one);
            one.CurrentBateryCharge = 60;
            shop.ChargePhone("sv");
            Assert.IsTrue(one.CurrentBateryCharge== 100);
        }
    }
}
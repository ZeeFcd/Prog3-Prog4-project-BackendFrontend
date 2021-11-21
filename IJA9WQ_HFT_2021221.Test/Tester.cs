using IJA9WQ_HFT_2021221.Logic;
using IJA9WQ_HFT_2021221.Models;
using IJA9WQ_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;

namespace IJA9WQ_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        HusbandLogic h;
        WifeLogic wi;
        WeddingLogic w;

        [SetUp]
        public void Init()
        {
            var mockHusbandRepository = new Mock<IHusbandRepository>();
            var mockWifeRepository = new Mock<IWifeRepository>();
            var mockWeddingRepository = new Mock<IWeddingRepository>();


            h = new HusbandLogic(mockHusbandRepository.Object);
            wi = new WifeLogic(mockWifeRepository.Object);
            w = new WeddingLogic(mockWeddingRepository.Object);

        }

        [TestCase(27,true)]
        [TestCase(15, false)]
        public void HusbandLogicCreateTest(int age,bool result)
        {
            if (result)
            {
                Assert.That(() => h.Create(new Husband() { Age = age }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => h.Create(new Husband() { Age = age }), Throws.Exception);
            }
            
        }

        [TestCase(16, true)]
        [TestCase(15, false)]
        public void WifeLogicCreateTest(int age, bool result)
        {
            if (result)
            {
                Assert.That(() => wi.Create(new Wife() { Age = age }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => wi.Create(new Wife() { Age = age }), Throws.Exception);
            }
            
        }

        [TestCase(5000, true)]
        [TestCase(-5000, false)]
        public void WeddingLogicCreateTest(int prize, bool result)
        {
            if (result)
            {
                
                Assert.That(() => w.Create(new Wedding() { Price = prize }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => w.Create(new Wedding() { Price = prize }), Throws.Exception);
            }
           
        }

        [Test]
        public void MarriedCouplesTest()
        { 
        }

        [Test]
        public void AverageAgeTest() 
        { 
        }

        [Test]
        public void WeddingPlacesByWifeTest()
        { 
        }

        [Test]
        public void WeddingPricesByHusbandTest()
        { 
        }

        [Test]
        public void WifeWhereHusbandIsOldestTest()
        { 
        }

    }
}

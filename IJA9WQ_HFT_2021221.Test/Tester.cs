using IJA9WQ_HFT_2021221.Logic;
using IJA9WQ_HFT_2021221.Models;
using IJA9WQ_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IJA9WQ_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        HusbandLogic h;
        WifeLogic wi;
        WeddingLogic w;
        Mock<IWeddingRepository> mockWeddingRepository;

         [SetUp]
        public void Init()
        {
            var mockHusbandRepository = new Mock<IHusbandRepository>();
            var mockWifeRepository = new Mock<IWifeRepository>();
            mockWeddingRepository = new Mock<IWeddingRepository>();
            
            h = new HusbandLogic(mockHusbandRepository.Object);
            wi = new WifeLogic(mockWifeRepository.Object);

            Husband fakehusband1 = new Husband() {Id=1,Name="Jerry Thompson", Age=17 };
            Husband fakehusband2 = new Husband() {Id = 2, Name = "Gerald Black", Age = 32 };
            Wife fakewife1 = new Wife() { Id = 1, Name = "Pamela Mensen", Age = 20 };
            Wife fakewife2 = new Wife() { Id=2 ,Name="Angela White", Age =28};
            var fakewedding1 = new Wedding() { Id=1 ,Place = "Los Angeles", Price = 4000, Husband =fakehusband1,Wife=fakewife1 };
            var fakewedding2 = new Wedding() { Id=2,Place="Hungary",Price=2000 ,Husband = fakehusband2, Wife = fakewife2 };
            var weddings = new List<Wedding>() { fakewedding1, fakewedding2 }.AsQueryable();

            mockWeddingRepository.Setup(t => t.ReadAll()).Returns(weddings);
            mockWeddingRepository.Setup(x => x.Read(It.IsAny<int>()));
            mockWeddingRepository.Setup(y => y.Update(It.IsAny<Wedding>()));
            mockWeddingRepository.Setup(z => z.Delete(It.IsAny<int>()));




            w = new WeddingLogic(mockWeddingRepository.Object);
            ;
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
            var result=w.MarriedCouples();

            var expected = new List<KeyValuePair<string, string>>()
            { new KeyValuePair<string,string>("Jerry Thompson","Pamela Mensen"),
              new KeyValuePair<string,string>("Gerald Black","Angela White"),
            };

            ;
            Assert.That(result, Is.EqualTo(expected));
            
        }

        [Test]
        public void AverageAgeTest() 
        {
            var result = w.AverageAge();

            Assert.That(result, Is.EqualTo(24.25));
        }

        [Test]
        public void WeddingPlacesByWifeTest()
        {
            var result = w.WeddingPlacesByWife();

            var expected = new List<KeyValuePair<string, string>>()
            { new KeyValuePair<string,string>("Pamela Mensen","Los Angeles"),
              new KeyValuePair<string,string>("Angela White","Hungary"),
            };

            ;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WeddingPricesByHusbandTest()
        {
            var result = w.WeddingPricesByHusband();

            var expected = new List<KeyValuePair<string, int>>()
            { new KeyValuePair<string,int>("Jerry Thompson",4000),
              new KeyValuePair<string,int>("Gerald Black",2000),
            };

            ;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WifeWhereHusbandIsOldestTest()
        {
            var result = w.WifeWhereHusbandIsOldest();
            ;
            Assert.That(result, Is.EqualTo("Angela White"));
        }

        [Test]
        public void WeddingReadMethodCallTest() 
        {
            w.Read(3);
            mockWeddingRepository.Verify(x => x.Read(3),Times.Once);
                       
        }

        [Test]
        public void WeddingDeletedMethodCallTest()
        {
            w.Delete(2);
            mockWeddingRepository.Verify(x => x.Delete(2), Times.Once);

        }


        [Test]
        public void WeddingUpdateMethodCallTest()
        {           
            var weddingObj= new Wedding() { Id = 2, Place = "Hungary", Price = 2000 };
            w.Update(weddingObj);
            mockWeddingRepository.Verify(x => x.Update(weddingObj), Times.Once);

        }

        


    }
}

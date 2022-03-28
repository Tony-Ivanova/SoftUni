namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class PresentsTests
    {
        private Present present;
        private Bag bag;
        private List<Present> presents;

        [SetUp]
        public void Setup()
        {
            this.bag = new Bag();
            this.present = new Present("Neshto si", 120);
            this.presents = new List<Present>();
        }

        [Test]
        public void Constructor_Present_Works_For()
        {
            Assert.AreEqual("Neshto si", present.Name);
            Assert.AreEqual(120, present.Magic);
        }        

        [Test]
        public void Added_Null_Present_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void Existing_Present_Throws_Exception()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Successfully_Adds_Present()
        {
            var expectedResult = $"Successfully added present {present.Name}.";
            Assert.AreEqual(expectedResult, bag.Create(present));
        }

        [Test]
        public void Check_If_Is_Removed()
        {
            bag.Create(present);

            Assert.AreEqual(true, bag.Remove(present));
        }       

        [Test]
        public void Get_Present_With_Least_Magic()
        {
            var firstPresent = present;
            var secondPresent = new Present("Second", 1);
            var thirdPresent = new Present("Third", 2);
            bag.Create(firstPresent);
            bag.Create(secondPresent);
            bag.Create(thirdPresent);

            var expectedPresent = secondPresent;
            var result = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(expectedPresent, result);
        }

        [Test]
        public void Successfully_Gets_Present_With_That_name()
        {
            var firstPresent = present;
            bag.Create(firstPresent);
            var expectedPresent = firstPresent;
            var result = bag.GetPresent("Neshto si");
            Assert.AreEqual(expectedPresent, result);
        }


        [Test]
        public void Successfully_Gets_All_Presents()
        {
            var firstPresent = present;
            var secondPresent = new Present("Second", 1);
            var thirdPresent = new Present("Third", 2);
            bag.Create(firstPresent);
            bag.Create(secondPresent);
            bag.Create(thirdPresent);
            var listPresents = new List<Present>();
            listPresents.Add(firstPresent);
            listPresents.Add(secondPresent);
            listPresents.Add(thirdPresent);

            var result = bag.GetPresents();

            Assert.AreEqual(listPresents, result);
        }
    }
}
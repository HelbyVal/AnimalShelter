using NUnit.Framework;
using PeaceLab5.Classes;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        public Register InitializeSystem()
        {
            Register register = new Register();
            RegContract regContract = new RegContract();
            RegShelter regShelter = new RegShelter();
            register.SetRegContract(regContract);
            regContract.SetRegShelter(regShelter);
            regShelter.AddShelter(new Shelter("222555666", "256413456", "ООО",
                                  new City("Тюмень", "Тюменская область")));
            regShelter.AddShelter(new Shelter("333888090", "502213494", "ОАО",
                                  new City("Тобольск", "Тюменская область")));
            return register;
        }
        [Test]
        public void TwoDayAnimal()
        {
            Register register = InitializeSystem();
            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023,07,1), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 2), "Тюмень");

            var cost = register.CreateReport("Тюмень", new DateTime(2023, 06, 30), new DateTime(2023, 07, 30));
            Assert.AreEqual(4.2, cost);
        }

        [Test]
        public void ZeroDayAnimal()
        {
            Register register = InitializeSystem();
            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 05, 1), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 05, 3), "Тюмень");

            var cost = register.CreateReport("Тюмень", new DateTime(2023, 06, 30), new DateTime(2023, 07, 30));
            Assert.AreEqual(0, cost);
        }

        [Test]
        public void SomeDaysAnimalWithCrossingDate() // несколько дней проживания, часть не попадёт в отчёт
        {
            Register register = InitializeSystem();
            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 07, 29), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 08, 15), "Тюмень");

            var cost = register.CreateReport("Тюмень", new DateTime(2023, 06, 30), new DateTime(2023, 07, 30));
            Assert.AreEqual(4.2, cost);
        }

        [Test]
        public void SomeAnimalsCrossingDays() // Несколько животных с днем  проживания
        {
            Register register = InitializeSystem();
            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 07, 29), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 31), "Тюмень");

            register.AddAnimal("Собака", "Чёрный", "Самка", 34.21, "2500016", new DateTime(2023, 07, 28), "Тюмень");
            register.ReleaseAnimal("2500016", new DateTime(2023, 07, 30), "Тюмень");
            
            var cost = register.CreateReport("Тюмень", new DateTime(2023, 06, 30), new DateTime(2023, 08, 29));
            Assert.AreEqual(12.6, cost);
        }

        [Test]
        public void BeyondDates() // Проживание животных вне дат отчёта
        {
            Register register = InitializeSystem();

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 07, 29), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 30), "Тюмень");

            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 2.1);
            var cost = register.CreateReport("Тюмень", new DateTime(2023, 06, 28), new DateTime(2023, 06, 29));
            Assert.AreEqual(0, cost);
        }

        [Test]
        public void SomeCards() // несколько карточек для одного животного
        {
            Register register = InitializeSystem();

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 07, 29), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 30), "Тюмень");

            register.AddAnimal("2500015", new DateTime(2023, 08, 5), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 08, 7), "Тюмень");

            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 2.1);
            var cost = register.CreateReport("Тюмень", new DateTime(2023, 07, 25), new DateTime(2023, 08, 25));
            Assert.AreEqual(10.5 , cost);
        }

        [Test]
        public void SomeAnimalsSomeCards() // несколько животных с несколькими картами
        {
            Register register = InitializeSystem();
            register.AddContract("Тюмень", new DateTime(2023, 9, 2), "1", 1);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 07, 29), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 30), "Тюмень");

            register.AddAnimal("2500015", new DateTime(2023, 08, 5), "Тюмень");
            register.ReleaseAnimal("2500015", new DateTime(2023, 08, 7), "Тюмень");

            register.AddAnimal("Собака", "Чёрный", "Самка", 34.21, "2500016", new DateTime(2023, 08, 20), "Тюмень");
            register.ReleaseAnimal("2500016", new DateTime(2023, 08, 22), "Тюмень");

            var cost = register.CreateReport("Тюмень", new DateTime(2023, 07, 25), new DateTime(2023, 08, 25));
            Assert.AreEqual(8, cost);
        }
        [Test]
        public void AnimalInsideShelter_One() // Животное не выпущено из приюта
        {
            Register register = InitializeSystem();
            register.AddContract("Тобольск", new DateTime(2023, 9, 2), "1", 2);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 06, 25), "Тобольск");

            var cost = register.CreateReport("Тобольск", new DateTime(2023, 06, 10), new DateTime(2023, 06, 27));
            Assert.AreEqual(6, cost);
        }

        [Test]
        public void AnimalInsideShelter_Two() // Животное не выпущено из приюта
        {
            Register register = InitializeSystem();
            register.AddContract("Тобольск", new DateTime(2023, 9, 2), "1", 2);

            register.AddAnimal("Кошка", "Серый", "Самец", 25.50, "2500015", new DateTime(2023, 06, 25), "Тобольск");

            var cost = register.CreateReport("Тобольск", new DateTime(2023, 06, 10), new DateTime(2023, 06, 30));
            Assert.AreEqual(12  , cost);
        }
    }
}
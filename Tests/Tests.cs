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
            regShelter.AddShelter(new Shelter("222555666", "256413456", "���",
                                  new City("������", "��������� �������")));
            regShelter.AddShelter(new Shelter("333888090", "502213494", "���",
                                  new City("��������", "��������� �������")));
            return register;
        }
        [Test]
        public void TwoDayAnimal()
        {
            Register register = InitializeSystem();
            register.AddContract("������", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023,07,1), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 2), "������");

            var cost = register.CreateReport("������", new DateTime(2023, 06, 30), new DateTime(2023, 07, 30));
            Assert.AreEqual(4.2, cost);
        }

        [Test]
        public void ZeroDayAnimal()
        {
            Register register = InitializeSystem();
            register.AddContract("������", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 05, 1), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 05, 3), "������");

            var cost = register.CreateReport("������", new DateTime(2023, 06, 30), new DateTime(2023, 07, 30));
            Assert.AreEqual(0, cost);
        }

        [Test]
        public void SomeDaysAnimalWithCrossingDate() // ��������� ���� ����������, ����� �� ������ � �����
        {
            Register register = InitializeSystem();
            register.AddContract("������", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 07, 29), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 08, 15), "������");

            var cost = register.CreateReport("������", new DateTime(2023, 06, 30), new DateTime(2023, 07, 30));
            Assert.AreEqual(4.2, cost);
        }

        [Test]
        public void SomeAnimalsCrossingDays() // ��������� �������� � ����  ����������
        {
            Register register = InitializeSystem();
            register.AddContract("������", new DateTime(2023, 9, 2), "1", 2.1);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 07, 29), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 31), "������");

            register.AddAnimal("������", "׸����", "�����", 34.21, "2500016", new DateTime(2023, 07, 28), "������");
            register.ReleaseAnimal("2500016", new DateTime(2023, 07, 30), "������");
            
            var cost = register.CreateReport("������", new DateTime(2023, 06, 30), new DateTime(2023, 08, 29));
            Assert.AreEqual(12.6, cost);
        }

        [Test]
        public void BeyondDates() // ���������� �������� ��� ��� ������
        {
            Register register = InitializeSystem();

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 07, 29), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 30), "������");

            register.AddContract("������", new DateTime(2023, 9, 2), "1", 2.1);
            var cost = register.CreateReport("������", new DateTime(2023, 06, 28), new DateTime(2023, 06, 29));
            Assert.AreEqual(0, cost);
        }

        [Test]
        public void SomeCards() // ��������� �������� ��� ������ ���������
        {
            Register register = InitializeSystem();

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 07, 29), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 30), "������");

            register.AddAnimal("2500015", new DateTime(2023, 08, 5), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 08, 7), "������");

            register.AddContract("������", new DateTime(2023, 9, 2), "1", 2.1);
            var cost = register.CreateReport("������", new DateTime(2023, 07, 25), new DateTime(2023, 08, 25));
            Assert.AreEqual(10.5 , cost);
        }

        [Test]
        public void SomeAnimalsSomeCards() // ��������� �������� � ����������� �������
        {
            Register register = InitializeSystem();
            register.AddContract("������", new DateTime(2023, 9, 2), "1", 1);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 07, 29), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 07, 30), "������");

            register.AddAnimal("2500015", new DateTime(2023, 08, 5), "������");
            register.ReleaseAnimal("2500015", new DateTime(2023, 08, 7), "������");

            register.AddAnimal("������", "׸����", "�����", 34.21, "2500016", new DateTime(2023, 08, 20), "������");
            register.ReleaseAnimal("2500016", new DateTime(2023, 08, 22), "������");

            var cost = register.CreateReport("������", new DateTime(2023, 07, 25), new DateTime(2023, 08, 25));
            Assert.AreEqual(8, cost);
        }
        [Test]
        public void AnimalInsideShelter_One() // �������� �� �������� �� ������
        {
            Register register = InitializeSystem();
            register.AddContract("��������", new DateTime(2023, 9, 2), "1", 2);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 06, 25), "��������");

            var cost = register.CreateReport("��������", new DateTime(2023, 06, 10), new DateTime(2023, 06, 27));
            Assert.AreEqual(6, cost);
        }

        [Test]
        public void AnimalInsideShelter_Two() // �������� �� �������� �� ������
        {
            Register register = InitializeSystem();
            register.AddContract("��������", new DateTime(2023, 9, 2), "1", 2);

            register.AddAnimal("�����", "�����", "�����", 25.50, "2500015", new DateTime(2023, 06, 25), "��������");

            var cost = register.CreateReport("��������", new DateTime(2023, 06, 10), new DateTime(2023, 06, 30));
            Assert.AreEqual(12  , cost);
        }
    }
}
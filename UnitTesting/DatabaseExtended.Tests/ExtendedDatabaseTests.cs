namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person[] personArr;

        [SetUp]
        public void Setup()
        {
            personArr = new[] { new Person(2, "Ivan"), new Person(3, "Pesho"), new Person(4, "Gosho") };
            db = new Database(personArr);
        }

        [Test]
        public void PersonGetConstructorCheck()
        {
            string personName = "Ivan";
            long id = 1L;
            Person person = new Person(id, personName);
            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(personName, person.UserName);
        }
        [Test]
        public void PersonSetConstructorCheck()
        {
            string personName = "Ivan";
            long id = 1L;
            Person personConstruct = new Person(id, personName);
            Assert.AreEqual(id, personConstruct.Id);
            Assert.AreEqual(personName, personConstruct.UserName);
        }
        [Test]
        public void DatabaseCheckConstructor()
        {
            Assert.AreEqual(3, db.Count);
        }
        [Test]
        public void DataBaseCheckEmptyConstructur()
        {
            Database database = new Database();
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, database.Count);
        }
        [Test]
        public void DataBaseMoreThan16people()
        {
            Person[] personsDbs = new Person[50];
            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(personsDbs);
            }, "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void DataBaseMoreThanBypeople()
        {
            Person expectedResult = personArr.Where(x => x.UserName == "Ivan").FirstOrDefault();
            Assert.AreEqual(expectedResult, db.FindByUsername("Ivan"));
        }
        [Test]
        public void DatabaseCheckAddPeopLeRange()
        {
            Database dbp = new Database(personArr);
            Assert.AreEqual(3, dbp.Count);
        }

        [Test]
        public void DatabaseCheckAdd()
        {
            Person personDbChck = new Person(1, "DimGosho");
            Database db = new Database(personArr);
            db.Add(personDbChck);
            int expectedResult = 4;
            Assert.AreEqual(expectedResult, db.Count);

        }
        [Test]
        public void DatabaseCheckAddWhenUserNameExist()
        {
            Person personDbUN = new Person(1, "Gosho");
            Database db = new Database(personArr);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(personDbUN);
            }, "There is already user with this username!");
        }
        [Test]
        public void DatabaseCheckAddWhenUserIDExist()
        {
            Person personUID = new Person(4, "Gosho");
            Database db = new Database(personArr);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(personUID);
            }, "There is already user with this Id!");
        }
        [Test]
        public void DatabaseCheckAddWhenUserIsCorrect()
        {
            Person personUISC = new Person(84, "Dimitrichko");
            Database db = new Database(personArr);
            int expectedResult = 4;
            db.Add(personUISC);
            Person expectedUser = personUISC;
            Assert.AreEqual(expectedResult, db.Count);
            Assert.AreEqual(expectedUser, db.FindByUsername("Dimitrichko"));

        }
        [Test]
        public void DataBaseCheckRemoveWhenDbIsEmpty()
        {
            Person personDBEMP = new Person(400, "Dimito");
            Database emptyDb = new Database(personDBEMP);
            emptyDb.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDb.Remove();
            });
        }
        [Test]
        public void DataBaseCheckRemov()
        {
            Person personR = new Person(400, "Dimito");
            Database emptyDb = new Database(personArr);
            emptyDb.Add(personR);
            Assert.AreEqual(personR, emptyDb.FindByUsername("Dimito"), "Correct add person and find by name");
            emptyDb.Remove();
            int expectedResult = 3;
            Assert.AreEqual(expectedResult, db.Count);
            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDb.FindByUsername("Dimito");
            }, "No user is present by this username!");
        }

        [TestCase("")]
        [TestCase(null)]
        public void DatabaseCheckFindWhenUserIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(name);
            }, "Username parameter is null!");
        }

        [TestCase(-10)]
        public void DataBaseCheckFindByIdWhenIDNegative(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(id);
            }, "Id should be a positive number!");
        }
        [TestCase(856958)]
        public void DataBaseCheckFindByIdWhenIDMissing(long id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(id);
            }, "No user is present by this ID!");
        }

        [TestCase(2)]
        public void DataBaseCheckFindByIdWhenIdIsCorrect(long id)
        {
            Person expectedPerson = new Person(2, "Ivan");
            Person actualPerson = db.FindById(id);
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);
            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
        }

        [Test]
        public void DataBaseCheckAddWhenIdExist()
        {
            Person personToAdded = new Person(2, "Grigor");
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(personToAdded);
            }, "There is already user with this Id!");
        }

        [Test]
        public void DataBaseCheckAddExeptionWhenDbIsFull()
        {

            for (int i = 90; i < 102; i++)
            {
                Person currentDBCheckPerson = new Person(i, "ivan" + i.ToString());
                db.Add(currentDBCheckPerson);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(100, "GclassIPetko"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]

        public void DataBaseCheckAddRangeIsOverDbCapacity()
        {
            Person[] peoplesChkDb;
            List<Person> ppp=new List<Person>();
           
            for (int i = 66; i < 84; i++)
            {
                Person perFromI=new Person(i,"I"+i.ToString());
                ppp.Add(perFromI);
            }
            peoplesChkDb = ppp.ToArray();
            Assert.Throws<ArgumentException>(() =>
            {
                Database rangeCheck= new Database(peoplesChkDb);
            }, "Provided data length should be in range [0..16]!");
           
        }

    }
}
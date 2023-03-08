namespace Database.Tests;

using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class DatabaseTests
{
    private int[] data;
    private int[] dataTestC;
    private int count;
    private Database database;
    private Database databaseTestMethod;
    private Database defDb;


    [SetUp]
    public void SeUp()
    {
        data = new int[16];
        database = new Database(data);
        dataTestC = new int[16];
        databaseTestMethod = new Database(dataTestC);

        this.defDb = new Database();

    }

    [Test]
    public void CheckCountElements()
    {
        Assert.AreEqual(data.Length, database.Count);
    }
    [Test]
    public void CheckCapacityGreatBySixtten()
    {
        int[] currentData = new int[55];

        Assert.Throws<InvalidOperationException>(() =>
        {
            database = new Database(currentData);
        });
    }

    [Test]
    public void CheckInitializationDatabaseWhenLenghtLessThanSixtten()
    {
        int[] current = new int[16];
        database = new Database(current);
        Assert.AreEqual(data.Length, database.Count);
    }
    [Test]
    public void CheckInitializationAddMethod()
    {
        int sum = 0;
        database = new Database(data);

        int sumarr = data.Sum();
        Assert.AreEqual(data.Sum(), sumarr);
    }

    [Test]
    public void CheckRemoveMethodI()
    {
        database.Remove();
        Assert.AreEqual(15, database.Count);
    }
    [Test]
    public void CheckRemoveMethodLastElement()
    {
        database = new Database(data);
        database.Remove();
        Assert.AreEqual(data.Length - 1, database.Count);
    }

    [Test]
    public void CheckLastElementDatabaseAfterRemove()
    {
        database = new Database(data);
        database.Remove();
        int[] afterRemove = database.Fetch();
        Assert.AreEqual(afterRemove.Last(), 0);
    }

    [Test]
    public void CheckLastElementDatabaseBeforeRemove()
    {
        int[] currentData = new int[0];
        database = new Database(currentData);
        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }
    [Test]
    public void CheckLastElementDatabaseFetchIsZero()
    {
        int[] currentData = new int[0];
        database = new Database(currentData);
        Assert.AreEqual(0, database.Fetch().Count());
    }
    [Test]
    public void CheckLastElementDatabaseFetchIsSexteen()
    {
        int[] currentData = new int[16];
        database = new Database(currentData);
        Assert.AreEqual(currentData.Length, database.Fetch().Count());
    }
    [Test]
    public void CheckElementsWhenUseFetch()
    {
        int[] currentData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        database = new Database(currentData);
        Assert.AreEqual(currentData, database.Fetch());
    }

    [TestCase(new int[] { })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
    public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
    {
        //Arrange

        //Act
        Database db = new Database(data);

        //Assert
        int expectedCount = data.Length;
        int actualCount = db.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    //1 Main Invalid Case + 1 Edge Invalid Case
    [Test]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
    public void ConstructorShouldThrowExcpetionWhenInputDataIsAbove16Count(int[] data)
    {
        //AAA
        Assert.Throws<InvalidOperationException>(() =>
        {
            Database db = new Database(data);
        }, "Array's capacity must be exactly 16 integers!");
    }

    //We will assume that Fetch() method is working just fine!
    [TestCase(new int[] { })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
    public void ConstructorShouldAddElementsIntoDataField(int[] data)
    {
        Database db = new Database(data);

        int[] expectedData = data;
        int[] actualData = db.Fetch();

        CollectionAssert.AreEqual(expectedData, actualData);
    }

    [TestCase(new int[] { })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
    public void CountShouldReturnCorrectCount(int[] data)
    {
        //Arrange
        Database db = new Database(data);

        //Act
        int expectedCount = data.Length;
        int actualCount = db.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    //I assume that Count property is tested and working fine!
    [Test]
    public void AddingElementsShouldIncreaseCount()
    {
        int expectedCount = 5;
        //Arrange + Act
        for (int i = 1; i <= expectedCount; i++)
        {
            this.defDb.Add(i);
        }

        int actualCount = this.defDb.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void AddingElementsShouldAddThemToTheDataCollection()
    {
        int[] expectedData = new int[5];
        for (int i = 1; i <= 5; i++)
        {
            this.defDb.Add(i);
            expectedData[i - 1] = i;
        }

        int[] actualData = this.defDb.Fetch();

        CollectionAssert.AreEqual(expectedData, actualData);
    }

    [Test]
    public void AddingMoreThan16ElementsShouldThrowAnException()
    {
        //Adding elements to the full capacity
        for (int i = 1; i <= 16; i++)
        {
            this.defDb.Add(i);
        }

        //Full capacity!
        Assert.Throws<InvalidOperationException>(() =>
        {
            this.defDb.Add(17);
        }, "Array's capacity must be exactly 16 integers!");
    }

    [Test]
    public void RemovingElementShouldDecreaseCount()
    {
        int initialCount = 5;
        //Arrange + Act
        for (int i = 1; i <= initialCount; i++)
        {
            this.defDb.Add(i);
        }

        int removeCount = 2;
        for (int i = 1; i <= removeCount; i++)
        {
            this.defDb.Remove();
        }

        int expectedCount = initialCount - removeCount;
        int actualCount = this.defDb.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void RemovingElementShouldRemoveItFromTheDataCollection()
    {
        int initialCount = 5;
        //Arrange + Act
        for (int i = 1; i <= initialCount; i++)
        {
            this.defDb.Add(i);
        }

        int removeCount = 2;
        for (int i = 1; i <= removeCount; i++)
        {
            this.defDb.Remove();
        }

        int[] expectedData = new int[] { 1, 2, 3 };
        int[] actualData = this.defDb.Fetch();

        CollectionAssert.AreEqual(expectedData, actualData);
    }

    [Test]
    public void RemoveShouldThrowExceptionWhenThereAreNoElementsInDb()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            this.defDb.Remove();
        }, "The collection is empty!");
    }

    //I assume that the constructor is working just fine!
    [TestCase(new int[] { })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
    public void FetchShouldReturnCollectionWithElementsInTheDb(int[] data)
    {
        Database db = new Database(data);

        int[] expectedData = data;
        int[] actualData = db.Fetch();

        CollectionAssert.AreEqual(expectedData, actualData);
    }
}




namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            string Title = "Harry";
            string Author = "Ivan";
            int InventoryNumber = 10;
            string Category = "Fan";
            string Holder = "Peter";
            TextBook book = new TextBook(Title,Author,Category);

        }

        [Test]
        public void testTextBookConstructor()
        {
            string Title = "Harry";
            TextBook book = new TextBook(Title,"Ivan","Fan");
            Assert.AreEqual(Title, book.Title);
        }
    }
}
namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void CreateBookByConstructor()
        {
            string bookName = "book1";
            string author = "Author1";
            Book book = new Book(bookName, author);
            Assert.That(book != null);
        }

        //Book book1 = new Book("bookName1", "authorName1");
        //Book book2 = new Book("bookName2", "authorName2");

        [TestCase(null, "authorName1")]
        [TestCase("", "authorName2")]
        public void BookNameShouldNotBeNullOrEmoty(string bookName, string authorName)
        {
           Book book = null;
           Assert.Throws<ArgumentException>(() =>
           {
               Book book = new Book(bookName, authorName);
           }, $"Invalid {nameof(book)}!");
        }

        [Test]
        public void BookNameShouldReturnCorrectData()
        {
            string expectedBookName = "book1";
            string expectedAuthorName = "Author1";

            Book book1 = new Book(expectedBookName, expectedAuthorName);
            string actualBookName = book1.BookName;
            string actualAuthorName = book1.Author;
            Assert.AreEqual(expectedBookName, actualBookName);
            //Assert.AreEqual(expectedAuthorName, actualAuthorName);
        }

        [TestCase("bookName1", null)]
        [TestCase("bookName1", "")]
        public void AuthorShouldNotBeNullOrEmoty(string bookName, string authorName)
        {
            Book book = null;
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, authorName);
            }, $"Invalid {nameof(book)}!");
        }

        [Test]
        public void AuthorShouldReturnCorrectData()
        {
            string expectedBookName = "book1";
            string expectedAuthorName = "Author1";

            Book book1 = new Book(expectedBookName, expectedAuthorName);
            string actualBookName = book1.BookName;
            string actualAuthorName = book1.Author;
            //Assert.AreEqual(expectedBookName, actualBookName);
            Assert.AreEqual(expectedAuthorName, actualAuthorName);
        }

        [Test]
        public void TestFootnoteCountShouldreturnCorretCount()
        {
            Book book1 = new Book("bookName1", "authorName1");
            book1.AddFootnote(20, "explanations");
            int actualCount = book1.FootnoteCount;
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, actualCount, "FootnoteCount must return correct count.");
        }

        [Test]
        public void AddFootNoteShouldThrwEsceptioIfFootNoteExistInList()
        {
            Book book1 = new Book("bookName1", "authorName1");
            book1.AddFootnote(20, "explanations");
            Assert.Throws<InvalidOperationException>(() => book1.AddFootnote(20, "explanations"), "Footnote doesn't exists!");
        }

        [Test]
        public void FindFootNoteShouldThrwEsceptioIfFootNoteDoesNotExistInList()
        {
            Book book1 = new Book("bookName1", "authorName1");
            book1.AddFootnote(20, "explanations");
            Assert.Throws<InvalidOperationException>(() => book1.FindFootnote(25), "Footnote doesn't exists!");
        }

        [Test]
        public void FindFootNoteShouldReturnCorrectString()
        {
            Book book1 = new Book("bookName1", "authorName1");
            book1.AddFootnote(30, "explanations");
            string actualString = book1.FindFootnote(30);
            string expectedString = "Footnote #30: explanations";
            Assert.AreEqual(expectedString, actualString, "FindFootNote should return correct string.");
        }




        [Test]
        public void AlterFootNoteShouldThrwEsceptioIfFootNoteDoesNotExistInList()
        {
            Book book1 = new Book("bookName1", "authorName1");
            book1.AddFootnote(20, "explanations");
            Assert.Throws<InvalidOperationException>(() => book1.AlterFootnote(25, "Explanations2"), "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootNoteShouldReturnCorrectString()
        {
            Book book1 = new Book("bookName1", "authorName1");
            book1.AddFootnote(30, "explanations");
            book1.AlterFootnote(30, "different explanations");
            string expectedString = "Footnote #30: different explanations";
            string actualString = book1.FindFootnote(30);
            Assert.AreEqual(expectedString, actualString, "FindFootNote should return correct string.");
        }

    }
}
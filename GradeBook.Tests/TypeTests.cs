using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            // log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello!");
            //Assert.Equal("Hello!", result);
            Assert.Equal(3, count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");
            

            //act
            

            //assert
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book1");
            var book2 = book1;
            

            //act
            

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            //act
            

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");

            //act
            

            //assert
            Assert.Equal("Book1", book1.Name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange
            var book1 = GetBook("Book1");
            GetBookSetName2(ref book1, "New Name");

            //act
            

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Dwight";
            var upper = MakeUppercase(name);

            Assert.Equal("Dwight", name);
            Assert.Equal("DWIGHT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        private void SetInt(ref int x)
        {
            x=42;
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        private void GetBookSetName2(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}

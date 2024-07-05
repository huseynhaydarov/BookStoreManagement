namespace UnitTests.AuthorTests
{
    public class AuthorTests
    {
        [Fact]
        public void Create_GivenSomeValidParameters_AuthorObjectCreatedSuccessfully()
        {
            // Arrange
            var fullName = "William Shakespeare";
            var dateOfBirth = new DateTime(1930, 06, 28);
            var biography = "William Shakespeare was a renowned English poet, playwright, and actor born in 1564. Read about his life and works.";

            // Act 
            var actual = AuthorEntity.Create(fullName, dateOfBirth, biography);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(fullName, actual.FullName);
            Assert.Equal(dateOfBirth, actual.DateOfBirth);
            Assert.Equal(biography, actual.Biography);
            Assert.NotNull(actual.Books);
            Assert.Empty(actual.Books);
        }
        [Theory]
        [InlineData("", "dateOfBirth", "biography")]
        [InlineData("fullName", "", "biography")]
        [InlineData("fullName", "biography", "")]
        public void Create_GivenSomeIncorrectParameters_ThrowArgumentException(string fullName, DateTime dateOfBirth, string biography)
        {
            // Arrange
            // Act
            Action actual = () => AuthorEntity.Create(fullName, dateOfBirth, biography);

            // Assert
            actual.Should().Throw<ArgumentException>("parameters are incorrect but did not throw Exception");
        }


        private class AuthorTestDto
        {
            internal AuthorTestDto(string fullName, DateTime dateOfBirth, string biography)
            {
                FullName = fullName;
                DateOfBirth = dateOfBirth;
                Biography = biography;
            }

            internal string FullName { get; }

            internal DateTime DateOfBirth { get; }

            internal string Biography { get; }
        }
    }
}

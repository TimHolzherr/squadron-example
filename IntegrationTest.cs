using Xunit;
using System.Linq;
using FluentAssertions;

namespace squadron_example {

    [Collection("Database collection")]
    public class IntegrationTest {

        private DatabaseContext _context;
        private const int Rating = 1;

        public IntegrationTest(DatabaseFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void PersistetBlog__RetriveBlog__SameRating() {
            // Arrange
            _context.Blogs.Add(new Blog()
            {
                Rating = Rating,
            });
            _context.SaveChanges();

            // Act
            var retrieved = _context.Blogs.Single();

            // Assert
            retrieved.Rating.Should().Be(Rating);
        }
    }
}
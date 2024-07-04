using Application.Auhtors.Commands;
using Application.Authors.Commands;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using IntegrationTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.Authors
{
    public class CreateAuthorCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateAuthorRequestModel, AuthorEntity>();
                cfg.CreateMap<AuthorEntity, AuthorResponse>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldCreateAuthor_WhenAuthorDoesNotExist()
        {
            // Arrange
            var dbContext = _fixture.BuildDbContext(new Random().Next().ToString());
            await dbContext.Database.EnsureCreatedAsync(); 

            var authorRepository = new AuthorRepository(dbContext);
            var handler = new CreateAuthorCommandHandler(_mapper, authorRepository);

            var command = new CreateAuthorCommand
            {
                FullName = "Test Author",
                DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Biography = "Test Biography"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            var author = await dbContext.Authors.FirstOrDefaultAsync(a => a.FullName == "Test Author");
            Assert.NotNull(author);
            Assert.Equal("Test Author", author.FullName);
            Assert.Equal(new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc), author.DateOfBirth);
            Assert.Equal("Test Biography", author.Biography);

        }
    }
}

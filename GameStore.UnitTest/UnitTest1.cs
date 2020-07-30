using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Persistence;
using GameStore.Infrastructure.Services;
using GameStore.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace GameStore.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanPaginate()
        {
            // Arrange
            const int pageSize = 3;
            const int page = 2;
            var games = new List<Game>
            {
                new Game {Id = 1, Name = "Game1"},
                new Game {Id = 2, Name = "Game2"},
                new Game {Id = 3, Name = "Game3"},
                new Game {Id = 4, Name = "Game4"},
                new Game {Id = 5, Name = "Game5"}
            }.AsQueryable();
            var gamesMock = CreateDbSetMock(games);
            var options = new DbContextOptions<ApplicationDbContext>();
            var applicationDbContextMock = new Mock<ApplicationDbContext>(options);
            applicationDbContextMock.Setup(x => x.Set<Game>()).Returns(gamesMock.Object);
            var unitOfWork = new UnitOfWork(applicationDbContextMock.Object);
            var gameService = new GameService(unitOfWork);
            var homeController = new HomeController(null, gameService) { PageSize = pageSize };

            // Act
            var result = (IEnumerable<Game>)((ViewResult)homeController.Index(page)).Model;

            // Assert
            var resultGames = result.ToList();
            Assert.IsTrue(resultGames.Count == 2);
            Assert.AreEqual(resultGames[0].Name, "Game4");
            Assert.AreEqual(resultGames[1].Name, "Game5");
        }

        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
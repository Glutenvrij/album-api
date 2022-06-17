using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Album.Api.Services;
using Album.Api.Database;
using Album.Api.Models;

namespace Album.Api.Tests
{
    public class UnitTestAlbumService
    {
        public readonly AlbumService _service;
        public UnitTestAlbumService()
        {
            AppDbContext context = CreateTestDatabase();

            context.Albums.Add(new() { Id = 1, Name = "albumvalue1", Artist = "artistname1" });
            context.Albums.Add(new() { Id = 2, Name = "albumvalue2", Artist = "artistname2" });
            context.Albums.Add(new() { Id = 3, Name = "albumvalue3", Artist = "artistname3" });
            context.Albums.Add(new() { Id = 4, Name = "albumvalue4", Artist = "artistname4" });
            context.Albums.Add(new() { Id = 5, Name = "albumvalue5", Artist = "artistname5" });
            context.SaveChanges();

            _service = new AlbumService(context);
        }

        public static AppDbContext CreateTestDatabase()
        {
            var context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlite("Data Source=:memory:;").Options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void GetAlbumns()
        {
            var result = _service.GetAlbums();
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(6, true)]
        public void GetAlbumById(int id, bool expected)
        {
            var result = _service.GetAlbum(id);
            Assert.Equal(result == null, expected);
        }

        [Theory]
        [InlineData(3, "Early Autumn", "Heize", "image.url", true)]
        [InlineData(6, "Late Autumn", "Heize", "image.url", false)]
        public void UpdateAlbumById(int id, string name, string artist, string imageurl, bool expected)
        {
            var newAlbum = new AlbumModel
            {
                Id = id,
                Name = name,
                Artist = artist,
                ImageUrl = imageurl
            };

            if (_service.GetAlbum(id) == null) { return; }

            _service.UpdateAlbum(id, newAlbum);

            var album = _service.GetAlbum(id);
            var result = album.Id == album.Id &&
                        album.Name == album.Name &&
                        album.Artist == album.Artist &&
                        album.ImageUrl == album.ImageUrl;

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(3, "Early Autumn", "Heize", "image.url", false)]
        [InlineData(6, "Late Autumn", "Heize", "image.url", true)]
        public void Createlbum(int id, string name, string artist, string imageurl, bool expected)
        {
            // Arrange
            var album = new AlbumModel
            {
                Id = id,
                Name = name,
                Artist = artist,
                ImageUrl = imageurl
            };

            // Act
            var getalbum = _service.GetAlbum(id);
            if (getalbum != null) //checks if album exists
            {
                return;
            }

            _service.CreateAlbum(album);

            var result = _service.GetAlbum(id) != null; //checks if new album exists

            // Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(6, false)]
        public void DeleteAlbum(int id, bool expected)
        {
            // Act
            var result = _service.DeleteAlbum(id) != null; //checks if album exists

            // Assert
            Assert.Equal(result, expected);
        }
    }
}
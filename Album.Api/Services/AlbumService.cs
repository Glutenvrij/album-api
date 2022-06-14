using System;
using System.Collections.Generic;
using System.Linq;
using Album.Api.Database;
using Album.Api.Models;

namespace Album.Api.Services
{
   /* public interface IAlbumService
    {
        List<AlbumModel> GetAlbums();
        AlbumModel GetAlbum(int id);
        void PutAlbum(int id, AlbumModel album);
        void PostAlbum(AlbumModel album);
        AlbumModel DeleteAlbum(int id);
    }*/
    public class AlbumService : ServiceBase
    {
        
      /*  public class AlbumService : IAlbumService
        {*/
        private readonly AppDbContext _context;

        public string testmessage()
        {
            return "asdsadsa";
        }

        public AlbumService(AppDbContext context)
        {
            _context = context;
        }
        public List<AlbumModel> GetAlbums()
        {
            return _context.Albums.ToList();
        }
        public AlbumModel GetAlbum(int id)
        {
            return _context.Albums.Find(id);
        }
        public void UpdateAlbum(int id, AlbumModel album)
        {
            AlbumModel a = _context.Albums.Find(album.Id);
            a.Id = album.Id;
            a.Name = album.Name;
            a.Artist = album.Artist;
            a.ImageUrl = album.ImageUrl;
            _context.SaveChanges();
        }
        public void CreateAlbum(AlbumModel album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }
        public AlbumModel DeleteAlbum(int id)
        {
            var album = _context.Albums.Find(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
            return album;
        }
    }
}


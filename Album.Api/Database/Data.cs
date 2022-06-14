using Album.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Album.Api.Database
{
    public class Data
    {
        public static void Initialize(AppDbContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.Albums.Any()) return;

            var Albums = new AlbumModel[]
            {
                new AlbumModel{Name="Justice",Artist="Justin Bieber",ImageUrl="https://upload.wikimedia.org/wikipedia/en/0/08/Justin_Bieber_-_Justice.png"},
                new AlbumModel{Name="Changes",Artist="Justin Bieber",ImageUrl="https://upload.wikimedia.org/wikipedia/en/1/16/Justin_Bieber_-_Changes.png"},
                new AlbumModel{Name="Purpose",Artist="Justin Bieber",ImageUrl="https://upload.wikimedia.org/wikipedia/en/2/27/Justin_Bieber_-_Purpose_%28Official_Album_Cover%29.png"},
                new AlbumModel{Name="Late Autumn",Artist="Heize",ImageUrl="https://m.media-amazon.com/images/I/71DWwZzLGoL._SS500_.jpg"},
                new AlbumModel{Name="Wish & Wind",Artist="Heize",ImageUrl="https://pm1.narvii.com/6762/6609ea65c49a8bc6355de99115cb85ccffe9b147v2_hq.jpg"},
            };
            ctx.Albums.AddRange(Albums);
            ctx.SaveChanges();
        }
    }
}

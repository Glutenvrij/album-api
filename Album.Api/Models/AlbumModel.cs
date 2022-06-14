using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Models
{
    public class AlbumModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Artist { get; set; }
        public string ImageUrl { get; set; }

        public AlbumModel()
        {
            this.Id = this.Id++;
        }

    /*    public AlbumModel(string name, string artist, string url)
        {
            this.Id++;
            this.Name = name;
            this.Artist = artist;
            this.ImageUrl = url;
        }*/

    }
}

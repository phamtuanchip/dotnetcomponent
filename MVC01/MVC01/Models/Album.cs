using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC01.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }

        public String Title { get; set; }
      
        public decimal Price { get; set; }
        public String AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }

    }
}
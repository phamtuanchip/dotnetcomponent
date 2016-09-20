using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC01.Models
{
    public class Genre
    {
        public String Name { get; set; }
        public int GenreId { get; set; }
        public String Description { get; set; }
        public List<Album> Albums { get; set; }


    }
}
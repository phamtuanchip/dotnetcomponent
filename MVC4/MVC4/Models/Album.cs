﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC4.Models
{
    public class Album
    {
        public long AlbumId { get; set; }
        public string Title { get; set; }

        public long ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
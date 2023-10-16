using System;
using System.Collections.Generic;
using System.Linq;

using ChinookContext;
using ChinookEntities;

namespace Project.Models
{
    public class InsertViewModel
    {
        public List<Album> Albums {get; set;}
        public List<Artist> Artists {get; set;}
        public List<Track> Tracks {get; set;}
    }
}
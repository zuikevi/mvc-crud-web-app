using System;
using System.Collections.Generic;
using System.Linq;

using ChinookContext;
using ChinookEntities;

namespace Project.Models
{
    public class AlbumsViewModel
    {
        public List<Album> Albums {get; set;}
        public List<Artist> Artists {get; set;}
        public Album insAlbum {get; set;}
        public int trackCount {get; set;}
        public int trackCountAdd {get; set;}
        public int trackCountRemove {get; set;}
        public int count {get; set;}
    }
}
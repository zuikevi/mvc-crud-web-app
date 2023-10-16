using System;
using System.Collections.Generic;
using System.Linq;

using ChinookContext;
using ChinookEntities;

namespace Project.Models
{
    public class UpdateViewModel
    {
        public List<Album> Albums {get; set;}
        public List<Artist> Artists {get; set;}
        public List<Track> Tracks {get; set;}
        public Album selAlbum {get; set;}
        public Artist selArtist {get; set;}
        public int trackCount {get; set;}
        public int trackCountAdd {get; set;}
        public int trackCountRemove {get; set;}
    }
}
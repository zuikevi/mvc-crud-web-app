using System;
using System.Collections.Generic;
using System.Linq;

using ChinookContext;
using ChinookEntities;

namespace Project.Models
{
    public class DeleteViewModel
    {
        public Album selAlbum {get; set;}
        public List<Track> Tracks {get; set;}
    }
}
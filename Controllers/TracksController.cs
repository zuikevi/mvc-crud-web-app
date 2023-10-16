using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Project.Models;
using ChinookContext;
using ChinookEntities;

namespace Project.Controllers
{
    public class TracksController : Controller
    {
        //Function that gets and displays tracks of the selected album, based on the id parameter passed when clicking the link 'details' in album index view
        public IActionResult Index(String id)
        {
            TracksViewModel model = new TracksViewModel();
            Int32 temp;
            ChinookDatabase db = new ChinookDatabase();

            model.Tracks = db.Tracks.Where(f => f.AlbumId == Int32.Parse(id)).ToList();
            model.albumTitle = db.Albums.Single(f => f.AlbumId == Int32.Parse(id)).Title;
            temp = db.Albums.Single(f => f.AlbumId == Int32.Parse(id)).ArtistId;
            model.artistName = db.Artists.Single(f => f.ArtistId == temp).Name;
            return View(model);
        }
    }
}
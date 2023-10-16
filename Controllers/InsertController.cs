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
    public class InsertController : Controller
    {
        //Function displays the main insert view and updates number of tracks and input boxes the user chooses
        public IActionResult Index(String id)
        {
            AlbumsViewModel model = new AlbumsViewModel();
            ChinookDatabase db = new ChinookDatabase();
            model.Artists = db.Artists.ToList();
            model.trackCount = Int32.Parse(id);
            model.trackCountAdd = model.trackCount + 1;
            model.trackCountRemove = model.trackCount - 1;
            return View(model);
        }

        //Function used to update the selected album, selected album is determined by the id parameter
        public IActionResult InsertConfirm(String id){
            InsertViewModel model = new InsertViewModel();
            ChinookDatabase db = new ChinookDatabase();
            String strName = Request.Form["tbxArtistId"];
            int insArtistId = -1, count = 0, trackCount = 0;

            model.Artists = db.Artists.ToList();
            insArtistId = model.Artists.Single(f => f.Name == strName).ArtistId;

            string str = Request.Form["tbxTitle"];
            if(str == "") str = "New Album";
            Album insAlbum = new Album()
            {
                Title = str,
                ArtistId = insArtistId
            };

            db.Albums.Add(insAlbum);
            db.SaveChanges();

            trackCount = Int32.Parse(id);

            while(count < trackCount){
                string str2 = count.ToString();
                Track insTrack = new Track()
                {
                    Name = Request.Form[str2],
                    AlbumId = insAlbum.AlbumId,
                    MediaTypeId = 1,
                    GenreId = 5,
                    Composer = strName,
                    Milliseconds = 230600,
                    Bytes = 5510400,
                    UnitPrice = 0.99f
                };
                db.Tracks.Add(insTrack);
                count++;
            }
            db.SaveChanges();
            return Redirect("~/Albums/Index");
        }
    }
}
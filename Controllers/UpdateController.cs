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
    public class UpdateController : Controller
    {
        //Function that gets specific information, such as artits and tracks, related to the selected album
        public IActionResult Index(String id)
        {
            UpdateViewModel model = new UpdateViewModel();
            ChinookDatabase db = new ChinookDatabase();
            model.selAlbum = db.Albums.Single(a => a.AlbumId == Int32.Parse(id));
            model.selArtist = db.Artists.Single(a => a.ArtistId == model.selAlbum.ArtistId);
            model.Tracks = db.Tracks.Where(f => f.AlbumId == Int32.Parse(id)).ToList();
            return View(model);
        }

        //Main function used to update album, artist and tracks
        public IActionResult Updated(String id)
        {
            UpdateViewModel model = new UpdateViewModel();
            ChinookDatabase db = new ChinookDatabase();
            Album updateAlbum = db.Albums.Single(a => a.AlbumId == Int32.Parse(id));
            updateAlbum.Title = Request.Form["tbxTitle"];
            updateAlbum.ArtistId = db.Artists.Single(a => a.Name == Request.Form["tbxArtistId"].ToString()).ArtistId;

            model.Tracks = db.Tracks.Where(f => f.AlbumId == Int32.Parse(id)).ToList();

            int count = 0;
            foreach(Track track in model.Tracks){
                Track track1 = track;
                track1.Name = Request.Form[count.ToString()];
                db.Tracks.Update(track1);
                db.SaveChanges();
                count++;
            }
            
            db.Albums.Update(updateAlbum);
            db.SaveChanges();
            return Redirect("~/Albums/Index");
        }
    }
}
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
    public class DeleteController : Controller
    {
        //Function used to delete selected album and save changes made to the database
        public IActionResult Index(String id)
        {
            ChinookDatabase db = new ChinookDatabase();
            var tracks = db.Tracks.Where(f => f.AlbumId == Int32.Parse(id));

            foreach(Track track in tracks){
                db.Tracks.Remove(db.Tracks.Single(f => f == track));
            }
            db.SaveChanges();

            db.Albums.Remove(db.Albums.Single(f => f.AlbumId == Int32.Parse(id)));
            db.SaveChanges();

            return Redirect("~/Albums/Index");
        }
    }
}
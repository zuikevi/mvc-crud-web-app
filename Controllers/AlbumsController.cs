using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Project.Models;
using ChinookEntities;
using ChinookContext;

namespace Project.Controllers
{
    public class AlbumsController : Controller
    {
        //Function used to get albums and artist list and sort the artist list
        public IActionResult Index()
        {
            AlbumsViewModel model = new AlbumsViewModel();
            ChinookDatabase db = new ChinookDatabase();
            model.Albums = db.Albums.ToList();
            model.Artists = db.Artists.ToList();
            model.Artists.Sort((x, y) => string.Compare(x.Name, y.Name));
            return View(model);
        }
    }
}
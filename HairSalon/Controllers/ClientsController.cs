using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;
    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Client> model = _db.Clients.Include(client => client.Stylist).ToList();
      var count = _db.Stylists.Count();
      return View(model);
    }
    public ActionResult Create()
    {

      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client)
    {
      try
      {
      _db.Clients.Add(client);
      _db.SaveChanges();
      }
      catch(DbUpdateException e)
      {
        TempData["ErrorMessage"] = "The Client phone number already exists in the data. Please check again.";
      }      
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == thisClient.StylistId);
      ViewBag.StylistName = thisStylist.StylistName;
      return View(thisClient);
    }
    public ActionResult Edit(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.StylistID = new SelectList(_db.Stylists, "StylistId", "StylistName");
      return View(thisClient);
    }
    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Search()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Search(string clientName)
    {
      List<Client> thisClients = _db.Clients.Where(client => client.ClientName == clientName).ToList();
      return View("SearchResult", thisClients);
    }
  }
}
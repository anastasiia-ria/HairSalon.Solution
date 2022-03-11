using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly HairSalonContext _db;

    public AppointmentsController(HairSalonContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Appointment> model = _db.Appointments.Include(appointment => appointment.Client).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      var times = new List<SelectListItem>();
      times.Add(new SelectListItem() { Text = "9:00 AM", Value = "9:00 AM" });
      times.Add(new SelectListItem() { Text = "10:00 AM", Value = "10:00 AM" });
      times.Add(new SelectListItem() { Text = "11:00 AM", Value = "11:00 AM" });
      times.Add(new SelectListItem() { Text = "12:00 PM", Value = "12:00 PM" });
      times.Add(new SelectListItem() { Text = "1:00 PM", Value = "1:00 PM" });
      times.Add(new SelectListItem() { Text = "2:00 PM", Value = "2:00 PM" });
      times.Add(new SelectListItem() { Text = "3:00 PM", Value = "3:00 PM" });
      times.Add(new SelectListItem() { Text = "4:00 PM", Value = "4:00 PM" });
      times.Add(new SelectListItem() { Text = "5:00 PM", Value = "5:00 PM" });
      ViewBag.Time = times;
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name") { };
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name") { };
      return View();
    }

    public ActionResult CreateForStylist(int id)
    {
      ViewBag.ClientId = new SelectList(_db.Clients.Where(client => client.StylistId == id), "ClientId", "Name") { };
      ViewBag.StylistId = new SelectList(_db.Stylists.Where(stylist => stylist.StylistId == id), "StylistId", "Name") { };
      return View("Create");
    }

    public ActionResult CreateForClient(int clientId, int stylistId)
    {
      ViewBag.ClientId = new SelectList(_db.Clients.Where(client => client.ClientId == clientId), "ClientId", "Name") { };
      ViewBag.StylistId = new SelectList(_db.Stylists.Where(stylist => stylist.StylistId == stylistId), "StylistId", "Name") { };
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      _db.Appointments.Add(appointment);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = appointment.ClientId });
    }

    public ActionResult Details(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      return View(thisAppointment);
    }

    public ActionResult Edit(int id)
    {
      var thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      var times = new List<SelectListItem>();
      times.Add(new SelectListItem() { Text = "9:00 AM", Value = "9:00 AM" });
      times.Add(new SelectListItem() { Text = "10:00 AM", Value = "10:00 AM" });
      times.Add(new SelectListItem() { Text = "11:00 AM", Value = "11:00 AM" });
      times.Add(new SelectListItem() { Text = "12:00 PM", Value = "12:00 PM" });
      times.Add(new SelectListItem() { Text = "1:00 PM", Value = "1:00 PM" });
      times.Add(new SelectListItem() { Text = "2:00 PM", Value = "2:00 PM" });
      times.Add(new SelectListItem() { Text = "3:00 PM", Value = "3:00 PM" });
      times.Add(new SelectListItem() { Text = "4:00 PM", Value = "4:00 PM" });
      times.Add(new SelectListItem() { Text = "5:00 PM", Value = "5:00 PM" });
      ViewBag.Time = times;
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name") { };
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      return View(thisAppointment);
    }

    [HttpPost]
    public ActionResult Edit(Appointment appointment)
    {
      _db.Entry(appointment).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = appointment.AppointmentId });
    }

    public ActionResult Delete(int id)
    {
      var thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      return View(thisAppointment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      _db.Appointments.Remove(thisAppointment);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = thisAppointment.ClientId });
    }
  }
}
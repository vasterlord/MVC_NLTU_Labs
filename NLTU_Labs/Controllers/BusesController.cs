using NLTU_Labs.Data;
using NLTU_Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace NLTU_Labs.Controllers
{
    public class BusesController : Controller
    {
        private BusRepository _busesRepository = null;

        public BusesController()
        {
            _busesRepository = new BusRepository();
        }

        public ActionResult Index()
        {
            List<Bus> entries = _busesRepository.GetBusesPark();
            return View(entries);
        } 

        public ActionResult IndexRoute()
        {
            List<Bus> entries = _busesRepository.GetBusesRoute();
            return View(entries);
        }

        public ActionResult Add()
        {
            Bus bus = new Bus();
            return View(bus);
        } 

        [HttpPost]
        public ActionResult Add(Bus bus)
        {
            ValidateEntry(bus);

            if (ModelState.IsValid)
            {
                _busesRepository.AddBusPark(bus);

                TempData["Message"] = "Your bus was successfully added!";

                return RedirectToAction("Index");
            }
            return View(bus);
        }

        public ActionResult EditFromPark(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _busesRepository.GetBusPark((int)id);

            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        } 

        [HttpPost]
        public ActionResult EditFromPark(Bus bus)
        {
            ValidateEntry(bus);

            if (ModelState.IsValid)
            {
                _busesRepository.UpdateBusPark(bus);

                TempData["Message"] = "Your bus was successfully updated!";

                return RedirectToAction("Index");
            }
            return View(bus);
        } 

        public ActionResult EditFromRoute(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _busesRepository.GetBusRoute((int)id);

            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        } 

        [HttpPost]
        public ActionResult EditFromRoute(Bus bus)
        {
            ValidateEntry(bus);

            if (ModelState.IsValid)
            {
                _busesRepository.UpdateBusRoute(bus);

                TempData["Message"] = "Your bus was successfully updated!";

                return RedirectToAction("IndexRoute");
            }
            return View(bus);
        }

        public ActionResult DeleteFromPark(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _busesRepository.GetBusPark((int)id);

            if (bus == null)
            {
                return HttpNotFound();
            }

            return View(bus);
        }

        [HttpPost]
        public ActionResult DeleteFromPark(int id)
        {
            _busesRepository.DeleteBusPark(id);

            TempData["Message"] = "Your entry was successfully deleted!";

            return RedirectToAction("Index");
        }

        private void ValidateEntry(Bus bus)
        {
            if (ModelState.IsValidField("DriverName") && bus.DriverName == null)
            {
                ModelState.AddModelError("DriverName",
                    "The Driver name field value can't be null.");
            }
        }

        public ActionResult DeleteFromRoute(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _busesRepository.GetBusRoute((int)id);

            if (bus == null)
            {
                return HttpNotFound();
            }

            return View(bus);
        }

        [HttpPost]
        public ActionResult DeleteFromRoute(int id)
        {
            _busesRepository.DeleteBusRoute(id);

            TempData["Message"] = "Your entry was successfully deleted!";

            return RedirectToAction("IndexRoute");
        }
    }
}
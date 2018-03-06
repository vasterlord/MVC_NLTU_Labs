using NLTU_Labs.Data;
using NLTU_Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLTU_Labs.Controllers
{
    public class ConvertingController : Controller
    {
        private ConvertRepository convertRepository = null;

        public ConvertingController()
        {
            convertRepository = new ConvertRepository();
        }
         
        public ActionResult IndexConvert()
        {
            ViewBag.SelectListItems = new SelectList(Data.Data.Options);
            return View(new ConvertValue());
        }
        [HttpPost]
        public ActionResult IndexConvert(ConvertValue convertValue)
        {
            ViewBag.SelectListItems = new SelectList(Data.Data.Options);
            try
            {
                convertRepository.SelectConveringType(convertValue, convertValue.OptionValue);
                if (ModelState.IsValid)
                {
                    TempData["Message"] = "Your value was successfully converted!";
                }
                else
                {
                    convertValue.Value = "";
                    convertValue.Result = "";
                }
            }
            catch (Exception ex)
            {
                convertValue.Value = "";
                convertValue.Result = "";
                ModelState.AddModelError("Result",ex.Message);  
            }
            return View(convertValue);
        }
    }
}

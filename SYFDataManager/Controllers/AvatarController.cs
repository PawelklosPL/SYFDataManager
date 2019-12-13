using Newtonsoft.Json;
using SYFDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Calculation.Avatar;

namespace SYFDataManager.Controllers
{
    public class AvatarController : Controller
    {
        // GET: Avatar
        public ActionResult Index()
        {
            AvatarPreparationDTO avatars = new AvatarPreparationDTO();

            return Content(JsonConvert.SerializeObject(avatars.getAvatarsList(10)));
        }

        // GET: Avatar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Avatar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avatar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avatar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Avatar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avatar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Avatar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

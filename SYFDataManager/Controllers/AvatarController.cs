using Calculation.Avatar;
using Calculations.Avatars;
using Newtonsoft.Json;
using SYFDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SYFDataManager.Controllers
{
    public class AvatarController : Controller
    {
        // GET: Avatar
        public ActionResult Index()
        {

            try
            {
                AvatarPreparationDTO avatars = new AvatarPreparationDTO();
                return Content(JsonConvert.SerializeObject(avatars.getAvatarsList()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // GET: Avatar/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                AvatarPreparationDTO avatars = new AvatarPreparationDTO();
                return Content(JsonConvert.SerializeObject(avatars.getAvatar(id)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // GET: Avatar/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // POST: Avatar/Create
        [HttpPost]
        public ActionResult Create(AvatarModel avatar)
        {
            try
            {
                AvatarPreparationDTO model = new AvatarPreparationDTO();
                AvatarModel createdAvatar  = model.createAvatar(avatar);

                return Content(JsonConvert.SerializeObject(createdAvatar));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
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
            try
            {
                AvatarPreparationDTO model = new AvatarPreparationDTO();
                model.deleteAvatar(id);
                return Content(JsonConvert.SerializeObject(true));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
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

﻿using Newtonsoft.Json;
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
            List<AvatarModel> pNewProducts = new List<AvatarModel>();
            AvatarModel avatarModel = new AvatarModel();
            avatarModel.Id = 1;
            avatarModel.AuthorName = "Name";
            avatarModel.AuthorId = "1";
            avatarModel.FolderName = "FOLDER NAME";
            avatarModel.ShortDescription = "short Desc";
            avatarModel.PublishDate = 12345;
            avatarModel.ImagesUrl = new string[1] { "/assets/temp/1.jpg" };
            avatarModel.Tags = new string[1] { "tagi" };
            avatarModel.SharePoint = 333;

            pNewProducts.Add(avatarModel);
            avatarModel.ShortDescription = "";
            pNewProducts.Add(avatarModel);

            return Content(JsonConvert.SerializeObject(pNewProducts));
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

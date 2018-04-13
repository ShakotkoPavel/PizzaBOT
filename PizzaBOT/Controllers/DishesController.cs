using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzaBOT.Models;
using PizzaBOT.Context.DishRepository;


namespace PizzaBOT.Controllers
{
    public class DishesController : Controller
    {
        IDishRepository rep;

        public DishesController(IDishRepository repository)
        {
            rep = repository;

        }

        public async Task<ActionResult> List()
        {
            return View(await rep.GetDishes());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = rep.GetDishById(id);
            if (dish == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Details of product " + dish.Name;
            return View(dish);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DishId,Name,Price,Description,ImageData,ImageMimeType")] Dish dish, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    dish.ImageMimeType = image.ContentType;
                    dish.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(dish.ImageData, 0, image.ContentLength);
                }

                rep.AddDish(dish);
                return RedirectToAction("List");
            }

            return View(dish);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = rep.GetDishById(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Edit product " + dish.Name;
            return View(dish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DishId,Name,Price,Description,ImageData,ImageMimeType")] Dish dish, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    dish.ImageMimeType = image.ContentType;
                    dish.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(dish.ImageData, 0, image.ContentLength);
                }

                rep.EditDish(dish);
                return RedirectToAction("List");
            }
            return View(dish);
        }

        public FileContentResult GetImage(int dishId)
        {
            var dish = rep.GetDishById(dishId);
            if (dish != null)
            {
                if(dish.ImageData != null)
                {
                    return File(dish.ImageData, dish.ImageMimeType);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = rep.GetDishById(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.DeleteDish(id);
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}

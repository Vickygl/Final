using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBaseConnection;

namespace ClothStore.Controllers
{
    public class ClothController : Controller
    {
      public ActionResult AddNewClothes()
        {
            var con = new DBConnection();
            return View(new Clothings());

        }
        [HttpPost]
        public ActionResult AddNewClothes(Clothings clothings)
        {
            var con = new DBConnection();
            try
            {
                con.AddNewClothes(clothings);
                return View(new Clothings());
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new Clothings());

            }
        }
        public ActionResult UpdateClothes(String id)
        {
            int clothid = Convert.ToInt32(id);
            var con = new DBConnection();
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateCothes(Clothings clothings)
        {

            var con = new DBConnection();
            try
            {
                con.UpdateClothes(clothings);

                return View(clothings);
            }
            catch (Exception)
            {
                throw;
            }
        }

            public ActionResult DeleteClothes(int id)
            {
                var con = new DBConnection();
                int clothid = Convert.ToInt32(id);
                try
                {
                 con.DeleteClothes(clothid);
                return View(clothid);
                 
                }
                catch (Exception ex)
                { 
                    throw ex;
                }
            }
            public ActionResult GetAllClothes()
            {
            var con = new DBConnection();
            var cloth = con.GetAllClothes();
            return View(cloth);
             }
    }
}


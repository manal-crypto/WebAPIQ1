using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TransactionBse161001Controller : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();
        // GET: TransactionBse161001
        public ActionResult Index()
        {
            IEnumerable<TransactionBse161001> empList = null;
            HttpResponseMessage response = GlobalVariable.Webapiclient.GetAsync("TransactionBse161001").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<TransactionBse161001>>().Result;
            return View(empList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionBse161001 student = db.TransactionBse161001.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,TransactionDate,TransactionType,TransactionAmount")] TransactionBse161001 transactionBse161001)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51685/api/TransactionBse161001/");
                var postTask = client.PostAsJsonAsync<TransactionBse161001>("transactionBse161001", transactionBse161001);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Enter different Id.");

            return View(transactionBse161001);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionBse161001 transactionBse161001 = db.TransactionBse161001.Find(id);
            if (transactionBse161001 == null)
            {
                return HttpNotFound();
            }
            return View(transactionBse161001);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionBse161001 transactionBse161001)
        {
         

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("http://localhost:51685/api/TransactionBse161001/");
                var putTask = client.PutAsJsonAsync<TransactionBse161001>("transactionBse161001", transactionBse161001);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)

                {

                    return RedirectToAction("Index");

                }
            }

            return View(transactionBse161001);
        }
        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionBse161001 transactionBse161001 = db.TransactionBse161001.Find(id);
            if (transactionBse161001 == null)
            {
                return HttpNotFound();
            }
            return View(transactionBse161001);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("http://localhost:51685/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("transactionBse161001/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }
    }
}
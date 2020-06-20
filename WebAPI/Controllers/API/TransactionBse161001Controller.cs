using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers.API
{
    public class TransactionBse161001Controller : ApiController
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: api/TransactionBse161001
        public IQueryable<TransactionBse161001> GetTransactionBse161001()
        {
            return db.TransactionBse161001;
        }

        // GET: api/TransactionBse161001/5
        [ResponseType(typeof(TransactionBse161001))]
        public IHttpActionResult GetTransactionBse161001(int id)
        {
            TransactionBse161001 transactionBse161001 = db.TransactionBse161001.Find(id);
            if (transactionBse161001 == null)
            {
                return NotFound();
            }

            return Ok(transactionBse161001);
        }

        // PUT: api/TransactionBse161001/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransactionBse161001(TransactionBse161001 transactionBse161001)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (transactionBse161001 == null)
            {
                return BadRequest();
            }

            db.Entry(transactionBse161001).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionBse161001Exists(transactionBse161001.TransactionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TransactionBse161001
        [ResponseType(typeof(TransactionBse161001))]
        public IHttpActionResult PostTransactionBse161001(TransactionBse161001 transactionBse161001)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionBse161001.Add(transactionBse161001);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionBse161001Exists(transactionBse161001.TransactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = transactionBse161001.TransactionId }, transactionBse161001);
        }

        // DELETE: api/TransactionBse161001/5
        [ResponseType(typeof(TransactionBse161001))]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Transaction id");
            using (var ctx = new DatabaseEntities())
            {
                var transaction = ctx.TransactionBse161001
                    .Where(s => s.TransactionId == id)
                    .FirstOrDefault();

                ctx.Entry(transaction).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionBse161001Exists(int id)
        {
            return db.TransactionBse161001.Count(e => e.TransactionId == id) > 0;
        }
    }
}
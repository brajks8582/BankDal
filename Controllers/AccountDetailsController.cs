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
using BGSBcodefirst.Models;

namespace BGSBDAlcode.Controllers
{
    public class AccountDetailsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/AccountDetails
        public IQueryable<AccountDetail> GetAccountDetails()
        {
            return db.AccountDetails;
        }

        // GET: api/AccountDetails/5
        [ResponseType(typeof(AccountDetail))]
        public AccountDetail GetAccountDetail(long id)
        {
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            //if (accountDetail == null)
            //{
            //    return NotFound();
            //}
            var acc1 = db.AccountDetails
                 .Include("Customer").Include("AtmCumDebitCard").Include("Transaction")
                 .Where(s => s.CustomerID == id)
                 .FirstOrDefault<AccountDetail>();

            return acc1;
        }

        // PUT: api/AccountDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountDetail(long id, AccountDetail accountDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountDetail.AccountNo)
            {
                return BadRequest();
            }

            db.Entry(accountDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountDetailExists(id))
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

        // POST: api/AccountDetails
        [ResponseType(typeof(AccountDetail))]
        public IHttpActionResult PostAccountDetail(AccountDetail accountDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountDetails.Add(accountDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accountDetail.AccountNo }, accountDetail);
        }

        // DELETE: api/AccountDetails/5
        [ResponseType(typeof(AccountDetail))]
        public IHttpActionResult DeleteAccountDetail(long id)
        {
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            if (accountDetail == null)
            {
                return NotFound();
            }

            db.AccountDetails.Remove(accountDetail);
            db.SaveChanges();

            return Ok(accountDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountDetailExists(long id)
        {
            return db.AccountDetails.Count(e => e.AccountNo == id) > 0;
        }
    }
}
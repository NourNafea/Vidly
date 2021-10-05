using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public ActionResult New()
        {
            return View();
        }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }
        

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers
                .Include(c=>c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer==null)
            
                return HttpNotFound();
            return View(customer);
        }


    }
}
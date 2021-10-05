using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public ActionResult New()
        {
            var MembershipType = _context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = MembershipType
            };
            return View("CustomerForm",ViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id==0)
            {
                 _context.Customers.Add(customer);
            }
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDb.Name = customer.Name;
                CustomerInDb.BirthDateTime = customer.BirthDateTime;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
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


        public ActionResult Edit(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if (Customer == null)
                return HttpNotFound();

            var ViewModel = new CustomerFormViewModel()
            {
                Customer = Customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",ViewModel);
        }
    }
}
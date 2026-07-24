using Blood_Donation_Management_System.EF;
using Blood_Donation_Management_System.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Blood_Donation_Management_System.Controllers
{
    public class DonationController : Controller
    {
        private readonly BloodBankDbContext db;

        public DonationController(BloodBankDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Donations.Include(d => d.Donor).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Donors = db.Donors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Donation d)
        {
            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState)
                {
                    foreach (var error in item.Value.Errors)
                    {
                        Console.WriteLine($"{item.Key}: {error.ErrorMessage}");
                    }
                }

                ViewBag.Donors = db.Donors.ToList();
                return View(d);
            }

            ViewBag.Donors = db.Donors.ToList();
            return View(d);
        }
    }
}

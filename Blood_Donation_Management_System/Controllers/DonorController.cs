using Blood_Donation_Management_System.EF;
using Blood_Donation_Management_System.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_Management_System.Controllers
{
    public class DonorController : Controller
    {
        private readonly BloodBankDbContext db;

        public DonorController(BloodBankDbContext db)
        {
            this.db = db;
        }

        // GET: Donor
        public IActionResult Index()
        {
            var data = db.Donors.ToList(); // select query
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Donor d)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(d);   // insert query
                db.SaveChanges();   // executes the query
                return RedirectToAction("Index");
            }
            return View(d);
        }

        // GET: Donor/Details/5
        public IActionResult Details(int id)
        {
            var data = db.Donors.Find(id); // search by PK
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Donors.Find(id);
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Donor formObj)
        {
            if (ModelState.IsValid)
            {
                var exObj = db.Donors.Find(formObj.DonorId);
                if (exObj == null) return NotFound();

                exObj.FullName = formObj.FullName;
                exObj.BloodGroup = formObj.BloodGroup;
                exObj.ContactNo = formObj.ContactNo;
                exObj.City = formObj.City;
                exObj.LastDonationDate = formObj.LastDonationDate;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formObj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = db.Donors.Find(id);
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(string Dcsn, int DonorId)
        {
            if (Dcsn == "Yes")
            {
                var data = db.Donors.Find(DonorId);
                if (data != null)
                {
                    db.Donors.Remove(data);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}

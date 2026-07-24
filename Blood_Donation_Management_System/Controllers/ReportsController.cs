using Blood_Donation_Management_System.EF;
using Blood_Donation_Management_System.EF.Tables;
using Blood_Donation_Management_System.Models;
using Microsoft.AspNetCore.Mvc;


namespace Blood_Donation_Management_System.Controllers
{
    public class ReportsController : Controller
    {
        private readonly BloodBankDbContext db;

        public ReportsController(BloodBankDbContext db)
        {
            this.db = db;
        }

        // Feature 1: Filter donors by a selected blood group
        [HttpGet]
        public IActionResult ByBloodGroup(string selectedGroup)
        {
            var groups = db.Donors.Select(d => d.BloodGroup).Distinct().OrderBy(g => g).ToList();
            ViewBag.Groups = groups;
            ViewBag.Selected = selectedGroup;

            List<Donor> data;
            if (!string.IsNullOrEmpty(selectedGroup))
            {
                data = (from d in db.Donors
                        where d.BloodGroup == selectedGroup
                        select d).ToList();
            }
            else
            {
                data = new List<Donor>();
            }

            return View(data);
        }
        // Feature 2: List all donors sorted by LastDonationDate, most recent first
        public IActionResult RecentDonors()
        {
            var data = (from d in db.Donors
                        orderby d.LastDonationDate descending
                        select d).ToList();
            return View(data);
        }

        // Feature 3: Show each donor alongside their total number of donations
        public IActionResult DonationCounts()
        {
            var data = (from d in db.Donors
                        select new DonorDonationCount
                        {
                            DonorId = d.DonorId,
                            FullName = d.FullName,
                            BloodGroup = d.BloodGroup,
                            TotalDonations = d.Donations.Count()
                        }).ToList();

            return View(data);
        }

        // Feature 4: Display the total volume of blood collected across all donations
        public IActionResult TotalVolume()
        {
            int total = db.Donations.Sum(d => (int?)d.VolumeMl) ?? 0;
            ViewBag.TotalVolume = total;
            return View();
        }
    }
}

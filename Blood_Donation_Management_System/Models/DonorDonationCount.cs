
namespace Blood_Donation_Management_System.Models
{
    public class DonorDonationCount
    {
        public int DonorId { get; set; }
        public string FullName { get; set; } = null!;
        public string BloodGroup { get; set; } = null!;
        public int TotalDonations { get; set; }
    }
}

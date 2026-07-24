using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_Management_System.EF.Tables
{
    public class DonorValidation
    {
        [ModelMetadataType(typeof(DonorMetadata))]
        public partial class Donor
        {
        }

        public class DonorMetadata
        {
            [Required(ErrorMessage = "Full name is required")]
            [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
            public string FullName { get; set; } = null!;

            [Required(ErrorMessage = "Blood group is required")]
            [RegularExpression("^(A|B|AB|O)[+-]$", ErrorMessage = "Enter a valid blood group, e.g. A+, O-")]
            public string BloodGroup { get; set; } = null!;

            [Required(ErrorMessage = "Contact number is required")]
            [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Contact number must be 10-15 digits")]
            public string ContactNo { get; set; } = null!;

            [Required(ErrorMessage = "City is required")]
            [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
            public string City { get; set; } = null!;

            [DataType(DataType.Date)]
            public DateTime? LastDonationDate { get; set; }
        }
    }
}

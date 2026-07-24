using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_Management_System.EF.Tables
{
    [ModelMetadataType(typeof(DonationMetadata))]
    public partial class Donation
    {
    }

    public class DonationMetadata
    {
        [Required(ErrorMessage = "Please select a donor")]
        public int DonorId { get; set; }

       
        [ValidateNever]
        public object Donor { get; set; } = null!;

        [Required(ErrorMessage = "Donation date is required")]
        [DataType(DataType.Date)]
        public DateTime DonationDate { get; set; }

        [Required(ErrorMessage = "Volume is required")]
        [Range(100, 1000, ErrorMessage = "Volume must be between 100ml and 1000ml")]
        public int VolumeMl { get; set; }

        [Required(ErrorMessage = "Camp name is required")]
        [StringLength(100, ErrorMessage = "Camp name cannot exceed 100 characters")]
        public string CampName { get; set; } = null!;
    }
}
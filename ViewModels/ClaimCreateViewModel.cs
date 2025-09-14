using System.ComponentModel.DataAnnotations;
namespace PROG6212_VC_ST10257779.ViewModels
{
    public class ClaimCreateViewModel
    {
        [Required]
        public int LecturerId { get; set; }
        [Range(2020, 2100)]
        public int Year { get; set; } = System.DateTime.UtcNow.Year;
        [Range(1,12)]
        public int Month { get; set; } = System.DateTime.UtcNow.Month;
        [Range(0, 400)]
        public decimal HoursWorked { get; set; }
        [Range(0, 10000)]
        public decimal HourlyRate { get; set; }
        public string? DummyUploadName { get; set; }
    }
}

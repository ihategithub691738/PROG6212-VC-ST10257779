using System;
namespace PROG6212_VC_ST10257779.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; } // 1-12
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public decimal Amount => Math.Round(HoursWorked * HourlyRate, 2);
    }
}
/*
 * Code assistance: OpenAI ChatGPT
 * Code assistance: STACKOVERFLOW
 * Date: 2025-09-14
 */


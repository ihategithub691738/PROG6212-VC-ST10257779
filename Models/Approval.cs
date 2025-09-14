using System;
namespace PROG6212_VC_ST10257779.Models
{
    public class Approval
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public ApproverRole Role { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
        public string? Comment { get; set; }
        public DateTime? ActionedAt { get; set; }
    }
}
/*
 * Code assistance: OpenAI ChatGPT
 * Code assistance: STACKOVERFLOW
 * Date: 2025-09-14
 */


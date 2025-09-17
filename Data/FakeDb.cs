using PROG6212_VC_ST10257779.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PROG6212_VC_ST10257779.Data
{
    public static class FakeDb
    {
        public static List<Lecturer> Lecturers { get; } = new()
        {
            new Lecturer { Id = 1, StaffNo = "L0001", FirstName = "Ayesha", LastName = "Pillay", Email = "ayesha.pillay@example.edu", Department="Computer Science"},
            new Lecturer { Id = 2, StaffNo = "L0002", FirstName = "Johan", LastName = "Steyn", Email = "johan.steyn@example.edu", Department="Information Systems"},
            new Lecturer { Id = 3, StaffNo = "L0003", FirstName = "Naledi", LastName = "Mokoena", Email = "naledi.mokoena@example.edu", Department="Mathematics"}
        };

        public static List<Claim> Claims { get; } = new()
        {
            new Claim { Id = 1, LecturerId = 1, Year = DateTime.UtcNow.Year, Month = DateTime.UtcNow.Month, HoursWorked = 12, HourlyRate = 520, Status = ClaimStatus.Submitted },
            new Claim { Id = 2, LecturerId = 2, Year = DateTime.UtcNow.Year, Month = DateTime.UtcNow.Month-1 <=0?1:DateTime.UtcNow.Month-1, HoursWorked = 8, HourlyRate = 480, Status = ClaimStatus.Verified },
            new Claim { Id = 3, LecturerId = 3, Year = DateTime.UtcNow.Year, Month = DateTime.UtcNow.Month-2 <=0?1:DateTime.UtcNow.Month-2, HoursWorked = 20, HourlyRate = 500, Status = ClaimStatus.Approved }
        };

        public static List<SupportDocument> Documents { get; } = new()
        {
            new SupportDocument { Id = 1, ClaimId = 1, FileName = "AttendanceSheet.pdf", FileType = "application/pdf"}
        };

        public static List<Approval> Approvals { get; } = new()
        {
            new Approval { Id=1, ClaimId=1, Role=ApproverRole.ProgrammeCoordinator, Status=ApprovalStatus.Pending },
            new Approval { Id=2, ClaimId=2, Role=ApproverRole.ProgrammeCoordinator, Status=ApprovalStatus.Approved, ActionedAt = DateTime.UtcNow.AddDays(-2)},
            new Approval { Id=3, ClaimId=2, Role=ApproverRole.AcademicManager, Status=ApprovalStatus.Pending },
            new Approval { Id=4, ClaimId=3, Role=ApproverRole.ProgrammeCoordinator, Status=ApprovalStatus.Approved, ActionedAt = DateTime.UtcNow.AddDays(-10)},
            new Approval { Id=5, ClaimId=3, Role=ApproverRole.AcademicManager, Status=ApprovalStatus.Approved, ActionedAt = DateTime.UtcNow.AddDays(-9)}
        };

        public static int NextClaimId => Claims.Count == 0 ? 1 : Claims.Max(c => c.Id) + 1;

        public static void AddClaim(Claim c)
        {
            c.Id = NextClaimId;
            Claims.Add(c);
            Approvals.Add(new Approval{ ClaimId=c.Id, Role=ApproverRole.ProgrammeCoordinator, Status=ApprovalStatus.Pending });
            Approvals.Add(new Approval{ ClaimId=c.Id, Role=ApproverRole.AcademicManager, Status=ApprovalStatus.Pending });
        }

        public static Lecturer? GetLecturer(int id) => Lecturers.FirstOrDefault(l => l.Id == id);
    }
}

/*
 * Code assistance: STACKOVERFLOW
 * Date: 2025-09-14
 */

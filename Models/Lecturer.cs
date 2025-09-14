namespace PROG6212_VC_ST10257779.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string StaffNo { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Department { get; set; } = "";
        public string FullName => $"{FirstName} {LastName}";
    }
}
/*
 * Code assistance: OpenAI ChatGPT
 * Code assistance: STACKOVERFLOW
 * Date: 2025-09-14
 */


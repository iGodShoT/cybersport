using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class Treaty
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime StartDate { get; set; }
        public int ScheduleId { get; set; }
        public int Salary { get; set; }
    }
}

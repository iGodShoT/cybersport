using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Salary { get; set; }
    }
}

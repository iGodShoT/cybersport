using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class Operation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int OrganisationId { get; set; }

    }
}

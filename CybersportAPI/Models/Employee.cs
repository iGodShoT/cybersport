using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
        }

        public int Id { get; set; }
        public int PositionId { get; set; }
        public int CommonDataId { get; set; }
    }
}

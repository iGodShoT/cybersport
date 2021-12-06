using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class Team
    {
        public Team()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DisciplineId { get; set; }

    }
}

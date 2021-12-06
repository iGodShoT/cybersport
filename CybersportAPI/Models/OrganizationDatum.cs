using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class OrganizationDatum
    {
        public OrganizationDatum()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public decimal Balance { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class CommonDatum
    {
        public CommonDatum()
        {
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string PassSeria { get; set; }
        public string PassNum { get; set; }
        public string Telephone { get; set; }
        public int UserId { get; set; }
    }
}

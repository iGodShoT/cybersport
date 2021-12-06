using System;
using System.Collections.Generic;

#nullable disable

namespace CybersportAPI.Models
{
    public partial class Player
    {
        public Player()
        {
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public int CommonDataId { get; set; }
        public int TeamId { get; set; }
    }
}

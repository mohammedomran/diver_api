using System;

namespace Divers.Models
{
    public class Roomrate
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public int RoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

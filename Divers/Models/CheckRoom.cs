using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Models
{
    public class CheckRoom
    {
        public int Id { get; set; }
        public int AdultsNumber { get; set; }
        public int KidsNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}

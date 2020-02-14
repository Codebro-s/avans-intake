using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Models
{
    public class Performance
    {
        public int Id { get; set; }

        public Performer Performer { get; set; }

        public Stage Stage { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
